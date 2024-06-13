using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data.OleDb;
using System.Data;

namespace AccesoDato
{
    public class ProductoDao
    {
        
        BaseDeDato bd;

        public int BdCodeError {get; set;}

        public string BdMsgError {get; set;}

        public ProductoDao(){
            BdCodeError = 0;
            BdMsgError = "";
            bd = new BaseDeDato();
            bd.Conectar();
        }


        public static List<Producto> ListarProducto(){
            List<Producto> Producto = new List<Producto>();
            Data data = new Data();
            string vSql = "SELECT [Id], [Nombre], [Valor] FROM Producto"; 
            DataTable dt = data.CargarDt(vSql, CommandType.Text);
            foreach (DataRow dr in dt.Rows){
                Producto producto = new Producto{
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = Convert.ToString(dr["Nombre"])
                };
                Producto.Add(producto);
            }
            return Producto;
        }

        public static List<Producto> CargarGrilla(){
            return ListarProducto();
        }

        public int Consultar (Producto producto)
        {
            int numReg = 0;
            var vSql = "SELECT [Id], [Nombre], [Valor] FROM Producto WHERE [Id]=?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, producto.Id);
            numReg = bd.EjecutarComando();
            bd.Desconectar();
            if(numReg <= 0)
            {

            }
            return numReg;
        }

        public int Insertar(Producto producto){
            int numReg = 0;
            var vSql = "INSERT INTO Producto ([Id], [Nombre], [Valor]) VALUES (?,?,?)";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, producto.Id);
            bd.AsignarParametro("?", OleDbType.Integer, producto.Nombre);
            bd.AsignarParametro("?", OleDbType.Integer, producto.Valor);
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
