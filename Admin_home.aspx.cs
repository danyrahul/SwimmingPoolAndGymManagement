using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SwimmingPoolAndGymManagement
{
    public partial class Admin_home : System.Web.UI.Page
    {
        public static int isAdmin = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            clientsData.Visible = false;
            

            SqlConnection s2 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);
            try
            {
                s2.Open();
                string name = (string)Session["u"];
                string Q = "select UserName from [dbo].[CredentialsTable] where UserName = @name";
                SqlCommand c = new SqlCommand(Q, s2);
                c.Parameters.AddWithValue("@name", name);
                string n=(string)c.ExecuteScalar();
                Label2.Text = "Welcome " + n;
            }

            catch(Exception ms)
            {
                Console.WriteLine(ms);
            }

            finally
            {
                s2.Close();
            }
            
        }



        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bindData()
        {
            clientsData.Visible = false;
            

            DataTable dt = new DataTable();
            string query = "SELECT * from [dbo].[CredentialsTable] as C INNER JOIN [dbo].[UserDetailsTable] as T " +
                "ON C.UserName = T.UserName where isAdmin = " + isAdmin.ToString();


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }

            if (dt.Rows.Count == 0)
            {
                //If no records then add a dummy row.
                dt.Rows.Add();
            }

            clientsData.DataSource = dt;
            clientsData.DataBind();
            clientsData.Visible = true;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            isAdmin = 0;
            bindData();
        }

        protected void clientsData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString))
                {
                    con.Open();
                    string userName = (clientsData.FooterRow.FindControl("textBox2") as TextBox).Text.Trim();
                    string gender = (clientsData.FooterRow.FindControl("textBox4") as TextBox).Text.Trim();
                    string firstName = (clientsData.FooterRow.FindControl("textBox6") as TextBox).Text.Trim();
                    string lastName = (clientsData.FooterRow.FindControl("textBox8") as TextBox).Text.Trim();
                    string emailId = (clientsData.FooterRow.FindControl("textBox10") as TextBox).Text.Trim();
                    string phoneNumber = (clientsData.FooterRow.FindControl("textBox12") as TextBox).Text.Trim();

                    string query1 = "Insert into [dbo].[CredentialsTable] (UserName, Password, IsAdmin)  Values(@userName,@password, @isAdmin)";

                    using (SqlCommand cmd = new SqlCommand(query1, con))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@password", "1234");
                        cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                        cmd.ExecuteNonQuery();
                    }

                    string query2 = "Insert into [dbo].[UserDetailsTable] (UserName, Gender, firstName, lastName, EmailId, PhoneNumber) " +
                        "Values(@userName,@gender,@firstName,@lastName,@emailId,@phoneNumber)";


                    using (SqlCommand cmd = new SqlCommand(query2, con))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@emailId", emailId);
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        cmd.ExecuteNonQuery();
                    }


                    con.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            bindData();
        }

        protected void clientsData_RowEditCancelCommand(object sender, GridViewCancelEditEventArgs e)
        {
            clientsData.EditIndex = -1;
            bindData();
        }

        protected void clientsData_RowDeleteCommand(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString))
            try
            {
                string userName = (clientsData.FooterRow.FindControl("textBox1") as TextBox).Text.Trim();

                string query1 = "Delete from [dbo].[CredentialsTable] where UserName = @name";
                string query2 = "Delete from [dbo].[UserDetailsTable] where UserName = @name";

                foreach (var query in new List<string>() { query1, query2 })
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", userName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

             catch (Exception ss)
            {
                    Console.WriteLine(ss);
            }

            finally
            {
                    con.Close();
            }

            bindData();
        }

        protected void clientsData_RowEditCommand(object sender, GridViewEditEventArgs e)
        {
            clientsData.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void clientsData_RowUpdateCommand(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString))
            try
            {
                con.Open();
                string userName = (clientsData.Rows[e.RowIndex].FindControl("textBox2") as TextBox).Text.Trim();
                string gender = (clientsData.Rows[e.RowIndex].FindControl("textBox4") as TextBox).Text.Trim();
                string firstName = (clientsData.Rows[e.RowIndex].FindControl("textBox6") as TextBox).Text.Trim();
                string lastName = (clientsData.Rows[e.RowIndex].FindControl("textBox8") as TextBox).Text.Trim();
                string emailId = (clientsData.Rows[e.RowIndex].FindControl("textBox10") as TextBox).Text.Trim();
                string phoneNumber = (clientsData.Rows[e.RowIndex].FindControl("textBox12") as TextBox).Text.Trim();

                string query = "Update[dbo].[UserDetailsTable]" +
                    " set UserName= @user, Gender = @gender, " +
                    "firstName = @firstName, lastName = @lastName, EmailId = @emailId " +
                    "PhoneNumber = @phoneNumber where UserName = @name";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", userName);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@emailId", emailId);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.ExecuteNonQuery();
                }
                
            }

            catch(Exception ss)
                {
                    Console.WriteLine(ss);
                }

            finally
                {
                    con.Close();
                }

            bindData();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            isAdmin = 1;
            bindData();

        }
    }
}