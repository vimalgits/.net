<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormhome.aspx.cs" Inherits="BillingSoft.WebFormhome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <center>
            <h2>
                <asp:LinkButton ID="linkaddCompany" runat="server" OnClick="linkaddCompany_Click">Add Company  </asp:LinkButton><br />
            </h2>
            <h2>
                <asp:LinkButton ID="linkaddCustomer" runat="server" OnClick="linkaddCustomer_Click">Add Customer </asp:LinkButton><br />
            </h2>
            <h2>
                <asp:LinkButton ID="linkaddProductorservice" runat="server" OnClick="linkaddProductorservice_Click">Add Product/service </asp:LinkButton><br />
            </h2>
            <h2>
                <asp:LinkButton ID="linkaddGenerateBill" runat="server" OnClick="linkaddGenerateBill_Click">Generate Bill  </asp:LinkButton><br />
            </h2>
        </center>

    </form>
</body>
</html>
