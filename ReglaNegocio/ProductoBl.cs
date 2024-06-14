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

        public static Producto Consultar(string NProducto){
            ProductoDao clienteDao = new ProductoDao ();
            return clienteDao.Consultar(NProducto);
        }

        public static void CargarGrilla(GridView dgv){
            List<Producto> productos = ProductoDao.CargarGrilla();
            var datosmostrar = productos.Select(p => new{
                p.Id,
                p.Nombre,
                p.Valor
            }).ToList();
            dgv.DataSource = datosmostrar;
            dgv.DataBind();
        }

        public static void ListarProducto(DropDownList cmd)
        {
            List<Producto> producto = ProductoDao.CargarGrilla();
            cmd.DataSource = producto;
            cmd.DataValueField = "Id";
            cmd.DataTextField = "Nombe";
            cmd.DataValueField = "Valor";
            cmd.DataBind();
        }
    }
}
