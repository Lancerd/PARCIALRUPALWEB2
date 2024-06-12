using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;
using System.Data;

namespace AccesoDato
{
    public class VentaProductoDao
    {
        
        BaseDeDato bd;

        public int BdCodeError {get; set;}

        public string BdMsgError {get; set;}

        public VentaProducto(){
            BdCodeError = 0;
            BdMsgError = "";
            bd = new BaseDeDato;
            bd.Conectar;
        }

        public List<VentaProducto> ListarVentaProducto(int IdFactura)
        {
            List<VentaProducto> ventaProductos = new List<VentaProducto>();
            Data data = new Data();
            string vSql = @"SELECT 
                                p.IdProducto,
                                p.Valor
                            FROM 
                                Producto p
                            INNER JOIN 
                                FacturaProducto fp ON p.Id = fp.IdProducto
                            WHERE 
                                fp.IdFactura = ?";
            DataTable dt = data.CargarDt(vSql, CommandType.Text, new SqlParameter("@IdFactura", IdFactura));
            foreach (DataRow dr in dt.Rows)
            {
                VentaProducto ventaProducto = new VentaProducto
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                    ValorProducto = Convert.ToInt32(dr["Valor"]) 
                };
                ventaProductos.Add(ventaProducto);
            }
            return ventaProductos;
        }

        public int InsertarVP(VentaProducto ventaProducto){
            int numReg = 0;
            var vSql = "INSERT INTO Factura-Producto ([IdFactura], [IdProducto]) VALUES (?,?)";
            bd.CrearComando(vSql. CommandType.Text);
            bd.AsignarParametro("?", OleDbType.Integer, ventaProducto.IdFactura);
            bd.AsignarParametro("?", OleDbType.Integer, ventaProducto.IdProducto);
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

        public int EliminarV(int IdFactura){
            int numReg = 0;
            string vSql = "DELETE FROM Factura-Producto WHERE  [IdFactura] = ?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?",OleDbType.Integer, IdFactura);
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

        public int EliminarPV(int IdProducto){
            int numReg = 0;
            string vSql = "Delet FROM Factura-Producto WHERE  [IdProducto] = ?";
            bd.CrearComando(vSql, CommandType.Text);
            bd.AsignarParametro("?",OleDbType.Integer, IdProducto);
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
