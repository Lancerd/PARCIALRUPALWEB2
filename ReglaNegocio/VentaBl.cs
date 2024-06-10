using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using AccesoDato;
using Comun;

namespace ReglaNegocio
{
    public class VentaBl
    {
        public static void ListarVenta(DropDownList cmd){
            VentaDao ventaDao = new VentaDao();
            List<Venta> venta = VentaDao.ListarVenta(cmd);
            cmd.DataSource = venta;
            cmd.DataValueField = "Id";
            cmd.DataTextField = "IdCliente";
            cmd.DataBind();
        }
    }
}
