internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\Users\smith\Downloads\Taller 1";
        List<string> listaArchivos = Directory.GetFiles(path).ToList();

        StreamWriter indexador = new StreamWriter("index.csv");
        for(int i = 0; i < listaArchivos.Count; i++){
            // El método Path.GetFileWithoutExtension() devuelve solo el nombre del archivo
            // El método Path.GetExtension() devuelve la extensión del archivo
            indexador.WriteLine($"{i},{Path.GetFileNameWithoutExtension(listaArchivos[i])},{Path.GetExtension(listaArchivos[i])}");
        }

        indexador.Close();
    }
}