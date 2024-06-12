using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;


namespace AccesoDato
{
    public class VentaDao
    {

        BaseDeDato bd;

        public int BdCodeError {get; set;}

        public string BdMsgError {get; set;}

        public VentaDao(){
            BdCodeError = 0;
            BdMsgError = "";
            bd = new BaseDeDato;
            bd.Conectar;
        }

        public List<Venta> ListarVenta()
        {
            List<Venta> ventas = new List<Venta>();
            Data data = new Data();
            string vSql = @"
                SELECT 
                    Id, 
                    IdCliente, 
                FROM 
                    Factura";
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

        public int Eliminar(int Id){
            int numReg = 0;
            string vSql = "DELETE FROM Factura WHERE  [Id] = ?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?",OleDbType.Integer, Id);
            numReg = bd.EjecutarComando();
            bd.Desconectar();
            if(numReg <= 0){
                if(bd.BdCodeError != 0){
                    BdCodeError = bd.BdCodeError;
                    BdMsgError = bd.BdMsgError;
                }
            }
            return numReg;
        }

        public int Insertar(Venta venta){
            int numReg = 0;
            var vSql = "INSERT INTO Factura ([Id], [Nombre]) VALUES (?, ?)";
            bd.CrearComando(vSql. CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, venta.Id);
            bd.AsignarParametro("?", OleDbType.Integer, venta.IdCliente);
            numReg = bd.EjecutarComando();
            bd.Desconectar();
            if(numReg<=0){
                if(bd.BdCodeError!=0){
                    BdCodeError = bd.BdCodeError;
                    BdMsgError = bd.BdMsgError;
                }
            }
            return numReg;
        }
    }
}
