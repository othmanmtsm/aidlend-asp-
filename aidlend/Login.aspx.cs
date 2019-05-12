using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Login : System.Web.UI.Page
{
    //SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["dbAidlend"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                Msg.Text = String.Format("Hello {0} you are already logged in ", User.Identity.GetUserName());
                LoginStatus.Visible = true;
                logout.Visible = true;
            }
            else
            {
                loginForm.Visible = true;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var userStore = new UserStore<IdentityUser>();
        var userManager = new UserManager<IdentityUser>(userStore);

        var user = userManager.Find(txtName.Text, txtPassword.Text);

        if (user != null)
        {
            if (user.EmailConfirmed)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect("~/Main.aspx");
            }
            else
            {
                Msg.Text = "veuillez confirmer votre email";
                LoginStatus.Visible = true;
            }
        }
        else
        {
            Msg.Text = "Invalid username or password";
            LoginStatus.Visible = true;
        }
    }

    protected void logoutBtn_Click(object sender, EventArgs e)
    {
        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();
        Response.Redirect("~/Login.aspx");
    }
}