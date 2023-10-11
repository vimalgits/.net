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
    public partial class ViewLedger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanyName();
                LoadCustomerName();


            }
        }


        protected void ddlcompanynm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LedgerByCompanyname();
        }

        protected void ddlcustomernm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LedgerByCustomername();
            LoadCustomerNameByCompanyId();
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
            ddlcompanynm.Items.Insert(0, new ListItem("Select Company", ""));
            ddlcompanynm.SelectedIndex = 0;
        }
        private void LoadCustomerName()
        {
            // Load CompanyName Names

            string query = "select CustomerId,CustomerName from Customer_Deatils";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            adapter = new SqlDataAdapter(query, connection);
            DataTable dtCustomernm = new DataTable();




            connection.Open();
            adapter.Fill(dtCustomernm);

            connection.Close();

            ddlcustomernm.DataSource = dtCustomernm;
            ddlcustomernm.DataTextField = "CustomerName";
            ddlcustomernm.DataValueField = "CustomerId";
            ddlcustomernm.DataBind();
            ddlcustomernm.Items.Insert(0, new ListItem("Select Customer", ""));
            ddlcustomernm.SelectedIndex = 0;
        }
        private void LoadCustomerNameByCompanyId()
        {
            // Load CompanyName Names
            if (ddlcompanynm.SelectedValue != " ")
            {
                string query = "select distinct CustomerName,CustomerId from Customer_Deatils where CompanyId='" + ddlcompanynm.SelectedValue + "'";
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

                ddlcustomernm.Items.Insert(0, new ListItem("Select Customer", ""));
                ddlcustomernm.SelectedIndex = 0;
            }


        }
        private void LedgerByCustomername()
        {
            // Load Exam Names

            string queryExamName = "select * from Ledger_Main where CustomerId='" + ddlcustomernm.SelectedValue + "'";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryExamName, connection);


            adapter = new SqlDataAdapter(queryExamName, connection);
            DataTable dtExamNames = new DataTable();




            connection.Open();
            adapter.Fill(dtExamNames);

            connection.Close();

            gvledger.DataSource = dtExamNames;
            gvledger.DataBind();


        }
        private void LedgerByCompanyname()
        {
            // Load Exam Names

            string queryExamName = "select * from Ledger_Main where CompanyId='" + ddlcompanynm.SelectedValue + "'";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryExamName, connection);


            adapter = new SqlDataAdapter(queryExamName, connection);
            DataTable dt = new DataTable();




            connection.Open();
            adapter.Fill(dt);

            connection.Close();

            gvledger.DataSource = dt;
            gvledger.DataBind();


        }
        private void LedgerByDate()
        {
            // Load Exam Names

            string queryExamName = "select * from Ledger_Main where DateBillCreated BETWEEN '" + txtdatestart.Text + "' AND '" + txtdateend.Text + "'";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryExamName, connection);


            adapter = new SqlDataAdapter(queryExamName, connection);
            DataTable dt = new DataTable();




            connection.Open();
            adapter.Fill(dt);

            connection.Close();

            gvledger.DataSource = dt;
            gvledger.DataBind();


        }

        protected void txtdateend_TextChanged(object sender, EventArgs e)
        {
            LedgerByDate();

        }
    }
}