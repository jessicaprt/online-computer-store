using System.Data;
using System.Data.SqlClient;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class ComputerController
    {
        public static int GetComputerCount()
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var counter = 0;

            const string query = "SELECT * FROM dbo.de_savedComputers";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                        counter++;
                }
            }

            connection.Close();
            return counter;
        }

        public static void AddComputer(Computer computer)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            string query = "INSERT INTO dbo.de_savedComputers(typename, computerId, userId, username, part1, part2, part3, part4, part5) " +
                         "VALUES(@param1,@param2,@param3, @param4, @param5, @param6, @param7, @param8, @param9)";
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 10).Value = computer.ComputerType;
                cmd.Parameters.Add("@param2", SqlDbType.Int).Value = computer.Id;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = computer.UserId;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 40).Value = computer.UserName;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 20).Value = computer.Part1;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 20).Value = computer.Part2;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 20).Value = computer.Part3;
                cmd.Parameters.Add("@param8", SqlDbType.VarChar, 20).Value = computer.Part4;
                cmd.Parameters.Add("@param9", SqlDbType.VarChar, 20).Value = computer.Part5;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static Computer GetComputerById(int computerId, string typeName)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var computer = new Computer();

            string query = $"SELECT * FROM dbo.de_savedComputers WHERE computerId = '{computerId}' and typename = '{typeName}'";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        computer.ComputerType = reader.GetString(0);
                        computer.Id = reader.GetInt32(1);
                        computer.UserId = reader.GetInt32(2);
                        computer.UserName = reader.GetString(3);
                        computer.Part1 = reader.GetString(4);
                        computer.Part2 = reader.GetString(5);
                        computer.Part3 = reader.GetString(6);
                        computer.Part4 = reader.GetString(7);
                        computer.Part5 = reader.GetString(8);
                    }
                }
            }

            return computer;
        }
    }
}