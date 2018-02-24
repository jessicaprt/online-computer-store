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
            DisplayPassword1.Text = "";
            DisplayPasswordText.Text = "";
        }

        protected void Forgot(object sender, EventArgs e)
        {
            var currentUsername = Username.Text;
            var password = UserController.RetrievePassword(currentUsername);
            if (string.IsNullOrEmpty(password))
            {
                DisplayPassword1.Text = "<p class='text-danger'>username not found</p>";
            }
            else
            {
                DisplayPassword1.Text = "Your password is: ";
                DisplayPasswordText.Text = $"{password}";
            }
        }
    }
}