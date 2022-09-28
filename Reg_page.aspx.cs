using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SwimmingPoolAndGymManagement
{
    public partial class Reg_page : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                myConnection.Open();
                string userName = TextBox5.Text;
                string password = TextBox6.Text;
                string firstName = TextBox1.Text;
                string lastName = TextBox2.Text;
                string email = TextBox3.Text;
                string phn = TextBox4.Text;
                string gender = DropDownList1.DataTextField;
      

                string query = "Insert into [dbo].[CredentialsTable] (UserName, Password)  Values(@userName,@password)";

                string query2 = "Insert into [dbo].[UserDetailsTable] (UserName, Gender, firstName, lastName, EmailId, PhoneNumber) " +
                    "Values(@userName,@gender,@firstName,@lastName,@email,@phn)";

                SqlCommand insertCommand = new SqlCommand(query, myConnection);

                Console.WriteLine(userName + " " + password);

                insertCommand.Parameters.AddWithValue("@userName", userName);
                insertCommand.Parameters.AddWithValue("@password", password);
                

                insertCommand.ExecuteNonQuery();


                insertCommand = new SqlCommand(query2, myConnection);
                insertCommand.Parameters.AddWithValue("@userName", userName);
                insertCommand.Parameters.AddWithValue("@firstName", firstName);
                insertCommand.Parameters.AddWithValue("@lastName", lastName);
                insertCommand.Parameters.AddWithValue("@gender", gender);
                insertCommand.Parameters.AddWithValue("@email", email);
                insertCommand.Parameters.AddWithValue("@phn", phn);
                insertCommand.ExecuteNonQuery();

                
            }
            
            catch(SqlException ms)
            {
                Console.WriteLine(ms.Message);
            }

            finally
            {
                myConnection.Close();
            }

            Label8.Text = "Registered Successfully";
            HyperLink1.Text = "Goto Login Page";
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

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }



    }
}