using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;
using System.Data.OleDb;


namespace AccesoDato
{
    public class VentaDao
    {

        BaseDeDato bd;

        public int BdCodeError { get; set; }

        public string BdMsgError { get; set; }

        public VentaDao()
        {
            BdCodeError = 0;
            BdMsgError = "";
            bd = new BaseDeDato();
            bd.Conectar();
        }

        public List<Venta> ListarVenta()
        {
            List<Venta> ventas = new List<Venta>();
            Data data = new Data();
            string vSql = @"SELECT
                                Factura.Id, 
                                Clientes.Nombre AS NombreCliente
                            FROM
                                Factura
                            INNER JOIN
                                Clientes ON Factura.IdCliente = Clientes.Id";
            DataTable dt = data.CargarDt(vSql, CommandType.Text);
            foreach (DataRow dr in dt.Rows)
            {
                Venta venta = new Venta
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    IdCliente = Convert.ToInt32(dr["IdCliente"])
                };
                ventas.Add(venta);
            }
            return ventas;
        }

        public int Eliminar(Venta venta)
        {
            int numReg = 0;
            string vSql = "";
            vSql = "DELETE FROM Factura-Producto WHERE [IdFactura] = ?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, venta.Id);
            numReg += bd.EjecutarComando();
            bd.Desconectar();
            vSql = "DELETE FROM Factura WHERE  [Id] = ?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, venta.Id);
            numReg += bd.EjecutarComando();
            bd.Desconectar();
            
            if (numReg <= 0)
            {
                if (bd.BdCodeError != 0)
                {
                    BdCodeError = bd.BdCodeError;
                    BdMsgError = bd.BdMsgError;
                }
            }
            return numReg;
        }

        public int Insertar(Venta venta)
        {
            int numReg = 0;
            var vSql = "INSERT INTO Factura ([Id], [Nombre]) VALUES (?, ?)";
            bd.CrearComando(vSql,CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, venta.Id);
            bd.AsignarParametro("?", OleDbType.Integer, venta.IdCliente);
            numReg = bd.EjecutarComando();
            bd.Desconectar();
            if (numReg <= 0)
            {
                if (bd.BdCodeError != 0)
                {
                    BdCodeError = bd.BdCodeError;
                    BdMsgError = bd.BdMsgError;
                }
            }
            return numReg;
        }

        public int Actualizar(Venta venta)
        {
            int numReg = 0;
            var vSql = "UPDATE Factura SET [IdCliente]=? WHERE [Id] = ?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro(vSql, OleDbType.Integer, venta.IdCliente);
            bd.AsignarParametro("?", OleDbType.Integer, venta.Id);
            numReg = bd.EjecutarComando();
            bd.Desconectar();
            if(numReg <= 0)
            {
                if(bd.BdCodeError != 0)
                {
                    BdCodeError = bd.BdCodeError;
                    BdMsgError = bd.BdMsgError;
                }
            }
            return numReg;
        }
    }
}
