<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCompanyDeatil.aspx.cs" Inherits="BillingSoft.AddCompanyDeatil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="AddCompanyDetails.css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <center>
        <div style="margin-top: 100px; margin-left: 250px">


            <h1>Enter Company Deatils</h1>

            <br />
            <br />
            <asp:Label ID="HdnId" runat="server" Visible="false"></asp:Label>
            
            <table style="width: 50%; text-align: center;">
                <tr>
                    <td>
                        <asp:TextBox ID="txtcompynm" runat="server" CssClass="textbox" placeholder="Company Name"></asp:TextBox><br />
                        <%--<asp:RequiredFieldValidator ID="companynmRequiredFieldValidator" runat="server" ControlToValidate="txtcompynm" ForeColor="Red" Font-Size="Small"
                            ErrorMessage="Enter Company Name"></asp:RequiredFieldValidator>
                        --%>
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtcompyAddress" runat="server" CssClass="textbox" placeholder="Company Address"></asp:TextBox><br />
                        <%-- <asp:RequiredFieldValidator ID="compyAddressRequiredFieldValidator" runat="server" ControlToValidate="txtcompyAddress" ForeColor="Red" Font-Size="Small"
                            ErrorMessage="Enter Company Address"></asp:RequiredFieldValidator>
                        --%>
                        <br />
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtcompyMob" runat="server" CssClass="textbox" placeholder="Company Mobile Number"></asp:TextBox><br />
                        <%-- <asp:RequiredFieldValidator ID="compyMobRequiredFieldValidator1" runat="server" ControlToValidate="txtcompyMob" ForeColor="Red" Font-Size="Small"
                            ErrorMessage="Enter Company Mobile Number"></asp:RequiredFieldValidator>
                        --%><br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtcompyemail" runat="server" CssClass="textbox" placeholder="Company Email"></asp:TextBox><br />
                        <%-- <asp:RequiredFieldValidator ID="compyemailRequiredFieldValidator1" runat="server" ControlToValidate="txtcompyemail" ForeColor="Red" Font-Size="Small"
                            ErrorMessage="Enter Company Email"></asp:RequiredFieldValidator>
                        --%>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtcompyPAN" runat="server" CssClass="textbox" placeholder="Company PAN"></asp:TextBox><br />
                        <%-- <asp:RequiredFieldValidator ID="compyPANRequiredFieldValidator1" runat="server" ControlToValidate="txtcompyPAN" ForeColor="Red" Font-Size="Small"
                            ErrorMessage="Enter Company PAN Number"></asp:RequiredFieldValidator>
                        --%>
                        <br />
                        <td>
                            <asp:TextBox ID="txtcompyGstno" runat="server" CssClass="textbox" placeholder="Company GST"></asp:TextBox><br />
                            <%--<asp:RequiredFieldValidator ID="compyGstnoRequiredFieldValidator1" runat="server" ControlToValidate="txtcompyGstno" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Company GST Number"></asp:RequiredFieldValidator>
                            --%><br />
                        </td>
                </tr>

            </table>
            INVOICE PATTERN:<asp:TextBox ID="txtipshortcode" CssClass="invoiceboxcss" runat="server" placeholder="Short Code"></asp:TextBox><asp:TextBox ID="txtipyear" runat="server" CssClass="invoiceboxcss" placeholder="Year"></asp:TextBox><asp:TextBox ID="txtipserialno" runat="server" CssClass="invoiceboxcss" placeholder="Serial Start No."></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnsubmitCompnyDetails" runat="server" CssClass="btnSubmit" Text="Submit" OnClick="btnsubmitCompnyDetails_Click" />
            <asp:Button ID="btnupdate" runat="server" Visible="false" CssClass="btnSubmit" Text="Update" OnClick="btnupdate_Click" />

            <br />
            <br />
            <asp:ScriptManager ID="scriptmanager1" runat="server">
            </asp:ScriptManager>


            <asp:GridView ID="gvcompany" runat="server" AutoGenerateColumns="false" CssClass="gvcompanycss" OnRowCommand="gvcompany_RowCommand"  OnRowDeleting="gvcompany_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                             <asp:Label ID="lblcompanyid" Visible="false" runat="server" Text='<%# Eval("CompanyId") %>'/>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("CompanyAddress") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mobile">
                        <ItemTemplate>
                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("CompanyMobNo") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("CompanyEmail" )%>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="PAN">
                        <ItemTemplate>
                            <asp:Label ID="lblPAN" runat="server" Text='<%# Eval("CompanyPAN" )%>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="GST">
                        <ItemTemplate>
                            <asp:Label ID="lblGST" runat="server" Text='<%# Eval("CompanyGST" )%>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IP Short Code">
                        <ItemTemplate>
                            <asp:Label ID="lblIPShortCode" runat="server" Text='<%# Eval("IPShortCode" )%>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IP Year">
                        <ItemTemplate>
                            <asp:Label ID="lblIPYear" runat="server" Text='<%# Eval("IPYear" )%>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IP Series Start">
                        <ItemTemplate>
                            <asp:Label ID="lblIPSerialNumber" runat="server" Text='<%# Eval("IPSerialNumber" )%>'></asp:Label>
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

        </div>
    </center>


</asp:Content>
