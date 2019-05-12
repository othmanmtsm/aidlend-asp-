using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CauseSubmission : System.Web.UI.Page
{
    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        eventCategory.Items.Add("Mémorial");
        eventCategory.Items.Add("Médical");
        eventCategory.Items.Add("Urgence");
        eventCategory.Items.Add("Non lucratif");
        eventCategory.Items.Add("Education");
        eventCategory.Items.Add("Animal");
        eventCategory.Items.Add("Sports");
    }

    protected void submitCause_Click(object sender, EventArgs e)
    {
        using (cnx)
        {
            using (SqlCommand cmd = new SqlCommand("addCause",cnx))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@title", Value = eventTitle.Text });
                cmd.Parameters.Add (new SqlParameter { ParameterName = "@date", Value = eventDate.Text });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@location", Value = eventAdress.Text });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@description", Value = eventDescription.Text });
                HttpPostedFile postedFile = eventImg.PostedFile;
                Stream stream = postedFile.InputStream;
                BinaryReader reader = new BinaryReader(stream);
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@img", Value = reader.ReadBytes((int)stream.Length) });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@body", Value = eventBody.Text });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@organizer", Value = eventOrganizer.Text });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@category", Value = eventCategory.SelectedValue.ToString() });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@goal", Value = double.Parse(goal.Text) });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@bankNum", Value = card.Text });
                cnx.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("~/causePosted.aspx");
            }
        }
    }
}