using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafovias.Classes
{
    public class Dijkastra
    {
        public static void DijkstraInTime(Origen grafo, string origen, string destino){
        var distancias = new Dictionary<string, int>();
        var previos = new Dictionary<string, string>();
        var minHeap = new Heap<(int tiempo, string ciudad)>();

        // Inicializar distancias y previos
        foreach (var ciudad in grafo.Ciudad.Keys)
        {
            distancias[ciudad] = int.MaxValue;
            previos[ciudad] = null;
        }
        distancias[origen] = 0;
        minHeap.Insert((0, origen));

        while (!minHeap.IsEmpty())
        {
            (int tiempoActual, string ciudadActual) = minHeap.ExtractMin();

            if (ciudadActual == destino){

                break;
            }
            Dictionary<string,(int distancia,int tiempo)> causa= grafo.getDestinos(ciudadActual);

            foreach (var (vecino, (distancia, tiempo)) in causa)
            {
                int nuevoTiempo = tiempoActual + tiempo;

                if (nuevoTiempo < distancias[vecino])
                {
                    distancias[vecino] = nuevoTiempo;
                    previos[vecino] = ciudadActual;
                    minHeap.Insert((nuevoTiempo, vecino));
                }

            }
        }

        // Reconstruir la ruta
        var ruta = new List<string>();
        for (string ciudad = destino; ciudad != null; ciudad = previos[ciudad])
        {
            ruta.Add(ciudad);
        }
        ruta.Reverse();

        // Imprimir la ruta
        Console.WriteLine($"Ruta más corta desde {origen} hasta {destino}:");
        Console.WriteLine(string.Join(" -> ", ruta));
        Console.WriteLine($"Tiempo total: {distancias[destino]} ");
    }
    public static void DijkstraDistancia(Origen grafo, string origen, string destino)
{
    var distancias = new Dictionary<string, int>();
    var previos = new Dictionary<string, string>();
    var minHeap = new Heap<(int distancia, string ciudad)>();

    // Inicializar distancias y previos
    foreach (var ciudad in grafo.Ciudad.Keys)
    {
        distancias[ciudad] = int.MaxValue;
        previos[ciudad] = null;
    }
    distancias[origen] = 0;
    minHeap.Insert((0, origen));

    while (!minHeap.IsEmpty())
    {
        var (distanciaActual, ciudadActual) = minHeap.ExtractMin();

        if (ciudadActual == destino){break;}
        Dictionary<string,(int distancia,int tiempo)> causa= grafo.getDestinos(ciudadActual);

        foreach (var (vecino, (distancia, tiempo)) in causa)
        {
            int nuevaDistancia = distanciaActual + distancia; // Usamos la distancia como discriminador
            if (nuevaDistancia < distancias[vecino])
            {
                distancias[vecino] = nuevaDistancia;
                previos[vecino] = ciudadActual;
                minHeap.Insert((nuevaDistancia, vecino));
            }
        }
    }

    // Reconstruir la ruta
    var ruta = new List<string>();
    for (string ciudad = destino; ciudad != null; ciudad = previos[ciudad])
    {
        ruta.Add(ciudad);
    }
    ruta.Reverse();

    // Imprimir la ruta
    Console.WriteLine($"Ruta más corta desde {origen} hasta {destino} (basada en distancia):");
    Console.WriteLine(string.Join(" -> ", ruta));
    Console.WriteLine($"Distancia total: {distancias[destino]} km");
}
        
    }
}