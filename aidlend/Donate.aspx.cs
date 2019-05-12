using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Donate : System.Web.UI.Page
{
    string cns = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected string bnq;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("select bankNum from causes where id=@id",cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = Request.QueryString[0] });
                cnx.Open();
                bnq = cmd.ExecuteScalar().ToString();
                cnx.Close();
            }
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            
            using (SqlCommand cmd = new SqlCommand("spAddDonation",cnx))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@donor", Value = User.Identity.GetUserId() });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@cause", Value = Request.QueryString[0] });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@message", Value = msg.Text });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@amount", Value = double.Parse(mtn.Text) });
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        Response.Redirect("Thanku.aspx");
    }
}