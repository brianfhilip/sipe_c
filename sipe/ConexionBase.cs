using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace sipe
{
    class ConexionBase
    {
       public static MySqlConnection Conexion() {

            MySqlConnection miConexion = new MySqlConnection("server=127.0.0.1;Database=sipe;uid=root;pwd=");
            miConexion.Open();

            return miConexion;


        }


    }
}
