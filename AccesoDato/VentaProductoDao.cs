using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;

namespace AccesoDato
{
    public class VentaProductoDao
    {
        
        public List<Venta> ListarVentaproducto (int IdFActura){
            List<VentaProducto> VentaProducto = new List<VentaProducto>();
            Data data = new Data();
            string vSql = "SELECT [Id], [IdProducto] FROM Factura-Producto WHERE IdFActura = ?";
            DataTable dt = data.CargarDt(vSql,CommandType.Text);
            foreach (DataRow dr in dt.Rows){
                VentaProducto ventaProducto = new VentaProducto{
                    Id = Convert.ToInt32(dr["Id"]),
                    IdProducto = Convert.ToInt32(dr["IdProducto"])
                };
                Venta.Add(ventaProducto);
            }
            return VentaProducto;
        }

    }
}
