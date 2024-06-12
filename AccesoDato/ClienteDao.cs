using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;

namespace AccesoDato
{
    public class ClienteDao
    {

        BaseDeDato bd;

        public int BdCodeError {get; set;}

        public string BdMsgError {get; set;}

        public ClienteDao(){
            BdCodeError = 0;
            BdMsgError = "";
            bd = new BaseDeDato;
            bd.Conectar;
        }

        public List<Cliente> ListarCliente()
        {
            List<Venta> cliente = new List<Cliente>();
            Data data = new Data();
            string vSql = @"
                SELECT 
                    Id, 
                    Nombre, 
                FROM 
                    Cliente";
            DataTable dt = data.CargarDt(vSql, CommandType.Text);
            foreach (DataRow dr in dt.Rows)
            {
                Venta venta = new Venta
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    IdCliente = Convert.ToString(dr["Cliente"]),
                };
                ventas.Add(venta);
            }
            return ventas;
        }

        public int Eliminar(int Id){
            int numReg = 0;
            string vSql = "DELETE FROM Cliente WHERE  [Id] = ?";
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
            var vSql = "INSERT INTO Cliente ([Id], [Nombre]) VALUES (?, ?)";
            bd.CrearComando(vSql. CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, venta.Id);
            bd.AsignarParametro("?", OleDbType.VarChar, venta.Nombre);
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

        public int Eliminar(int Id){
            int numReg = 0;
            string vSql = "DELETE FROM Cliente WHERE  [Id] = ?";
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


    }
}
