using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class Producto
    {
        public int Id { get; set;}

        public string Nombre { get; set;} 

        public Producto (){
            Id = 0;
            Nombre = string.Empty;
        }

        public Producto (int Id, string Nombre){
            this.Id = Id;
            this.Nombre = Nombre;
        }
    }
}
