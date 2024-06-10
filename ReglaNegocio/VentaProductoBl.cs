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
            VentaProductoDao ventaDao = new VentaProductoDao();
            List<VentaProducto> ventaProducto = VentaProductoDao.ListarVentaProducto(cmd);
            cmd.DataSource = ventaProducto;
            cmd.DataValueField = "Id";
            cmd.DataTexField = "IdCliente";
            cmd.DataBind();
        }
    }
}
