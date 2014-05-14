<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventPageGenerator.aspx.cs" Inherits="PublishEvents_EventPageGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EventID,VendorID" DataSourceID="SD" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="EventID" HeaderText="EventID" InsertVisible="False" ReadOnly="True" SortExpression="EventID" />
                <asp:BoundField DataField="EventName" HeaderText="EventName" SortExpression="EventName" />
                <asp:BoundField DataField="VendorID" HeaderText="VendorID" InsertVisible="False" ReadOnly="True" SortExpression="VendorID" />
                <asp:BoundField DataField="VendorName" HeaderText="VendorName" SortExpression="VendorName" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Generate Page" ShowHeader="True" Text="Generate" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SD" runat="server" ConnectionString="<%$ ConnectionStrings:Folksplore %>" SelectCommand="select E.EventID,E.EventName,v.VendorID,v.VendorName
	FROM 
		TblEvent E	
	INNER JOIN TblVendor V ON V.VendorID=E.VendorID"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
