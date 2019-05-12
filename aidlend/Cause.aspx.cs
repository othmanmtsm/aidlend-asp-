using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Claims;

public partial class Cause : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    
    protected string title;
    protected string location;
    protected string description;
    protected string img;
    protected string body;
    protected string organizer;
    protected string category;
    protected string date;
    protected double raised;
    protected double goal;
    protected int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }

        var userIdentity = (ClaimsIdentity)HttpContext.Current.User.Identity;
        var claims = userIdentity.Claims;
        var roleClaimType = userIdentity.RoleClaimType;
        var roles = claims.Where(c => c.Type == roleClaimType).ToList();

        if (roles.Count != 0)
        {
            if (roles[0].Value == "admin")
            {
                acpt.Visible = true;
                sprm.Visible = true;
            }
        }
        else
        {
            acpt.Visible = false;
            sprm.Visible = false;
        }

        id = int.Parse(Request.QueryString[0]);
        using (SqlConnection cnx = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("select id,title,date,location,description,img,body,organizer,category,goal,raised from causes where id = id", cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    title = dr[1].ToString();
                    date = dr[2].ToString();
                    location = dr[3].ToString();
                    description = dr[4].ToString();
                    img = "data:Image/png;base64," + Convert.ToBase64String((byte[])dr[5]);
                    body = dr[6].ToString().Replace("\r\n", "<br />"); ;
                    organizer = dr[7].ToString();
                    category = dr[8].ToString();
                    goal = double.Parse(dr[9].ToString());
                    raised = double.Parse(dr[10].ToString());
                }
                dr.Close();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select a.UserName,b.amount,b.date,b.message,c.ImageData from [dbo].[AspNetUsers] a join [dbo].[donations] b on a.Id=b.donor join [dbo].[usersImgs] c on a.Id=c.userid where b.cause = @cid",cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@cid", Value = Request.QueryString[0] });
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    HtmlGenericControl donor = new HtmlGenericControl();
                    donor.Attributes["class"] = "donation-item";
                    donor.TagName = "div";
                    donor.InnerHtml = @"<div class='donar-thumb'>
								            <img class='img-fluid' style='height:100px;width:100px;' src='"+ "data:Image/png;base64," + Convert.ToBase64String((byte[])dr[4]) +@"'>
							            </div>
							            <div class='donation-content'>
								            <p class='date'>"+dr[2].ToString()+@"</p>
								            <h6 class='donation-comment-title'>"+dr[0].ToString()+@"</h6>
								            <p class='donation-comment-text'>"+dr[3].ToString()+@"</p>
							            </div>
							            <div class='donation-ammount'>"+dr[1].ToString()+@" DH</div>";
                    donss.Controls.Add(donor);
                }
            }

        }

    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
       
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("delete from causes where id=@id", cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = Request.QueryString[0] });
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        Response.Redirect("~/Settings.aspx");
    }

    protected void acpt_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("update causes set valid=1 where id=@id", cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = Request.QueryString[0] });
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        Response.Redirect("~/Settings.aspx");
    }
}