using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress
{
    public class DatabaseUtils
    {
        public static void CreateCommand(string queryString, SqlConnection connection)
        {
            var command = new SqlCommand(queryString, connection);
            command.Connection.Open();
        }

        public static SqlConnection CreateConnection()
        {
            const string connectionString = "Server=jp-comp466.database.windows.net;Database=comp466;User Id=MyAdmin;Password=1Password";
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        public static SqlDataReader GetSqlDataReader(SqlConnection connection, string query)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(query,connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
        }
    }
}