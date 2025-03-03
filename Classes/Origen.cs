using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafovias.Classes
{
    public class Origen
    {
        Dictionary<string,Destino> graf;
        public Origen(){
            graf=new Dictionary<string, Destino>();
        }
    }
}