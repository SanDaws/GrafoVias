using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grafovias.Util;

namespace Grafovias.Data;
    public static class FileIO
    {
        //Retunr a dynamically resize array whit all the lines of the text
        //this allows to re use multiple times and do the controllers the creation of the respective object
        //route must be an literal route
        public static List<string> UploadFile(string route){
            List<string> eachLane= new List<string>();
            using (StreamReader Archive=File.OpenText(route)){
                string? line;
                while ((line=Archive.ReadLine()) is not null){
                    eachLane.Add(line);
                }
            }
            return eachLane;
        }
        //route must be an literal route
        
        public static void SaveFile(string route, List<string> list){
            try{
            if (File.Exists(route))
            {
                File.WriteAllLines(route,list);
                Console.WriteLine();
                Util.Util.GreenText("El contenido se ha escrito exitosamente.");
            }
            else
            {
                Console.WriteLine("El archivo especificado no existe.");
                Console.WriteLine("Creando Archivo...");
                File.Create(route);
                SaveFile(route,list);
            }
        }
        catch (Exception ex)
        {
            Util.Util.RedText($"Imposible : {ex.Message}");
        }

        }

        
    }
