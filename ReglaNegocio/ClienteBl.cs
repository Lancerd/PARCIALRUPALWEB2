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
        ClienteDao clienteDao;

        public int BdCodeError;

        public string BdMsgError;

        public ClienteBl(){
            clienteDao = new ClienteDao();
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

        public int Actualizar (Cliente cliente){
            int numReg = 0;
            numReg = clienteDao.Actualizar(cliente);
            if(numReg <= 0){
                if(clienteDao.BdCodeError != 0){
                    BdCodeError = clienteDao.BdCodeError;
                    BdMsgError = clienteDao.BdMsgError;
                }
            }
            return numReg;
        }

        public int Insertar (Cliente cliente){
            int numReg = 0;
            numReg = clienteDao.Insertar(cliente);
            if(numReg <= 0){
                if(clienteDao.BdCodeError != 0){
                    BdCodeError = clienteDao.BdCodeError;
                    BdMsgError = clienteDao.BdMsgError;
                }
            }
            return numReg;
        }

        public static Cliente Consultar(string NCliente){
            ClienteDao clienteDao = new ClienteDao();
            return clienteDao.Consultar(NCliente);
        }
    }
}
