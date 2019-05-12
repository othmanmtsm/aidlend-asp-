using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserProfile : System.Web.UI.Page
{
    protected string username;
    protected string bio;
    protected string education;
    protected string job;
    protected string donations;
    protected string events;
    string cnstr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            username = string.Format(HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserName());
           
            
            using (SqlConnection cnx = new SqlConnection(cnstr))
            {
                using(SqlCommand cmd = new SqlCommand("spGetImageById", cnx))
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
                    profilePic.ImageUrl = "data:Image/png;base64," + strBase64;
                    cnx.Close();
                }
                using (SqlCommand cmd = new SqlCommand("select count(*) from donations where donor = @id",cnx))
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId()
                    });
                    cnx.Open();
                    donations = cmd.ExecuteScalar().ToString();
                    cnx.Close();
                }
                using (SqlCommand cmd = new SqlCommand("select count(*) from evntParticipants where idUser = @id", cnx))
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId()
                    });
                    cnx.Open();
                    events = cmd.ExecuteScalar().ToString();
                    cnx.Close();
                }
            }

            setProf();

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
       
    }

    public void setProf()
    {
        using (SqlConnection cnx = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from profiles where userId=@userId", cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId() });
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bioinp.Visible = false;
                    biopar.Visible = true;
                    eduinp.Visible = false;
                    edupar.Visible = true;
                    jobinp.Visible = false;
                    setProfileBtn.Visible = false;
                    while (dr.Read())
                    {
                        bio = dr[2].ToString().Replace("\r\n", "<br />");
                        education = dr[3].ToString();
                        job = dr[4].ToString();
                    }
                }
                else
                {
                    bioinp.Visible = true;
                    biopar.Visible = false;
                    eduinp.Visible = true;
                    edupar.Visible = false;
                    jobinp.Visible = true;
                    setProfileBtn.Visible = true;
                }
            }
        }
    }

    protected void setProfileBtn_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spSetProfile",cnx))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId() });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@bio", Value = bioinp.Text });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@edu", Value = eduinp.Text });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@job", Value = jobinp.Text });
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        setProf();
    }
}