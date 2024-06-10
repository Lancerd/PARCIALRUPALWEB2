using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class Venta
    {
        public int Id { get; set;}

        public string Nombre { get; set;} 

        public Venta (){
            Id = 0;
            Nombre = string.Empty;
        }

        public Venta (int Id, string Nombre){
            this.Id = Id;
            this.Nombre = Nombre;
        }

    }
}
