<%@ Page Title="Photography Tours | Fokal.in" Language="C#" MasterPageFile="~/m_other.master" AutoEventWireup="true" CodeFile="ListPSP.aspx.cs" Inherits="ListTours" %>
<asp:Content ID="PagePath" ContentPlaceHolderID="title" runat="server">
    <div style="height:30px; margin-left : 10px;">
            <small><asp:HyperLink ID="Home" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink> » Photography Service Providers</small> 
       </div>
</asp:Content>
<asp:Content ID="centreTopArticle" ContentPlaceHolderID="mainContent" runat="Server">
            <h1>Photography Service Providers</h1>     
    <%--<table >
            <tbody>
                <tr >
                    <td class="vendorimagebox">
                        <div class="vendorimage">
                            <a href="#">
                             <img class="smallvendorimage" src="http://www.fokal.in/images/logo-v2.jpg" />
                            </a>
                        </div>
                    </td>
                    <td class="vendorDetails">
                        
                        <h2 >
                            <a href="EventTemplate.aspx">Event Local Page Path</a>
                        </h2>
                        <small >
                            <span >
                                Organizer: 
                            </span>
                                Samsung
                        </small>
                        <div>
                        <small>
                            <span >
                                EventSubCategory
                            </span>
                            |
                            <span >
                                City
                            </span>
                            |
                            <span >
                                Theme
                            </span>
                        </small>
                            </div>
                            
                    </td>

                </tr>
                                
            </tbody>
        </table>       --%>
                <asp:Panel ID="PanelSearchResult" runat="server">

                </asp:Panel>
 
</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    Photography Events
</asp:Content>

   