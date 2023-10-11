using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.Design;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using System.Globalization;

namespace BillingSoft
{
    public partial class AddProductorService : System.Web.UI.Page
    {
        bool Insert = false;
        bool Update = false;
        bool Delete = false;
        string taxinfo = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCompanyName();
                ProductServicedata();
                ddlTaxInfo.Items.Insert(0, new ListItem("Select Tax Info", ""));
                ddlTaxInfo.Items.Insert(1, new ListItem("Excluded", "1"));
                ddlTaxInfo.Items.Insert(2, new ListItem("Included", "0"));
            }
        }


        protected void btnsubmitProductorServiceDetails_Click(object sender, EventArgs e)
        {
            InsertProduct();
            if (Insert == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                ProductServicedata();
                txtGst.Text = txtProductorServicenm.Text = txtProductorServicePrice.Text = txtProductorServiceQty.Text = string.Empty;

                ddlTaxInfo.SelectedIndex = 0;
                ddlcompanyid.SelectedIndex = 0;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Inserted')", true);
            }
           

        }
        private void InsertProduct()
        {
            try {
                string price = txtProductorServicePrice.Text;
                string GST = txtGst.Text;
                double GSTinamount = double.Parse(GST) * (double.Parse(price) / 100);
                string afterTaxPrice = "";
                string CGST = (double.Parse(GST) / 2).ToString();
                string SGST = (double.Parse(GST) / 2).ToString();

                if (ddlTaxInfo.SelectedValue == "1")
                {
                    afterTaxPrice = (double.Parse(price) + GSTinamount).ToString();

                }
                else if (ddlTaxInfo.SelectedValue == "0")
                {
                    afterTaxPrice = (double.Parse(price) - GSTinamount).ToString();
                }
                else
                {
                    Response.Write("some error occur");
                }

                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string insertquery = "insert into " +
    "ProductServices (ServiceOrProductName,ServiceOrProductCompanyId,ServiceOrProductQty,BeforeTaxPrice,TaxInfo,GST,AfterTaxPrice,CGST,SGST)" +
    "values(@ServiceOrProductName,@ServiceOrProductCompanyId,@ServiceOrProductQty,@BeforeTaxPrice,@TaxInfo,@GST,@AfterTaxPrice,@CGST,@SGST)";

                SqlCommand cmd = new SqlCommand(insertquery, con);
                cmd.Parameters.AddWithValue("@ServiceOrProductName", txtProductorServicenm.Text);
                cmd.Parameters.AddWithValue("@ServiceOrProductCompanyId", getcompanyid(ddlcompanyid.SelectedItem.Value));
                cmd.Parameters.AddWithValue("@ServiceOrProductQty", txtProductorServiceQty.Text);
                cmd.Parameters.AddWithValue("@BeforeTaxPrice", price);
                cmd.Parameters.AddWithValue("@TaxInfo", ddlTaxInfo.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@GST", txtGst.Text);
                cmd.Parameters.AddWithValue("@AfterTaxPrice", afterTaxPrice);
                cmd.Parameters.AddWithValue("@CGST", CGST);
                cmd.Parameters.AddWithValue("@SGST", SGST);




                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Insert = true;
            } 
            catch{ }
           


        }
        private string getcompanyid(string x)
        {
            string cmpnyid = "";
            try
            {
                string query = "select CompanyId from CompanyDetails where CompanyName='" + x + "'";
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

        private void LoadCompanyName()
        {
            // Load CompanyName Names

            string query = "select distinct CompanyName from CompanyDetails";
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            adapter = new SqlDataAdapter(query, connection);
            DataTable dtCompanyId = new DataTable();




            connection.Open();
            adapter.Fill(dtCompanyId);

            connection.Close();

            ddlcompanyid.DataSource = dtCompanyId;
            ddlcompanyid.DataTextField = "CompanyName";
            ddlcompanyid.DataValueField = "CompanyName";
            ddlcompanyid.DataBind();

            ddlcompanyid.Items.Insert(0, new ListItem("Select Company", ""));
        }
        private void ProductServicedata()
        {
            try
            {
                string query = "select * from ProductServices";
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();




                connection.Open();
                adapter.Fill(dt);

                connection.Close();

                gvProductorService.DataSource = dt;

                gvProductorService.DataBind();
            }
            catch { }
        }

        protected void gvProductorService_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose LinkButton was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProductorService.Rows[rowIndex];

                HdnId.Text = (row.FindControl("lblProductid") as Label).Text;
                txtProductorServicenm.Text = (row.FindControl("lblName") as Label).Text;
                var x= (row.FindControl("lblCompanyId") as Label).Text;
                ddlcompanyid.Text = getcompanynamebyid(x);
                txtProductorServicePrice.Text = (row.FindControl("lblBeforeTaxPrice") as Label).Text;
                 taxinfo= (row.FindControl("lblTaxInfo") as Label).Text;
                txtGst.Text = (row.FindControl("lblGST") as Label).Text;
                txtProductorServiceQty.Text = (row.FindControl("lblServiceOrProductQty") as Label).Text;

                if (taxinfo== "Included")
                {
                    ddlTaxInfo.SelectedIndex=2;
                }
                else if(taxinfo== "Excluded")
                {
                    ddlTaxInfo.SelectedIndex = 1;
                }
                else
                {
                    ddlTaxInfo.SelectedItem.Value = "";
                }

                
                btnupdate.Visible = true;
                btnsubmitProductorServiceDetails.Visible = false;

                

            }
        }

        protected void gvProductorService_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            GridViewRow row = gvProductorService.Rows[rowIndex];

            var idofdeltingelement = (row.FindControl("lblProductid") as Label).Text;
            DeleteDetails(idofdeltingelement);
        }
        private void DeleteDetails(string deleteid)
        {
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string updatequery = "delete ProductServices Where ServiceOrProductId='" + deleteid + "' ";

                SqlCommand cmd = new SqlCommand(updatequery, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Delete = true;
                if (Delete == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                    ProductServicedata();
                    txtGst.Text = txtProductorServicenm.Text = txtProductorServicePrice.Text = txtProductorServiceQty.Text = string.Empty;

                    ddlTaxInfo.SelectedIndex = 0;
                    ddlcompanyid.SelectedIndex = 0;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Deleted')", true);
                }
            }
            catch { }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            UpdateDetails();
            if (Update == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);

                
                txtGst.Text = txtProductorServicenm.Text = txtProductorServicePrice.Text = txtProductorServiceQty.Text  = string.Empty;
               
                ddlTaxInfo.SelectedIndex =0;
                ddlcompanyid.SelectedIndex=0;
                Response.Redirect("~/AddProductorService.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Updated')", true);
            }
        }
        private void UpdateDetails()
        {
            try
            {
                string price = txtProductorServicePrice.Text;
                string GST = txtGst.Text;
                double GSTinamount = double.Parse(GST) * (double.Parse(price) / 100);
                string afterTaxPrice = "";
                string CGST = (double.Parse(GST) / 2).ToString();
                string SGST = (double.Parse(GST) / 2).ToString();

                if (ddlTaxInfo.SelectedValue == "1")
                {
                    afterTaxPrice = (double.Parse(price) + GSTinamount).ToString();

                }
                else if (ddlTaxInfo.SelectedValue == "0")
                {
                    afterTaxPrice = (double.Parse(price) - GSTinamount).ToString();
                }
                else
                {
                    Response.Write("some error occur");
                }

                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mycs"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);

                string insertquery = "UPDATE " +
     "ProductServices SET ServiceOrProductName=@ServiceOrProductName,ServiceOrProductCompanyId=@ServiceOrProductCompanyId,ServiceOrProductQty=@ServiceOrProductQty," +
     "BeforeTaxPrice=@BeforeTaxPrice,TaxInfo=@TaxInfo,GST=@GST,AfterTaxPrice=@AfterTaxPrice,CGST=@CGST,SGST=@SGST where ServiceOrProductId='"+ HdnId.Text + "'";

                SqlCommand cmd = new SqlCommand(insertquery, con);
                cmd.Parameters.AddWithValue("@ServiceOrProductName", txtProductorServicenm.Text);
                cmd.Parameters.AddWithValue("@ServiceOrProductCompanyId", getcompanyid(ddlcompanyid.SelectedItem.Value));
                cmd.Parameters.AddWithValue("@ServiceOrProductQty", txtProductorServiceQty.Text);
                cmd.Parameters.AddWithValue("@BeforeTaxPrice", price);
                cmd.Parameters.AddWithValue("@TaxInfo", ddlTaxInfo.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@GST", txtGst.Text);
                cmd.Parameters.AddWithValue("@AfterTaxPrice", afterTaxPrice);
                cmd.Parameters.AddWithValue("@CGST", CGST);
                cmd.Parameters.AddWithValue("@SGST", SGST);




                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Update = true;
            }
            catch { }
        }
    }
}