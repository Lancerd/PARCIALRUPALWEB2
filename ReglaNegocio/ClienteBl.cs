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
        public static void ListarCliente(DropDownList cmb) { 
            ClienteDao clienteDao = new ClienteDao();
            List<Cliente> cliente = clienteDao.ListarCliente();
            cmb.DataSource = cliente;
            cmb.DataValueField = "Id";
            cmb.DataTextField = "Nombre";
            cmb.DataBind();
        }
    }
}
