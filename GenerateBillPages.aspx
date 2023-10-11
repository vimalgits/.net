<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateBillPages.aspx.cs" Inherits="BillingSoft.GenerateBillPages" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link rel="stylesheet" type="text/css" href="GenerateBill.css" />




    <%--adding suggestions--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>

    <%-- suggestions company name--%>
    <script type="text/javascript">



        $(document).ready(function () {

            CompanyNameLoad();
            CustomerNameLoad();
            ProductLoad();
            if (document.getElementById('<%= txttotalamount.ClientID%>').value != " ") {
                calculatePrice();
            }

        });

        function CompanyNameLoad() {

            $(".companynmcss").autocomplete({


                source: function (request, response) {

                    var param = { prefixText: document.getElementById('<%= txtcompanynm.ClientID %>').value };

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "GenerateBillPages.aspx/getCompanyNames",
                        data: JSON.stringify(param),
                        dataType: "json",
                        success: function (data) {

                            let output = [];
                            var items = data.d;



                            Object.keys(items).forEach(function (key) {
                                console.log('Key : ' + key + ', Value : ' + items[key]);
                                var x = items[key] + "-" + key;
                                output.push(x);

                            })


                            response(output);

                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });

                }


            });

        }
        function ProductLoad() {

            $(".productcss").autocomplete({


                source: function (request, response) {

                    var param = { prefixText: document.getElementById('<%= txtproductorService.ClientID %>').value, CompanyId: document.getElementById('<%= txtcompanyid.ClientID %>').value };

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "GenerateBillPages.aspx/getProduct",
                        data: JSON.stringify(param),
                        
                        dataType: "json",
                        success: function (data) {
                            let output = [];
                            var items = data.d;
                           
                           
                           
                           Object.keys(items).forEach(function (key) {
                                console.log('Key : ' + key + ', Value : ' + items[key]);
                               var x = items[key]+"-" + key;
                               output.push(x);
                              
                            })

                           
                            response(output);
                           
                           
                           
                            
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });

                }


            });

        }
        function CustomerNameLoad() {

            $(".customernmcss").autocomplete({


                source: function (request, response) {

                    var param = { prefixTextcustomer: document.getElementById('<%= txtcustomernm.ClientID %>').value };

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "GenerateBillPages.aspx/getCustomerNames",
                        data: JSON.stringify(param),
                        dataType: "json",
                        success: function (data) {
                            response(data.d);

                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });

                }


            });

        }
    </script>

    <script type="text/javascript">

        function textCompanyChanged() {


            var textBox = document.getElementById('<%= txtcompanynm.ClientID %>');

            var button = document.getElementById('<%= btnCompclick.ClientID %>');

            if (textBox.value.length > 1) {

                button.click();

            }
        }
        function textCustomerChanged() {

            var textBox = document.getElementById('<%= txtcustomernm.ClientID %>');
            var button = document.getElementById('<%= btnCustomerClick.ClientID %>');
            if (textBox.value.length > 2) {

                button.click();

            }
        }
    </script>


    <script>
        // JavaScript function to calculate the final price
        function calculatePrice() {
            var amount = parseFloat(document.getElementById('<%= txttotalamount.ClientID%>').value);
            var discount = parseFloat(document.getElementById('<%= txtDiscount.ClientID%>').value);


            var finalPrice = amount - (amount * (discount / 100));

            document.getElementById('<%= txtTotal.ClientID%>').value = finalPrice.toFixed(2);
        }

    </script>
    <%--adding calendar--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="js/jquery-ui-datepicker.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id*=txtdateofbilling]").datepicker({
                buttonImageOnly: true,
                buttonImage: 'Media\Images\icons8-calendar-48.png',
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>
    <script type="text/javascript">    

        function userValid() {
            var companynm = document.getElementById('<%= txtcompanynm.ClientID%>').value;
           
            var dateofbilling = document.getElementById('<%= txtdateofbilling.ClientID%>').value;
            var customernm = document.getElementById('<%= txtcustomernm.ClientID%>').value;


            var place = document.getElementById('<%= txtplace.ClientID%>').value;
            var repeat = document.getElementById('<%= ddlrepeat.ClientID%>').value;

            var productservice = document.getElementById('<%= txtproductorService.ClientID%>').value;
            var paymentmode = document.getElementById('<%= ddlPaymentMode.ClientID%>').value;

            var discount = document.getElementById('<%= txtDiscount.ClientID%>').value;


            if (discount == '') {
                alert("Please enter Discount");
                return false;
            }

            if (productservice == '') {
                alert("Please enter product/service");
                return false;
            }

            if (repeat == '') {
                alert("Please enter Repeat Infomation");
                return false;
            }

            if (place == '') {
                alert("Please enter Place");
                return false;
            }

            if (customernm == '') {
                alert("Please enter Customer Name");
                return false;
            }

            if (dateofbilling == '') {
                alert("Please enter Date of Billing");
                return false;
            }

            if (companynm == '') {
                alert("Please Company Name");
                return false;
            }

          

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <center style="margin-top: 65px; margin-left: 250px;">
        <asp:TextBox ID="txtcompanyid" runat="server" style="display:none" Visible="true" placeholder="hey"></asp:TextBox>
        
            <div style="border: 1px solid black; width: 80%; align-self: center;">
                <h1 align="left" style="padding-left: 80px; font-size: 50px; color: darkgray; font-family: Cambria, Cochin, Georgia, Times, Times New Roman, serif">INVOICE</h1>
                <div style="width: 100%; border-top: 1px solid black;">

                    <div style="border-bottom: 1px solid black; width: 100%">
                        <table style="width: 83%">
                            <tr>
                                <td>
                                    <br />
                                    <h4>Bill By:</h4>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtcompanynm" placeholder="Company Name " runat="server" CssClass="companynmcss" AutoPostBack="false" onkeyup="textCompanyChanged();"></asp:TextBox>
                                    <br />

                                    <br />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtcompanyaddress" runat="server" CssClass="custom-textbox" placeholder="Company Address"></asp:TextBox>
                                </td>
                                <td>
                                    <br />
                                    <asp:TextBox ID="txtinvoice" runat="server" CssClass="custom-textbox" ReadOnly="true"></asp:TextBox>
                                    <br />
                                    <%--<asp:RequiredFieldValidator ID="invoiceRequiredFieldValidator" runat="server" ErrorMessage="Enter Invoice Number" ControlToValidate="txtinvoice" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    <h4></h4>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <div style="width: 100%">
                        <table style="width: 83%">
                            <tr>

                                <td>
                                    <br />

                                    <h4>Bill To:</h4>

                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <br />
                                    <asp:TextBox ID="txtcustomernm" placeholder="Customer Name :" runat="server" CssClass="customernmcss" AutoPostBack="false" onkeyup="textCustomerChanged();"></asp:TextBox>
                                    <br />


                                </td>
                                <td>
                                    <br />
                                    <asp:TextBox ID="txtdateofbilling" runat="server" CssClass="custom-textbox" placeholder="Bill Date" AutoPostBack="false"></asp:TextBox>
                                    <br />
                                    <%--<asp:RequiredFieldValidator ID="dateofbillRequiredFieldValidator" runat="server" ErrorMessage="Date of billing cannot be blank" Font-Size="Small" ControlToValidate="txtdateofbilling" ForeColor="Red"></asp:RequiredFieldValidator>--%>


                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <asp:TextBox ID="txtcustomeraddress" runat="server" CssClass="custom-textbox" placeholder="Customer Address"></asp:TextBox></td>
                                <td>
                                    <h4>
                                        <br />
                                        <asp:TextBox ID="txtplace" placeholder="Place" runat="server" CssClass="custom-textbox"></asp:TextBox><br />

                                        <%--</h4> <asp:RequiredFieldValidator ID="placeRequiredFieldValidator" runat="server" ErrorMessage="Enter Place of Bill" Font-Size="Small" ControlToValidate="txtplace" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </td>


                            </tr>


                        </table>
                        <br />

                    </div>


                </div>
              
                <br />
                <div style="width: 100%; height: 50px; background-color: #2e4ead; display: inline-flex; color: white;">
                    <div style="width: 10%; padding: 5px; border-right: 1px solid white">SR.NO.</div>
                    <div style="width: 50%; padding: 5px; border-right: 1px solid white">Product Description</div>
                    <div style="width: 10%; padding: 5px; border-right: 1px solid white">Qty</div>
                    <div style="width: 15%; padding: 5px; border-right: 1px solid white">Rate</div>
                    <div style="width: 10%; padding: 5px; border-right: 1px solid white">GST<br />(%)</div>
                    <div style="width: 10%; padding: 5px; border-right: 1px solid white">CGST<br />(%)</div>
                    <div style="width: 10%; padding: 5px; border-right: 1px solid white">SGST<br />(%)</div>
                    
                    <div style="width: 15%; padding: 5px;">Amount</div>


                </div>
              
                <br />
                <asp:ScriptManager ID="scriptmanager1" runat="server">  
</asp:ScriptManager>  
<div>  
<asp:UpdatePanel ID="updatepnl" runat="server">  
<ContentTemplate> 
      <asp:GridView ID="Gvbill" runat="server" AutoGenerateColumns="false" Width="106%" ShowHeader="False" Style="text-align: center;"  OnRowDeleting="Gvbill_RowDeleting">
      <Columns>
          <asp:TemplateField ItemStyle-Width="8.8%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                  <%# Container.DataItemIndex + 1 %>
              </ItemTemplate>

          </asp:TemplateField>

        
          <asp:TemplateField ItemStyle-Width="37.4%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                  <asp:Literal ID="ltrProduct" runat="server" Text='<%# Eval("Product Description") %>'></asp:Literal>
              </ItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                  <asp:Literal ID="ltrQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Literal>
              </ItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField ItemStyle-Width="11.4%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                  <asp:Literal ID="ltrRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Literal>
              </ItemTemplate>
          </asp:TemplateField>

           <asp:TemplateField ItemStyle-Width="7.7%" ItemStyle-HorizontalAlign="Center">
     <ItemTemplate>
         <asp:Literal ID="ltrGST" runat="server" Text='<%# Eval("gst") %>'></asp:Literal>
     </ItemTemplate>
 </asp:TemplateField>

           <asp:TemplateField ItemStyle-Width="7.8%" ItemStyle-HorizontalAlign="Center">
     <ItemTemplate>
         <asp:Literal ID="ltrCGST" runat="server" Text='<%# Eval("cgst") %>'></asp:Literal>
     </ItemTemplate>
 </asp:TemplateField>

           <asp:TemplateField ItemStyle-Width="7.8%" ItemStyle-HorizontalAlign="Center">
     <ItemTemplate>
         <asp:Literal ID="ltrSGST" runat="server" Text='<%# Eval("sgst") %>'></asp:Literal>
     </ItemTemplate>
 </asp:TemplateField>

          <asp:TemplateField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                  <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Literal>
              </ItemTemplate>
          </asp:TemplateField>
          <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
      </Columns>
  </asp:GridView><br /><br />
    </ContentTemplate>  
</asp:UpdatePanel> 
     <div style="width: 100%;text-align:center">
    
     <table width="100%";>
         <tr>
             <td>
                 <asp:TextBox ID="txtproductorService" placeholder="Enter Product " runat="server" CssClass="productcss" ></asp:TextBox>
                 <asp:Button ID="btnIncrement" runat="server" Text="+" OnClick="btnIncrement_Click" CssClass="btn" Style="padding: 4px 10px; font-size: 15px; font-weight: 500; border-radius: 10px" />
                 <asp:TextBox ID="txtQuantity" runat="server" Text="1" ReadOnly="true" Style="width: 50px; border-radius: 50px" CssClass="custom-textbox" />
                 <asp:Button ID="btnDecrement" runat="server" Text="-" OnClick="btnDecrement_Click" CssClass="btn" Style="padding: 4px 10px; font-size: 16px; font-weight: 600; border-radius: 10px" />

                 <asp:Button ID="btnaddtobill" runat="server" Text="Add Item" OnClick="btnaddtobill_Click" CssClass="btn"  /><br /><br />
             </td>
           
         </tr>
         <tr>
             <td><section id="main">
                <div style="display:inline-flex;width:96%;">
                    <div style="text-align: left">
                 <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="ddlcss" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                     <asp:ListItem Text="Select Payment Mode" Value=""></asp:ListItem>
                     <asp:ListItem Text="Credit Card" Value="CreditCard"></asp:ListItem>
                     <asp:ListItem Text="Debit Card" Value="DebitCard"></asp:ListItem>
                     <asp:ListItem Text="UPI" Value="PayPal"></asp:ListItem>
                     <asp:ListItem Text="CASH" Value="BankTransfer"></asp:ListItem>
                     <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                 </asp:DropDownList>  <h4>
                     <asp:Label ID="lblPayment" runat="server"></asp:Label>
                 </h4> <asp:DropDownList ID="ddlrepeat" runat="server"  CssClass="ddlcss" AutoPostBack="true">
                     <asp:ListItem Text="Repeat" Value=""></asp:ListItem>
                     <asp:ListItem Text="monthly" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Quarterly" Value="6"></asp:ListItem>
                     <asp:ListItem Text="No Repeat" Value="N/A"></asp:ListItem>

                 </asp:DropDownList>
                </div><br /><br />
                 <div style="text-align: right; margin-right: 15px;" >
                     <h4>
                         
                         <asp:Label ID="lbltotalamt" runat="server" Text="Total Amount: " Visible="true"></asp:Label>
                         <asp:TextBox ID ="txttotalamount" AutoPostBack ="true" runat="server" CssClass="custom-textbox" Visible="true" ReadOnly="true" onchange="calculatePrice()"></asp:TextBox><br />
                         
                         
                     </h4>
                 </div>
                </div></section>
             </td>
         </tr>
         <tr>
             <td><br />
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

                         <asp:Label ID="lbltotal" runat="server" Text="Total: "  Visible="true"></asp:Label>
                         <asp:TextBox ID="txtTotal" runat="server" CssClass="custom-textbox" AutoPostBack="true" Visible="true" ReadOnly="true"></asp:TextBox></h4>
                 </div>
             </td>
         </tr>

     </table>
     <div style="text-align: center">
         
         <br />
         <asp:Button ID="btnGeneratebill" runat="server" Text="Generate Bill" CssClass="btn" Visible="true" OnClick="btnGeneratebill_Click" OnClientClick="return userValid();" /><br />
     </div>
 </div>
 
               
                <br />


                <br />



            </div></div>
        </center>

        <asp:Button ID="btnCompclick" runat="server" Text="click" Style="display: none" OnClick="btnCompclick_Click1" />
     
        <asp:TextBox ID="txtcompanyemail" runat="server" CssClass="custom-textbox" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtcompanymob" runat="server" CssClass="custom-textbox" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtcompanypan" runat="server" CssClass="custom-textbox" Visible="false"></asp:TextBox>
        <br />



        <asp:Button ID="btnCustomerClick" runat="server" Text="Click Me" Style="display: none" OnClick="btnCustomerClick_Click" />

        <asp:TextBox ID="txtcustomeremail" runat="server" CssClass="custom-textbox" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtcustomermob" runat="server" CssClass="custom-textbox" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtcustomerpan" runat="server" CssClass="custom-textbox" Visible="false"></asp:TextBox>
        <asp:HiddenField ID="hfcustomerid" runat="server" />
        <br />
    
</asp:Content>
