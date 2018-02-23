using System;
using System.Web;
using System.Web.UI;
using DigiExpress.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DigiExpress.Models;

namespace DigiExpress.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            var currentUsername = Username.Text;
            var password = UserController.RetrievePassword(currentUsername);
            DisplayPassword1.Text = "Your password is: ";

            DisplayPasswordText.Text = $"{password}";
        }
    }
}