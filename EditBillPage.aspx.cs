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
    public partial class EditLedgerPage : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanyName();
                LoadCustomer();
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
        private void LoadCustomer()
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
        protected void ddlcompanynm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomerName();
            LedgerByCompanyname();
        }

        protected void ddlcustomernm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LedgerByCustomername();

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
        private void ProductServicepurchased(string invoiceno)
        {
            // Load Exam Names

            string queryExamName = "select * from ProductServicepurchased where InvoiceNo='"+ invoiceno + "'";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryExamName, connection);


            adapter = new SqlDataAdapter(queryExamName, connection);
           




            connection.Open();
            adapter.Fill(dt);

            connection.Close();

            Gvbill.DataSource = dt;
            Gvbill.DataBind();
            ViewState["Records"] = dt;

        }

        protected void gvledger_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                

                     int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvledger.Rows[rowIndex];
                string invoiceNo = (row.FindControl("lblInvoiceNo") as Label).Text;
               
                ProductServicepurchased(invoiceNo);
               string companyid = (row.FindControl("lblCompanyId") as Label).Text;
                string customerid = (row.FindControl("lblCustomerId") as Label).Text;

                LoadCompanydetails(companyid);
                LoadCustomerdetails(customerid);
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showpopup(); ", true);
            }
        }

        protected void Gvbill_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = (DataTable)ViewState["Records"];
            dt.Rows[index].Delete();
            ViewState["Records"] = dt;
            double totalamount = 0;
           /* try {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalamount += double.Parse(dt.Rows[i][4].ToString());
                }
            }
            catch { }   */
           
            txttotalamount.Text = totalamount.ToString();

            Gvbill.DataSource = dt;
            Gvbill.DataBind();
        }
        private void LoadCompanydetails(string companyId)
        {
            

            try
            {
                string query = "select * from CompanyDetails where CompanyId = '" + companyId + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtCompanydetails = new DataTable();




                connection.Open();
                adapter.Fill(dtCompanydetails);
               
                txtcompanynm.Text = dtCompanydetails.Rows[0]["CompanyName"].ToString();
                txtcompanyaddress.Text = dtCompanydetails.Rows[0]["CompanyAddress"].ToString();
                

                connection.Close();

            }
            catch (Exception e4) { }


        }
        private void LoadCustomerdetails(string customerid)
        {

            try
            {
                string query = "select * from Customer_Deatils where CustomerId = '" + customerid + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtCustomerdetails = new DataTable();

                connection.Open();
                adapter.Fill(dtCustomerdetails);
                txtcustomernm.Text= dtCustomerdetails.Rows[0]["CustomerName"].ToString();
                txtcustomeraddress.Text = dtCustomerdetails.Rows[0]["CustomerAddress"].ToString();
                
                connection.Close();
            }
            catch (Exception e5) { }




        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private string LoadProductQty(string id)
        {
            string result = "";
            try
            {
                // Load CompanyName Names

                string query = "select ServiceOrProductQty from ProductServices where ServiceOrProductCompanyId = '" + txtcompanyid.Text.Trim() + "'and ServiceOrProductId ='" + id + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtProductQty = new DataTable();




                connection.Open();
                adapter.Fill(dtProductQty);
                connection.Close();
                result = dtProductQty.Rows[0][0].ToString();

            }
            catch (Exception e2) { }
            return result;
        }
        

       
        private DataTable LoadProductDetails(string productid)
        {
            DataTable dtProductPrice = new DataTable();
            try
            {
                // Load CompanyName Names

                string query = "select * from ProductServices where ServiceOrProductCompanyId= '" + txtcompanyid.Text.Trim() + "'and ServiceOrProductId ='" + productid + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);





                connection.Open();
                adapter.Fill(dtProductPrice);
                connection.Close();


            }
            catch (Exception e1) { }
            return dtProductPrice;
        }
        private string getProductId(string productnm)
        {


            string[] list = productnm.Trim().Split('-');

            string productidintxt = list[1];


            return productidintxt;
        }
        protected void btnaddtobill_Click(object sender, EventArgs e)
        {
            try
            {

                string productnmintxt = txtproductorService.Text;


                string productidintxt = getProductId(productnmintxt);
                // Iterate through the matches and extract the numbers


                int Qty = int.Parse(txtQuantity.Text);

                string productidindt = LoadProductDetails(productidintxt).Rows[0]["ServiceOrProductId"].ToString();
                string productnmindt = LoadProductDetails(productidintxt).Rows[0]["ServiceOrProductName"].ToString();

                string Beforetaxprice = LoadProductDetails(productidintxt).Rows[0]["BeforeTaxPrice"].ToString();
                string Aftertaxprice = LoadProductDetails(productidintxt).Rows[0]["AfterTaxPrice"].ToString();
                string gst = LoadProductDetails(productidintxt).Rows[0]["GST"].ToString();
                string cgst = LoadProductDetails(productidintxt).Rows[0]["CGST"].ToString();
                string sgst = LoadProductDetails(productidintxt).Rows[0]["SGST"].ToString();




                dt = (DataTable)ViewState["Records"];
                if (dt.Rows.Count > 0)
                {
                    if (productidintxt == dt.Rows[dt.Rows.Count - 1]["ProductId"].ToString())
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            dr.BeginEdit();
                            dr["Qty"] = int.Parse(dr["Qty"].ToString()) + int.Parse(txtQuantity.Text);
                            //.....
                            dr["Amount"] = int.Parse(dr["Amount"].ToString()) * int.Parse(dr["Qty"].ToString());
                            dr.EndEdit();
                        }

                        double totalamount = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            totalamount += double.Parse(dt.Rows[i][6].ToString());
                        }
                        txttotalamount.Text = totalamount.ToString();




                        Gvbill.DataSource = dt;
                        Gvbill.DataBind();
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();

                        dr[0] = productnmindt;
                        dr[1] = Qty;
                        dr[2] = Beforetaxprice;
                        dr[3] = gst;
                        dr[4] = cgst;
                        dr[5] = sgst;
                        var amount = double.Parse(Aftertaxprice) * double.Parse(txtQuantity.Text);
                        dr[6] = amount;
                        dr[7] = productidindt;

                        dt.Rows.Add(dr);
                        double totalamount = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            totalamount += double.Parse(dt.Rows[i][6].ToString());
                        }
                        txttotalamount.Text = totalamount.ToString();

                        Gvbill.DataSource = dt;
                        Gvbill.DataBind();
                    }
                }
                else
                {


                    DataRow dr = dt.NewRow();

                    dr[0] = productnmindt;
                    dr[1] = Qty;
                    dr[2] = Beforetaxprice;
                    dr[3] = gst;
                    dr[4] = cgst;
                    dr[5] = sgst;
                    var amount = double.Parse(Aftertaxprice) * double.Parse(txtQuantity.Text);
                    dr[6] = amount;
                    dr[7] = productidindt;

                    dt.Rows.Add(dr);
                    double totalamount = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalamount += double.Parse(dt.Rows[i][6].ToString());
                    }
                    txttotalamount.Text = totalamount.ToString();

                    Gvbill.DataSource = dt;
                    Gvbill.DataBind();
                }


            }
            catch { }
        }

        protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCompclick_Click(object sender, EventArgs e)
        {

        }

        protected void btnCustomerClick_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {

        }

        protected void btnIncrement_Click1(object sender, EventArgs e)
        {
            try
            {
                int quantity = int.Parse(txtQuantity.Text);
                if (int.Parse(LoadProductQty(getProductId(txtproductorService.Text)).ToString()) > quantity)
                {
                    quantity++;
                    txtQuantity.Text = quantity.ToString();
                }
            }
            catch (Exception e8) { }
        }

        protected void btnDecrement_Click1(object sender, EventArgs e)
        {
            try
            {
                int quantity = int.Parse(txtQuantity.Text);
                if (quantity > 1)
                {
                    quantity--;
                    txtQuantity.Text = quantity.ToString();
                }
            }
            catch (Exception e8) { }
        }
    }
}