using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class LoginController
    {
        public static User GetUser(SqlConnection connection, string query)
        {

            var user = new User();

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.UserName = reader.GetString(1);
                        user.Password = reader.GetString(2);
                    }
                }
            }
            return user;
        }

        public static string GetUserName(SqlConnection connection, string query)
        {
            var user = "";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                        user = reader.GetString(0);
                }
            }
            return user;

        }
    }
}