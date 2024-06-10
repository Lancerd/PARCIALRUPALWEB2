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

        public int IdCliente { get; set;} 

        public Venta (){
            Id = 0;
            IdCliente = 0;
        }

        public Venta (int Id, int IdCliente){
            this.Id = Id;
            this.IdCliente = IdCliente;
        }

    }
}
