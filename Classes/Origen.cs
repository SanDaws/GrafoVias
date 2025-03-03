using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafovias.Classes
{
    public class Origen
    {
        Dictionary<string,Destino> Ciudad;
        public Origen(){
            Destino adyacentes= new Destino();
            Ciudad=new Dictionary<string, Destino>();
        }
        public void AddCiudad(string Origen,string nombreDestino, int distancia,int tiempo){
            if (!Ciudad.ContainsKey(Origen))
            {
                Ciudad[Origen]= new Destino();
            }
            Ciudad[Origen].AddCiudad(nombreDestino,distancia,tiempo);
            
            if (!Ciudad.ContainsKey(nombreDestino))
            {
                Ciudad[nombreDestino]= new Destino();
            }
            Ciudad[nombreDestino].AddCiudad(Origen,distancia,tiempo);
            
        }
    }
}