using System;
using System.Collections.Generic;
using System.IO;
namespace Grafovias.Classes;
class MatrixPresent
{
    public static void MetodoGraficarKM(Origen ori)   // Genera la matriz tomando la distancia en KM
    {
        // string filePath = "C:/Users/ADMIN/Downloads/Datos vias.csv";        // Cambiar por directorio en el que este actualmente el .csv
        // Dictionary<string, Dictionary<string, int>> matrizAdyKM = new Dictionary<string, Dictionary<string, int>>();

        // string[] lineas = File.ReadAllLines(filePath);

        // foreach (string line in lineas)
        // {
        //     string[] columnas = line.Split(';');
        //     if (columnas.Length < 4) {
        //         continue;
        //     }

        //     string ciudad1 = columnas[0].Trim();
        //     string ciudad2 = columnas[1].Trim();
        //     int distanciaKm = int.Parse(columnas[2].Trim());
        //     int distanciaMin = int.Parse(columnas[3].Trim());

        //     if (!matrizAdyKM.ContainsKey(ciudad1))
        //     {
        //         matrizAdyKM[ciudad1] = new Dictionary<string, int>();
        //     }

        //     if (!matrizAdyKM.ContainsKey(ciudad2))
        //     {
        //         matrizAdyKM[ciudad2] = new Dictionary<string, int>();
        //     }

        //     matrizAdyKM[ciudad1][ciudad2] = distanciaKm;
        //     matrizAdyKM[ciudad2][ciudad1] = distanciaKm;
        // }

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
        
        
        bool impresao= impresion();

        if (impresao) {
            List<string> ciudades = ori.CiudadesName();
            Console.WriteLine("Matriz de Adyacencia (en KM)");
            Console.Write("\t");

            foreach (var ciudad in ciudades) {
                Console.Write(ciudad + "\t");
            } 
            Console.WriteLine();

            foreach (var ciudad1 in ciudades) {
                Console.Write(ciudad1 + "\t");

                foreach (var ciudad2 in ciudades) {
                    int dis=ori.Ciudad[ciudad1].GetDistancia(ciudad2);
                    int distancia = ori.ExistIn(ciudad1,ciudad2) ? dis  : 0;
                    Console.Write(distancia + "\t");
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
        // string filePath = "C:/Users/ADMIN/Downloads/Datos vias.csv";        // Cambiar por directorio en el que este actualmente el .csv
        // Dictionary<string, Dictionary<string, int>> matrizAdyMin = new Dictionary<string, Dictionary<string, int>>();

        // string[] lineas = File.ReadAllLines(filePath);

        // foreach (string line in lineas)
        // {
        //     string[] columnas = line.Split(';');
        //     if (columnas.Length < 4) {
        //         continue;
        //     }

        //     string ciudad1 = columnas[0].Trim();
        //     string ciudad2 = columnas[1].Trim();
        //     int distanciaKm = int.Parse(columnas[2].Trim());
        //     int distanciaMin = int.Parse(columnas[3].Trim());

        //     if (!matrizAdyMin.ContainsKey(ciudad1))
        //     {
        //         matrizAdyMin[ciudad1] = new Dictionary<string, int>();
        //     }

        //     if (!matrizAdyMin.ContainsKey(ciudad2))
        //     {
        //         matrizAdyMin[ciudad2] = new Dictionary<string, int>();
        //     }

        //     matrizAdyMin[ciudad1][ciudad2] = distanciaMin;
        //     matrizAdyMin[ciudad2][ciudad1] = distanciaMin;
        // }

        List<string> ciudades = ori.CiudadesName();
        Console.WriteLine("Matriz de Adyacencia (en Minutos)");
        Console.Write("\t");

        foreach (var ciudad in ciudades) {
            Console.Write(ciudad + "\t");
        } 
        Console.WriteLine();

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
    private static bool impresion(){
        Console.WriteLine($@"
        Desea imprimir?:
        1 : Si
        2:- No");
        ConsoleKeyInfo response=Console.ReadKey();
        switch (response.Key)
        {  
            case ConsoleKey.D1:
            return true;
            case ConsoleKey.D2:
            return false;
            
            default:
            impresion();
            break;
        }
        return false;// este solo existe para que no joda

    }
}