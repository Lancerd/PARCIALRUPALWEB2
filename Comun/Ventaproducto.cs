using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class VentaProducto
    {
        public int Id { get; set;}
        
        public int IdCliente { get; set;}

        public int IdProducto { get; set;} 

        public Venta (){
            Id = 0;
            IdCliente = 0;
            IdProducto = 0;
        }

        public VentaProducto (int Id, int IdCliente){
            this.Id = Id;
            this.IdCliente = IdCliente;
            this.IdProducto = IdProducto;
        }

    }
}
