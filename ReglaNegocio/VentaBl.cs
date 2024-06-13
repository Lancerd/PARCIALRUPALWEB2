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
        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public VentaBl()
        {
            BdCodeError = 0;
            BdMsgError = "";
            ventaDao = new VentaDao();
        }

        public int Insertar(Venta venta)
        {
            int numReg = 0;
            numReg = ventaDao.Insertar(venta);
            if (numReg <= 0)
            {
                if (ventaDao.BdCodeError != 0)
                {
                    BdCodeError = ventaDao.BdCodeError;
                    BdMsgError = ventaDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int Eliminar(Venta venta)
        {
            int numReg = 0;
            numReg = ventaDao.Eliminar(venta);
            if (numReg <= 0)
            {
                if (ventaDao.BdCodeError != 0)
                {
                    BdCodeError = ventaDao.BdCodeError;
                    BdMsgError = ventaDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarV(Venta venta)
        {
            int numReg = 0;
            numReg = ventaDao.Eliminar(venta);
            if (numReg <= 0)
            {
                if (ventaDao.BdCodeError != 0)
                {
                    BdCodeError = ventaDao.BdCodeError;
                    BdMsgError = ventaDao.BdMsgError;
                }
            }
            return numReg;
        }

        public static void ListarVenta(GridView dgv)
        {
            VentaDao ventaDao = new VentaDao();
            List<Venta> venta = ventaDao.ListarVenta();
            var DatosMostrar = venta.Select(v => new {
                v.Id,
                v.IdCliente
            }).ToList();
            dgv.DataSource = venta;
            dgv.DataBind();

            dgv.HeaderRow.Cells[2].Text = "Nombre";
        }
    }
}
