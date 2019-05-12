using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Participated : System.Web.UI.Page
{
    protected string user = HttpContext.Current.User.Identity.GetUserName();
    protected string evnt;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }
        evnt = Request.QueryString[0];
    }

    protected void print_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Event.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        irntable.RenderControl(htmlTextWriter);
        StringReader stringReader = new StringReader(stringWriter.ToString());
        Document Doc = new Document(PageSize.A6);
        HTMLWorker htmlparser = new HTMLWorker(Doc);
        PdfWriter.GetInstance(Doc, Response.OutputStream);
        Doc.Open();
        htmlparser.Parse(stringReader);
        Doc.Close();
        Response.Write(Doc);
        Server.Transfer("~/Events.aspx");
        Response.End();
    }
}