using System;
using System.Web.UI.WebControls;
using DigiExpress.Controllers;

namespace DigiExpress
{
    public partial class Cart : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = Context.User.Identity.Name;

            var total = CartController.GetTotalCartPrice(Context.User.Identity.Name);

            if (total > 0)
            {
                TotalPriceLabel.Visible = false;
                TotalPrice.Text = total.ToString();
            }
            else
            {
                TotalPriceLabel.Visible = false;
            }
            

        }

        protected void ConfirmOrder(object sender, CommandEventArgs e)
        {
            var args = e.CommandArgument.ToString().Split(',');

            var computerId = args[0].Trim();
            var computerType = args[1].Trim();

            OrderController.AddToOrdersHistory(int.Parse(computerId), computerType);
            CartController.RemoveFromCart(computerId, computerType);

            Response.Redirect("~/OrderMessage.aspx", true);

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