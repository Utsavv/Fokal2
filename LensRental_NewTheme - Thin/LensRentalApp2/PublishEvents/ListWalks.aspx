﻿<%@ Page Title="Photography Tours | Fokal.in" Language="C#" MasterPageFile="~/m_other.master" AutoEventWireup="true" CodeFile="ListWalks.aspx.cs" Inherits="ListTours" %>
<asp:Content ID="PagePath" ContentPlaceHolderID="title" runat="server">
    <div style="height:30px; margin-left : 10px;">
            <small><asp:HyperLink ID="Home" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink> » Walks</small> 
       </div>
</asp:Content>
<asp:Content ID="centreTopArticle" ContentPlaceHolderID="mainContent" runat="Server">
            <h1>Photo Walks</h1>            
                <asp:Panel ID="PanelSearchResult" runat="server">

                </asp:Panel>
 
</asp:Content>