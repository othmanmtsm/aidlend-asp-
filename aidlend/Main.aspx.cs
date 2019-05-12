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
using System.Web.UI.HtmlControls;

public partial class Main : System.Web.UI.Page
{
    protected string urgId ="";
    protected string urgTtl="";
    protected string urgGoal="0";
    protected string urgCollected="0";
    protected string urgDate="";
    protected string volunteers = "";
    protected string causes = "";
    protected string events = "";
    string cns = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection cnx = new SqlConnection(cns))
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
            using (SqlCommand cmd = new SqlCommand("select top 1 * from causes order by raised desc", cnx))
            {
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    urgId = dr[0].ToString();
                    urgTtl = dr[1].ToString();
                    urgDate = dr[2].ToString();
                    urgGoal = dr[9].ToString();
                    urgCollected = dr[10].ToString();
                }
                dr.Close();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select a.id,a.title,a.img,a.date,a.location from evnts a join evntParticipants b on a.id=b.idEvent where b.idUser=@idUser", cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@idUser", Value = User.Identity.GetUserId() });
                cnx.Open();
                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        HtmlGenericControl evnt = new HtmlGenericControl();
                        evnt.Attributes["class"] = "event";
                        evnt.TagName = "article";
                        evnt.InnerHtml = "<div class='event-thumb'><img class='img-fluid' src='" + "data:Image/png;base64," + Convert.ToBase64String((byte[])dr1[2]) + "' alt='Blog image'></div><div class='event-content'><h3 class='event-title'><a href = 'Event.aspx?id=" + dr1[0].ToString() + "' > " + dr1[1].ToString() + "</a></h3><p class='event-date'><i class='fa fa-clock-o'></i>" + dr1[3].ToString() + "</p><p class='event-location'><i class='fa fa-map-marker'></i>" + dr1[4].ToString() + "</p></div>";
                        prtsEvnts.Controls.Add(evnt);
                    }
                }
                else
                {
                    HtmlGenericControl err = new HtmlGenericControl();
                    err.TagName = "div";
                    err.InnerHtml = "<h4>Aucun evenement</h4><a href='Events.aspx' class='btn'>Parcourir les événements</a>";
                    prtsEvnts.Controls.Add(err);
                }
                dr1.Close();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select count(*) from evnts", cnx))
            {
                cnx.Open();
                events = cmd.ExecuteScalar().ToString();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select count(*) from causes", cnx))
            {
                cnx.Open();
                causes = cmd.ExecuteScalar().ToString();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select count(*) from AspNetUsers", cnx))
            {
                cnx.Open();
                volunteers = cmd.ExecuteScalar().ToString();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select top 3 id,title,location,img,category,goal,raised from causes", cnx))
            {
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    HtmlGenericControl colCntrl = new HtmlGenericControl();
                    colCntrl.Attributes["class"] = "col-lg-4 col-md-6";
                    colCntrl.TagName = "div";
                    dons.Controls.Add(colCntrl);

                    HtmlGenericControl causeCntrl = new HtmlGenericControl();
                    causeCntrl.Attributes["class"] = "cause";
                    causeCntrl.TagName = "div";
                    colCntrl.Controls.Add(causeCntrl);

                    HtmlGenericControl bannerCntrl = new HtmlGenericControl();
                    bannerCntrl.Attributes["class"] = "interactive-banner";
                    bannerCntrl.Attributes["href"] = "cause.aspx";
                    bannerCntrl.TagName = "a";
                    causeCntrl.Controls.Add(bannerCntrl);

                    HtmlGenericControl thumbCntrl = new HtmlGenericControl();
                    thumbCntrl.Attributes["class"] = "banner-thumb";
                    thumbCntrl.TagName = "span";
                    bannerCntrl.Controls.Add(thumbCntrl);

                    Image thmbImg = new Image();
                    thmbImg.Attributes["class"] = "img-fluid";
                    thmbImg.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])rd[3]);
                    thumbCntrl.Controls.Add(thmbImg);

                    HtmlGenericControl thmbCntnt = new HtmlGenericControl();
                    thmbCntnt.Attributes["class"] = "banner-content-wrap";
                    thmbCntnt.TagName = "span";
                    bannerCntrl.Controls.Add(thmbCntnt);

                    HtmlGenericControl cat = new HtmlGenericControl();
                    cat.Attributes["class"] = "category";
                    cat.InnerText = rd[4].ToString();
                    thmbCntnt.Controls.Add(cat);

                    HtmlGenericControl ttl = new HtmlGenericControl();
                    ttl.Attributes["class"] = "h5";
                    ttl.InnerText = rd[1].ToString();
                    ttl.TagName = "span";
                    thmbCntnt.Controls.Add(ttl);

                    HtmlGenericControl location = new HtmlGenericControl();
                    location.Attributes["class"] = "location";
                    location.InnerHtml = "<i class='fa fa-map-marker'></i> " + rd[2].ToString();
                    location.TagName = "span";
                    thmbCntnt.Controls.Add(location);

                    HtmlGenericControl causeCntnt = new HtmlGenericControl();
                    causeCntnt.Attributes["class"] = "cause-content";
                    causeCntnt.TagName = "div";
                    causeCntrl.Controls.Add(causeCntnt);

                    HtmlGenericControl progress = new HtmlGenericControl();
                    progress.Attributes["class"] = "progress-item";
                    progress.TagName = "div";
                    causeCntnt.Controls.Add(progress);

                    HtmlGenericControl progressBdy = new HtmlGenericControl();
                    progressBdy.Attributes["class"] = "progress-body";
                    progressBdy.TagName = "div";
                    progress.Controls.Add(progressBdy);

                    HtmlGenericControl prgrs = new HtmlGenericControl();
                    prgrs.Attributes["class"] = "progress";
                    prgrs.TagName = "div";
                    progressBdy.Controls.Add(prgrs);

                    HtmlGenericControl prgrdBar = new HtmlGenericControl();
                    prgrdBar.Attributes["class"] = "progress-bar";
                    prgrdBar.Attributes["role"] = "progressbar";
                    prgrdBar.Attributes["aria-valuenow"] = ((double.Parse(rd[6].ToString())*100)/double.Parse(rd[5].ToString())).ToString("F0");
                    prgrdBar.Attributes["aria-valuemin"] = "0";
                    prgrdBar.Attributes["aria-valuemax"] = "100";
                    prgrdBar.Attributes["style"] = "width: 0";
                    prgrs.Controls.Add(prgrdBar);

                    HtmlGenericControl prgrsText = new HtmlGenericControl();
                    prgrsText.Attributes["class"] = "progress-text";
                    prgrsText.TagName = "div";
                    progress.Controls.Add(prgrsText);

                    HtmlGenericControl goal = new HtmlGenericControl();
                    goal.Attributes["class"] = "goal";
                    goal.TagName = "div";
                    goal.InnerHtml = "<label> Goal : <label/><p>" + rd[5].ToString() + " DH</p>";
                    prgrsText.Controls.Add(goal);

                    HtmlGenericControl collected = new HtmlGenericControl();
                    collected.Attributes["class"] = "collected";
                    collected.TagName = "div";
                    collected.InnerHtml = "<label> Collected : <label/><p>" + rd[6].ToString() + " DH</p>";
                    prgrsText.Controls.Add(collected);

                    HtmlGenericControl donate = new HtmlGenericControl();
                    donate.TagName = "a";
                    donate.Attributes["class"] = "btn btn-sm btn-border";
                    donate.Attributes["href"] = "Cause.aspx?id=" + rd[0].ToString();
                    donate.InnerText = "Donate";
                    causeCntnt.Controls.Add(donate);

                }
            }
        }
    }
}