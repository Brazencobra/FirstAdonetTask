using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet.Helper
{
    static class Sql
    {
        static string ConnectionString = "Server=BRAZENCOBRA\\SQLEXPRESS;Database=Spotify;Trusted_connection=true;Integrated Security=true;encrypt=false";
        static SqlConnection _connection;
        public static SqlConnection Connection 
        {
            get 
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(ConnectionString);
                }
                return _connection;
            }
        }

        public static void ExecCommand(string command) 
        {
            Connection.Open();
            using (SqlCommand sqlcommand = new SqlCommand(command,Connection))
            {
                sqlcommand.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public static DataTable ExecQuery(string query)
        {
            DataTable dt = new DataTable();
            Connection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query,Connection))
            {
                adapter.Fill(dt);
            }
            Connection.Close();
            return dt;
        }
    }
}
