using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class EventSubmission : System.Web.UI.Page
{

    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }

        eventCategory.Items.Add("Mémorial");
        eventCategory.Items.Add("Médical");
        eventCategory.Items.Add("Urgence");
        eventCategory.Items.Add("Non lucratif");
        eventCategory.Items.Add("Education");
        eventCategory.Items.Add("Animal");
        eventCategory.Items.Add("Sports");
        

        eventCity.Items.Add("Marrakech");
        eventCity.Items.Add("Rabat");
        eventCity.Items.Add("Casablanca");
        eventCity.Items.Add("Fes");
        eventCity.Items.Add("Tangier");
        eventCity.Items.Add("Agadir");
        eventCity.Items.Add("Essaouira");
        eventCity.Items.Add("Meknes");
        eventCity.Items.Add("Tetouan");
        eventCity.Items.Add("El jadida");
        eventCity.Items.Add("Ouarzazate");
        eventCity.Items.Add("Oujda");
        eventCity.Items.Add("Safi");
        eventCity.Items.Add("Beni-Mellal");
        eventCity.Items.Add("Sale");
        eventCity.Items.Add("Taza");
        eventCity.Items.Add("Chefchaouen");
        eventCity.Items.Add("Nador");
        eventCity.Items.Add("Kenitra");
        eventCity.Items.Add("Ifran");
        eventCity.Items.Add("Mohammedia");
    }

    protected void Unnamed10_Click(object sender, EventArgs e)
    {
        
    }

    protected void submitEvnt_Click(object sender, EventArgs e)
    {

            using (cnx)
            {
                using (SqlCommand cmd = new SqlCommand("addEvents", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter Title = new SqlParameter { ParameterName = "@title", Value = eventTitle.Text };
                    cmd.Parameters.Add(Title);
                    SqlParameter Date = new SqlParameter { ParameterName = "@date", Value = eventDate.Text };
                    cmd.Parameters.Add(Date);
                    SqlParameter City = new SqlParameter { ParameterName = "@city", Value = eventCity.SelectedValue.ToString() };
                    cmd.Parameters.Add(City);
                    SqlParameter Location = new SqlParameter { ParameterName = "@location", Value = eventAdress.Text };
                    cmd.Parameters.Add(Location);
                    SqlParameter Category = new SqlParameter { ParameterName = "@category", Value = eventCategory.SelectedValue.ToString() };
                    cmd.Parameters.Add(Category);
                    SqlParameter Description = new SqlParameter { ParameterName = "@description", Value = eventDescription.Text };
                    cmd.Parameters.Add(Description);
                    HttpPostedFile postedFile = eventImg.PostedFile;
                    Stream stream = postedFile.InputStream;
                    BinaryReader reader = new BinaryReader(stream);
                    SqlParameter Img = new SqlParameter { ParameterName = "@img", Value = reader.ReadBytes((int)stream.Length) };
                    cmd.Parameters.Add(Img);
                    SqlParameter Body = new SqlParameter { ParameterName = "@body", Value = eventBody.Text };
                    cmd.Parameters.Add(Body);
                    SqlParameter Organizer = new SqlParameter { ParameterName = "@organizer", Value = eventOrganizer.Text };
                    cmd.Parameters.Add(Organizer);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/eventPosted.aspx");
                }
            }
    }
}