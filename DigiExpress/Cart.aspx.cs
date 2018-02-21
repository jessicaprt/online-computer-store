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
            Session["username"] = Context.User.Identity.Name;

        }

        protected void ConfirmOrder(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void RemoveFromCart(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}