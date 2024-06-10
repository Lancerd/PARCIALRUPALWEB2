using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using AccesoDato;
using System.Web.UI.WebControls;

namespace ReglaNegocio
{
    public class ProductoBl
    {
        public static void ListarProducto(DropDownList cmd){
            List<Producto> producto = ProductoDao.ListarProducto(cmd);
            cmd.DataSource = producto;
            cmd.DataValueField = "Id";
            cmd.DataTextField = "Nombre";
            cmd.DataBind();
        }
    }
}
