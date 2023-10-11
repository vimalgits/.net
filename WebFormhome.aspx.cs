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
    public partial class WebFormhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void linkaddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomerDeatils.aspx");
        }
       
        protected void linkaddCompany_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("AddCompanyDeatils.aspx");
        }

        protected void linkaddProductorservice_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProductorServices.aspx");
        }

        protected void linkaddGenerateBill_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerateBillPage.aspx");
        }

        
    }
}
