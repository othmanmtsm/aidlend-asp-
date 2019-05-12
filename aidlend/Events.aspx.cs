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

public partial class Events : System.Web.UI.Page
{
    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public void loadEvents(string rqt)
    {
        using (cnx)
        {
            SqlCommand cmd = new SqlCommand(rqt, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                HtmlGenericControl rowCntrl = new HtmlGenericControl();
                rowCntrl.Attributes["class"] = "col-lg-4 col-md-6";
                rowCntrl.TagName = "div";
                pnlEvents.Controls.Add(rowCntrl);

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
                titleLink.Attributes["href"] = "/Event.aspx?id=" + rd[0].ToString();
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
                location.InnerHtml = "<i class='fa fa-map - marker'></i> " + rd[3].ToString();
                eventCntnt.Controls.Add(location);

                HtmlGenericControl description = new HtmlGenericControl();
                description.Attributes["class"] = "event-excerpt";
                description.Attributes["style"] = "height:60px; line-height:20px;overflow:hidden;";
                description.TagName = "p";
                description.InnerText = rd[4].ToString();
                eventCntnt.Controls.Add(description);

                HtmlGenericControl readMore = new HtmlGenericControl();
                readMore.Attributes["class"] = "btn readmore";
                readMore.Attributes["href"] = "/Event.aspx?id=" + rd[0].ToString();
                readMore.TagName = "a";
                readMore.InnerText = "Lire la suite";
                eventCntnt.Controls.Add(readMore);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("Mémorial");
            DropDownList1.Items.Add("Médical");
            DropDownList1.Items.Add("Urgence");
            DropDownList1.Items.Add("Non lucratif");
            DropDownList1.Items.Add("Education");
            DropDownList1.Items.Add("Animal");
            DropDownList1.Items.Add("Sports");


            DropDownList2.Items.Add("Marrakech");
            DropDownList2.Items.Add("Rabat");
            DropDownList2.Items.Add("Casablanca");
            DropDownList2.Items.Add("Fes");
            DropDownList2.Items.Add("Tangier");
            DropDownList2.Items.Add("Agadir");
            DropDownList2.Items.Add("Essaouira");
            DropDownList2.Items.Add("Meknes");
            DropDownList2.Items.Add("Tetouan");
            DropDownList2.Items.Add("El jadida");
            DropDownList2.Items.Add("Ouarzazate");
            DropDownList2.Items.Add("Oujda");
            DropDownList2.Items.Add("Safi");
            DropDownList2.Items.Add("Beni-Mellal");
            DropDownList2.Items.Add("Sale");
            DropDownList2.Items.Add("Taza");
            DropDownList2.Items.Add("Chefchaouen");
            DropDownList2.Items.Add("Nador");
            DropDownList2.Items.Add("Kenitra");
            DropDownList2.Items.Add("Ifran");
            DropDownList2.Items.Add("Mohammedia");
            loadEvents("select id,title,date,location,description,img from evnts where valid=1");
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        string rqt = "select id,title,date,location,description,img from evnts where valid=1 and city='" + DropDownList2.SelectedValue + "' and category='" + DropDownList1.SelectedValue + "'";
        loadEvents(rqt);
    }
}