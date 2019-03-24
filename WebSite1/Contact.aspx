    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfContactID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name" />
                    </td>
                    <td>
                        <asp:TextBox ID="TxtName" runat="server" />
                    </td>

                    <tr>

                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Mobile" />
                    </td>
                    <td>
                        <asp:TextBox ID="TxtMobile" runat="server" />
                    </td>

                    <tr>

                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Address" />
                    </td>
                    <td>
                        <asp:TextBox ID="TxtAddress" runat="server"  TextMode="MultiLine"/>
                    </td>
                </tr>
                    </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Page_Load" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="Page_Load" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                     </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblSucessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                     </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                     </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ContactID") %>' >View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
