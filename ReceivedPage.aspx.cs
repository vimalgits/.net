using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillingSoft
{
    public partial class ReceivedPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                LoadCompanyName();

            }
        }
       private void LoadCompanyName()
        {
            // Load CompanyName Names

            string query = "select distinct CompanyName,CompanyId from CompanyDetails";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            adapter = new SqlDataAdapter(query, connection);
            DataTable dtCompanynm = new DataTable();




            connection.Open();
            adapter.Fill(dtCompanynm);

            connection.Close();

            ddlcompanynm.DataSource = dtCompanynm;
            ddlcompanynm.DataTextField = "CompanyName";
            ddlcompanynm.DataValueField = "CompanyId";
            ddlcompanynm.DataBind();
            ddlcompanynm.Items.Insert(0, new ListItem("Select Company", " "));
            ddlcompanynm.SelectedIndex = 0;


        }
        private void LoadCustomerName()
        {
            // Load CompanyName Names

            string query = "select distinct CustomerName,CustomerId from Customer_Deatils where CompanyId='"+ddlcompanynm.SelectedValue+"'";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            adapter = new SqlDataAdapter(query, connection);
            DataTable dtCompanyId = new DataTable();




            connection.Open();
            adapter.Fill(dtCompanyId);

            connection.Close();

            ddlcustomernm.DataSource = dtCompanyId;
            ddlcustomernm.DataTextField = "CustomerName";
            ddlcustomernm.DataValueField = "CustomerId";
            ddlcustomernm.DataBind();
            ddlcustomernm.Items.Insert(0, new ListItem("Select Customer", " "));
            ddlcustomernm.SelectedIndex = 0;
        }
        private string GetDuebyid(string idcustomer)
        {

            string val = "";
            string xyz = "0";
            try
            {
                string query = "select Balance from Ledger_Main_log where CustomerId = '" + idcustomer + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter = new SqlDataAdapter(query, connection);
                DataTable dtDue = new DataTable();

                connection.Open();
                adapter.Fill(dtDue);
                connection.Close();



                val = dtDue.Rows[dtDue.Rows.Count - 1]["Balance"].ToString();

                xyz = Math.Round(double.Parse(val), 2).ToString();
                txtDue.Text = xyz.ToString();

                
                


            }
            catch (Exception) { }

            return xyz;
        }

        protected void ddlcustomernm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDue.Text = (GetDuebyid(ddlcustomernm.SelectedValue)).ToString();
        }

    
        private void datatomain()
        {
            try
            {
                string invoiceno = "";
                string Paymentmode = ddlPaymentMode.SelectedItem.Text;
                string datecreated = "";
                double Amount = double.Parse(txtamount.Text.ToString());

                double Due = double.Parse(GetDuebyid(ddlcustomernm.SelectedValue));

                double Bal = Math.Abs(Due) - Amount;
                double RemainBal = Math.Abs(Due) + Amount;

                string insertQuery = "insert into " +
                      "Ledger_Main (InvoiceNo,CompanyId,CustomerId,Credit,Debit,Balance,Payment_Mode,RepeatInfo,Cheque_No,DateBillCreated,SeriesInfo) " +
                      "values(@InvoiceNo,@Company_Name,@CustomerId,@Credit,@Debit,@Balance,@Payment_Mode,@RepeatInfo,@Cheque_No,@DateBillCreated,@SeriesInfo)";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);

                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                cmd.Parameters.AddWithValue("@CompanyId", "");
                cmd.Parameters.AddWithValue("@CustomerId", ddlcustomernm.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@RepeatInfo", 0);


                cmd.Parameters.AddWithValue("@Debit", 0);
                cmd.Parameters.AddWithValue("@Credit", Amount);
                if (Bal > 0)
                {
                    cmd.Parameters.AddWithValue("@Balance", "-" + Bal);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Balance", Bal);
                }

                if (Paymentmode.ToString().ToLower() == "Select Payment Mode".ToLower())
                {
                    cmd.Parameters.AddWithValue("@Payment_Mode", "NA");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Payment_Mode", Paymentmode);
                }


                cmd.Parameters.AddWithValue("@Cheque_No", 0);
                cmd.Parameters.AddWithValue("@DateBillCreated", datecreated);
                cmd.Parameters.AddWithValue("@SeriesInfo", "");


                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch {

            }
        }
        private void datatomainlog()
        {
            try
            {
                string invoiceno = "";
                string Paymentmode = ddlPaymentMode.SelectedItem.Text;
                string datecreated = "";
                double Amount = double.Parse(txtamount.Text.ToString());

                double Due = double.Parse(GetDuebyid(ddlcustomernm.SelectedValue).ToString());

                double Bal = Math.Abs(Due) - Amount;
                double RemainBal = Math.Abs(Due) + Amount;

                string insertQuery = "insert into " +
                      "Ledger_Main_log (InvoiceNo,CompanyId,CustomerId,Credit,Debit,Balance,Payment_Mode,RepeatInfo,Cheque_No,DateBillCreated) " +
                      "values(@InvoiceNo,@CompanyId,@CustomerId,@Credit,@Debit,@Balance,@Payment_Mode,@RepeatInfo,@Cheque_No,@DateBillCreated)";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);

                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                cmd.Parameters.AddWithValue("@CompanyId", "");
                cmd.Parameters.AddWithValue("@CustomerId", ddlcustomernm.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@RepeatInfo", 0);


                cmd.Parameters.AddWithValue("@Debit", 0);
                cmd.Parameters.AddWithValue("@Credit", Amount);
                if (Bal > 0)
                {
                    cmd.Parameters.AddWithValue("@Balance", "-" + Bal);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Balance", Bal);
                }

                if (Paymentmode.ToString().ToLower() == "Select Payment Mode".ToLower())
                {
                    cmd.Parameters.AddWithValue("@Payment_Mode", "NA");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Payment_Mode", Paymentmode);
                }


                cmd.Parameters.AddWithValue("@Cheque_No", 0);
                cmd.Parameters.AddWithValue("@DateBillCreated", datecreated);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
        }

        protected void btnreceived_Click(object sender, EventArgs e)
        {
            datatomain();
            datatomainlog();
            ddlcustomernm.SelectedIndex = 0; ddlcompanynm.SelectedIndex = 0;
            txtamount.Text = txtDue.Text= string.Empty;
        }

        protected void ddlcompanynm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomerName();
        }
    }
}