using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class UserController
    {
        public static User GetUser(SqlConnection connection, string query)
        {

            var user = new User();
            var command = new SqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows) return user;
                while (reader.Read())
                {
                    user.Id = reader.GetInt32(0);
                    user.UserName = reader.GetString(1);
                    user.Password = reader.GetString(2);
                }
            }
            return user;
        }

        public static string GetUserName(SqlConnection connection, string username, string password)
        {
            var user = "";

            var query = $"SELECT username FROM dbo.de_user WHERE username = '{username}' and password = '{password}'";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows) return user;
                while (reader.Read())
                    user = reader.GetString(0);
            }
            return user;
        }

        public static int GetUserIdByName(string username)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var userId = -1;

            var query = $"SELECT userId FROM dbo.de_user WHERE username = '{username}'";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows) return userId;
                while (reader.Read())
                    userId = reader.GetInt32(0);
            }

            return userId;
        }

        public static void AddNewUser(string name, string password)
        {

        }

        public static int GetTotalusers()
        {
            var totalNumber = 0;
            
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            using (connection)
            {
                const string query = "SELECT * FROM dbo.de_user;";
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return totalNumber;
                    while (reader.Read())
                        totalNumber++;
                }
            }
            
            return totalNumber;
        }

        public static string RetrievePassword(string username)
        {
            var password = "";

            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            using (connection)
            {
                var query = $"SELECT password FROM dbo.de_user WHERE username='{username}';";
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return password;
                    while (reader.Read())
                        password = reader.GetString(0);
                }
            }

            return password;
        }
    }
}