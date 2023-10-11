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
    public partial class EditCompanyDetail : System.Web.UI.Page
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
            ddlcompanynm.Items.Insert(0, new ListItem("Select Company", ""));
            ddlcompanynm.SelectedIndex = 0;
        }

        private void CompanyDetailsByCompanyname()
        {
            // Load Exam Names

            string queryExamName = "select * from CompanyDetails where CompanyId='" + ddlcompanynm.SelectedValue + "'";
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

        protected void ddlcompanynm_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDetailsByCompanyname();
        }
        private void CompanyDetailsByDate()
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

            gvcompany.DataSource = dt;
            gvcompany.DataBind();


        }
        protected void txtdateend_TextChanged(object sender, EventArgs e)
        {
            CompanyDetailsByDate();
        }
    }
}