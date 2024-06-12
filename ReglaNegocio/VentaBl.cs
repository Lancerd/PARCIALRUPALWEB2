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

        VentaDao ventaDao;
        public int BdCodeError {get; set;}
        public int BdMsgError {get; set;}

        public VentaProductoBl(){
            BdCodeError = 0;
            BdMsgError = "";
            ventaDao = new VentaDao();
        }

        public int InsertarVP (Venta venta){
            int numReg = 0;
            numReg = ventaDao.InsertarVP(venta);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError != 0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarVP(Venta venta){
            int numReg = 0;
            numReg = VentaDao.Eliminar(venta);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError !=0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarV(Venta venta){
            int numReg = 0;
            numReg = VentaDao.Eliminar(venta);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError !=0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

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
