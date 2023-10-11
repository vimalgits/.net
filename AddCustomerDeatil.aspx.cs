using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillingSoft
{
    public partial class AddCustomerDeatil : System.Web.UI.Page
    {
        bool Insert = false;
        bool Update = false;
        bool Delete = false;
        string name = "";
        string companyid = "";
        string Id = "";
        string Address = "";
        string City = "";
        string Mobile = "";
        string Email = "";
        string PAN = "";
        string GST = "";
        string IPShortCode = "";
        string IPYear = "";
        string IPSeriesStart = "";
        string idofdeltingelement = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            customerdata();
        }


        protected void btnsubmitcustomerDetails_Click(object sender, EventArgs e)
        {
            InsertCustomer();


            if (Insert == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                customerdata();
                txtcustomernm.Text = txtcustomerAddress.Text = txtcustomeremail.Text = txtcustomerMob.Text = txtcompanynm.Text = txtcustomerPAN.Text = string.Empty;

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Inserted')", true);
            }

        }

        private void InsertCustomer()
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);

            string insertquery = "insert into " +
     "Customer_Deatils (CustomerName,CompanyId,CustomerAddress,CustomerGST,CustomerCity,CustomerMobNo,CustomerEmail,CustomerPAN,CustomerDateCreated) " +
     "values(@CustomerName,@CompanyId,@CustomerAddress,@CustomerGST,@CustomerCity,@CustomerMobNo,@CustomerEmail,@CustomerPAN,@CustomerDateCreated)";

            SqlCommand cmd = new SqlCommand(insertquery, con);
            cmd.Parameters.AddWithValue("@CustomerName", txtcustomernm.Text);
            cmd.Parameters.AddWithValue("@CompanyId", getcompanyid(txtcompanynm.Text));
            cmd.Parameters.AddWithValue("@CustomerAddress", txtcustomerAddress.Text);
            cmd.Parameters.AddWithValue("@CustomerCity", txtcustomercity.Text);
            cmd.Parameters.AddWithValue("@CustomerGST", txtcustomergst.Text);
            cmd.Parameters.AddWithValue("@CustomerMobNo", txtcustomerMob.Text);
            cmd.Parameters.AddWithValue("@CustomerEmail", txtcustomeremail.Text);
            cmd.Parameters.AddWithValue("@CustomerPAN", txtcustomerPAN.Text);
            cmd.Parameters.AddWithValue("@CustomerDateCreated", DateTime.Now.ToString("dd-MM-yyyy"));


            

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Insert = true;

        }
        [WebMethod]
        public static List<string> getCompanyNames(string prefixText)
        {
            List<string> companies = new List<string>();
            try
            {


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select CompanyName from CompanyDetails  where " +
                   "CompanyName like @SearchText + '%'";
                        cmd.Parameters.AddWithValue("@SearchText", prefixText);
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                companies.Add(dr["CompanyName"].ToString());
                            }
                        }
                        conn.Close();
                    }

                }

            }
            catch (Exception e6) { }
            return companies;
        }
        private void customerdata()
        {
            try
            {
                string query = "select * from Customer_Deatils";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtCustomer = new DataTable();




                connection.Open();
                adapter.Fill(dtCustomer);

                connection.Close();

                gvcustomers.DataSource = dtCustomer;

                gvcustomers.DataBind();
            }
            catch { }
        }
        private string getcompanyid(string x)
        {
            string cmpnyid = "";
            try
            {
                string query = "select CompanyId from CompanyDetails where CompanyName='"+x+"'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtCustomer = new DataTable();




                connection.Open();
                adapter.Fill(dtCustomer);

                connection.Close();
                cmpnyid = dtCustomer.Rows[0][0].ToString();


            }
            catch { }
            return cmpnyid;
        }
        private string getcompanynamebyid(string x)
        {
            string cmpnynm = "";
            try
            {
                string query = "select CompanyName from CompanyDetails where CompanyId ='" + x + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtCustomer = new DataTable();




                connection.Open();
                adapter.Fill(dtCustomer);

                connection.Close();
                cmpnynm = dtCustomer.Rows[0][0].ToString();


            }
            catch { }
            return cmpnynm;
        }

        private void UpdateDetails()
        {
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string insertquery = "UPDATE " +
     "Customer_Deatils SET CustomerName=@CustomerName,CompanyId=@CompanyId,CustomerAddress=@CustomerAddress," +
     "CustomerGST=@CustomerGST,CustomerCity=@CustomerCity," +
     "CustomerMobNo=@CustomerMobNo,CustomerEmail=@CustomerEmail,CustomerPAN=@CustomerPAN  Where CustomerId='" + HdnId.Text + "' ";

                SqlCommand cmd = new SqlCommand(insertquery, con);
                cmd.Parameters.AddWithValue("@CustomerName", txtcustomernm.Text);
                cmd.Parameters.AddWithValue("@CompanyId", getcompanyid(txtcompanynm.Text));
                cmd.Parameters.AddWithValue("@CustomerAddress", txtcustomerAddress.Text);
                cmd.Parameters.AddWithValue("@CustomerCity", txtcustomercity.Text);
                cmd.Parameters.AddWithValue("@CustomerGST", txtcustomergst.Text);
                cmd.Parameters.AddWithValue("@CustomerMobNo", txtcustomerMob.Text);
                cmd.Parameters.AddWithValue("@CustomerEmail", txtcustomeremail.Text);
                cmd.Parameters.AddWithValue("@CustomerPAN", txtcustomerPAN.Text);
               



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Update = true;

            }
            catch { }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            UpdateDetails();
            if (Update == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);

                
                txtcustomernm.Text = txtcustomerAddress.Text = txtcustomeremail.Text = txtcustomerMob.Text = txtcompanynm.Text = txtcustomerPAN.Text = string.Empty;
                Response.Redirect("~/AddCustomerDeatil.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Updated')", true);
            }
        }

        protected void gvcustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose LinkButton was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvcustomers.Rows[rowIndex];

                name = (row.FindControl("lblName") as Label).Text;
                companyid = (row.FindControl("lblCompanyid") as Label).Text;

                Address = (row.FindControl("lblAddress") as Label).Text;
                City = (row.FindControl("lblCity") as Label).Text;
                Mobile = (row.FindControl("lblMobile") as Label).Text;
                Email = (row.FindControl("lblEmail") as Label).Text;
                PAN = (row.FindControl("lblPAN") as Label).Text;
                GST = (row.FindControl("lblGST") as Label).Text;
                

                HdnId.Text = (row.FindControl("lblCustomerid") as Label).Text;


                txtcustomernm.Text = name;
                txtcompanynm.Text = getcompanynamebyid(companyid);
                txtcustomerAddress.Text = Address;
                txtcustomeremail.Text = Email;
                txtcustomerPAN.Text = PAN;
                txtcustomerMob.Text = Mobile;
                txtcustomergst.Text = GST;
                txtcustomercity.Text = City;


                btnupdate.Visible = true;
                btnsubmitcustomerDetails.Visible = false;


            }
        }

        protected void gvcustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            GridViewRow row = gvcustomers.Rows[rowIndex];

            idofdeltingelement = (row.FindControl("lblCustomerid") as Label).Text;
            DeleteDetails(idofdeltingelement);
        }
        private void DeleteDetails(string deleteid)
        {
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string updatequery = "delete Customer_Deatils Where CustomerId='" + deleteid + "' ";

                SqlCommand cmd = new SqlCommand(updatequery, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Delete = true;
                if (Delete == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                    customerdata();
                    txtcustomernm.Text = txtcustomerAddress.Text = txtcustomeremail.Text = txtcustomerMob.Text = txtcompanynm.Text = txtcustomerPAN.Text = string.Empty;

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Deleted')", true);
                }
            }
            catch { }
        }
    }
}