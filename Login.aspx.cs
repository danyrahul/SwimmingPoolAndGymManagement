using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data.Common;

namespace SwimmingPoolAndGymManagement
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection s1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                s1.Open();
                string userName = TextBox1.Text;
                string password = TextBox2.Text;
                Session["u"] = userName;
                string q1 = "select IsAdmin from [dbo].[CredentialsTable] where UserName = @userName and Password = @password";
                SqlCommand cmd = new SqlCommand(q1, s1);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("Password", password);
                int a = (int)cmd.ExecuteScalar();
                if (a == 0)
                {
                    Response.Redirect("Customer_home.aspx");
                }
                else
                {
                    Response.Redirect("Admin_home.aspx");
                }
            }

            catch (Exception ms)
            {
                Console.WriteLine(ms.Message);
            }

            finally
            {
                s1.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reg_page.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pass_Reset.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}