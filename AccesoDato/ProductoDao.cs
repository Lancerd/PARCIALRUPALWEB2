using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;

namespace AccesoDato
{
    public class ProductoDao
    {
         public List<Producto> ListarProducto (){
            List<Producto> Producto = new List<Producto>();
            Data data = new Data();
            string vSql = "SELECT [Id] [IdCliente] FROM Cliente";
            DataTable dt = data.CargarDt(vSql,CommandType.Text);
            foreach (DataRow dr in dt.Rows){
                Producto producto = new Producto{
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = Convert.ToString(dr["Nombre"])
                };
                Producto.Add(producto);
            }
            return Producto;
        }
    }
}
