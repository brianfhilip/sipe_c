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
            /*string connectionString = "Data Source=MSSQL1;" +
                 "Initial Catalog=AdventureWorks;Integrated Security=SSPI;" +
                "MultipleActiveResultSets=True";*/
            MySqlConnection miConexion =new  MySqlConnection("server=127.0.0.1;database=sipe;user=root;pwd=;");//no srve ? pille este codigo en el procedure
           miConexion.Open();
            return miConexion;
        }
    }   //esta como rapida jajaj espere
}
