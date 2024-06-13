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

        public int IdFactura { get; set;}

        public int Valor { get; set;} 

        public VentaProducto (){
            IdFactura = 0;
            IdProducto = 0;
            Valor = 0;
        }

        public VentaProducto (int IdFactura, int IdProducto , int Valor){
            this.IdFactura = IdFactura;
            this.IdProducto = IdProducto;
            this.Valor = Valor;
        }

    }
}
