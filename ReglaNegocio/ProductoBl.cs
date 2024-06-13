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
        ProductoDao productoDao;
        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public ProductoBl()
        {
            BdCodeError = 0;
            BdMsgError = "";
            productoDao = new ProductoDao();
        }

        public int Insertar(Producto producto)
        {
            int numReg = 0;
            numReg = productoDao.Insertar(producto);
            if (numReg <= 0)
            {
                if (productoDao.BdCodeError != 0)
                {
                    BdCodeError = productoDao.BdCodeError;
                    BdMsgError = productoDao.BdMsgError;
                }
            }
            return numReg;
        }


        public static void ListarProducto(DropDownList cmd)
        {
            ProductoDao productoDao = new ProductoDao();
            List<Producto> producto = productoDao.ListarProducto();
            cmd.DataSource = producto;
            cmd.DataValueField = "Id";
            cmd.DataTextField = "Nombe";
            cmd.DataValueField = "Valor";
            cmd.DataBind();
        }
    }
}
