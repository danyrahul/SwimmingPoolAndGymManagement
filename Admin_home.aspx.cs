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
        public static int num = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            clientsData.Visible = false;

            Session["i"] = 1;
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

        private void tt(int val)
        {
            if (val == 0)
            {
                clientsData.Columns[0].Visible = true;
                clientsData.Columns[0].HeaderText = "UserName";

                clientsData.Columns[1].Visible = true;
                clientsData.Columns[1].HeaderText = "Gender";

                clientsData.Columns[2].Visible = true;
                clientsData.Columns[2].HeaderText = "firstName";

                clientsData.Columns[3].Visible = true;
                clientsData.Columns[3].HeaderText = "lastName";

                clientsData.Columns[4].Visible = true;
                clientsData.Columns[4].HeaderText = "emailId";

                clientsData.Columns[5].Visible = true;
                clientsData.Columns[5].HeaderText = "phoneNumber";
            }
            else
            {
                clientsData.Columns[0].Visible = true;
                clientsData.Columns[0].HeaderText = "ItemName";

                clientsData.Columns[1].Visible = true;
                clientsData.Columns[1].HeaderText = "Quantity";

                clientsData.Columns[2].Visible = false;
                clientsData.Columns[3].Visible = false;
                clientsData.Columns[4].Visible = false;
                clientsData.Columns[5].Visible = false;
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
            Response.Redirect("View_Profile.aspx");

        }

        private void bindData(int val = 0)
        {
            clientsData.Visible = false;
            string query;
            string p = "Pending";
            DataTable dt = new DataTable();

            if (val == 10)
            {
                query = "select * from [dbo].[EquipTable]";
            }
            else if (num == 0)
            {
                query = "SELECT * from [dbo].[CredentialsTable] as C INNER JOIN [dbo].[UserDetailsTable] as T " +
                "ON C.UserName = T.UserName where isAdmin = " + isAdmin.ToString();
            }
            else
            {
                string queryFormat = "Select * from [dbo].[Arequest] as C INNER JOIN [dbo].[UserDetailsTable] as T " +
                "on C.UserName = T.UserName where Areq = '{0}'";

                query = String.Format(queryFormat, p);
            }

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

            if (val == 10)
            {
                equipmentData.DataSource = dt;
                equipmentData.DataBind();
                equipmentData.Visible = true;
            }
            else
            {
                clientsData.DataSource = dt;
                clientsData.DataBind();
                clientsData.Visible = true;
            }
        }

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            tt(0);
            isAdmin = 0;
            num = 0;
            bindData();
        }

        protected void clientsData_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button lbDelete = (Button)e.Row.Cells[6].FindControl("Button3");
            Button lbEdit = (Button)e.Row.Cells[6].FindControl("Button4");
            Button lbSave = (Button)e.Row.Cells[6].FindControl("Button5");
            Button lbCancel = (Button)e.Row.Cells[6].FindControl("Button6");
            Button lbAddNew = (Button)e.Row.Cells[6].FindControl("Button7");
            Button lbApprove = (Button)e.Row.Cells[6].FindControl("Button8");


            if (isAdmin == 1 && (lbDelete != null && lbEdit != null))
            {
                lbDelete.Visible = false;
                lbEdit.Visible = false;
                lbApprove.Visible = false;
            }

            if(num == 0 && lbApprove != null)
            {
                lbApprove.Visible = false;
            }

            if (num == 1 && lbApprove != null)
            {
                if (lbEdit != null)
                {
                    lbEdit.Visible = false;
                }

                lbApprove.Visible = true;
                clientsData.ShowFooter = false;
            }
        }

        protected void equipmentData_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button lbDelete = (Button)e.Row.Cells[2].FindControl("Button3");
            Button lbEdit = (Button)e.Row.Cells[2].FindControl("Button4");
            Button lbSave = (Button)e.Row.Cells[2].FindControl("Button5");
            Button lbCancel = (Button)e.Row.Cells[2].FindControl("Button6");
            Button lbAddNew = (Button)e.Row.Cells[2].FindControl("Button7");
            Button lbApprove = (Button)e.Row.Cells[2].FindControl("Button8");


            if (isAdmin == 1 && (lbDelete != null && lbEdit != null))
            {
                lbDelete.Visible = false;
                lbEdit.Visible = false;
                lbApprove.Visible = false;
            }

            if (num == 0 && lbApprove != null)
            {
                lbApprove.Visible = false;
            }

            if (num == 1 && lbApprove != null)
            {
                if (lbEdit != null)
                {
                    lbEdit.Visible = false;
                }

                lbApprove.Visible = true;
                equipmentData.ShowFooter = false;
            }
        }

        protected void clientsData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddNew")

                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString))
                    {
                        con.Open();

                        string userName = (clientsData.FooterRow.FindControl("TextBox2") as TextBox).Text.Trim();
                        string gender = (clientsData.FooterRow.FindControl("TextBox4") as TextBox).Text.Trim();
                        string firstName = (clientsData.FooterRow.FindControl("TextBox6") as TextBox).Text.Trim();
                        string lastName = (clientsData.FooterRow.FindControl("TextBox8") as TextBox).Text.Trim();
                        string emailId = (clientsData.FooterRow.FindControl("TextBox10") as TextBox).Text.Trim();
                        string phoneNumber = (clientsData.FooterRow.FindControl("TextBox12") as TextBox).Text.Trim();

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
                        bindData();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected void equipmentData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddNew")

                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString))
                    {
                        con.Open();

                        string Ename = (clientsData.FooterRow.FindControl("TextBox02") as TextBox).Text.Trim();
                        string Quantity = (clientsData.FooterRow.FindControl("TextBox04") as TextBox).Text.Trim();
                        

                        string query1 = "Insert into [dbo].[EquipTable] (Ename,Quantity)  Values(@Ename,@Quantity)";

                        using (SqlCommand cmd = new SqlCommand(query1, con))
                        {
                            cmd.Parameters.AddWithValue("@Ename", Ename);
                            cmd.Parameters.AddWithValue("@Quantity", Quantity);
                            
                            cmd.ExecuteNonQuery();
                        }

                       


                        con.Close();
                        bindData();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected void clientsData_RowEditCancelCommand(object sender, GridViewCancelEditEventArgs e)
        {
            clientsData.EditIndex = -1;
            bindData();
        }


        protected void equipmentData_RowEditCancelCommand(object sender, GridViewCancelEditEventArgs e)
        {
            equipmentData.EditIndex = -1;
            bindData();
        }

        protected void clientsData_RowDeleteCommand(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();
                    string userName = (clientsData.Rows[e.RowIndex].FindControl("Label1") as Label).Text.Trim();

                    string q1 = "Delete from [dbo].[CredentialsTable] where UserName = @userName";
                    string q2 = "Delete from [dbo].[UserDetailsTable] where UserName = @userName";
                    string q3 = "Delete from [dbo].[Arequest] where UserName = @userName";


                    foreach (var query in new List<string>() { q1, q2, q3 })
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@userName", userName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    bindData();
                }
                catch (Exception ss)
                {
                    Console.WriteLine(ss);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void equipmentData_RowDeleteCommand(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

            try
            {
                con.Open();
                string Ename = (clientsData.Rows[e.RowIndex].FindControl("Label01") as Label).Text.Trim();

                string query = "Delete from [dbo].[CredentialsTable] where Ename = @Ename";



                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Ename", Ename);
                cmd.ExecuteNonQuery();
                    
                
                bindData();

            }
            catch (Exception ss)
            {
                Console.WriteLine(ss);
            }
            finally
            {
                con.Close();
            }


        }

        protected void clientsData_RowEditCommand(object sender, GridViewEditEventArgs e)
        {
            clientsData.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void equipmentData_RowEditCommand(object sender, GridViewEditEventArgs e)
        {
            equipmentData.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void clientsData_RowUpdateCommand(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);
           
            try
            {
                con.Open();

                
                string userName = (clientsData.Rows[e.RowIndex].FindControl("TextBox1") as TextBox)?.Text.Trim();
                string gender = (clientsData.Rows[e.RowIndex].FindControl("TextBox3") as TextBox)?.Text.Trim();
                string firstName = (clientsData.Rows[e.RowIndex].FindControl("TextBox5") as TextBox)?.Text.Trim();
                string lastName = (clientsData.Rows[e.RowIndex].FindControl("TextBox7") as TextBox)?.Text.Trim();
                string emailId = (clientsData.Rows[e.RowIndex].FindControl("TextBox9") as TextBox)?.Text.Trim();
                string phoneNumber = (clientsData.Rows[e.RowIndex].FindControl("TextBox11") as TextBox)?.Text.Trim();
                string query = "";

                if (num == 1)
                {
                    userName = (clientsData.Rows[e.RowIndex].FindControl("Label1") as Label).Text.Trim();
                    query = String.Format("Update [dbo].[CredentialsTable] set IsAdmin = 1 where UserName = '{0}'", userName);
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                         cmd.ExecuteNonQuery();
                    }


                    query = String.Format("DELETE from [dbo].[Arequest] where UserName = '{0}'", userName);
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    con.Close();
                    clientsData.EditIndex = -1;
                    bindData();
                    return;
                }


                query = "Update[dbo].[UserDetailsTable]" +
                " set UserName= @userName, Gender = @gender, " +
                "firstName = @firstName, lastName = @lastName, EmailId = @emailId, " +
                "PhoneNumber = @phoneNumber where UserName = @userName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
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

            clientsData.EditIndex = -1;
            bindData();
        }

        protected void equipmentData_RowUpdateCommand(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

            try
            {
                con.Open();

                string Ename = (equipmentData.Rows[e.RowIndex].FindControl("TextBox02") as TextBox).Text.Trim();
                string Quantity = (equipmentData.Rows[e.RowIndex].FindControl("TextBox04") as TextBox).Text.Trim();

                string query = "";
                    
                query = String.Format("Update [dbo].[EquipTable] set Quantity = '{0}'  where Ename = '{1}' ", Quantity,Ename);
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

                clientsData.EditIndex = -1;
                bindData();
            }
            catch (Exception ss)
            {
                Console.WriteLine(ss);
                clientsData.EditIndex = -1;
                bindData();
            }
            finally
            {
                con.Close();
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            tt(0);
            isAdmin = 1;
            num = 0;
            bindData();
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            tt(0);
            num = 1;
            isAdmin = 0;
            bindData();
        }

        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            tt(10);
            bindData(10);
        }
    }
}