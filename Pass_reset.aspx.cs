using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;

namespace SwimmingPoolAndGymManagement
{
    
    public partial class Pass_reset : System.Web.UI.Page
    {
        public static int ret;
        SqlConnection s2= new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected int SendMail(string mail)
        {
            Random random = new Random();
            int activationcode = random.Next(1001, 9999);
            

            MailMessage msg = new MailMessage();
            msg.Subject = "Activation Code to Verify Email Address";
            msg.Body = "Dear " + activationcode + "\n\nThanks and regards";
            
            string toadress = mail;
            
            msg.To.Add(toadress);
            
            string fromAddress = "danyrahul47@gmail.com";
            string fromPassword = "glnhoakykxxhgzju";
            
            msg.From = new MailAddress(fromAddress);

            SmtpClient smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;

            }


            try
            {
                smtp.Send(toadress, fromAddress, msg.Subject, msg.Body);
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }
            return activationcode;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text != TextBox3.Text)
            {
                Label7.Visible = true;
            }
            else
            {
                Label7.Visible = false;
                s2.Open();


                string pass = TextBox3.Text;
                string u = TextBox1.Text;


                string q3 = "update [dbo].[CredentialsTable] set Password = @pass where UserName = @u";
                SqlCommand c = new SqlCommand(q3, s2);
                c.Parameters.AddWithValue("@u", u);
                c.Parameters.AddWithValue("@pass", pass);
                c.ExecuteNonQuery();


                Label8.Visible = true;
                HyperLink1.Visible = true;

               
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                s2.Open();
                string userName = TextBox1.Text;
                string q1 = "select * from [dbo].[CredentialsTable] where UserName = @userName";
                SqlCommand check = new SqlCommand(q1, s2);
                check.Parameters.AddWithValue("@userName", userName);
                SqlDataReader reader = check.ExecuteReader();
                if (reader.HasRows)
                {
                    Label1.Visible = false;
                    reader.Close();
                    string q2 = "select EmailId from [dbo].[UserDetailsTable] where UserName = @userName";
                    SqlCommand check1 = new SqlCommand(q2, s2);
                    check1.Parameters.AddWithValue("@userName", userName);
                    string m = ((string)check1.ExecuteScalar());
                    ret = SendMail(m);

                    Button3.Visible = false;
                    Label3.Visible = true;
                    TextBox4.Visible = true;
                    Button2.Visible = true;
                    
                }
                else
                {
                    Label1.Visible = true;
                }
            }
            catch (Exception ms)
            {
                Console.WriteLine(ms.Message);
            }
            finally
            {
                s2.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int val = int.Parse(TextBox4.Text);
            if (val == ret)
            {
                Label3.Visible = false;
                TextBox4.Visible = false;
                Button2.Visible = false;


                Label4.Visible = true;
                TextBox2.Visible = true;

                Label5.Visible = true;
                TextBox3.Visible = true;

                Button1.Visible = true;

                Label6.Visible = true;
                Label6.Text = "Otp Validation Successful";

            }
            else
            {
                Label6.Visible = true;
            }
        }
    }
}