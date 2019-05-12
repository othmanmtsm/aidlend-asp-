using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Security;
using System.Security.Claims;

public partial class EventsReview : System.Web.UI.Page
{
    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }
        var userIdentity = (ClaimsIdentity)User.Identity;
        var claims = userIdentity.Claims;
        var roleClaimType = userIdentity.RoleClaimType;
        var roles = claims.Where(c => c.Type == roleClaimType).ToList();

        if (User.Identity.IsAuthenticated && roles[0].Value == "admin")
        {
            SqlCommand cmd = new SqlCommand("select id,title,date,location,description,img from evnts", cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
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

                HtmlGenericControl thmbBtn = new HtmlGenericControl();
                thmbBtn.Attributes["class"] = "btn btn-sm";
                thmbBtn.TagName = "a";
                thmbBtn.InnerText = "Participate";
                thmbHoverCntnt.Controls.Add(thmbBtn);

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
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}