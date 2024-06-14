using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace AccesoDato
{
    public class BaseDeDato
    {
        string cadConex;
        OleDbConnection cn;
        OleDbCommand cmd;

        public int BdCodeError { get; set; }
        public string BdMsgError { get; set;}


        public BaseDeDato (){
            BdCodeError = 0;
            BdMsgError = "";
            cadConex = ConfigurationManager.ConnectionStrings["cadConexAccess"].ConnectionString;
        }

        public void Conectar (){
            try{
                cn = new OleDbConnection(cadConex);
                cn.Open();
            }catch (OleDbException ex){
                BdCodeError = ex.ErrorCode;
                BdMsgError = ex.Message;
                Desconectar();
            }
        }

        public void Desconectar (){
            if(cn != null){
                cn.Close();
                cn.Dispose();
                cn = null;
            }
        }

        public void CrearComando (string pComando, CommandType pTipo){
            cmd = new OleDbCommand(pComando, cn);
            cmd.CommandType = pTipo;
        }

        public void AsignarParametro (string pNombre, OleDbType pTipo, object pValor){
            cmd.Parameters.Add(pNombre, pTipo).Value = pValor;
        }

        public int EjecutarComando (){
            int numReg = 0;
            try{
                numReg = cmd.ExecuteNonQuery();
            }catch(OleDbException ex){
                BdCodeError = ex.ErrorCode;
                BdMsgError = ex.Message;
                Desconectar();
            }
            return numReg;
        }

        public DataTable EjecutarConsulta (){
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new   OleDbDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public OleDbDataReader EjecutarConsultaReader()=> cmd.ExecuteReader();

    }
}
