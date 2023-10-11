<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewLedger.aspx.cs" Inherits="BillingSoft.ViewLedger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="ViewLedger.css" />
   
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
        <div style="margin-top: 70px; margin-left: 246px; ">
            <h1>Ledger</h1>
            <br />
            <div style="display: inline-flex">
                <asp:DropDownList ID="ddlcompanynm" runat="server" AutoPostBack="true" CssClass="ddlcss" OnSelectedIndexChanged="ddlcompanynm_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlcustomernm" runat="server" AutoPostBack="true" CssClass="ddlcss" OnSelectedIndexChanged="ddlcustomernm_SelectedIndexChanged">
                    <asp:ListItem Text="Select Customer" Value=""></asp:ListItem>
                </asp:DropDownList>

                <div id="datediv">
                    <center>
                        <asp:TextBox ID="txtdatestart" runat="server" CssClass="custom-textbox" placeholder="Start Date" AutoPostBack="true"></asp:TextBox>
                        To
        <asp:TextBox ID="txtdateend" runat="server" CssClass="custom-textbox" placeholder="End Date" AutoPostBack="true" OnTextChanged="txtdateend_TextChanged"></asp:TextBox>

                    </center>

                </div>
            </div>


            <br />
            <br />
            <asp:GridView ID="gvledger" runat="server" AutoGenerateColumns="false" CssClass="gvledgercss">
                <Columns>
                    <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ControlStyle-BorderColor="White">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField ItemStyle-Width="7.8%" HeaderText="Invoice No" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Literal ID="ltrSGST" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date of Bill" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("DateBillCreated") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CompanyId" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("CompanyId") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("Credit") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("Debit") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Balance" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("Balance") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>



                </Columns>
            </asp:GridView>
        </div>
    </center>
</asp:Content>
