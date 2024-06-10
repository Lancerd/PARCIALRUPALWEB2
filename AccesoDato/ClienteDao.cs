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
        public List<Cliente> ListarCliente (){
            List<Cliente> Cliente = new List<Cliente>();
            Data data = new Data();
            string vSql = "SELECT [Id] [IdCliente] FROM Cliente";
            DataTable dt = data.CargarDt(vSql,CommandType.Text);
            foreach (DataRow dr in dt.Rows){
                Cliente cliente = new Cliente{
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = Convert.ToString(dr["Nombre"])
                };
                Cliente.Add(cliente);
            }
            return Cliente;
        }
    }
}
