using System;
using System.Collections.Generic;
using System.IO;
namespace Grafovias.Classes;
class MatrixPresent
{
    public static void MetodoGraficarKM(Origen ori)   // Genera la matriz tomando la distancia en KM
    {
        /*
        188 sin contar los nombres laterales
        209 en total
        2 por lado

        */
        int a=Console.WindowWidth;
        Console.WriteLine(a);
        bool impresao= impresion();

        if (impresao) {
            List<string> ciudades = ori.CiudadesName();//72 ciudades para el ejemplo
            Console.WriteLine("Matriz de Adyacencia (en KM)");

            Encabezado(ciudades);
            Console.WriteLine(new string('_',Console.WindowWidth));

            foreach (var ciudad1 in ciudades) {

                Console.Write(
$@"{ciudad1,21}");

                foreach (var ciudad2 in ciudades) {
                    int dis=ori.Ciudad[ciudad1].GetDistancia(ciudad2);
                    int distancia = ori.ExistIn(ciudad1,ciudad2) ? dis  : 0;
                    if (distancia==0)
                    {
                        Util.Util.RedText(
$@"{"__",-2}");


                    }else{
                        Util.Util.GreenText(
$@"{distancia,-3}");


                    }
                }
                Console.WriteLine();
            }
        }
        else{
            Console.WriteLine("Ha terminado el programa");
        }
    }

    public static void MetodoGraficarTiempo(Origen ori)  // Genera la matriz tomando el tiempo
    {

        List<string> ciudades = ori.CiudadesName();
        Console.WriteLine("Matriz de Adyacencia (en Minutos)");
        Console.Write("\t");

        foreach (var ciudad in ciudades) {
            Console.Write(ciudad + "\t");
        } 
        Console.WriteLine(new string('_',73));

        foreach (var ciudad1 in ciudades) {
            Console.Write(ciudad1 + "\t");

            foreach (var ciudad2 in ciudades) {
                int dis=ori.Ciudad[ciudad1].GetTiempo(ciudad2);
                    int tiempo = ori.ExistIn(ciudad1,ciudad2) ? dis  : 0;

                Console.Write(tiempo + "\t");
            }
            Console.WriteLine();
        }
    }
    public static void Proximidad(Origen ori){
        Console.WriteLine("Ingrese la ciudad 1");
        var CiudadA = Util.Exceptions.AntiEMptyorNull();
        Console.WriteLine("Ingrese la ciudad 2");
        var CiudadB = Util.Exceptions.AntiEMptyorNull();

        bool existance = ori.ExistIn(CiudadA,CiudadB);
        if (existance) {
            Console.WriteLine("Estan conectados");
            Console.WriteLine("");
        }
            else {
                Console.WriteLine("No hay conexion");
                Console.WriteLine("");
            }
        

    }
    private static bool impresion(){
        Console.WriteLine($@"
        Desea imprimir?:
        1 : Si
        2: No");
        ConsoleKeyInfo response=Console.ReadKey();
        switch (response.Key)
        {  
            case ConsoleKey.D1:
            return true;
            case ConsoleKey.D2:
            return false;
            
            default:
            return impresion();
            
        }


    }
    private static void Encabezado(List<string> ciudades){
        int lng= LongestName(ciudades);

        // Crear una matriz para almacenar las letras de las ciudades
        char[,] nombresCiudades = new char[lng, ciudades.Count];

        // Llenar la matriz con las letras de las ciudades, alineadas en la parte inferior
        for (int i = 0; i < ciudades.Count; i++)
        {
            string ciudad = ciudades[i];
            int diferencia = lng - ciudad.Length; // Espacios que faltan para llegar a la longitud máxima

            for (int j = 0; j < lng; j++)
            {
                if (j < diferencia)
                {
                    nombresCiudades[j, i] = ' '; // Rellenar con espacios en la parte superior
                }
                else
                {
                    nombresCiudades[j, i] = ciudad[j - diferencia]; // Colocar las letras de la ciudad en la parte inferior
                }
            }
        }

        // Imprimir la matriz en el formato deseado
        for (int i = 0; i < lng; i++)
        {
            Console.Write(
$"{" ",21}");
            
            for (int j = 0; j < ciudades.Count; j++)
            {
Console.Write(
$"{nombresCiudades[i, j],2}");
            }
            Console.WriteLine();
        }
    }
    public static int LongestName(List<string> ciudades){
        List<string> clone= ciudades;
         string longest = clone.OrderByDescending(s => s.Length).FirstOrDefault();
        return longest.Length;
    }
    
}