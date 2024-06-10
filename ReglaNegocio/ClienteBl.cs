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
    public class ClienteBl
    {
        public static void ListarCliente(DropDownList cmd){
            ClienteDao clienteDao = new ClienteDao();
            List<Cliente> cliente = ClienteDao.ListarCliente(cmd);
            cmd.DataSource = cliente;
            cmd.DataValueField = "Id";
            cmd.DataTextField = "Nombre";
            cmd.DataBind();
        }
    }
}
