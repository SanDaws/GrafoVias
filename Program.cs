
using Grafovias.Data;

namespace Grafovias;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<string> modeus=FileIO.UploadFile($@"Data\Datos vias.csv");
        HashSet<string> ciudades=new HashSet<string>();
        foreach (string item in modeus)
        {
            string[] divi= item.Split(";");
            ciudades.Add(divi[0]);
            ciudades.Add(divi[1]);
        }

        foreach (string recorrido in ciudades)
        {
            Console.WriteLine(recorrido);
            
        }
    }
}
