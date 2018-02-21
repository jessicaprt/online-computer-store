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
            }

            connection.Close();
            return cartItems;
        }

        public static void AddToCart(CartItem cartItem)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var query = "INSERT INTO dbo.de_onCart(username, typename, computerId) " +
                        "VALUES(@param1, @param2, @param3, @param4)";

            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 40).Value = cartItem.UserName;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 10).Value = cartItem.TypeName;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = cartItem.ComputerId;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = cartItem.Price;
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

        public static List<RenderedCartItem> RenderCart(string username)
        {
            var cartItems = new List<RenderedCartItem>();

            var unrenderedCartItems = GetCartItems(username);

            foreach (var cartItem in unrenderedCartItems)
            {
                var computer = LaptopController.GetLaptopById(cartItem.ComputerId);
                var newRenderedCartItem = new RenderedCartItem();

                newRenderedCartItem.ImageUrl = GetImageUrl(cartItem.TypeName);
                newRenderedCartItem.ComputerName = GetComputerName(cartItem.TypeName);
                newRenderedCartItem.Part1 = computer.Part1;
                newRenderedCartItem.Part2 = computer.Part2;
                newRenderedCartItem.Part3 = computer.Part3;
                newRenderedCartItem.Part4 = computer.Part4;
                newRenderedCartItem.Part5 = computer.Part5;
                newRenderedCartItem.Price = cartItem.Price;

                cartItems.Add(newRenderedCartItem);
            }

            return cartItems;
        }

        public static string GetImageUrl(string computerType)
        {
            if (computerType == "laptop")
                return "images/winbook.png";
            return "images/winbook_desktop.png";
        }

        public static string GetComputerName(string computerType)
        {
            if (computerType == "laptop")
                return "WinBook laptop";
            return "WinBox computer";
        }

    }
}