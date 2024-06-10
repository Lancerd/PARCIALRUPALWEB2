using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDato
{
    internal class Data
    {
        BaseDeDato bd;

        public void Preparar (string pComando, CommandType pTipo){
            bd = new BaseDeDato ();
            bd.Conectar();
            bd.CrearComando(pComando, pTipo);
        }

        public void AsignarParametro (string pComando, OleDbType pTipo, object pValor){
            bd.AsignarParametro (pComando, pTipo, pValor);
        }

        public DataTable CargarDt (){
            DataTable dt = bd.EjecutarConsulta();
            bd.Desconectar();
            return dt;
        }

        public DataTable CargarDt (string pComando, CommandType pTipo){
            Preparar(pComando, pTipo);
            return CargarDt();
        }

    }
}
