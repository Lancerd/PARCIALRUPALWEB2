using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class VentaProducto
    {
        
        public int IdProducto { get; set;}

        public sat

        public int Valor { get; set;} 

        public Venta (){
            IdProducto = 0;
            Valor = 0;
        }

        public VentaProducto (int IdFactura, int IdProducto){
            this.IdFactura = IdFactura;
            this.IdProducto = IdProducto;
        }

    }
}
