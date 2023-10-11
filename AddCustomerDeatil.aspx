<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomerDeatil.aspx.cs" Inherits="BillingSoft.AddCustomerDeatil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="AddCustomerDeatils.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>

    <%-- suggestions company name--%>
    <script type="text/javascript">



        $(document).ready(function () {

            CompanyNameLoad();



        });
        function CompanyNameLoad() {

            $(".csscompanynm").autocomplete({


                source: function (request, response) {

                    var param = { prefixText: document.getElementById('<%= txtcompanynm.ClientID %>').value };

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "AddCustomerDeatil.aspx/getCompanyNames",
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <center>
       <div style="margin-top: 100px; margin-left: 250px">
            <center>
                <h1>Enter Customer Deatils</h1>
                <br />
                <br />
                <asp:Label ID="HdnId" runat="server" Visible="false"></asp:Label>

                <table style="width: 50%; text-align: center;">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtcustomernm" placeholder="Customer Name" runat="server" CssClass="custom-textbox"></asp:TextBox><br />
                            <%-- <asp:RequiredFieldValidator ID="txtcustomernmRequiredFieldValidator" runat="server" ControlToValidate="txtcustomernm" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Customer Name"></asp:RequiredFieldValidator>--%>
                            <br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtcompanynm" runat="server" placeholder="Company Name" CssClass="csscompanynm" onkeyup="textCompanyChanged();"></asp:TextBox><br />
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcompanynm" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Company Name"></asp:RequiredFieldValidator>--%>
                            <br />
                        </td>


                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtcustomerAddress" placeholder="Customer Address" runat="server" CssClass="custom-textbox"></asp:TextBox><br />
                            <%--<asp:RequiredFieldValidator ID="customerAddressRequiredFieldValidator" runat="server" ControlToValidate="txtcustomerAddress" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Customer Address"></asp:RequiredFieldValidator>
                            --%><br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtcustomercity" placeholder="Customer City" runat="server" CssClass="custom-textbox"></asp:TextBox><br />
                            <%-- <asp:RequiredFieldValidator ID="customercityRequiredFieldValidator" runat="server" ControlToValidate="txtcustomercity" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Customer City"></asp:RequiredFieldValidator>
                            --%>
                            <br />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtcustomerMob" placeholder="Customer Mobile Number " runat="server" CssClass="custom-textbox"></asp:TextBox><br />
                            <%--  <asp:RequiredFieldValidator ID="txtcustomerMobRequiredFieldValidator" runat="server" ControlToValidate="txtcustomerMob" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Customer Mobile Number"></asp:RequiredFieldValidator>
                            --%>
                            <br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtcustomeremail" placeholder="Customer Email" runat="server" CssClass="custom-textbox"></asp:TextBox><br />
                            <%-- <asp:RequiredFieldValidator ID="customeremailRequiredFieldValidator" runat="server" ControlToValidate="txtcustomeremail" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Customer Email"></asp:RequiredFieldValidator>
                            --%>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtcustomerPAN" runat="server" placeholder="Customer PAN No." CssClass="custom-textbox"></asp:TextBox><br />
                            <%-- <asp:RequiredFieldValidator ID="customerPANRequiredFieldValidator1" runat="server" ControlToValidate="txtcustomerPAN" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Customer PAN Number"></asp:RequiredFieldValidator>
                            --%>
                            <br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtcustomergst" runat="server" placeholder="Customer GST" CssClass="custom-textbox"></asp:TextBox><br />
                            <%--<asp:RequiredFieldValidator ID="customergstRequiredFieldValidator" runat="server" ControlToValidate="txtcustomergst" ForeColor="Red" Font-Size="Small"
                                ErrorMessage="Enter Customer GST Number"></asp:RequiredFieldValidator>
                            --%>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                </table>



                <asp:Button ID="btnsubmitcustomerDetails" runat="server" CssClass="btnSubmit" Text="Submit" OnClick="btnsubmitcustomerDetails_Click" />
                <asp:Button ID="btnupdate" runat="server" Visible="false" CssClass="btnSubmit" Text="Update" OnClick="btnupdate_Click" />
                <br />
                <br />
                <asp:GridView ID="gvcustomers" runat="server" AutoGenerateColumns="false" CssClass="gvcustomerscss" OnRowCommand="gvcustomers_RowCommand" OnRowDeleting="gvcustomers_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("CustomerName") %>'></asp:Label>
                                <asp:Label ID="lblCustomerid" Visible="false" runat="server" Text='<%# Eval("CustomerId") %>' />
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Company Id">
                            <ItemTemplate>

                                <asp:Label ID="lblCompanyid" Visible="true" runat="server" Text='<%# Eval("CompanyId") %>' />
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("CustomerAddress") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("CustomerCity") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mobile">
                            <ItemTemplate>
                                <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("CustomerMobNo") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("CustomerEmail" )%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PAN">
                            <ItemTemplate>
                                <asp:Label ID="lblPAN" runat="server" Text='<%# Eval("CustomerPAN" )%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="GST">
                            <ItemTemplate>
                                <asp:Label ID="lblGST" runat="server" Text='<%# Eval("CustomerGST" )%>'></asp:Label>
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
        </div>

    </center>
</asp:Content>
