using System;
using System.Collections.Generic;
using System.IO;
namespace Grafovias.Classes;
class MatrixPresent
{
    static void MetodoGraficarKM()   // Genera la matriz tomando la distancia en KM
    {
        string filePath = "C:/Users/ADMIN/Downloads/Datos vias.csv";        // Cambiar por directorio en el que este actualmente el .csv
        Dictionary<string, Dictionary<string, int>> matrizAdyKM = new Dictionary<string, Dictionary<string, int>>();

        string[] lineas = File.ReadAllLines(filePath);

        foreach (string line in lineas)
        {
            string[] columnas = line.Split(';');
            if (columnas.Length < 4) {
                continue;
            }

            string ciudad1 = columnas[0].Trim();
            string ciudad2 = columnas[1].Trim();
            int distanciaKm = int.Parse(columnas[2].Trim());
            int distanciaMin = int.Parse(columnas[3].Trim());

            if (!matrizAdyKM.ContainsKey(ciudad1))
            {
                matrizAdyKM[ciudad1] = new Dictionary<string, int>();
            }

            if (!matrizAdyKM.ContainsKey(ciudad2))
            {
                matrizAdyKM[ciudad2] = new Dictionary<string, int>();
            }

            matrizAdyKM[ciudad1][ciudad2] = distanciaKm;
            matrizAdyKM[ciudad2][ciudad1] = distanciaKm;
        }

        Console.WriteLine("Ingrese la ciudad 1");
        var askcity1 = Console.ReadLine();
        Console.WriteLine("Ingrese la ciudad 2");
        var askcity2 = Console.ReadLine();

        bool chck = matrizAdyKM[askcity1].ContainsKey(askcity2) ? true : false;
        if (chck == true) {
            Console.WriteLine("Estan conectados");
            Console.WriteLine("");
        }
            else {
                Console.WriteLine("No hay conexion");
                Console.WriteLine("");
            }
        
        
        Console.WriteLine("Desea imprimir la matriz? Escriba Si o No");
        var seguir = Console.ReadLine();

        if (seguir == "Si") {
            List<string> ciudades = new List<string>(matrizAdyKM.Keys);
            Console.WriteLine("Matriz de Adyacencia (en KM)");
            Console.Write("\t");

            foreach (var ciudad in ciudades) {
                Console.Write(ciudad + "\t");
            } 
            Console.WriteLine();

            foreach (var ciudad1 in ciudades) {
                Console.Write(ciudad1 + "\t");

                foreach (var ciudad2 in ciudades) {
                    int distancia = matrizAdyKM[ciudad1].ContainsKey(ciudad2) ? matrizAdyKM[ciudad1][ciudad2] : 0;
                    Console.Write(distancia + "\t");
                }
                Console.WriteLine();
            }
        }
        else{
            Console.WriteLine("Ha terminado el programa");
        }
    }

    static void MetodoGraficarTiempo()  // Genera la matriz tomando el tiempo
    {
        string filePath = "C:/Users/ADMIN/Downloads/Datos vias.csv";        // Cambiar por directorio en el que este actualmente el .csv
        Dictionary<string, Dictionary<string, int>> matrizAdyMin = new Dictionary<string, Dictionary<string, int>>();

        string[] lineas = File.ReadAllLines(filePath);

        foreach (string line in lineas)
        {
            string[] columnas = line.Split(';');
            if (columnas.Length < 4) {
                continue;
            }

            string ciudad1 = columnas[0].Trim();
            string ciudad2 = columnas[1].Trim();
            int distanciaKm = int.Parse(columnas[2].Trim());
            int distanciaMin = int.Parse(columnas[3].Trim());

            if (!matrizAdyMin.ContainsKey(ciudad1))
            {
                matrizAdyMin[ciudad1] = new Dictionary<string, int>();
            }

            if (!matrizAdyMin.ContainsKey(ciudad2))
            {
                matrizAdyMin[ciudad2] = new Dictionary<string, int>();
            }

            matrizAdyMin[ciudad1][ciudad2] = distanciaMin;
            matrizAdyMin[ciudad2][ciudad1] = distanciaMin;
        }

        List<string> ciudades = new List<string>(matrizAdyMin.Keys);
        Console.WriteLine("Matriz de Adyacencia (en Minutos)");
        Console.Write("\t");

        foreach (var ciudad in ciudades) {
            Console.Write(ciudad + "\t");
        } 
        Console.WriteLine();

        foreach (var ciudad1 in ciudades) {
            Console.Write(ciudad1 + "\t");

            foreach (var ciudad2 in ciudades) {
                int tiempo = matrizAdyMin[ciudad1].ContainsKey(ciudad2) ? matrizAdyMin[ciudad1][ciudad2] : 0;
                Console.Write(tiempo + "\t");
            }
            Console.WriteLine();
        }
    }
}