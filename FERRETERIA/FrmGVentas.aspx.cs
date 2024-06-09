using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
t 
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

        }

        protected void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes actualizar el DropDownList CmbFactura basado en la selección de CmbCliente
            // Por ejemplo, puedes cargar las facturas asociadas al cliente seleccionado

            // Puedes obtener el cliente seleccionado así:
            string clienteSeleccionado = CmbCliente.SelectedValue;

            // Luego, puedes cargar las facturas asociadas a este cliente en el DropDownList CmbFactura
            // Supongamos que tienes un método llamado CargarFacturas que carga las facturas asociadas a un cliente en el DropDownList CmbFactura
            CargarFacturas(clienteSeleccionado);
        }

        protected void CargarFacturas(string clienteId)
        {
            // Aquí deberías implementar el código para acceder a tu base de datos y recuperar las facturas asociadas al cliente seleccionado.
            // Supongamos que tienes una clase llamada DataAccess con un método llamado ObtenerFacturasPorCliente que devuelve una lista de facturas para un cliente dado.

            //List<Factura> facturas = DataAccess.ObtenerFacturasPorCliente(clienteId);

            // Una vez que tienes la lista de facturas, puedes asignarla al DropDownList CmbFactura
            // Suponiendo que cada factura tiene un campo "Nombre" que deseas mostrar en el DropDownList
            // Suponiendo que cada factura tiene un campo "Id" que deseas utilizar como valor en el DropDownList
            
            

            // Opcionalmente, puedes agregar un elemento por defecto al DropDownList
            CmbFactura.Items.Insert(0, new ListItem("Seleccione una factura", ""));
        }

    }
}