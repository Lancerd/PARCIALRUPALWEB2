using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
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
            bd = new BaseDeDato;
            bd.Conectar;
        }


        public List<Producto> ListarProduto(){
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

        public int Eliminar(int Id){
            int numReg = 0;
            string vSql = "DELETE FROM Producto WHERE  [Id] = ?";
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

        public int Insertar(VentaProducto ventaProducto){
            int numReg = 0;
            var vSql = "INSERT INTO Producto ([Id]) VALUES (?)";
            bd.CrearComando(vSql. CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, Producto.Id);
            bd.AsignarParametro("?", OleDbType.VarChar, Producto.Nombre);
            bd.AsignarParametro("?", OleDbType.Integer, Producto.Valor);
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
