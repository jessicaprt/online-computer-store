using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using DigiExpress.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DigiExpress.Models;

namespace DigiExpress.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage1.Text = "";
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var newUser = Username.Text;
            var password = Password.Text;
            var confPassword = ConfirmPassword.Text;
            var usernames = UserController.GetAllUsernames();

            if (usernames.Contains(newUser))
                ErrorMessage1.Text = "<ul><li>Username already exists</li></ul>";
            else
            {
                if (password == confPassword)
                {
                    UserController.AddNewUser(newUser, password);

                    Session["username"] = newUser;
                    FormsAuthentication.SetAuthCookie(newUser, true);

                    Response.Redirect("../Default.aspx", true);
                }
            }
        }
    }
}