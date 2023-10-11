using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;

namespace BillingSoft
{
    public partial class GenerateBillPages : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Loadpage();
        }
        DataTable dt = new DataTable();

        private void Loadpage()
        {


            if (!IsPostBack)
            {


                try
                {
                    if (ViewState["Records"] == null)
                    {

                        dt.Columns.Add("Product Description");
                        dt.Columns.Add("Qty");
                        dt.Columns.Add("Rate");
                        dt.Columns.Add("gst");
                        dt.Columns.Add("cgst");
                        dt.Columns.Add("sgst");
                        dt.Columns.Add("Amount");
                        dt.Columns.Add("ProductId");
                        ViewState["Records"] = dt;
                    }
                }
                catch (Exception e) { }
            }

            if (ddlPaymentMode.SelectedItem.Text.ToLower().Trim() == "select payment mode")
            {

                lblPayment.Text = "UnPaid";
            }
            else
            {
                lblPayment.Text = "Paid";
            }

            //

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
        //load product Qty
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
        //get customer details on 

        protected void btnCustomerClick_Click(object sender, EventArgs e)
        {
            LoadCustomerdetails(txtcustomernm.Text);
        }
        private string getSeriesInfo(string companyId)
        {
            string lastitem = "";
            try
            {
                string query = "select  SeriesInfo from Ledger_Main where CompanyId = '" + companyId + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtSeriesInfo = new DataTable();
                DataTable dtSeriesInfoSorted = new DataTable();

                connection.Open();
                adapter.Fill(dtSeriesInfo);
                connection.Close();

                DataView dv = dtSeriesInfo.DefaultView;
                dv.Sort = "SeriesInfo DESC";
                dtSeriesInfoSorted = dv.ToTable();

                lastitem = dtSeriesInfoSorted.Rows[0][0].ToString();
            }
            catch (Exception e2) { }
            return lastitem;
        }
        private void LoadCompanydetails(string companyId)
        {
            ViewState["companyId"] = companyId;

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
                double SerialnoinLedger = 0;
                string Serialno = "";
                string lastiteminledger = getSeriesInfo(companyId);
                string[] words = lastiteminledger.Split('-');
                if (words[0]!="")
                {
                     SerialnoinLedger = double.Parse(words[1]);
                }
                
                string shortcode = dtCompanydetails.Rows[0]["IPShortCode"].ToString();
                string yearofip = dtCompanydetails.Rows[0]["IPYear"].ToString();
                double x = double.Parse(dtCompanydetails.Rows[0]["IPSerialNumber"].ToString());
                if (x < SerialnoinLedger)
                {
                    SerialnoinLedger++;
                    Serialno = SerialnoinLedger.ToString();
                    
                }
                else
                {
                    x++;
                    Serialno = x.ToString();
                }
                

                
                ViewState["seriesInfo"] = companyId + "-" + Serialno;


                    txtinvoice.Text = shortcode + yearofip + Serialno;
                

                txtcompanyid.Text = dtCompanydetails.Rows[0]["CompanyId"].ToString();
                txtcompanynm.Text = dtCompanydetails.Rows[0]["CompanyName"].ToString();
                txtcompanyaddress.Text = dtCompanydetails.Rows[0]["CompanyAddress"].ToString();
                txtcompanyemail.Text = dtCompanydetails.Rows[0]["CompanyEmail"].ToString();
                txtcompanymob.Text = dtCompanydetails.Rows[0]["CompanyMobNo"].ToString();
                txtcompanypan.Text = dtCompanydetails.Rows[0]["CompanyPAN"].ToString();

                connection.Close();

            }
            catch (Exception e4) { }


        }
        private void LoadCustomerdetails(string customername)
        {

            try
            {
                string query = "select * from Customer_Deatils where CustomerName = '" + customername + "'";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dtCustomerdetails = new DataTable();




                connection.Open();
                adapter.Fill(dtCustomerdetails);
                txtcustomeraddress.Text = dtCustomerdetails.Rows[0]["CustomerAddress"].ToString();
                txtcustomermob.Text = dtCustomerdetails.Rows[0]["CustomerMobNo"].ToString();
                txtcustomeremail.Text = dtCustomerdetails.Rows[0]["CustomerEmail"].ToString();
                txtcustomerpan.Text = dtCustomerdetails.Rows[0]["CustomerPAN"].ToString();

                hfcustomerid.Value = dtCustomerdetails.Rows[0]["CustomerId"].ToString();
                if (hfcustomerid.Value != "")
                {
                    GetDuebyid(hfcustomerid.Value);
                }
                else
                {

                }
                connection.Close();
            }
            catch (Exception e5) { }




        }




        [WebMethod]
        public static Dictionary<string, string> getCompanyNames(string prefixText)
        {
            Dictionary<string, string> companies = new Dictionary<string, string>();

            try
            {


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select CompanyName,CompanyId from CompanyDetails  where " +
                   "CompanyName like @SearchText + '%'";
                        cmd.Parameters.AddWithValue("@SearchText", prefixText);
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string companyId = dr["CompanyId"].ToString();
                                string companyName = dr["CompanyName"].ToString();
                                companies.Add(companyId, companyName);
                            }
                        }
                        conn.Close();
                    }

                }

            }
            catch (Exception e6) { }
            return companies;
        }
        [WebMethod]
        public static List<string> getCustomerNames(string prefixTextcustomer)
        {
            List<string> custmer = new List<string>();
            try
            {


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select CustomerName from Customer_Deatils  where " +
                   "CustomerName like @SearchText + '%'";
                        cmd.Parameters.AddWithValue("@SearchText", prefixTextcustomer);
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                custmer.Add(dr["CustomerName"].ToString());
                            }
                        }
                        conn.Close();
                    }

                }

            }
            catch (Exception e7) { }
            return custmer;
        }
        [WebMethod]
        public static Dictionary<string, string> getProduct(string prefixText, string CompanyId)
        {

            Dictionary<string, string> products = new Dictionary<string, string>();

            try
            {


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select ServiceOrProductName,ServiceOrProductId from ProductServices where ServiceOrProductCompanyId=@ServiceOrProductCompanyId and ServiceOrProductName like @SearchText + '%'";
                        cmd.Parameters.AddWithValue("@SearchText", prefixText);
                        cmd.Parameters.AddWithValue("@ServiceOrProductCompanyId", CompanyId);
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string productId = dr["ServiceOrProductId"].ToString();
                                string productName = dr["ServiceOrProductName"].ToString();
                                products.Add(productId, productName);
                                //products.Add(dr["ServiceOrProductName"].ToString());
                            }
                        }
                        conn.Close();
                    }

                }

            }
            catch (Exception e6) { }
            return products;
        }
        protected void btnIncrement_Click(object sender, EventArgs e)
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

        protected void btnDecrement_Click(object sender, EventArgs e)
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

        private string getProductId(string productnm)
        {


            string[] list = productnm.Trim().Split('-');

            string productidintxt = list[1];


            return productidintxt;
        }

        protected void btnaddtobill_Click(object sender, EventArgs e)
        {

            lbltotalamt.Visible = true;

            lbltotal.Visible = true;

            txtTotal.Visible = true;
            txttotalamount.Visible = true;

            btnGeneratebill.Visible = true;
            lblpersign.Visible = true;

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


        private void insertdatatomain()
        {

            try
            {
                string res = txtcompanynm.Text.Substring(0, 3).ToUpper();
                string invoiceno = txtinvoice.Text;
                string Paymentmode = ddlPaymentMode.SelectedItem.Text;
                string datecreated = txtdateofbilling.Text;
                double Amount = double.Parse(txtTotal.Text.ToString());
                string seriesinfo = ViewState["seriesInfo"].ToString();
                string companyid = ViewState["companyId"].ToString();

                if (lblPayment.Text.ToLower() == "paid")
                {
                    for (int i = 0; i < 2; i++)
                    {


                        double Due = double.Parse(ViewState["due"].ToString());

                        double Bal = Math.Abs(Due) - Amount;
                        double RemainBal = double.Parse(ViewState["RemainBal"].ToString());

                        string insertQuery = "insert into " +
                              "Ledger_Main (InvoiceNo,CompanyId,CustomerId,Credit,Debit,Balance,Payment_Mode,RepeatInfo,Cheque_No,DateBillCreated,SeriesInfo) " +
                              "values(@InvoiceNo,@CompanyId,@CustomerId,@Credit,@Debit,@Balance,@Payment_Mode,@RepeatInfo,@Cheque_No,@DateBillCreated,@SeriesInfo)";
                        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                        SqlConnection connection = new SqlConnection(ConnectionString);

                        SqlCommand cmd = new SqlCommand(insertQuery, connection);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@CompanyId", companyid);
                        cmd.Parameters.AddWithValue("@CustomerId", hfcustomerid.Value);
                        cmd.Parameters.AddWithValue("@Amount", Amount);
                        cmd.Parameters.AddWithValue("@RepeatInfo", ddlrepeat.SelectedValue);
                        cmd.Parameters.AddWithValue("@SeriesInfo", seriesinfo);
                        if (i == 0)
                        {
                            cmd.Parameters.AddWithValue("@Credit", 0);
                            cmd.Parameters.AddWithValue("@Debit", Amount);
                            cmd.Parameters.AddWithValue("@Balance", "-" + RemainBal);
                        }
                        else if (i == 1)
                        {
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


                }

                else if (lblPayment.Text.ToLower() == "unpaid")
                {

                    Amount = double.Parse(txtTotal.Text.ToString());
                    double Due = double.Parse(ViewState["dueinunpaid"].ToString());
                    double Bal = Amount + Math.Abs(Due);

                    Paymentmode = ddlPaymentMode.SelectedItem.Text;

                    string insertQuery = "insert into " +
                          "Ledger_Main (InvoiceNo,CompanyId,CustomerId,Credit,Debit,Balance,Payment_Mode,RepeatInfo,Cheque_No,DateBillCreated,SeriesInfo) " +
                          "values(@InvoiceNo,@CompanyId,@CustomerId,@Credit,@Debit,@Balance,@Payment_Mode,@RepeatInfo,@Cheque_No,@DateBillCreated,@SeriesInfo)";
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                    SqlConnection connection = new SqlConnection(ConnectionString);

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);

                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                    cmd.Parameters.AddWithValue("@CompanyId", companyid);
                    cmd.Parameters.AddWithValue("@CustomerId", hfcustomerid.Value);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@RepeatInfo", ddlrepeat.SelectedValue);

                    cmd.Parameters.AddWithValue("@Credit", 0);
                    cmd.Parameters.AddWithValue("@Debit", Amount);
                    cmd.Parameters.AddWithValue("@Balance", "-" + Bal);
                    cmd.Parameters.AddWithValue("@SeriesInfo", seriesinfo);



                    if (Paymentmode.ToString().ToLower() == "Select Payment Mode".ToLower())
                    {
                        cmd.Parameters.AddWithValue("@Payment_Mode", "NA");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Payment_Mode", Paymentmode);
                    }


                    cmd.Parameters.AddWithValue("@Cheque_No", 0);
                    cmd.Parameters.AddWithValue("@DateBillCreated", txtdateofbilling.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {

                }
            }
            catch { }

        }
        private void insertdataProductServicepurchased()
        {

            int x = 0;
            foreach (GridViewRow row in Gvbill.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    Literal ltrProduct = row.FindControl("ltrProduct") as Literal;
                    Literal ltrQty = row.FindControl("ltrQty") as Literal;
                    Literal ltrRate = row.FindControl("ltrRate") as Literal;
                    Literal ltrAmount = row.FindControl("ltrAmount") as Literal;

                    Literal ltrGST = row.FindControl("ltrGST") as Literal;
                    Literal ltrCGST = row.FindControl("ltrCGST") as Literal;
                    Literal ltrSGST = row.FindControl("ltrSGST") as Literal;

                    string invoiceno = txtinvoice.Text;
                    string Product = ltrProduct.Text;
                    string Qty = ltrQty.Text;
                    string Rate = ltrRate.Text;
                    string Amount = ltrAmount.Text;

                    string GST = ltrGST.Text;
                    string CGST = ltrCGST.Text;
                    string SGST = ltrSGST.Text;

                    string res = txtcompanynm.Text.Substring(0, 3).ToUpper();

                    string insertQuery = "insert into " +
                     "ProductServicepurchased (InvoiceNo,ServiceOrProductName,Qty,Rate,Amount,GST,CGST,SGST) " +
                     "values(@InvoiceNo,@ServiceOrProductName,@Qty,@Rate,@Amount,@GST,@CGST,@SGST)";

                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                    SqlConnection connection = new SqlConnection(ConnectionString);

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);

                    cmd.Parameters.AddWithValue("@ServiceOrProductName", Product);
                    cmd.Parameters.AddWithValue("@Qty", Qty);
                    cmd.Parameters.AddWithValue("@Rate", Rate);
                    cmd.Parameters.AddWithValue("@Amount", Amount);

                    cmd.Parameters.AddWithValue("@GST", GST);
                    cmd.Parameters.AddWithValue("@CGST", CGST);
                    cmd.Parameters.AddWithValue("@SGST", SGST);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    x++;

                }
            }
            if (x > 0)
            {
                Response.Write("Data Inserted");

            }
            else { Response.Write("Data Not Inserted"); }
        }
        private void insertdatatomainlog()
        {

            try
            {
                string res = txtcompanynm.Text.Substring(0, 3).ToUpper();
                string invoiceno = txtinvoice.Text;
                string Paymentmode = ddlPaymentMode.SelectedItem.Text;
                string datecreated = txtdateofbilling.Text;
                double Amount = double.Parse(txtTotal.Text.ToString());
                string companyid = ViewState["companyId"].ToString();
                if (lblPayment.Text.ToLower() == "paid")
                {
                    for (int i = 0; i < 2; i++)
                    {


                        double Due = double.Parse(GetDuebyid(hfcustomerid.Value).ToString());

                        ViewState["due"] = Due;

                        double Bal = Math.Abs(Due) - Amount;
                        double RemainBal = Math.Abs(Due) + Amount;
                        string insertQuery = "insert into " +
                              "Ledger_Main_log (InvoiceNo,CompanyId,CustomerId,Credit,Debit,Balance,Payment_Mode,RepeatInfo,Cheque_No,DateBillCreated) " +
                              "values(@InvoiceNo,@CompanyId,@CustomerId,@Credit,@Debit,@Balance,@Payment_Mode,@RepeatInfo,@Cheque_No,@DateBillCreated)";
                        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                        SqlConnection connection = new SqlConnection(ConnectionString);

                        SqlCommand cmd = new SqlCommand(insertQuery, connection);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@CompanyId", companyid);
                        cmd.Parameters.AddWithValue("@CustomerId", hfcustomerid.Value);
                        cmd.Parameters.AddWithValue("@Amount", Amount);
                        cmd.Parameters.AddWithValue("@RepeatInfo", ddlrepeat.SelectedValue);
                        if (i == 0)
                        {
                            cmd.Parameters.AddWithValue("@Credit", 0);
                            cmd.Parameters.AddWithValue("@Debit", Amount);
                            cmd.Parameters.AddWithValue("@Balance", "-" + RemainBal);
                            ViewState["RemainBal"] = RemainBal;

                        }
                        else if (i == 1)
                        {
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


                }

                else if (lblPayment.Text.ToLower() == "unpaid")
                {

                    Amount = double.Parse(txtTotal.Text.ToString());
                    double Due = double.Parse(GetDuebyid(hfcustomerid.Value).ToString());
                    ViewState["dueinunpaid"] = Due;
                    double Bal = Amount + Math.Abs(Due);

                    Paymentmode = ddlPaymentMode.SelectedItem.Text;

                    string insertQuery = "insert into " +
                          "Ledger_Main_log (InvoiceNo,CompanyId,CustomerId,Credit,Debit,Balance,Payment_Mode,RepeatInfo,Cheque_No,DateBillCreated) " +
                          "values(@InvoiceNo,@CompanyId,@CustomerId,@Credit,@Debit,@Balance,@Payment_Mode,@RepeatInfo,@Cheque_No,@DateBillCreated)";
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                    SqlConnection connection = new SqlConnection(ConnectionString);

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);

                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                    cmd.Parameters.AddWithValue("@CompanyId", companyid);
                    cmd.Parameters.AddWithValue("@CustomerId", hfcustomerid.Value);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@RepeatInfo", ddlrepeat.SelectedValue);

                    cmd.Parameters.AddWithValue("@Credit", 0);
                    cmd.Parameters.AddWithValue("@Debit", Amount);
                    cmd.Parameters.AddWithValue("@Balance", "-" + Bal);




                    if (Paymentmode.ToString().ToLower() == "Select Payment Mode".ToLower())
                    {
                        cmd.Parameters.AddWithValue("@Payment_Mode", "NA");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Payment_Mode", Paymentmode);
                    }


                    cmd.Parameters.AddWithValue("@Cheque_No", 0);
                    cmd.Parameters.AddWithValue("@DateBillCreated", txtdateofbilling.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {

                }
            }
            catch { }


        }
        //generate bill
        protected void btnGeneratebill_Click(object sender, EventArgs e)
        {

            insertdatatomainlog();
            insertdatatomain();

            insertdataProductServicepurchased();


            var Invoice = txtinvoice.Text;

            //company info
            var companyname = txtcompanynm.Text.Trim();
            var companyaddress = txtcompanyaddress.Text.Trim();
            var companyemail = txtcompanyemail.Text.Trim();
            var companymobile = txtcompanymob.Text.Trim();
            var companypan = txtcompanypan.Text.Trim();
            // customer info
            var customername = txtcustomernm.Text.Trim();
            var customeraddress = txtcustomeraddress.Text.Trim();
            var customeremail = txtcustomeremail.Text.Trim();
            var customermobile = txtcustomermob.Text.Trim();
            var customerpan = txtcustomerpan.Text.Trim();

            //BILL info
            var Billdate = txtdateofbilling.Text.Trim();
            var Rowtotal = txttotalamount.Text.Trim();
            var discount = txtDiscount.Text.Trim();

            var Finaltotal = txtTotal.Text.Trim();



            string responseUrl = "PrintOfBill.aspx?";
            responseUrl += "Invoiceno=" + Invoice + "&Companyname=" + companyname + "&Billdate=" + Billdate + "&Companyaddress=" + companyaddress + "&Companyemail=" + companyemail + "&Companymobile=" + companymobile + "&Companypan=" + companypan;

            responseUrl += "&Customername=" + customername + "&Customeraddress=" + customeraddress + "&Customeremail=" + customeremail + "&Customermobile=" + customermobile + "&Customerpan=" + customerpan;

            responseUrl += "&Rowtotal=" + Rowtotal + "&Discount=" + discount + "&Finaltotal=" + Finaltotal;





            Response.Redirect(responseUrl);




        }

        protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlPaymentMode.SelectedItem.Text.ToLower().Trim() == "select payment mode")
            {

                lblPayment.Text = "UnPaid";
            }
            else
            {
                lblPayment.Text = "Paid";
            }
        }


        private int GetDuebyid(string idcustomer)
        {

            string val = "";
            int xyz = 0;
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


                txtDue.Text = val.ToString();


                xyz = int.Parse(val.ToString());


            }
            catch (Exception) { }

            return xyz;
        }



        protected void Gvbill_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = (DataTable)ViewState["Records"];
            dt.Rows[index].Delete();
            ViewState["Records"] = dt;
            double totalamount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalamount += double.Parse(dt.Rows[i][6].ToString());
            }
            txttotalamount.Text = totalamount.ToString();

            Gvbill.DataSource = dt;
            Gvbill.DataBind();
        }




        protected void btnCompclick_Click1(object sender, EventArgs e)
        {
            try
            {
                string x = txtcompanynm.Text;
                string[] words = x.Split('-');
                LoadCompanydetails(words[1]);

            }
            catch (Exception e3) { }
        }


    }
}
/*ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:setValue(); ", true);
 
 
 */