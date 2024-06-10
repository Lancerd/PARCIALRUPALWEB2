using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using AccesoDato;

namespace ReglaNegocio
{
    public class ProductoBl
    {
        public static void ListarProducto(DropDownList cmd){
            List<Producto> producto = ProductoDao.ListarProducto(cmd);
            cmd.DataSource = producto;
            cmd.DataValueField = "Id";
            cmd.DataTexField = "Nombre";
            cmd.DataBind();
        }
    }
}
