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

        }
        protected void DgvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = new TableCell();
                Button btn = new Button();
                btn.Text = "Botón";
                btn.CssClass = "btn btn-primary";
                btn.Click += new EventHandler(btn_Click);
                cell.Controls.Add(btn);
                e.Row.Cells.Add(cell);
            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            // Lógica del evento clic del botón aquí
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMenu.aspx");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarProduto();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}