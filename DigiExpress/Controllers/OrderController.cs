using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class OrderController
    {
        public static List<OrderItem> GetOrderItems(string username)
        {
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var orderItems = new List<OrderItem>();

            var query = $"SELECT * FROM dbo.de_orders where username = '{username}'";

            var command = new SqlCommand(query, connection);


            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var orderItem = new OrderItem();

                        orderItem.UserName = reader.GetString(0);
                        orderItem.TypeName = reader.GetString(1);
                        orderItem.ComputerId = reader.GetInt32(2);
                        orderItem.Price = reader.GetInt32(3);

                        orderItems.Add(orderItem);
                    }
                }
            }

            connection.Close();
            return orderItems;
        }

        public static void AddToOrdersHistory(int computerId, string computerType)
        {

            IOrder orderItem = CartController.GetCartItemByIdAndType(computerId, computerType);

            
            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            var query = "INSERT INTO dbo.de_orders(username, typename, computerId, price) " +
                        "VALUES(@param1, @param2, @param3, @param4)";

            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 40).Value = orderItem.UserName;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 10).Value = orderItem.TypeName;
                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = orderItem.ComputerId;
                cmd.Parameters.Add("@param4", SqlDbType.Int).Value = orderItem.Price;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static List<RenderItem> RenderOrders(string username)
        {
            var cartItems = new List<RenderItem>();

            var unrenderedCartItems = GetOrderItems(username);

            foreach (var cartItem in unrenderedCartItems)
            {
                var computer = ComputerController.GetComputerById(cartItem.ComputerId, cartItem.TypeName);
                var newRenderedCartItem = new RenderItem();

                newRenderedCartItem.ImageUrl = GetImageUrl(cartItem.TypeName);
                newRenderedCartItem.ComputerIdType = $"{cartItem.ComputerId}, {cartItem.TypeName}";
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