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
    public partial class PrintOfBill1 : System.Web.UI.Page
    {
        string Invoiceno = "";
        double totalamount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Rowtotal"] != null && Request.QueryString["Billdate"] != null && Request.QueryString["Discount"] != null && Request.QueryString["Finaltotal"] != null && Request.QueryString["Invoiceno"] != null && Request.QueryString["Companyname"] != null && Request.QueryString["Companyaddress"] != null && Request.QueryString["Companyemail"] != null && Request.QueryString["Companymobile"] != null && Request.QueryString["Companypan"] != null)
                {
                    Invoiceno = Request.QueryString["Invoiceno"].ToString();
                    lblInvoiceno.Text = Invoiceno;
                    lblcompanynm.Text = Request.QueryString["Companyname"].ToString();
                    lblcompanyadd.Text = Request.QueryString["Companyaddress"].ToString();
                    lblcompanyemail.Text = Request.QueryString["Companyemail"].ToString();
                    lblcompanymobile.Text = Request.QueryString["Companymobile"].ToString();
                    lblcompanypan.Text = Request.QueryString["Companypan"].ToString();



                    lblcustomernm.Text = Request.QueryString["Customername"].ToString();
                    lblcustomeraddress.Text = Request.QueryString["Customeraddress"].ToString();
                    lblcustomeremail.Text = Request.QueryString["Customeremail"].ToString();
                    lblcustomermobile.Text = Request.QueryString["Customermobile"].ToString();
                    lblcustomerpan.Text = Request.QueryString["Customerpan"].ToString();

                    lblInvoicedate.Text = Request.QueryString["Billdate"].ToString();
                    ltrTotalAmount.Text = Request.QueryString["Rowtotal"].ToString();
                    ltrdiscount.Text = Request.QueryString["Discount"].ToString();

                    ltrFinalAmount.Text = Request.QueryString["Finaltotal"].ToString();




                }
            }
            catch (Exception)
            {

            }
            loaddata();
        }
        private void loaddata()
        {
            try
            {
                string query = "select * from ProductServicepurchased where InvoiceNo = '" + Invoiceno + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtBilldetails = new DataTable();




                connection.Open();
                adapter.Fill(dtBilldetails);

                connection.Close();



                GvBillPrint.DataSource = dtBilldetails;
                GvBillPrint.DataBind();




            }
            catch (Exception e5) { }

        }
    }
}