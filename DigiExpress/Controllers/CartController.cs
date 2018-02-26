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
        public static List<CartItem> GetCartItems(string username)
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
                        
                        cartItem.UserName = reader.GetString(0);
                        cartItem.TypeName = reader.GetString(1);
                        cartItem.ComputerId = reader.GetInt32(2);
                        cartItem.Price = reader.GetInt32(3);

                        cartItems.Add(cartItem);
                    }
                }
                reader.Close();
            }
            return cartItems;
        }

        public static CartItem GetCartItemByIdAndType(int computerId, string computerType)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var cartItem = new CartItem();
            
            var query = $"SELECT * FROM dbo.de_onCart where computerId = '{computerId}' and typename ='{computerType}'";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cartItem.UserName = reader.GetString(0);
                        cartItem.TypeName = reader.GetString(1);
                        cartItem.ComputerId = reader.GetInt32(2);
                        cartItem.Price = reader.GetInt32(3);
                    }
                }

                reader.Close();
            }
            
            return cartItem;
        }

        public static void AddToCart(CartItem cartItem)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var query = "INSERT INTO dbo.de_onCart(username, typename, computerId, price) " +
                        "VALUES(@param1, @param2, @param3, @param4)";

            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 40).Value = cartItem.UserName;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 10).Value = cartItem.TypeName;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = cartItem.ComputerId;
                cmd.Parameters.Add("@param4", SqlDbType.Int).Value = cartItem.Price;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static void RemoveFromCart(string computerId, string computerType)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var computerIdString = computerId;
            using (connection)
            {
                var query =
                    $"DELETE FROM dbo.de_onCart WHERE typename = '{computerType}' and computerId = '{computerIdString}' ";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static int GetTotalCartPrice(string username)
        {
            int price = 0;
            var cartItems = GetCartItems(username);

            foreach (var cartItem in cartItems)
                price += cartItem.Price;

            return price;
        }
    }
}