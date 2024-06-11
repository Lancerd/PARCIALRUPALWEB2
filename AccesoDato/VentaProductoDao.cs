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
        
        public List<VentaProducto> ListarVentaProducto(int IdFactura)
        {
            List<VentaProducto> ventaProductos = new List<VentaProducto>();
            Data data = new Data();
            string vSql = @"SELECT 
                                p.IdProducto,
                                p.Valor
                            FROM 
                                Producto p
                            INNER JOIN 
                                FacturaProducto fp ON p.Id = fp.IdProducto
                            WHERE 
                                fp.IdFactura = ?";
            DataTable dt = data.CargarDt(vSql, CommandType.Text, new SqlParameter("@IdFactura", IdFactura));
            foreach (DataRow dr in dt.Rows)
            {
                VentaProducto ventaProducto = new VentaProducto
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                    ValorProducto = Convert.ToDecimal(dr["Valor"]) 
                };
                ventaProductos.Add(ventaProducto);
            }
            return ventaProductos;
        }

    }
}
