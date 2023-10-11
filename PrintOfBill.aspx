<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintOfBill.aspx.cs" Inherits="BillingSoft.PrintOfBill1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="GeneratedBill.css" />
</head>
<body>
    <form id="form1" runat="server">
        <center style="margin-top: 65px; height: 100%">
     <div class="bill">
         <div style="display: inline-flex; flex-wrap: nowrap; width: 100%">
             <div style="text-align: left; padding: 35px; width: 50%">
                 <h2>
                     <asp:Label ID="lblcompanynm" runat="server"></asp:Label></h2>
                 <h3>
                     <asp:Label ID="lblcompanyadd" runat="server"></asp:Label><br />
                     Email:<asp:Label ID="lblcompanyemail" runat="server"></asp:Label><br />
                     Mobile:<asp:Label ID="lblcompanymobile" runat="server"></asp:Label><br />
                     PAN No:<asp:Label ID="lblcompanypan" runat="server"></asp:Label></h3>

             </div>
             <div style="text-align: right; padding: 35px; width: 50%">
                 <p style="font-size: 35px; font-weight: 400">INVOICE</p>
             </div>
         </div>

         <div style="display: inline-flex; width: 100%; border-top: 1px solid black;">
             <div style="text-align: left; padding-left: 35px; width: 50%; border-right: 1px solid black;">
                 <table>
                     <tr>
                         <td>Invoice no:</td>
                         <td>
                             <asp:Label ID="lblInvoiceno" runat="server"></asp:Label></td>
                     </tr>
                     <tr>
                         <td>Invoice Date:</td>
                         <td>
                             <asp:Label ID="lblInvoicedate" runat="server"></asp:Label></td>
                     </tr>
                 </table>

             </div>
             <div style="text-align: right; padding-right: 35px; width: 50%;">
             </div>
         </div>

         <div style="display: inline-flex; width: 100%; border-top: 1px solid black; background-color: hsl(0, 0%, 90%);">
             <div style="text-align: left; padding: 0px 5px; width: 50%; border-right: 1px solid black;">
                 <h5>Bill To:</h5>
             </div>
             <div style="text-align: left; padding: 0px 5px; width: 50%;">
                 <h5>Ship To:</h5>
             </div>
         </div>

         <div style="display: inline-flex; width: 100%; border-top: 1px solid black; border-bottom: 1px solid black;">
             <div style="text-align: left; padding: 0px 35px; width: 50%; border-right: 1px solid black;">
                 Customer Name:<asp:Label ID="lblcustomernm" runat="server"></asp:Label><br />
                 Email:<asp:Label ID="lblcustomeremail" runat="server"></asp:Label><br />
                 Mobile:<asp:Label ID="lblcustomermobile" runat="server"></asp:Label><br />
                 PAN No:<asp:Label ID="lblcustomerpan" runat="server"></asp:Label><br />
                 Customer Address:<asp:Label ID="lblcustomeraddress" runat="server"></asp:Label>
             </div>
             <div style="text-align: left; padding: 0px 35px; width: 50%;">
                 <h5>Address:<asp:Label ID="lblshipaddress" runat="server">Ajmer</asp:Label>
                 </h5>
             </div>
         </div>
         <center>
             <asp:GridView ID="GvBillPrint" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#1c66ce" HeaderStyle-ForeColor="White">
                 <Columns>
                     <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" ControlStyle-BorderColor="White">
                         <ItemTemplate>
                             <%# Container.DataItemIndex + 1 %>
                         </ItemTemplate>

                     </asp:TemplateField>


                     <asp:TemplateField HeaderText="Product Description" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                             <asp:Literal ID="ltrProduct" runat="server" Text='<%# Eval("ServiceOrProductName") %>'></asp:Literal>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Qty" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                             <asp:Literal ID="ltrQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Literal>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                             <asp:Literal ID="ltrRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Literal>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField ItemStyle-Width="7.7%" HeaderText="GST" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                             <asp:Literal ID="ltrGST" runat="server" Text='<%# Eval("gst") %>'></asp:Literal>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField ItemStyle-Width="7.8%" HeaderText="CGST" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                             <asp:Literal ID="ltrCGST" runat="server" Text='<%# Eval("cgst") %>'></asp:Literal>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField ItemStyle-Width="7.8%"  HeaderText="SGST" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                             <asp:Literal ID="ltrSGST" runat="server" Text='<%# Eval("sgst") %>'></asp:Literal>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                             <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Literal>
                         </ItemTemplate>
                     </asp:TemplateField>

                 </Columns>
             </asp:GridView>
             <table style="width: 100%;">
                 <tbody>
                     <tr style="font-weight: bold">
                         <td style="width: 70%"></td>
                         <td>Amount:</td>
                         <td>
                             <asp:Literal ID="ltrTotalAmount" runat="server"></asp:Literal></td>
                     </tr>

                     <tr style="font-weight: bold">
                         <td style="width: 70%"></td>
                         <td>Discount:</td>
                         <td>
                             <asp:Literal ID="ltrdiscount" runat="server"></asp:Literal></td>
                     </tr>



                     <tr style="font-weight: bold">
                         <td style="width: 70%"></td>
                         <td>Total Amount:</td>
                         <td>
                             <asp:Literal ID="ltrFinalAmount" runat="server"></asp:Literal></td>
                     </tr>
                 </tbody>
             </table>
     </div>


     <script>
         // Use JavaScript to trigger the print dialog when the page loads.
         window.onload = function () {
             window.print();
         };
     </script>
 </center>
    </form>
</body>
</html>
