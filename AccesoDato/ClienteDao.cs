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
    public class ClienteDao
    {

        BaseDeDato bd;

        public int BdCodeError {get; set;}

        public string BdMsgError {get; set;}

        public ClienteDao(){
            BdCodeError = 0;
            BdMsgError = "";
            bd = new BaseDeDato ();
            bd.Conectar();
        }

        public static List<Cliente> ListarCliente()
        {
            List<Cliente> Clientes = new List<Cliente>();
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
                Cliente cliente = new Cliente
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = Convert.ToString(dr["IdProducto"]),
                };
                Clientes.Add(cliente);
            }
            return Clientes;
        }

        public static List<Cliente> CargarGrilla (){
            return ListarCliente();
        }

        public int Aptualizar (Cliente cliente)
        {
            int numReg = 0;
            var vSql = "UPDATE Cliente SET [Nombre]=? WHERE [Id]=?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?", OleDbType.VarChar, cliente.Nombre);
            bd.AsignarParametro("?", OleDbType.Integer, cliente.Id);
            numReg = bd.EjecutarComando();
            bd.Desconectar();
            if(numReg <= 0)
            {
                if(BdCodeError != 0)
                {
                    BdCodeError = bd.BdCodeError;
                    BdMsgError = bd.BdMsgError;
                }
            }
            return numReg;
        }

        public int Insertar(Cliente cliente){
            int numReg = 0;
            var vSql = "INSERT INTO Cliente ([Id], [Nombre]) VALUES (?, ?)";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, cliente.Id);
            bd.AsignarParametro("?", OleDbType.VarChar, cliente.Nombre);
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
