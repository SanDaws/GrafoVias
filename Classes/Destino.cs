using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafovias.Classes
{
    public class Destino
    {
        Dictionary<string,(int,int)> CiudadesDestino;
        public Destino(){
            CiudadesDestino= new Dictionary<string, (int, int)>();
        }
        public int getDistancia(string NombreCiudad){
            (int,int) tpl=CiudadesDestino[NombreCiudad];
            return tpl.Item1;
        }
        public int getTiempo(string NombreCiudad){
            (int,int) tpl=CiudadesDestino[NombreCiudad];
            return tpl.Item1;
        }

    }
}