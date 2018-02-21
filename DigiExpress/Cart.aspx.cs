using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiExpress.Controllers;
using DigiExpress.Models;

namespace DigiExpress
{
    public partial class Cart : System.Web.UI.Page
    {
        private string _username;
        private List<CartItem> _cartItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            _username = Context.User.Identity.Name;
            _cartItems = CartController.GetCartItems(_username);

            Session["username"] = Context.User.Identity.Name;

        }
    }
}