﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Comun;
using ReglaNegocio;

namespace FERRETERIA
{
    public partial class FrmGVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCombo_cliente();
        }
        private void CargarCombo_cliente()
        {
            ClienteBl.ListarCliente(CmbCliente);
        }
        protected void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void CargarFacturas(Cliente cliente)
        {
            
        }
    }
}