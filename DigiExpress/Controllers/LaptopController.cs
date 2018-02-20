using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class LaptopController
    {
        public static int GetLaptopCount()
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var counter = 0;

            const string query = "SELECT * FROM dbo.de_laptops";

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

        public static void AddLaptop(Laptop laptop)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            string query = "INSERT INTO dbo.de_laptops(typename, laptopid, userId, username, screen, processor, ram, ssd, os) " +
                         "VALUES(@param1,@param2,@param3, @param4, @param5, @param6, @param7, @param8, @param9)";
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 10).Value = laptop.ComputerType;
                cmd.Parameters.Add("@param2", SqlDbType.Int).Value = laptop.Id;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = laptop.UserId;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 40).Value = laptop.UserName;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 20).Value = laptop.Screen;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 20).Value = laptop.Processor;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 20).Value = laptop.Ram;
                cmd.Parameters.Add("@param8", SqlDbType.VarChar, 20).Value = laptop.Ssd;
                cmd.Parameters.Add("@param9", SqlDbType.VarChar, 20).Value = laptop.Os;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}