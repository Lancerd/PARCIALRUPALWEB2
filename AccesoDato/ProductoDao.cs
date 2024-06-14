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

        public Producto Consultar (string NProducto)
        {
            Producto producto = new Producto();
            var vSql = "SELECT [Id], [Nombre], [Valor] FROM Producto WHERE [Nombre]=?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?", OleDbType.VarChar, NProducto);
            OleDbDataReader dr = bd.EjecutarConsultaReader();
            if(dr.Read()){
                producto.Nombre = NProducto;
                producto.Id = Convert.ToInt32(dr["Id"]);
                producto.Valor = Convert.ToInt32(dr["Valor"]);
                producto.Consulto = true;
            }
            bd.Desconectar();
            dr.Close();
            return producto;
            
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
