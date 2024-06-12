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
        VentaProductoDao ventaProductoDao;
        public int BdCodeError {get; set;}
        public int BdMsgError {get; set;}

        public VentaProductoBl(){
            BdCodeError = 0;
            BdMsgError = "";
            ventaProductoDao = new VentaProductoDao();
        }

        public int InsertarVP (VentaProducto ventaProducto){
            int numReg = 0;
            numReg = ventaProductoDao.InsertarVP(ventaProducto);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError != 0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarVP(VentaProducto ventaProducto){
            int numReg = 0;
            numReg = VentaProductoDao.EliminarVP(ventaProducto);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError !=0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarV(VentaProducto ventaProducto){
            int numReg = 0;
            numReg = VentaProductoDao.EliminarV(ventaProducto);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError !=0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public static void ListarVentaProducto(DropDownList cmd){
            VentaProductoDao ventaProductoDao = new VentaProductoDao();
            List<VentaProducto> ventaProducto = VentaProductoDao.ListarVentaProducto(cmd);
            cmd.DataSource = ventaProducto;
            cmd.DataValueField = "IdFactura";
            cmd.DataValueField = "IdProducto";
            cmd.DataBind();
        }        
    }
}
