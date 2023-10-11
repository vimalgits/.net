<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceivedPage.aspx.cs" Inherits="BillingSoft.ReceivedPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="Receivedpage.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <center style="margin-top: 15%; margin-left: 250px;">
        <div style="border: 1px solid black; width: 50%; align-self: center;border-radius:10px">
            <br />
            <asp:DropDownList ID="ddlcompanynm" runat="server" AutoPostBack="true" CssClass="ddlcss" OnSelectedIndexChanged="ddlcompanynm_SelectedIndexChanged">
    <asp:ListItem Text="Select Customer Name" Value=""></asp:ListItem>
</asp:DropDownList>
            <br />
            <asp:DropDownList ID="ddlcustomernm" runat="server" AutoPostBack="true" CssClass="ddlcss" OnSelectedIndexChanged="ddlcustomernm_SelectedIndexChanged">
                <asp:ListItem Text="Select Customer Name" Value=""></asp:ListItem>
            </asp:DropDownList>
            <br />
           
            <asp:TextBox ID="txtDue" runat="server" CssClass="txtbox" Placeholder="Due" ReadOnly="true"></asp:TextBox><br />
            <asp:TextBox ID="txtamount" runat="server" CssClass="txtbox" Placeholder="Enter Amount"></asp:TextBox><br />
            <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="ddlcss" AutoPostBack="true" >
                <asp:ListItem Text="Select Payment Mode" Value=""></asp:ListItem>
                <asp:ListItem Text="Credit Card" Value="CreditCard"></asp:ListItem>
                <asp:ListItem Text="Debit Card" Value="DebitCard"></asp:ListItem>
                <asp:ListItem Text="UPI" Value="PayPal"></asp:ListItem>
                <asp:ListItem Text="CASH" Value="BankTransfer"></asp:ListItem>
                <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
            </asp:DropDownList><br />
             <asp:Button ID="btnreceived" runat="server" CssClass="btnSubmit" Text="Submit" OnClick="btnreceived_Click" />
        </div>
    </center>
</asp:Content>
