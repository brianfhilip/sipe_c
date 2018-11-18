using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace sipe
{
    class conexion
    {
        public static MySqlConnection crearConexion()
        {
            MySqlConnection miConexion =new  MySqlConnection("server=127.0.0.1;database=sipe;user=root;pwd=;");
            miConexion.Open();
            return miConexion;
        }
    }
}
