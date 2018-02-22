using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiExpress
{
    public partial class OrderMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RedirectToOrdersHistory(object sender, EventArgs e)
        {
            Response.Redirect("~/OrdersHistory.aspx", true);
        }
    }
}