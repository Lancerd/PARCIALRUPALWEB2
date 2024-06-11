using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDato;
using Comun;

namespace ReglaNegocio
{
    public class VentaProductoBl
    {
        public static void ListarVentaProducto(DropDownList cmd){
            VentaProductoDao venaProductoDao = new VentaProductoDao();
            List<VentaProducto> ventaProducto = VentaProductoDao.ListarVentaProducto(cmd);
            cmd.DataSource = ventaProducto;
            cmd.DataValueField = "IdProducto";
            cmd.DataTexField = "Valor";
            cmd.DataBind();
        }
    }
}
