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

        public int Valor {get; set;}

        public bool Consulto {get; set;}

        public Producto (){
            Id = 0;
            Nombre = string.Empty;
            Valor = 0;
            Consulto = false;
        }

        public Producto (int Id, string Nombre, int Valor, bool Consulto){
            this.Id = Id;
            this.Nombre = Nombre;
            this.Valor = Valor;
            this.Consulto = Consulto;
        }
    }
}
