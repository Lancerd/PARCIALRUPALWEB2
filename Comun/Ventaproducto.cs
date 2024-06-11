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

        public int Valor { get; set;} 

        public Venta (){
            IdProducto = 0;
            Valor = 0;
        }

        public VentaProducto (int IdProducto, int Valor){
            this.IdProducto = IdProducto;
            this.Valor = Valor;
        }

    }
}
