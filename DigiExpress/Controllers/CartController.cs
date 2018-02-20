using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class CartController
    {
        public static List<CartItem> GetCartItems(String username)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var cartItems = new List<CartItem>();

            var query = $"SELECT * FROM dbo.de_onCart where username = '{username}'";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var cartItem = new CartItem();

                        cartItem.OrderId = reader.GetInt32(0);
                        cartItem.UserName = reader.GetString(1);
                        cartItem.TypeName = reader.GetString(2);
                        cartItem.ComputerId = reader.GetInt32(3);

                        cartItems.Add(cartItem);
                    }
                }
            }

            connection.Close();
            return cartItems;
        }

        public static void AddToCart(CartItem cartItem)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var query = "INSERT INTO dbo.de_onCart(orderId, username, typename, computerId) " +
                        "VALUES(@param1, @param2, @param3, @param4)";

            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@param1", SqlDbType.Int).Value = cartItem.OrderId;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 40).Value = cartItem.UserName;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 10).Value = cartItem.TypeName;
                cmd.Parameters.Add("@param4", SqlDbType.Int).Value = cartItem.ComputerId;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static void RemoveToCart(string orderId)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            using (connection)
            {
                var query = $"DELETE FROM  dbo.de_onCart WHERE orderId = '{orderId}'";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}