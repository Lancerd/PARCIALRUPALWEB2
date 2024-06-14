using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Comun;
using ReglaNegocio;

namespace FERRETERIA
{
    public partial class FrmGInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void Limpiar (){
            TxtIDCLiente.Text = "";
            TxtNCliente.Text = "";
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Cliente cliente = ClienteBl.Consultar(TxtIDCLiente.Text);
            if(cliente.Consulto){
                TxtIDCLiente.Text = cliente.Id.ToString();
                TxtNCliente.Text = cliente.Nombre;
            }else{
                LblMensaje.Text = "No se encontro el cliente";
            }
            
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "";
            ClienteBl clienteBl = new ClienteBl();
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(TxtIDCLiente.Text);
            cliente.Nombre = TxtNCliente.Text;
            if(clienteBl.Insertar(cliente) > 0){
                LblMensaje.Text = "Se agrego el cliente";
                Limpiar();
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "";
            ClienteBl clienteBl = new ClienteBl();
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(TxtIDCLiente.Text);
            cliente.Nombre = TxtNCliente.Text;
            if(clienteBl.Actualizar(cliente) < 0){
                LblMensaje.Text = "Se actualizo el cliente";
                Limpiar();
            }else{
                if(clienteBl.BdCodeError !=0){
                    LblMensaje.Text = clienteBl.BdMsgError;
                }else{
                    LblMensaje.Text = "No existe el cliente";
                }
            }
        }


        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMenu.aspx");
        }
    }
}