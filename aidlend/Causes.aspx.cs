using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Causes : System.Web.UI.Page
{
    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("Mémorial");
            DropDownList1.Items.Add("Médical");
            DropDownList1.Items.Add("Urgence");
            DropDownList1.Items.Add("Non lucratif");
            DropDownList1.Items.Add("Education");
            DropDownList1.Items.Add("Animal");
            DropDownList1.Items.Add("Sports");
        }
        loadCauses("select id,title,location,img,category,goal,raised from causes where valid=1");
    }

    public void loadCauses(string rqt)
    {
        using (SqlCommand cmd = new SqlCommand(rqt, cnx))
        {
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                HtmlGenericControl colCntrl = new HtmlGenericControl();
                colCntrl.Attributes["class"] = "col-lg-4 col-md-6";
                colCntrl.TagName = "div";
                causess.Controls.Add(colCntrl);

                HtmlGenericControl causeCntrl = new HtmlGenericControl();
                causeCntrl.Attributes["class"] = "cause";
                causeCntrl.TagName = "div";
                colCntrl.Controls.Add(causeCntrl);

                HtmlGenericControl bannerCntrl = new HtmlGenericControl();
                bannerCntrl.Attributes["class"] = "interactive-banner";
                bannerCntrl.Attributes["href"] = "Cause.aspx?id=" + rd[0].ToString();
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
                prgrdBar.Attributes["aria-valuenow"] = ((double.Parse(rd[6].ToString()) * 100) / double.Parse(rd[5].ToString())).ToString("F0");
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
            rd.Close();
            cnx.Close();
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        causess.Controls.Clear();
        string rqt = "select id,title,location,img,category,goal,raised from causes where valid=1 and category='" + DropDownList1.SelectedValue + "'";
        loadCauses(rqt);
    }
}