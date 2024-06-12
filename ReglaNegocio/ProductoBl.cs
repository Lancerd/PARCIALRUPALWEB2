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
        productoDao productoDao;
        public int BdCodeError {get; set;}
        public int BdMsgError {get; set;}

        public productoProductoBl(){
            BdCodeError = 0;
            BdMsgError = "";
            productoDao = new ProductoDao();
        }

        public int InsertarVP (Producto producto){
            int numReg = 0;
            numReg = productoDao.InsertarVP(producto);
            if(numReg <= 0){
                if(productoProductoDao.BdCodeError != 0){
                    BdCodeError = productoProductoDao.BdCodeError;
                    BdMsgError = productoProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarVP(producto Producto){
            int numReg = 0;
            numReg = productoDao.Eliminar(producto);
            if(numReg <= 0){
                if(productoProductoDao.BdCodeError !=0){
                    BdCodeError = productoProductoDao.BdCodeError;
                    BdMsgError = productoProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarV(producto producto){
            int numReg = 0;
            numReg = productoDao.Eliminar(producto);
            if(numReg <= 0){
                if(productoProductoDao.BdCodeError !=0){
                    BdCodeError = productoProductoDao.BdCodeError;
                    BdMsgError = productoProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public static void Listarproducto(DropDownList cmd){
            productoDao productoDao = new productoDao();
            List<producto> producto = productoDao.Listarproducto(cmd);
            cmd.DataSource = producto;
            cmd.DataValueField = "Id";
            cmd.DataTextField = "Nombe";
            cmd.DataValueField = "Valor";
            cmd.DataBind();
        }
    }
}
