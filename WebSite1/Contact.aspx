    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name" />º
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtName" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Mobile" />º
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtMobile" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Address" />º
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtAddress" runat="server" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
