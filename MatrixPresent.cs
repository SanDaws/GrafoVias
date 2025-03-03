using System;
using System.Collections.Generic;
using System.IO;

class MatrixPresent
{
    static void MetodoGraficarKM()   // Genera la matriz tomando la distancia en KM
    {
        string filePath = "C:/Users/ADMIN/Downloads/Datos vias.csv";        // Cambiar por directorio en el que este actualmente el .csv
        Dictionary<string, Dictionary<string, int>> matrizAdy = new Dictionary<string, Dictionary<string, int>>();

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

            if (!matrizAdy.ContainsKey(ciudad1))
            {
                matrizAdy[ciudad1] = new Dictionary<string, int>();
            }

            if (!matrizAdy.ContainsKey(ciudad2))
            {
                matrizAdy[ciudad2] = new Dictionary<string, int>();
            }

            matrizAdy[ciudad1][ciudad2] = distanciaKm;
            matrizAdy[ciudad2][ciudad1] = distanciaKm;
        }

        List<string> ciudades = new List<string>(matrizAdy.Keys);
        Console.WriteLine("Matriz de Adyacencia (en KM)");
        Console.Write("\t");

        foreach (var ciudad in ciudades) {
            Console.Write(ciudad + "\t");
        } 
        Console.WriteLine();

        foreach (var ciudad1 in ciudades) {
            Console.Write(ciudad1 + "\t");

            foreach (var ciudad2 in ciudades) {
                int distancia = matrizAdy[ciudad1].ContainsKey(ciudad2) ? matrizAdy[ciudad1][ciudad2] : 0;
                Console.Write(distancia + "\t");
            }
            Console.WriteLine();
        }
    }

    static void MetodoGraficarTiempo()  // Genera la matriz tomando el tiempo
    {
        string filePath = "C:/Users/ADMIN/Downloads/Datos vias.csv";        // Cambiar por directorio en el que este actualmente el .csv
        Dictionary<string, Dictionary<string, int>> matrizAdy = new Dictionary<string, Dictionary<string, int>>();

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

            if (!matrizAdy.ContainsKey(ciudad1))
            {
                matrizAdy[ciudad1] = new Dictionary<string, int>();
            }

            if (!matrizAdy.ContainsKey(ciudad2))
            {
                matrizAdy[ciudad2] = new Dictionary<string, int>();
            }

            matrizAdy[ciudad1][ciudad2] = distanciaMin;
            matrizAdy[ciudad2][ciudad1] = distanciaMin;
        }

        List<string> ciudades = new List<string>(matrizAdy.Keys);
        Console.WriteLine("Matriz de Adyacencia (en Minutos)");
        Console.Write("\t");

        foreach (var ciudad in ciudades) {
            Console.Write(ciudad + "\t");
        } 
        Console.WriteLine();

        foreach (var ciudad1 in ciudades) {
            Console.Write(ciudad1 + "\t");

            foreach (var ciudad2 in ciudades) {
                int tiempo = matrizAdy[ciudad1].ContainsKey(ciudad2) ? matrizAdy[ciudad1][ciudad2] : 0;
                Console.Write(tiempo + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main() {
        MetodoGraficarKM();
        MetodoGraficarTiempo();
    }
}
