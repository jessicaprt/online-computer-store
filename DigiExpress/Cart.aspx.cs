using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiExpress
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["computer"] != null)
            {
                if (Session["computer"].ToString() == "laptop")
                    Image.Text = "<img src='images/winbook.png' class='shop-disp-image'>";
                else if (Session["computer"].ToString() == "desktop")
                    Image.Text = "<img src='images/winbook_desktop.png' class='shop-disp-image'>";

                Part1.Text = Session["part1"].ToString();
                Part2.Text = Session["part2"].ToString();
                Part3.Text = Session["part3"].ToString();
                Part4.Text = Session["part4"].ToString();
                Part5.Text = Session["part5"].ToString();
            }
        }
    }
}