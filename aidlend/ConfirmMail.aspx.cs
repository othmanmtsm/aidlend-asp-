using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConfirmMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count!=0)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("confirmEmail",cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = Request.QueryString[0] });
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            cnfrmaccnt.Visible = true;
            confrmsend.Visible = false;
        }
        else
        {
            cnfrmaccnt.Visible = false;
            confrmsend.Visible = true;
        }
    }
}