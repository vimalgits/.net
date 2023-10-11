using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillingSoft
{
    public partial class AddCompanyDeatil : System.Web.UI.Page
    {
        bool Insert = false;
        bool Update = false;
        bool Delete = false;
        string name = "";
        string Id = "";
        string Address = "";
        string Mobile = "";
        string Email = "";
        string PAN = "";
        string GST = "";
        string IPShortCode = "";
        string IPYear = "";
        string IPSeriesStart = "";
        string idofdeltingelement="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyDetails();
            }
        }
        protected void btnsubmitCompnyDetails_Click(object sender, EventArgs e)
        {
            InsertCompany();
            if (Insert == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                CompanyDetails();
                txtcompynm.Text = txtcompyAddress.Text = txtcompyMob.Text = txtcompyemail.Text = txtcompyPAN.Text = txtcompyGstno.Text = string.Empty;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Inserted')", true);
            }
        }
        private void InsertCompany()
        {
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string insertquery = "insert into " +
                    "CompanyDetails (CompanyName,CompanyAddress,CompanyMobNo,CompanyEmail,CompanyPAN,CompanyDateCreated,CompanyGST,IPShortCode,IPYear,IPSerialNumber) " +
                    "values(@CompanyName,@CompanyAddress,@CompanyMobNo,@CompanyEmail,@CompanyPAN,@CompanyDateCreated,@CompanyGST,@IPShortCode,@IPYear,@IPSerialNumber)";

                SqlCommand cmd = new SqlCommand(insertquery, con);
                cmd.Parameters.AddWithValue("@CompanyName", txtcompynm.Text);
                cmd.Parameters.AddWithValue("@CompanyAddress", txtcompyAddress.Text);
                cmd.Parameters.AddWithValue("@CompanyMobNo", txtcompyMob.Text);
                cmd.Parameters.AddWithValue("@CompanyEmail", txtcompyemail.Text);
                cmd.Parameters.AddWithValue("@CompanyPAN", txtcompyPAN.Text);
                cmd.Parameters.AddWithValue("@CompanyDateCreated", DateTime.Now.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@CompanyGST", txtcompyGstno.Text);

                cmd.Parameters.AddWithValue("@IPShortCode", txtipshortcode.Text);
                cmd.Parameters.AddWithValue("@IPYear", txtipyear.Text);
                cmd.Parameters.AddWithValue("@IPSerialNumber", txtipserialno.Text);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Insert = true;

            }
            catch { }


        }
        private void UpdateDetails()
        {
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string updatequery = "UPDATE CompanyDetails SET CompanyName=@CompanyName,CompanyAddress=@CompanyAddress,CompanyMobNo=@CompanyMobNo," +
                    "CompanyEmail=@CompanyEmail,CompanyPAN=@CompanyPAN,CompanyDateCreated=@CompanyDateCreated," +
                    "CompanyGST=@CompanyGST,IPShortCode=@IPShortCode,IPYear=@IPYear,IPSerialNumber=@IPSerialNumber Where CompanyId='"+ HdnId.Text + "' ";

                SqlCommand cmd = new SqlCommand(updatequery, con);
                cmd.Parameters.AddWithValue("@CompanyName", txtcompynm.Text);
                cmd.Parameters.AddWithValue("@CompanyAddress", txtcompyAddress.Text);
                cmd.Parameters.AddWithValue("@CompanyMobNo", txtcompyMob.Text);
                cmd.Parameters.AddWithValue("@CompanyEmail", txtcompyemail.Text);
                cmd.Parameters.AddWithValue("@CompanyPAN", txtcompyPAN.Text);
                cmd.Parameters.AddWithValue("@CompanyDateCreated", DateTime.Now.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@CompanyGST", txtcompyGstno.Text);

                cmd.Parameters.AddWithValue("@IPShortCode", txtipshortcode.Text);
                cmd.Parameters.AddWithValue("@IPYear", txtipyear.Text);
                cmd.Parameters.AddWithValue("@IPSerialNumber", txtipserialno.Text);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Update = true;

            }
            catch { }
        }
        private void DeleteDetails(string deleteid)
        {
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string updatequery = "delete CompanyDetails Where CompanyId='" + deleteid + "' ";

                SqlCommand cmd = new SqlCommand(updatequery, con);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Delete = true;
                if (Delete == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
                    CompanyDetails();
                    txtcompynm.Text = txtcompyAddress.Text = txtcompyMob.Text = txtcompyemail.Text = txtcompyPAN.Text = txtcompyGstno.Text = string.Empty;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Deleted')", true);
                }
            }
            catch { }
        }
        private void CompanyDetails()
        {
            // Load Exam Names

            string queryExamName = "select * from CompanyDetails ORDER BY CompanyId DESC;";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryExamName, connection);


            adapter = new SqlDataAdapter(queryExamName, connection);
            DataTable dt = new DataTable();




            connection.Open();
            adapter.Fill(dt);

            connection.Close();

            gvcompany.DataSource = dt;
            gvcompany.DataBind();





        }

        
        protected void gvcompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose LinkButton was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvcompany.Rows[rowIndex];

                 name = (row.FindControl("lblName") as Label).Text;
                
                 Address = (row.FindControl("lblAddress") as Label).Text;
                 Mobile = (row.FindControl("lblMobile") as Label).Text;
                 Email = (row.FindControl("lblEmail") as Label).Text;
                 PAN = (row.FindControl("lblPAN") as Label).Text;
                 GST = (row.FindControl("lblGST") as Label).Text;
                 IPShortCode = (row.FindControl("lblIPShortCode") as Label).Text;
                 IPYear = (row.FindControl("lblIPYear") as Label).Text;
                 IPSeriesStart = (row.FindControl("lblIPSerialNumber") as Label).Text;
                HdnId.Text = (row.FindControl("lblcompanyid") as Label).Text;
                

                txtcompynm.Text= name;
                txtcompyAddress.Text= Address;
                txtcompyemail.Text= Email;
                txtcompyPAN.Text= PAN;
                txtcompyMob.Text= Mobile;
                txtcompyGstno.Text= GST;
               

                

                btnupdate.Visible = true;
                btnsubmitCompnyDetails.Visible = false;


            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            UpdateDetails();
            if (Update == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                
                txtcompynm.Text = txtcompyAddress.Text = txtcompyMob.Text = txtcompyemail.Text = txtcompyPAN.Text = txtcompyGstno.Text = string.Empty;
                Response.Redirect("~/AddCompanyDeatil.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Updated')", true);
            }

        }

        
        protected void gvcompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            GridViewRow row = gvcompany.Rows[rowIndex];

            idofdeltingelement = (row.FindControl("lblcompanyid") as Label).Text;
            DeleteDetails(idofdeltingelement);
        }

       
    }
}
/*
*/