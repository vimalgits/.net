<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCompanyDetail.aspx.cs" Inherits="BillingSoft.EditCompanyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="EditCompanycss.css" />
    <%--adding calendar--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="js/jquery-ui-datepicker.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id*=txtdatestart]").datepicker({
                buttonImageOnly: true,
                buttonImage: 'Media\Images\icons8-calendar-48.png',
                dateFormat: 'dd-mm-yy'
            });
            $("[id*=txtdateend]").datepicker({
                buttonImageOnly: true,
                buttonImage: 'Media\Images\icons8-calendar-48.png',
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <center>
        <div style="margin-top: 150px; margin-left: 250px">

            <h1>Edit Company Deatils</h1>
           
            <div style="display: inline-flex">
                <asp:DropDownList ID="ddlcompanynm" runat="server" AutoPostBack="true" CssClass="ddlcss" OnSelectedIndexChanged="ddlcompanynm_SelectedIndexChanged">
                </asp:DropDownList>

                <div id="datediv">
                    <center>
                        <asp:TextBox ID="txtdatestart" runat="server" CssClass="custom-textbox" placeholder="Start Date" AutoPostBack="true"></asp:TextBox>To<asp:TextBox ID="txtdateend" runat="server" CssClass="custom-textbox" placeholder="End Date" AutoPostBack="true" OnTextChanged="txtdateend_TextChanged"></asp:TextBox>

                    </center>

                </div>
            </div>

            <br />
            <br />
            <asp:GridView ID="gvcompany" runat="server" AutoGenerateColumns="true" CssClass="gvcompanycss"></asp:GridView>
        </div>
    </center>
</asp:Content>
