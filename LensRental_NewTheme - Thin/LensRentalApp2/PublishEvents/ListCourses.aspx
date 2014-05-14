<%@ Page Title="Photography Tours | Fokal.in" Language="C#" MasterPageFile="~/m_other.master" AutoEventWireup="true" CodeFile="ListCourses.aspx.cs" Inherits="ListTours" %>
<asp:Content ID="PagePath" ContentPlaceHolderID="title" runat="server">
    <div style="height:30px; margin-left : 10px;">
            <small><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink> » Courses</small> 
       </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="Server">
            
            <h1>Photography Courses</h1>            
                <asp:Panel ID="PanelSearchResult" runat="server">

                </asp:Panel>
 
            
</asp:Content>
