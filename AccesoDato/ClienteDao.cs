using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;

namespace AccesoDato
{
    public class ClienteDao
    {
       public List<Venta> ListarVenta()
        {
            List<Venta> ventas = new List<Venta>();
            Data data = new Data();
            string vSql = @"
                SELECT 
                    f.Id, 
                    f.IdCliente, 
                    c.Nombre AS NombreCliente
                FROM 
                    Factura f 
                INNER JOIN 
                    Cliente c ON f.IdCliente = c.Id";
            DataTable dt = data.CargarDt(vSql, CommandType.Text);
            foreach (DataRow dr in dt.Rows)
            {
                Venta venta = new Venta
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    IdCliente = Convert.ToInt32(dr["IdCliente"]),
                    NombreCliente = dr["NombreCliente"].ToString()
                };
                ventas.Add(venta);
            }
            return ventas;
        }
    }
}
