using tarea;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();
        Tarea tareaBuscada = new Tarea();
        bool continuar = true;
        string confirmar = String.Empty;
        string filtro = String.Empty;

        // Generando el numero N de forma aleatoria
        int N = new Random().Next(2, 11);
        cargarTareasPendientes(N, tareasPendientes);
        moverTareas(tareasPendientes, tareasRealizadas);

        Console.Write("\n¿Desea buscar alguna tarea pendiente? Si/No: ");
        confirmar = Console.ReadLine();
        if(confirmar.ToLower() == "si"){
            while(continuar){
                Console.Write("\nIngrese la descripción de la tarea a buscar: ");
                filtro = Console.ReadLine();
                tareaBuscada = buscarTareaPorDescripcion(tareasPendientes, filtro);
                if(String.IsNullOrEmpty(tareaBuscada.Descripcion)){
                    Console.WriteLine("\nNo existe la tarea pendiente que desea encontrar\n");
                } else{
                    Console.WriteLine("\n===========TAREA BUSCADA===========\n");
                    tareaBuscada.MostrarTarea();
                }
                Console.Write("\n¿Desea buscar otra tarea pendiente? Si/No: ");
                confirmar = Console.ReadLine();
                if(confirmar.ToLower() != "si"){
                    continuar = false;
                }
            }
        }

        if(tareasRealizadas.Count > 0){
            guardarSumarioEmpleado(tareasRealizadas);
        } else{
            Console.WriteLine("\nNo puede guardarse el sumario de horas trabajadas porque no hay tareas realizadas\n");
        }
    }

    // Función para cargar las tareas pendientes
    public static void cargarTareasPendientes(int n_tareas, List<Tarea> pendientes){
        int duracion = 0;
        string num = String.Empty;

        for(int i = 0; i < n_tareas; i++){
            Console.WriteLine($"\n***********TAREA {i}***********\n");
            var nuevaTarea = new Tarea();
            nuevaTarea.Id = i;
            Console.Write("Descripción: ");
            nuevaTarea.Descripcion = Console.ReadLine();
            do{
                Console.Write("Duración (debe estar en 10 y 100): ");
                num = Console.ReadLine();
                if( !int.TryParse(num, out duracion) || (duracion < 10 || duracion > 100) ) Console.WriteLine("ERROR. Tiempo de duración incorrecto.\n");
            }while(!int.TryParse(num, out duracion) || (duracion < 10 || duracion > 100));
            nuevaTarea.Duracion = duracion;
            pendientes.Insert(nuevaTarea.Id, nuevaTarea);
        }
    }

    public static void moverTareas(List<Tarea> pendientes, List<Tarea> realizadas){
        string respuesta;
        foreach(var tareaPendiente in pendientes){
            Console.Write($"\n¿Realizó la tarea de id: {tareaPendiente.Id}? si/no: ");
            respuesta = Console.ReadLine();
            if(respuesta == "si"){
                realizadas.Add(tareaPendiente);
            }
        }

        foreach (var tareaARemover in realizadas){
            pendientes.Remove(tareaARemover);
        }
    }

    public static Tarea buscarTareaPorDescripcion(List<Tarea> pendientes, string descripcion){
        Tarea tareaABuscar = new Tarea();
        foreach (var tareaP in pendientes){
            if(tareaP.Descripcion == descripcion){
                tareaABuscar = tareaP;
            }
        }

        return tareaABuscar;
    }

    public static void mostrarTareas(List<Tarea> listaTareas){
        if(listaTareas.Count == 0){
            Console.WriteLine("\nNo hay tareas guardadas\n");
        } else{
            foreach(var tarea in listaTareas){
                tarea.MostrarTarea();
            }
        }
    }

    public static void guardarSumarioEmpleado(List<Tarea> realizadas){
        int totalHoras = 0;
        StreamWriter dato = new StreamWriter("sumario.txt");
        foreach(var tareaR in realizadas){
            totalHoras += tareaR.Duracion;
        }
        dato.WriteLine($"Sumario: {totalHoras}");
        dato.Close();
    }
}
