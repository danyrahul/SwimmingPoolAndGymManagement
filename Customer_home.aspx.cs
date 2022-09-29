using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwimmingPoolAndGymManagement
{
    public partial class Customer_home : System.Web.UI.Page
    {
        protected static bool isSlotBooking = false;
        protected static string name = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            clientsData.Visible = false;


            Session["i"] = 0;



            SqlConnection s2 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);
            try
            {
                s2.Open();
                name = (string)Session["u"];
                string Q = "select UserName from [dbo].[CredentialsTable] where UserName = @name";
                SqlCommand c = new SqlCommand(Q, s2);
                c.Parameters.AddWithValue("@name", name);
                string n = (string)c.ExecuteScalar();
                LabelMain.Text = "Welcome " + n;
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

        private void bindData(string query)
        {
            clientsData.Visible = false;

            DataTable dt = new DataTable();

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



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_Profile.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            isSlotBooking = true;
            string query = "select SlotId,Day,Time,Total,Available,StartDate,EndDate from [dbo].[Slot_info]";
            bindData(query);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            isSlotBooking = false;
            string query = "select T.SlotId,Day,Time,Total,Available,StartDate,EndDate from [dbo].[Slot_info] T " +
                "inner join [dbo].[UserSlotTable] S on T.SlotId = S.SlotId " +
                "where EndDate < GetDate()";
            bindData(query);

        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            isSlotBooking = false;
            string query = "select T.SlotId,T.Day,Time,Total,Available,StartDate,EndDate from [dbo].[Slot_info] T " +
            "inner join [dbo].[UserSlotTable] S on T.Slotid = S.SLotId " +
            "where (StartDate <= GetDate() and EndDate >= GetDate())";
            bindData(query);

        }


        protected void clientsData_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button lbBook = (Button)e.Row.Cells[6].FindControl("Button3");

            if(isSlotBooking == false && lbBook != null)
            {
                lbBook.Visible = false;
            }
        }

        protected void clientsData_RowUpdateCommand(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

            try
            {
                con.Open();

                string slotId = (clientsData.Rows[e.RowIndex].FindControl("Label1") as Label)?.Text.Trim();
                string day = (clientsData.Rows[e.RowIndex].FindControl("Label2") as Label)?.Text.Trim();
                string time = (clientsData.Rows[e.RowIndex].FindControl("Label3") as Label)?.Text.Trim();
                int total = Int32.Parse((clientsData.Rows[e.RowIndex].FindControl("Label4") as Label)?.Text.Trim());
                int available = Int32.Parse((clientsData.Rows[e.RowIndex].FindControl("Label5") as Label)?.Text.Trim());
                string startdate = (clientsData.Rows[e.RowIndex].FindControl("Label6") as Label)?.Text.Trim();
                string enddate = (clientsData.Rows[e.RowIndex].FindControl("Label7") as Label)?.Text.Trim();
                string query = "";

                if (isSlotBooking == true)
                {
                    query = String.Format("Update [dbo].[Slot_info] set Available = Available - 1 where SlotId= {0}", slotId);
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    int userRank = total - available + 1;
                    string userName = (string)Session["u"];
                    query = "insert into [dbo].[UserSlotTable] (SlotId, userName, userRank) " +
                        "Values(@slotId, @userName, @userRank)";


                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@slotId", slotId);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@userRank", userRank);

                        cmd.ExecuteNonQuery();
                    }

                    clientsData.EditIndex = -1;

                    query = "select SlotId,Day,Time,Total,Available,StartDate,EndDate from [dbo].[Slot_info]";
                    bindData(query);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }
        }
       
        
    }
}