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
        ClienteDao ClienteDao;

        public int BdCodeError;

        public string BdMsgError;

        public ClienteBl(){
            ClienteDao = new ClienteDao();
            BdCodeError = 0;
            BdMsgError = "";
        }
        public static void ListarCliente(DropDownList cmb) { 
            ClienteDao clienteDao = new ClienteDao();
            List<Cliente> cliente = ClienteDao.ListarCliente();
            cmb.DataSource = cliente;
            cmb.DataValueField = "Id";
            cmb.DataTextField = "Nombre";
            cmb.DataBind();
        }

        public static void CargarGrilla(GridView dgv){
            List<Cliente> clientes = ClienteDao.CargarGrilla();
            var datosmostrar = clientes.Select(c => new {
                c.Id,
                c.Nombre
            }).ToList();
            dgv.DataSource = datosmostrar;
            dgv.DataBind();
        }

    }
}
