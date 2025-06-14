using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cobranza
{
    internal class ConexionMysql : Conexion
    {
        private MySqlConnection connection;
        private string cadenaConexion;
        public ConexionMysql()
        {
            cadenaConexion = "Database=" + database +
                "; DataSource=" + server +
            "; User Id=" + user +
                "; Password=" + password;

            connection = new MySqlConnection(cadenaConexion);

        }

        public MySqlConnection GetConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
               

            }
            return connection;
        }
    }
}