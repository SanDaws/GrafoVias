using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafovias.Classes
{
    public class Destino
    {
        public Dictionary<string,(int distancia,int tiempo)> CiudadesDestino;
        public Destino(){
            CiudadesDestino= new Dictionary<string, (int, int)>();
        }
        public int GetDistancia(string NombreCiudad){
            if (Exist(NombreCiudad)){
                (int distancia,int tiempo) tpl=CiudadesDestino[NombreCiudad];
            return tpl.distancia;}else
            {
                return 0;
            }
        }
        public int GetTiempo(string NombreCiudad){
            if (Exist(NombreCiudad)){
                (int distancia,int tiempo) tpl=CiudadesDestino[NombreCiudad];
            return tpl.tiempo;}else
            {
                return 0;
            }
        }
        public void AddCiudad(string nombre, int distancia,int tiempo){
            CiudadesDestino[nombre]=(distancia,tiempo);
        }
        public override string ToString()
        {
            string concated="";
            foreach (var item in CiudadesDestino)
            {
                string eachFormat=$@"{item.Key}: {GetTiempo(item.Key)}/ {GetDistancia(item.Key)}, ";
                concated +=eachFormat;
                
            }
            return concated;
        }
        public Dictionary<string,(int distancia,int tiempo)> GetCiudaddestino()=>CiudadesDestino;
        public bool Exist(string ciudad)=> CiudadesDestino.ContainsKey(ciudad);
        public List<string> DestinoNames()=>new List<string>(CiudadesDestino.Keys); 
        
            
    }
}