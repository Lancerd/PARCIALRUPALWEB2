using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDato;
using Comun;
using System.Web.UI.WebControls;

namespace ReglaNegocio
{
    public class VentaProductoBl
    {
        VentaProductoDao ventaProductoDao;
        public int BdCodeError {get; set;}
        public string BdMsgError {get; set;}

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
            numReg = ventaProductoDao.EliminarPV(ventaProducto);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError !=0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int Eliminar(VentaProducto ventaProducto){
            int numReg = 0;
            numReg = ventaProductoDao.EliminarV(ventaProducto);
            if(numReg <= 0){
                if(ventaProductoDao.BdCodeError !=0){
                    BdCodeError = ventaProductoDao.BdCodeError;
                    BdMsgError = ventaProductoDao.BdMsgError;
                }
            }
            return numReg;
        }

        public static void ListarVentaProducto(GridView dgv){
            List<VentaProducto> ventaProductos = VentaProductoDao.CargarGrilla();
            var datosmostrar = ventaProductos.Select(vp => new
            {
                vp.IdProducto,
                vp.Valor
            }).ToList();
            dgv.DataSource = datosmostrar;
            dgv.DataBind();
            dgv.HeaderRow.Cells[1].Text = "Producto";
        }
    }
}
