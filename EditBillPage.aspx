<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBillPage.aspx.cs" Inherits="BillingSoft.EditLedgerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="EditLedger.css" />

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
    src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript">


        function showpopup() {
            $("#popupdiv").dialog({
                title: "Edit Bill",
                width: 900,
                height: 700,
                modal: true,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                }
            });
            return false;
            re
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <center>
        <div style="margin-top: 70px; margin-left: 246px">
            <h1>Edit in Bills Here</h1>
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
            <%-- code for popup --%>
            <div>
                <div id="popupdiv" title="Edit Bill" style="display: none">
                    <br />
                    <div style="text-align: center">
                         <asp:TextBox ID="txtcompanyid" runat="server" style="display:none" Visible="true" placeholder="hey"></asp:TextBox>
                        <table>
                            <tr>
                                <td>Company Name:<asp:TextBox ID="txtcompanynm" placeholder="Company Name " runat="server" CssClass="companynmcss" AutoPostBack="false"></asp:TextBox>
                                    <%--onkeyup="textCompanyChanged();"--%></td>
                                <td>Company Address:<asp:TextBox ID="txtcompanyaddress" runat="server" CssClass="custom-textbox" placeholder="Company Address"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Customer Name:  <asp:TextBox ID="txtcustomernm" placeholder="Customer Name :" runat="server" CssClass="customernmcss" AutoPostBack="false"></asp:TextBox>
                                    <%--onkeyup="textCustomerChanged();"--%></td>
                                <td>Customer Address:<asp:TextBox ID="txtcustomeraddress" runat="server" CssClass="custom-textbox" placeholder="Customer Address"></asp:TextBox></td>
                            </tr>
                        </table>



                    </div>

                <br />
                                   
                <asp:GridView ID="Gvbill" runat="server" AutoGenerateColumns="false" Width="100%" Style="text-align: center;"  OnRowDeleting="Gvbill_RowDeleting">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sr.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>

                        </asp:TemplateField>


                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Literal ID="ltrProduct" runat="server" Text='<%# Eval("ServiceOrProductName") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Qty">
                            <ItemTemplate>
                                <asp:Literal ID="ltrQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Rate">
                            <ItemTemplate>
                                <asp:Literal ID="ltrRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="GST(Total)">
                            <ItemTemplate>
                                <asp:Literal ID="ltrGST" runat="server" Text='<%# Eval("GST") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="CGST">
                            <ItemTemplate>
                                <asp:Literal ID="ltrCGST" runat="server" Text='<%# Eval("CGST") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="SGST">
                            <ItemTemplate>
                                <asp:Literal ID="ltrSGST" runat="server" Text='<%# Eval("SGST") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Amount">
                            <ItemTemplate>
                                <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
    
                <table width="100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtproductorService" placeholder="Enter Product " runat="server" CssClass="productcss"></asp:TextBox>
                            <asp:Button ID="btnIncrement" runat="server" Text="+" OnClick="btnIncrement_Click1" CssClass="btn" Style="padding: 4px 10px; font-size: 15px; font-weight: 500; border-radius: 10px" />
                            <asp:TextBox ID="txtQuantity" runat="server" Text="1" ReadOnly="true" Style="width: 50px; border-radius: 50px" CssClass="custom-textbox" />
                            <asp:Button ID="btnDecrement" runat="server" Text="-" OnClick="btnDecrement_Click1" CssClass="btn" Style="padding: 4px 10px; font-size: 16px; font-weight: 600; border-radius: 10px" />

                            <asp:Button ID="btnaddtobill" runat="server" Text="Add Item" OnClick="btnaddtobill_Click" CssClass="btn" />
                    </tr>
                    <tr>
                        <td>
                            <section id="main">
                                <div style="display: inline-flex; width: 96%;">
                                    <div style="text-align: left">
                                        <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="ddlcss" AutoPostBack="false" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                                            <asp:ListItem Text="Select Payment Mode" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Credit Card" Value="CreditCard"></asp:ListItem>
                                            <asp:ListItem Text="Debit Card" Value="DebitCard"></asp:ListItem>
                                            <asp:ListItem Text="UPI" Value="PayPal"></asp:ListItem>
                                            <asp:ListItem Text="CASH" Value="BankTransfer"></asp:ListItem>
                                            <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                        </asp:DropDownList>
                                        <h4>
                                            <asp:Label ID="lblPayment" runat="server"></asp:Label>
                                        </h4>
                                        <asp:DropDownList ID="ddlrepeat" runat="server" CssClass="ddlcss" AutoPostBack="false">
                                            <asp:ListItem Text="Repeat" Value=""></asp:ListItem>
                                            <asp:ListItem Text="monthly" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Quarterly" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="No Repeat" Value="N/A"></asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <br />
                                    <div style="text-align: right; margin-right: 15px;">
                                        <h4>

                                            <asp:Label ID="lbltotalamt" runat="server" Text="Total Amount: " Visible="true"></asp:Label>
                                            <asp:TextBox ID="txttotalamount" AutoPostBack="true" runat="server" CssClass="custom-textbox" Visible="true" onchange="calculatePrice()"></asp:TextBox><br />


                                        </h4>
                                    </div>
                                </div>
                            </section>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <section id="main">
                                <div style="text-align: left">
                                    <h4>Due:<asp:TextBox ID="txtDue" runat="server" CssClass="custom-textbox" ReadOnly="true"></asp:TextBox></h4>
                                </div>

                                <div style="text-align: right">
                                    <h4>

                                        <%-- <asp:Label ID="lbltax" runat="server" Text="Tax: " Visible="true"></asp:Label>
                     <asp:TextBox ID="txtTax" runat="server" CssClass="custom-textbox" oninput="calculatePrice()">
                     </asp:TextBox><asp:Label ID="lblpersign2" runat="server" Text="%" Visible="true"></asp:Label>--%>

                                    </h4>


                                </div>
                            </section>
                        </td>
                    </tr>
                    <tr>

                        <td>
                            <div style="text-align: right">
                                <h4>
                                    <asp:Label ID="lbldiscount" runat="server" Text="Discount: " Visible="true"></asp:Label>
                                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="custom-textbox" Text="0" Visible="true" onchange="calculatePrice()">
                                    </asp:TextBox><asp:Label ID="lblpersign" runat="server" Text="%" Visible="true"></asp:Label>

                                </h4>

                                <%--<asp:RequiredFieldValidator ID="discountRequiredFieldValidator" runat="server" ControlToValidate="txtDiscount" ForeColor="Red" Font-Size="Small" ErrorMessage="Enter Discount in Number"></asp:RequiredFieldValidator>--%>
                            </div>
                        </td>
                    </tr>
                    <tr>

                        <td>
                            <div style="text-align: right; margin-right: 15px">
                                <h4>

                                    <asp:Label ID="lbltotal" runat="server" Text="Total: " Visible="true"></asp:Label>
                                    <asp:TextBox ID="txtTotal" runat="server" CssClass="custom-textbox" AutoPostBack="true" Visible="true"></asp:TextBox></h4>
                            </div>
                        </td>
                    </tr>

                </table>
                </div>


            </div>
            <asp:GridView ID="gvledger" runat="server" AutoGenerateColumns="false" CssClass="gvledgercss" OnRowCommand="gvledger_RowCommand1">
                <Columns>
                    <asp:TemplateField HeaderText="Invoice No">
                        <ItemTemplate>
                            <asp:Label ID="lblInvoiceNo" Visible="true" runat="server" Text='<%# Eval("InvoiceNo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Company Id">
                        <ItemTemplate>
                            <asp:Label ID="lblCompanyId" Visible="true" runat="server" Text='<%# Eval("CompanyId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Customer Id">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerId" Visible="true" runat="server" Text='<%# Eval("CustomerId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Payment Mode">
                        <ItemTemplate>
                            <asp:Label ID="lblPaymentMode" Visible="true" runat="server" Text='<%# Eval("Payment_Mode") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Edit" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </center>
</asp:Content>
