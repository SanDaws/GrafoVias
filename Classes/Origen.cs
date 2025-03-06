using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafovias.Classes
{
    public class Origen
    {
        public Dictionary<string,Destino> Ciudad;
        public Origen(){
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
        
        public override string ToString()
        {   
            string List="";
            foreach (var item in Ciudad)
            {
                List+= $@"{item.Key} : {Ciudad[item.Key].ToString()}"+ Environment.NewLine;
            }
            return List;
        }
        public Dictionary<string,(int distancia,int tiempo)> getDestinos(string ciudad){
            return Ciudad[ciudad].GetCiudaddestino();
        }
        public bool ExistIn(string origen,string Destino)=>(Ciudad.ContainsKey(origen)==true)?Ciudad[origen].Exist(Destino):false; 
        public bool Exist(string origen)=>(Ciudad.ContainsKey(origen)==true)?true:false;
                public List<string> CiudadesName()=>new List<string>(Ciudad.Keys); 
    }
}