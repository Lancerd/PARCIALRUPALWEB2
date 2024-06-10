using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDato;
using Comun;

namespace ReglaNegocio
{
    internal class VentaBl
    {
        public static void ListarVenta(DropDownList cmd){
            VentaDao ventaDao = new VentaDao();
            List<Venta> venta = VentaDao.ListarVenta(cmd);
            cmd.DataSource = venta;
            cmd.DataValueField = "Id";
            cmd.DataTexField = "IdCliente";
            cmd.DataBind();
        }
    }
}
