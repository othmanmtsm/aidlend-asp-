using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.IO;
using System.Net.Mail;
using System.Net;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Main.aspx");
        }
    }

    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser()
            {
                UserName = txtName.Text,
                Email = txtMail.Text,
                PhoneNumber = txtPhone.Text
            };

            // IMAGE
            if (picUp.HasFile)
            {
                HttpPostedFile postedFile = picUp.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;
                string[] extentions = { ".jpg", ".png", ".jpeg", ".gif" };
                if (extentions.Contains(fileExtension.ToLower()) || fileSize < 5000000)
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    using (cnx)
                    {
                        SqlCommand cmd = new SqlCommand("spUploadImage", cnx);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter name = new SqlParameter()
                        {
                            ParameterName = @"Name",
                            Value = filename
                        };
                        cmd.Parameters.Add(name);

                        SqlParameter size = new SqlParameter()
                        {
                            ParameterName = "@Size",
                            Value = fileSize
                        };
                        cmd.Parameters.Add(size);

                        SqlParameter imgData = new SqlParameter()
                        {
                            ParameterName = "@ImageData",
                            Value = bytes
                        };
                        cmd.Parameters.Add(imgData);

                        SqlParameter userId = new SqlParameter()
                        {
                            ParameterName = "@UserId",
                            Value = user.Id
                        };
                        cmd.Parameters.Add(userId);

                        cnx.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    imgErr.Text = "File non valid or too large";
                    return;
                }
            }
            IdentityResult result = manager.Create(user, txtPassword.Text);

            if (result.Succeeded)
            {
                MailMessage message = new MailMessage();
                message.To.Add(user.Email);
                message.Subject = "Aidlend email confirmation";
                message.From = new MailAddress("othman.motassim18@gmail.com");
                message.Body = "Clickez sur le lien pour verifier votre email "+Environment.NewLine+ "https://www.aidlend.gq/ConfirmMail.aspx?id=" + user.Id;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("contact.aidlend@gmail.com", "Password11!");
                smtp.Send(message);
                Response.Redirect("ConfirmMail.aspx");
            }
            else
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}