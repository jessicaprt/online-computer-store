using System;
using System.Activities.Statements;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Windows.Forms;
using DigiExpress.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DigiExpress.Models;

namespace DigiExpress.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            InvalidLogin.Text = "";
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var connection = DatabaseUtils.CreateConnection();

                connection.Open();

                var currentUsername = Username.Text;
                var currentPassword = Password.Text;

                var getUser = UserController.GetUserName(connection, currentUsername, currentPassword);
                

                if ( (getUser == "") || (getUser == null) )
                {
                    InvalidLogin.Text = "Invalid username and password combination";
                }
                else
                {
                    Session["username"] = getUser;
                    FormsAuthentication.SetAuthCookie(Username.Text, true);

                    Response.Redirect("../Default.aspx", true);
                }
            }
        }
    }
}