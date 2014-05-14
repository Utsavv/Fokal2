<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PSPPageGenerator.aspx.cs" Inherits="PublishEvents_EventPageGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="VendorID" DataSourceID="SD" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="VendorID" HeaderText="VendorID" InsertVisible="False" ReadOnly="True" SortExpression="EventID" />
                <asp:BoundField DataField="VendorName" HeaderText="VendorName" SortExpression="EventName" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Generate Page" ShowHeader="True" Text="Generate" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SD" runat="server" ConnectionString="<%$ ConnectionStrings:Folksplore %>" SelectCommand="select VendorID,VendorName from tblvendor"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
