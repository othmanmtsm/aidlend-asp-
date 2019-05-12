using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class headerfooter : System.Web.UI.MasterPage
{
    protected string img;
    string cnstr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                using (SqlConnection cnx = new SqlConnection(cnstr))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetImageById", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter userid = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId()
                        };
                        cmd.Parameters.Add(userid);
                        cnx.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        string strBase64 = Convert.ToBase64String(bytes);
                        img = "data:Image/png;base64," + strBase64;
                    }
                }





                //var userIdentity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                //var claims = userIdentity.Claims;
                //var roleClaimType = userIdentity.RoleClaimType;
                //var roles = claims.Where(c => c.Type == roleClaimType).ToList();

                //if (roles.Count != 0)
                //{
                //    if (roles[0].Value == "admin")
                //    {
                //        dshbrdLnk.Visible = true;
                //    }
                //}
                //else
                //{
                //    dshbrdLnk.Visible = false;
                //}
            }
        }
    }


    //protected void logoutLnk_Click(object sender, EventArgs e)
    //{
    //    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
    //    authenticationManager.SignOut();
    //    Response.Redirect("~/Login.aspx");
    //}
}
