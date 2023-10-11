<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProductorService.aspx.cs" Inherits="BillingSoft.AddProductorService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="AddProductorServices.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <center style="margin-top: 150px; margin-left: 250px">
        <h2>Enter Product Deatils</h2>
        <br />
        <br />
        <asp:Label ID="HdnId" runat="server" Visible="false"></asp:Label>
        <table width="50%">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlcompanyid" runat="server" CssClass="ddlcompanyidcss" AutoPostBack="true">
                    </asp:DropDownList><br>
                    <%--<asp:RequiredFieldValidator ID="companyidRequiredFieldValidator1" runat="server" ControlToValidate="ddlcompanyid" ForeColor="Red" Font-Size="Small"
                        ErrorMessage="Select Company of Product"></asp:RequiredFieldValidator>
                    --%><br />
                </td>
                <td>
                    <asp:TextBox ID="txtProductorServicenm" placeholder="Product Name" runat="server" CssClass="custom-textbox"></asp:TextBox><br />
                    <%--<asp:RequiredFieldValidator ID="productorServicenmRequiredFieldValidator" runat="server" ControlToValidate="txtProductorServicenm" ForeColor="Red" Font-Size="Small"
                        ErrorMessage="Enter Productor/Service name"></asp:RequiredFieldValidator>
                    --%><br />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <asp:TextBox ID="txtProductorServicePrice" runat="server" placeholder="Product Price" CssClass="custom-textbox"></asp:TextBox><br />
                   <%-- <asp:RequiredFieldValidator ID="productorServicePriceRequiredFieldValidator1" runat="server" ControlToValidate="txtProductorServicePrice" ForeColor="Red" Font-Size="Small"
                        ErrorMessage="Enter Productor/Service Price"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Price Should be in Numbers" ForeColor="Red" Font-Size="Small" ControlToValidate="txtProductorServicePrice" ValidationExpression="^\d+$" ValidationGroup="OnlyNumbers"></asp:RegularExpressionValidator>
                   --%> <br />
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="ddlTaxInfo" runat="server" CssClass="ddlcompanyidcss" AutoPostBack="true">
                       
                    </asp:DropDownList><br>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTaxInfo" ForeColor="Red" Font-Size="Small"
                        ErrorMessage="Select Tax Information"></asp:RequiredFieldValidator>
                   --%> <br />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:TextBox ID="txtGst" runat="server" placeholder="Product GST" CssClass="custom-textbox"></asp:TextBox><br />
                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGst" ForeColor="Red" Font-Size="Small"
                        ErrorMessage="Enter Productor/Service GST"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="GST Should be in Numbers" ForeColor="Red" Font-Size="Small" ControlToValidate="txtGst" ValidationExpression="^\d+$" ValidationGroup="OnlyNumbers"></asp:RegularExpressionValidator>
                    --%><br />
                </td>
                <td>
                    <asp:TextBox ID="txtProductorServiceQty" placeholder="Qty" runat="server" CssClass="custom-textbox"></asp:TextBox><br />
                   <%-- <asp:RequiredFieldValidator ID="productorServiceQtyRequiredFieldValidator1" runat="server" ControlToValidate="txtProductorServiceQty" ForeColor="Red" Font-Size="Small"
                        ErrorMessage="Enter Quantity"></asp:RequiredFieldValidator>
                   --%> <br />
                </td>
            </tr>
        </table>








        <asp:Button ID="btnsubmitProductorServiceDetails" runat="server" ValidationGroup="OnlyNumbers" CssClass="btnSubmit" Text="Submit" OnClick="btnsubmitProductorServiceDetails_Click" />
        <asp:Button ID="btnupdate" runat="server" Visible="false" CssClass="btnSubmit" Text="Update" OnClick="btnupdate_Click" />
        <br />
        <br />
        <asp:GridView ID="gvProductorService" runat="server" AutoGenerateColumns="false" CssClass="gvcss" OnRowCommand="gvProductorService_RowCommand" OnRowDeleting="gvProductorService_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("ServiceOrProductName") %>'></asp:Label>
                        <asp:Label ID="lblProductid" Visible="false" runat="server" Text='<%# Eval("ServiceOrProductId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Company Id">
                    <ItemTemplate>

                        <asp:Label ID="lblCompanyId" Visible="true" runat="server" Text='<%# Eval("ServiceOrProductCompanyId") %>' />
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="BeforeTax Price">
                    <ItemTemplate>
                        <asp:Label ID="lblBeforeTaxPrice" runat="server" Text='<%# Eval("BeforeTaxPrice") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="TaxInfo">
                    <ItemTemplate>
                        <asp:Label ID="lblTaxInfo" runat="server" Text='<%# Eval("TaxInfo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="GST">
                    <ItemTemplate>
                        <asp:Label ID="lblGST" runat="server" Text='<%# Eval("GST") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="AfterTaxPrice">
                    <ItemTemplate>
                        <asp:Label ID="lblAfterTaxPrice" runat="server" Text='<%# Eval("AfterTaxPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Qty">
                    <ItemTemplate>
                        <asp:Label ID="lblServiceOrProductQty" runat="server" Text='<%# Eval("ServiceOrProductQty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Edit" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />

            </Columns>
        </asp:GridView>

    </center>
</asp:Content>
