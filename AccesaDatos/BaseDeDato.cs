using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace AccesaDatos
{
    public class BaseDeDato
    {
        string cadConex;
        OleDbConnection cn;
        OleDbCommand cmd;

        public int BdCodeError {get; set;}
        public int BdMsgError {get; set;}
    }
}
