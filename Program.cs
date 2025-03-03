
using Grafovias.Classes;
using Grafovias.Data;

namespace Grafovias;

class Program
{
    static void Main(string[] args)
    {

        Origen origenes= new Origen();
        Import(origenes);
        Console.WriteLine(origenes.ToString());

       
        
    }
    static void Import(Origen org){
        List<string> modeus=FileIO.UploadFile($@"Data\Datos vias.csv");
        foreach (string item in modeus)
        {
            if (item==modeus[0])
            {
                continue;
            }
            string[] divi= item.Split(";");
            org.AddCiudad(divi[0],divi[1],int.Parse(divi[2]),int.Parse(divi[3]));
            
        }
    }
    
}
