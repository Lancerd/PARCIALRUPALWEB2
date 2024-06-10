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
        

        public List<Usuario> ListarUsuarios(){
            List<Usuario> usuarios = new List<Usuario>();
            Data data = new Data();
            string vSql = "SELECT [Id], [Nombre], [Apellido] FROM Usuario"; 
            DataTable dt = data.Preparar(vSql, CommandType.Text);
            foreach (DataRow dr in dt.Rows){
                Usuario usuario = new Usuario{
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = Convert.ToString(dr["Nombre"])
                };
                usuarios.Add(usuario);
            }
            return usuarios;
        }
    }
}
