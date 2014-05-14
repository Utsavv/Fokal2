<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <table style="width: 600px; height: 200px">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMessage" runat="server" Text="lblMessage" Width="100%" BackColor="#C0C0FF" BorderColor="#FFE0C0" Font-Bold="True" Font-Size="Large" ForeColor="#C00000"></asp:Label>
                        </td>
                    </tr>
                    <tr style="text-align: center">
                        <td colspan="2"><b>Database Query</b></td>
                    </tr>
                    <tr>
                        <td>Database Name :- </td>
                        <td>
                            <asp:TextBox ID="txtDatabase" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtDatabaseValidator" ControlToValidate="txtDatabase" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="SQLQueryGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Database IP :- </td>
                        <td>
                            <asp:TextBox ID="txtIP" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtIP" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="SQLQueryGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Database UserName :- </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtUserNameValidator" ControlToValidate="txtUserName" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="SQLQueryGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Database Password :- </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtPasswordValidator" ControlToValidate="txtPassword" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="SQLQueryGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>SQL Query To Executer</td>
                        <td>
                            <asp:TextBox ID="txtSqlQuery" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtSqlQueryValidator" ControlToValidate="txtSqlQuery" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="SQLQueryGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnExecuteQuery" runat="server" Text="Execute Query" OnClick="btnExecuteQuery_Click" CausesValidation="true" ValidationGroup="SQLQueryGroup" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
