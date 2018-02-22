using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class RenderItemController
    {
        public static List<RenderItem> RenderCartItems(string username)
        {
            var cartItems = new List<RenderItem>();

            var unrenderedCartItems = CartController.GetCartItems(username);

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

        public static List<RenderItem> RenderOrderItems(string username)
        {
            var cartItems = new List<RenderItem>();

            var unrenderedCartItems = OrderController.GetOrderItems(username);

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