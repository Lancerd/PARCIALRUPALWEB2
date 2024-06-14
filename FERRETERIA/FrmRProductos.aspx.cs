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
    public partial class FrmRProguctos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla(){
            ProductoBl.CargarGrilla(DgvProductos);
        }

        private void Limpiar()
        {
            TxtNProducto.Text = string.Empty;
            TxtValor.Text = string.Empty;
        }
        
        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMenu.aspx");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ProductoBl.Consultar(TxtNProducto.Text);
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            ProductoBl productoBl = new ProductoBl();
            producto.Nombre = TxtNProducto.Text;
            producto.Valor = Convert.ToInt32(TxtValor.Text);
            if (productoBl.Insertar(producto) > 0)
            {
                LblMensaje.Text = "Se agrego el producto";
                Limpiar();
            }
            else
            {
                if(productoBl.BdCodeError != 0)
                {
                    LblMensaje.Text = productoBl.BdMsgError;
                }
                else
                {
                    LblMensaje.Text = "No se agrego el producto";
                }
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            ProductoBl productoBl = new ProductoBl();
            producto.Nombre = TxtNProducto.Text;
            producto.Valor = Convert.ToInt32(TxtValor.Text);
            if (productoBl.Insertar(producto) > 0)
            {
                LblMensaje.Text = "Se Actualizo el producto";
                Limpiar();
            }
            else
            {
                if (productoBl.BdCodeError != 0)
                {
                    LblMensaje.Text = productoBl.BdMsgError;
                }
                else
                {
                    LblMensaje.Text = "No se agrego el producto";
                }
            }
        }

        protected void DgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}