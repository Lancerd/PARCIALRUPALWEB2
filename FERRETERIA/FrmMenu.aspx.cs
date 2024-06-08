using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FERRETERIA
{
    public partial class FrmMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRProductos_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("FrmRProductos.aspx");
        }

        protected void BtnGPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmGPedidos.aspx");
        }

        protected void BtnGVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmGVentas.aspx");
        }

        protected void BtnGInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmGInventario.aspx");
        }
    }
}
