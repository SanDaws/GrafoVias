
using Grafovias.Classes;
using Grafovias.Data;

namespace Grafovias;

class Program
{
    static void Main(string[] args)
    {

        Origen origenes= new Origen();
        Import(origenes);
        Util.Util.Title("Carreteras de colombia",ConsoleColor.DarkBlue);
        Console.WriteLine(origenes.ToString());
        VerRutamasCorta(origenes);
        VerRutamasCortaDistancia(origenes);
        MatrixPresent.MetodoGraficarKM(origenes);
        Console.ReadKey();
        MatrixPresent.MetodoGraficarTiempo(origenes);
        

        


       
        
    }
      //importa todo el archivo y lo agrega a el grafo
    static void Import(Origen org){
        //en si no retorna nada pero si altera el grafo poblandolo de datos
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
    static void VerRutamasCorta(Origen or){
        Console.WriteLine("origen");
        string Origen= Util.Exceptions.AntiEMptyorNull();
        Console.WriteLine("Destino");
        string Destino= Util.Exceptions.AntiEMptyorNull();
        Dijkastra.DijkstraInTime(or,Origen,Destino);
    }
    static void VerRutamasCortaDistancia(Origen or){
        Console.WriteLine("origen");
        string Origen= Util.Exceptions.AntiEMptyorNull();
        Console.WriteLine("Destino");
        string Destino= Util.Exceptions.AntiEMptyorNull();
        Dijkastra.DijkstraDistancia(or,Origen,Destino);
    }
    
}
