using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web.UI.HtmlControls;

public partial class Event : System.Web.UI.Page
{
    string cns = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected string title;
    protected string date;
    protected string city;
    protected string location;
    protected string category;
    protected string description;
    protected string img;
    protected string body;
    protected string organizer;
    static protected int participants;
    protected List<string> images=new List<string>();
    protected List<string> videos= new List<string>();
    int valid;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!IsPostBack)
        {
            loadCom();
        }
        
        int eventId = int.Parse(Request.QueryString[0]);
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("select * from evnts where id=@id", cnx))
            {
                SqlParameter id = new SqlParameter { ParameterName = "@id", Value = eventId };
                cmd.Parameters.Add(id);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    title = rd[1].ToString();
                    date = rd[2].ToString();
                    city = rd[2].ToString();
                    location = rd[4].ToString();
                    category = rd[5].ToString();
                    description = rd[6].ToString();
                    img = "data:Image/png;base64," + Convert.ToBase64String((byte[])rd[7]);
                    body = rd[8].ToString().Replace("\r\n", "<br />");
                    organizer = rd[9].ToString();
                    participants = int.Parse(rd[10].ToString());
                    valid =int.Parse(rd[11].ToString());
                }
                rd.Close();
            }

            //using (SqlCommand cmd1 = new SqlCommand("select b.img,b.videoUrl from evnts a join evntsMedia b on a.id=b.eventId where a.id=@id", cnx))
            //{
            //    SqlParameter id = new SqlParameter { ParameterName = "@id", Value = eventId };
            //    cmd1.Parameters.Add(id);
            //    SqlDataReader rd1 = cmd1.ExecuteReader();
            //    while (rd1.Read())
            //    {
            //        images.Add("data:Image/png;base64," + Convert.ToBase64String((byte[])rd1[0]));
            //        videos.Add(rd1[1].ToString());
            //    }
            //    rd1.Close();
            //    cnx.Close();
            //}
        }

       

        var userIdentity = (ClaimsIdentity)User.Identity;
        var claims = userIdentity.Claims;
        var roleClaimType = userIdentity.RoleClaimType;
        var roles = claims.Where(c => c.Type == roleClaimType).ToList();

        if (roles.Count!=0)
        {
            if (roles[0].Value == "admin")
            {
                nrml.Visible = false;
            }
        }
        else
        {
            admin.Visible = false;
        }
    }

    protected void acptBtn_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("update evnts set valid=1 where id=@id",cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = int.Parse(Request.QueryString[0]) });
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        Response.Redirect("~/Settings.aspx");
    }

    protected void dltBtn_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("delete from evnts where id=@id",cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = int.Parse(Request.QueryString[0]) });
                cnx.Open();
                cmd.ExecuteNonQuery(); // ON UPDATE ON DELETE CASCADE NEEDED ASAP
            }
        }
        Response.Redirect("~/Settings.aspx");
    }

    protected void Participate_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("spParticipate",cnx))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter userID = new SqlParameter { ParameterName = "@idUser", Value = User.Identity.GetUserId() };
                cmd.Parameters.Add(userID);
                SqlParameter evntID = new SqlParameter { ParameterName = "@idEvent", Value = Request.QueryString[0] };
                cmd.Parameters.Add(evntID);
                cnx.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("~/Participated.aspx?event="+ title);
            }
        }
    }

    public void loadCom()
    {
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            using (SqlCommand cmd2 = new SqlCommand("SELECT a.date,a.comment,b.UserName,c.ImageData FROM eventComments a join AspNetUsers b on a.idUser=b.Id join usersImgs c on b.Id = c.userid where a.idEvent=@event", cnx))
            {
                cmd2.Parameters.Add(new SqlParameter { ParameterName = "@event", Value = Request.QueryString[0] });
                cnx.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    HtmlGenericControl cmnt = new HtmlGenericControl();
                    cmnt.Attributes["class"] = "donation-item";
                    cmnt.TagName = "div";
                    cmnt.InnerHtml = @"<div style='width:150px;' class='donar-thumb'>
								            <img class='img-fluid' style='width:100px;height:100px' src='" + "data:Image/png;base64," + Convert.ToBase64String((byte[])dr[3]) + @"'>
							            </div>
							            <div class='donation-content'>
								            <p class='date'>" + dr[0].ToString() + @"</p>
								            <h6 class='donation-comment-title'>" + dr[2].ToString() + @"</h6>
								            <p class='donation-comment-text'>" + dr[1].ToString() + @"</p>
							            </div>";
                    comments.Controls.Add(cmnt);
                }
            }
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("spAddComment",cnx))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@event", Value = Request.QueryString[0] });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@user", Value = User.Identity.GetUserId() });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@comment", Value = addCom.Text.Replace("\r\n", "<br />")});
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        addCom.Text = "";
        loadCom();
    }
}