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

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = Context.User.Identity.Name;

        }

        protected void ConfirmOrder(object sender, CommandEventArgs e)
        {
            var args = e.CommandArgument.ToString().Split(',');

            var computerId = args[0].Trim();
            var computerType = args[1].Trim();

            OrderController.AddToOrdersHistory(int.Parse(computerId), computerType);
            CartController.RemoveFromCart(computerId, computerType);

            Response.Redirect("~/Default.aspx", true);

        }

        protected void RemoveFromCart(object sender, CommandEventArgs e)
        {
            var args = e.CommandArgument.ToString().Split(',');

            var computerId = args[0].Trim();
            var computerType = args[1].Trim();
             
            CartController.RemoveFromCart(computerId, computerType);
            Response.Redirect("~/Cart.aspx", true);
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}