using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace SwimmingPoolAndGymManagement
{
    public partial class View_Profile : System.Web.UI.Page
    {
        public static bool isInEditMode = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(isInEditMode)
            {
                return;
            }

            Label11.Visible = false;
            Label12.Visible = false;
            SqlConnection s2 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);
            try
            {
                s2.Open();
                string name = (string)Session["u"];
                string Q = "select UserName from [dbo].[CredentialsTable] where UserName = @name";
                SqlCommand c = new SqlCommand(Q, s2);
                c.Parameters.AddWithValue("@name", name);
                string n = (string)c.ExecuteScalar();
                Label2.Text = "Welcome " + n;


                TextBox1.Text = n;
                
                string q1 = "select firstName from [dbo].[UserDetailsTable] where UserName = @name";
                c = new SqlCommand(q1, s2);
                c.Parameters.AddWithValue("@name", name);
                n = (string)c.ExecuteScalar();

                TextBox2.Text = n;

                q1 = "select lastName from [dbo].[UserDetailsTable] where UserName = @name";
                c = new SqlCommand(q1, s2);
                c.Parameters.AddWithValue("@name", name);
                n = (string)c.ExecuteScalar();

                TextBox3.Text = n;


                q1 = "select EmailId from [dbo].[UserDetailsTable] where UserName = @name";
                c = new SqlCommand(q1, s2);
                c.Parameters.AddWithValue("@name", name);
                n = (string)c.ExecuteScalar();

                TextBox4.Text = n;


                q1 = "select Gender from [dbo].[UserDetailsTable] where UserName = @name";
                c = new SqlCommand(q1, s2);
                c.Parameters.AddWithValue("@name", name);
                n = (string)c.ExecuteScalar();

                TextBox5.Text = n;


                q1 = "select PhoneNumber from [dbo].[UserDetailsTable] where UserName = @name";
                c = new SqlCommand(q1, s2);
                c.Parameters.AddWithValue("@name", name);
                n = (string)c.ExecuteScalar();

                TextBox6.Text = n;

                q1 = "select IsAdmin from [dbo].[CredentialsTable] where UserName = @name";
                c = new SqlCommand(q1, s2);
                c.Parameters.AddWithValue("@name", name);
                int i = (int)c.ExecuteScalar();

                if(i == 0)
                {
                    TextBox7.Text = "Client";
                    CheckBox1.Visible = true;
                    Label10.Visible = true;
                    
                    Button3.Visible = true;
                }
                else
                {
                    TextBox7.Text = "Admin";
                }    
                

            }

            catch (Exception ms)
            {
                Console.WriteLine(ms);
            }

            finally
            {
                s2.Close();
            }
        }

        private void inse()
        {
            SqlConnection s3 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

            try
            {
                s3.Open();
                string approve = "Pending";
                string qu1 = "Insert into [dbo].[Arequest] (UserName, Areq) Values(@userName,@approve)";
                SqlCommand i = new SqlCommand(qu1, s3);
                i.Parameters.AddWithValue("@userName", TextBox1.Text );
                i.Parameters.AddWithValue("@approve", approve);

                i.ExecuteNonQuery();

            }

            catch(Exception ms)
            {
                Console.WriteLine(ms);
            }

            finally
            {
                s3.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int abc = (int)Session["i"];

            if (abc == 1 )
            {
                Response.Redirect("Admin_home.aspx");
            }
            
            else
            {
                Response.Redirect("Customer_home.aspx");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(CheckBox1.Checked == true)
            {
                Label11.Visible = true;
                inse();
            }
            else
            {
                Label12.Visible = true;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            
            TextBox6.ReadOnly = false;
            TextBox5.ReadOnly = false;
            TextBox4.ReadOnly = false;
            TextBox3.ReadOnly = false;
            TextBox2.ReadOnly = false;
            Button4.Visible = false;
            Button5.Visible = true;
            Button6.Visible = true;
            isInEditMode = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            
            SqlConnection s3 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);
            try
            {
                s3.Open();

                string userName = TextBox1.Text;
                string gender = TextBox5.Text;
                string firstName = TextBox2.Text;
                string lastName = TextBox3.Text;
                string emailId = TextBox4.Text;
                string phoneNumber = TextBox6.Text;

                string query = "Update [dbo].[UserDetailsTable]" +
                " set Gender = @gender, " +
                "firstName = @firstName, lastName = @lastName, EmailId = @emailId, " +
                "PhoneNumber = @phoneNumber where UserName = @userName";


                SqlCommand i = new SqlCommand(query, s3);
                i.Parameters.AddWithValue("@gender", gender);
                i.Parameters.AddWithValue("@firstName", firstName);
                i.Parameters.AddWithValue("@lastName", lastName);
                i.Parameters.AddWithValue("@emailId", emailId);
                i.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                i.Parameters.AddWithValue("@userName", userName);
                i.ExecuteNonQuery();

            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                s3.Close();
            }

            isInEditMode = false;

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            
            TextBox6.ReadOnly = false;
            TextBox5.ReadOnly = false;
            TextBox4.ReadOnly = false;
            TextBox3.ReadOnly = false;
            TextBox2.ReadOnly = false;
            Button4.Visible = true;
            Button5.Visible = false;
            Button6.Visible = false;

        }
    }
}