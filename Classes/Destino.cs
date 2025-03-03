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
        public int GetDistancia(string NombreCiudad){
            (int distancia,int tiempo) tpl=CiudadesDestino[NombreCiudad];
            return tpl.distancia;
        }
        public int GetTiempo(string NombreCiudad){
            (int distancia,int tiempo) tpl=CiudadesDestino[NombreCiudad];
            return tpl.tiempo;
        }
        public void AddCiudad(string nombre, int distancia,int tiempo){
            CiudadesDestino[nombre]=(distancia,tiempo);
        }

    }
}