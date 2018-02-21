using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class DesktopController
    {
        public static int GetDesktopCount()
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var counter = 0;

            const string query = "SELECT * FROM dbo.de_desktops";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        counter++;
                    }
                }
            }

            connection.Close();
            return counter;
        }

        public static void AddDesktop(Desktop desktop)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            string query = "INSERT INTO dbo.de_desktops(typename, desktopId, userId, username, processor, ram, ssd, os, videocard) " +
                         "VALUES(@param1,@param2,@param3, @param4, @param5, @param6, @param7, @param8, @param9)";
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 10).Value = desktop.ComputerType;
                cmd.Parameters.Add("@param2", SqlDbType.Int).Value = desktop.Id;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = desktop.UserId;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 40).Value = desktop.UserName;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 20).Value = desktop.Part1;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 20).Value = desktop.Part2;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 20).Value = desktop.Part3;
                cmd.Parameters.Add("@param8", SqlDbType.VarChar, 20).Value = desktop.Part4;
                cmd.Parameters.Add("@param9", SqlDbType.VarChar, 20).Value = desktop.Part5;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static Desktop GetDesktopById(int computerId)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var desktop = new Desktop();

            string query = $"SELECT * FROM dbo.de_desktops WHERE desktopId = '{computerId}'";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        desktop.ComputerType = reader.GetString(0);
                        desktop.Id = reader.GetInt32(1);
                        desktop.UserId = reader.GetInt32(2);
                        desktop.UserName = reader.GetString(3);
                        desktop.Part1 = reader.GetString(4);
                        desktop.Part2 = reader.GetString(5);
                        desktop.Part3 = reader.GetString(6);
                        desktop.Part4 = reader.GetString(7);
                        desktop.Part5 = reader.GetString(8);
                    }
                }
            }

            return desktop;
        }
    }
}