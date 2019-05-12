using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Settings : System.Web.UI.Page
{
    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
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
                adminsett.Visible = true;
            }
        }
        else
        {
            adminsett.Visible = false;
        }
        using (cnx)
        {
            using (SqlCommand cmd = new SqlCommand("select id,title,date,location,description,img from evnts where valid=0", cnx))
            {
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        HtmlGenericControl rowCntrl = new HtmlGenericControl();
                        rowCntrl.Attributes["class"] = "col-12";
                        rowCntrl.TagName = "div";
                        eventsRev.Controls.Add(rowCntrl);

                        HtmlGenericControl evntDv = new HtmlGenericControl();
                        rowCntrl.Attributes["class"] = "events events-list";
                        rowCntrl.TagName = "div";
                        rowCntrl.Controls.Add(evntDv);

                        HtmlGenericControl articleCntrl = new HtmlGenericControl();
                        articleCntrl.Attributes["class"] = "event";
                        articleCntrl.TagName = "article";
                        rowCntrl.Controls.Add(articleCntrl);

                        HtmlGenericControl thmbCntrl = new HtmlGenericControl();
                        thmbCntrl.Attributes["class"] = "event-thumb";
                        thmbCntrl.TagName = "div";
                        articleCntrl.Controls.Add(thmbCntrl);

                        Image imgThmb = new Image();
                        imgThmb.Attributes["class"] = "img-fluid";
                        imgThmb.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])rd[5]);
                        thmbCntrl.Controls.Add(imgThmb);

                        HtmlGenericControl thmbHoverCntrl = new HtmlGenericControl();
                        thmbHoverCntrl.Attributes["class"] = "thumb-hover";
                        thmbHoverCntrl.TagName = "div";
                        thmbCntrl.Controls.Add(thmbHoverCntrl);

                        HtmlGenericControl thmbHoverCntnt = new HtmlGenericControl();
                        thmbHoverCntnt.Attributes["class"] = "thumb-hover-content";
                        thmbHoverCntnt.TagName = "div";
                        thmbHoverCntrl.Controls.Add(thmbHoverCntnt);

                        HtmlGenericControl countDownCntrl = new HtmlGenericControl();
                        countDownCntrl.Attributes["class"] = "countdown countdown-3";
                        countDownCntrl.Attributes["data-time"] = rd[2].ToString();
                        countDownCntrl.TagName = "div";
                        thmbHoverCntnt.Controls.Add(countDownCntrl);

                        HtmlGenericControl eventCntnt = new HtmlGenericControl();
                        eventCntnt.Attributes["class"] = "event-content";
                        eventCntnt.TagName = "div";
                        articleCntrl.Controls.Add(eventCntnt);

                        HtmlGenericControl title = new HtmlGenericControl();
                        title.Attributes["class"] = "event-title";
                        title.TagName = "h3";
                        HtmlGenericControl titleLink = new HtmlGenericControl();
                        titleLink.Attributes["href"] = "#";
                        titleLink.TagName = "a";
                        titleLink.InnerText = rd[1].ToString();
                        title.Controls.Add(titleLink);
                        eventCntnt.Controls.Add(title);

                        HtmlGenericControl date = new HtmlGenericControl();
                        date.Attributes["class"] = "event-date";
                        date.TagName = "p";
                        date.InnerHtml = "<i class='fa fa-calendar'></i> " + rd[2].ToString();
                        eventCntnt.Controls.Add(date);

                        HtmlGenericControl location = new HtmlGenericControl();
                        location.Attributes["class"] = "event-location";
                        location.TagName = "p";
                        location.InnerHtml = "<i class='fa fa-map-marker'></i> " + rd[3].ToString();
                        eventCntnt.Controls.Add(location);

                        HtmlGenericControl description = new HtmlGenericControl();
                        description.Attributes["class"] = "event-excerpt";
                        description.TagName = "p";
                        description.InnerText = rd[4].ToString();
                        eventCntnt.Controls.Add(description);

                        HtmlGenericControl readMore = new HtmlGenericControl();
                        readMore.Attributes["class"] = "btn readmore";
                        readMore.Attributes["href"] = "/Event.aspx?id=" + rd[0].ToString();
                        readMore.TagName = "a";
                        readMore.InnerText = "Read More";
                        eventCntnt.Controls.Add(readMore);
                    }
                }
                else
                {
                    HtmlGenericControl noevnts = new HtmlGenericControl();
                    noevnts.TagName = "p";
                    noevnts.InnerText = "No new events";
                    eventsRev.Controls.Add(noevnts);
                }
                rd.Close();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select * from causes where valid=0", cnx))
            {
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        HtmlGenericControl cause = new HtmlGenericControl();
                        cause.Attributes["class"] = "cause";
                        cause.TagName = "article";
                        cause.InnerHtml = @"<div class='cause-thumb'>
                                                <img class='img-fluid' src='" + "data:Image/png;base64," + Convert.ToBase64String((byte[])dr[5]) + @"' alt='Blog image'>
                                                <div class='thumb-hover'>
                                                    <div class='thumb-hover-content'>
                                                        <p class='event-date'><i class='fa fa-calendar'></i>" + dr[2].ToString() + @"</p>
                                                        <p class='event-location'><i class='fa fa-map-marker'></i>" + dr[3].ToString() + @"</p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='cause-content'>
                                                <h3 class='cause-title'><a href='cause-single.html'>" + dr[1].ToString() + @"</a></h3>
                                                <div class='progress-item'>
                                                    <div class='progress-head'>
                                                        <div class='collected'>
                                                            <label>Collected: </label>
                                                            <p>" + dr[10].ToString() + @" DH</p>
                                                        </div>
                                                        <div class='goal'>
                                                            <label>Goal: </label>
                                                            <p>" + dr[9].ToString() + @" DH</p>
                                                        </div>
                                                    </div>
                                                    <div class='progress-body'>
                                                        <div class='progress'>
                                                            <div class='progress-bar animated' role='progressbar' aria-valuenow='" + ((double.Parse(dr[10].ToString()) * 100) / double.Parse(dr[9].ToString())).ToString("F0") + @"' aria-valuemin='0' aria-valuemax='100' style='width: 0;'></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <p class='cause-excerpt'>" + dr[4].ToString() + @"</p>
                                                <a class='btn readmore' href='Cause.aspx?id=" + dr[0].ToString() + @"'>Afficher plus</a>
                                            </div>";

                        donationsRev.Controls.Add(cause);

                    }
                }
                else
                {
                    HtmlGenericControl noevnts = new HtmlGenericControl();
                    noevnts.TagName = "p";
                    noevnts.InnerText = "No new donations";
                    donationsRev.Controls.Add(noevnts);
                }
                dr.Close();
                cnx.Close();
            }
            using (SqlCommand cmd = new SqlCommand("select a.*,b.amount from [dbo].[causes] a join [dbo].[donations] b on a.id=b.cause where b.donor=@id",cnx))
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = User.Identity.GetUserId() });
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        HtmlGenericControl cause = new HtmlGenericControl();
                        cause.Attributes["class"] = "cause";
                        cause.TagName = "article";
                        cause.InnerHtml = @"<div class='cause-thumb'>
                                                <img class='img-fluid' src='" + "data:Image/png;base64," + Convert.ToBase64String((byte[])dr[5]) + @"' alt='Blog image'>
                                                <div class='thumb-hover'>
                                                    <div class='thumb-hover-content'>
                                                        <p class='event-date'><i class='fa fa-calendar'></i>" + dr[2].ToString() + @"</p>
                                                        <p class='event-location'><i class='fa fa-map-marker'></i>" + dr[3].ToString() + @"</p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='cause-content'>
                                                <h3 class='cause-title'><a href='Cause.aspx?id=" + dr[0].ToString() + @">" + dr[1].ToString() + @"</a></h3>
                                                <div class='progress-item'>
                                                    <div class='progress-head'>
                                                        <div class='goal'>
                                                            <label>Montant que j'ai donné : </label>
                                                            <p>" + dr[13].ToString() + @" DH</p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <a class='btn readmore' href='Cause.aspx?id=" + dr[0].ToString() + @"'>Afficher plus</a>
                                            </div>";
                        Panel2.Controls.Add(cause);
                    }
                }
                else
                {
                    HtmlGenericControl noevnts = new HtmlGenericControl();
                    noevnts.TagName = "p";
                    noevnts.InnerText = "No donations";
                    Panel2.Controls.Add(noevnts);
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
                        evnt.InnerHtml = "<div class='col-12'><div class='events events-list'><div class='event'><div class='event-thumb'><img class='img-fluid' src='" + "data:Image/png;base64," + Convert.ToBase64String((byte[])dr1[2]) + "' alt='Blog image'></div><div class='event-content'><h3 class='event-title'><a href = 'Event.aspx?id=" + dr1[0].ToString() + "' > " + dr1[1].ToString() + "</a></h3><p class='event-date'><i class='fa fa-clock-o'></i>" + dr1[3].ToString() + "</p><p class='event-location'><i class='fa fa-map-marker'></i>" + dr1[4].ToString() + "</p></div></div></div>";
                        Panel1.Controls.Add(evnt);
                    }
                }
                else
                {
                    HtmlGenericControl err = new HtmlGenericControl();
                    err.TagName = "p";
                    err.InnerHtml = "no events";
                    Panel1.Controls.Add(err);
                }
                dr1.Close();
                cnx.Close();
            }
        }
    }
}