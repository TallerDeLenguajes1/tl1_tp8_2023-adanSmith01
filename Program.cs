internal class Program
{
    private static void Main(string[] args)
    {
        string path;
        Console.Write("Ingrese una ruta valida: ");
        path = Console.ReadLine();

        if(!Directory.Exists(path)){
            Console.WriteLine("ERROR. Ruta invalida\n");
        } else{
            List<string> listaArchivos = Directory.GetFiles(path).ToList();
            Console.WriteLine("Lista de archivos");
            listaArchivos.ForEach(Console.WriteLine);
            using(StreamWriter indexador = new StreamWriter("index.csv")){

                for(int i = 0; i < listaArchivos.Count; i++){
                    // El método Path.GetFileWithoutExtension() devuelve solo el nombre del archivo
                    // El método Path.GetExtension() devuelve la extensión del archivo
                    indexador.WriteLine($"{i},{Path.GetFileNameWithoutExtension(listaArchivos[i])},{Path.GetExtension(listaArchivos[i])}");
                }

                indexador.Close();
                indexador.Dispose();
            }


        }
    }
}