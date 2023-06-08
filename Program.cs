using tarea;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();
        
        // Generando el numero N de forma aleatoria
        Random r = new Random();
        int N = r.Next(2, 5);
        cargarTareasPendientes(2, tareasPendientes);
        moverTareas(tareasPendientes, tareasRealizadas);
        
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

}