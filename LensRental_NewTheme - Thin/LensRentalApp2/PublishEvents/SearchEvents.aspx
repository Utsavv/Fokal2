<%@ Page Title="Search for Photography events | Fokal.in" Language="C#" MasterPageFile="~/m_fokalpage.master" AutoEventWireup="true" CodeFile="SearchEvents.aspx.cs" Inherits="SearchEvents" %>
<asp:Content ID="TopBanner" ContentPlaceHolderID="TopBannerImg" runat="server">
                                            <ul class="tpack">
                                        <li style=" background:url('..\\images\\banner_combined.png' ) top no-repeat #000000"; z-index: 1000; id="Li1">
                                            <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/PublishEvents/SearchEvents.aspx"></asp:HyperLink>
                                        </li>
                                        <li id="Li2"></li>
                                        <%--<li id="tpack3">3</li>--%>
                                    </ul>
                                    <div class="clear"></div>
                                    <%--<div class="sub_tpack">
                                        sdsdfdf
                                    </div>--%>
</asp:Content>

<asp:Content ID="homepage_centre_top" ContentPlaceHolderID="pageCentreTop" runat="server">
                                                                
    <%--<div id="homepage_center_top">--%>
                                <div >

</asp:Content>
<asp:Content ID="MainDetails" ContentPlaceHolderID="pageCentrePicture" runat="Server">
                                        
                                    
    </asp:Content>

<asp:Content ID="centreTopArticle" ContentPlaceHolderID="centreTopArticle" runat="Server">
    <h2 class="catHdr">Search For Events in your City</h2> <br />
        <%--<form runat="server">--%>
            <table border="0" cellspacing="0" cellpadding="0" width=0% class="eventsTable">
                <tr>
                    <td><label for="event" >Event Type</label></td>
            
                    <td><asp:DropDownList ID="dropEvent" DataTextField="EventName" DataValueField="id" style="width:200px; height:20px" runat="server" ValidationGroup="SearchEvents">
                            <asp:ListItem Text="Select Event" Value="null"></asp:ListItem>
                            <asp:ListItem Text="Course" Value="Course"></asp:ListItem>
                            <asp:ListItem Text="Workshop" Value="Workshop"></asp:ListItem>
                            <asp:ListItem Text="Event" Value="Event"></asp:ListItem>
                            <asp:ListItem Text="Tour" Value="Tour"></asp:ListItem>
                                
                        </asp:DropDownList></td>
                       
                    <td><label for="name"><span>C</span>ity</label></td>
                    
                    <td><asp:DropDownList ID="dropCity" runat="server" DataTextField="CityName" DataValueField="id" style="width:200px; height:20px" ValidationGroup="SearchEvents">
                                <asp:ListItem Text="Select City" Value="0"></asp:ListItem>
                                <asp:ListItem Text="National Capital Region" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Bangalore" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Hyderabad" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Kolkata" Value="8"></asp:ListItem>
                                <asp:ListItem Text="Chennai" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Mumbai" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Pune" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Chandigarh" Value="7"></asp:ListItem>
                            </asp:DropDownList></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Search" CausesValidation="true" ValidationGroup="SearchEvents" OnClick="btnSearch_Click" CssClass="submit-btn" /></td>
                </tr>
            </table>
            <%--Print the results--%>

            <section class="clearfix">
                     <asp:Panel ID="PanelSearchResult" runat="server">
                        
                      </asp:Panel>

                </section>
                     <%--</form>--%>

</asp:Content>
<asp:Content ID="SideBarCkass"  ContentPlaceHolderID="sidebarclasstop" runat="server">
<div id="homepage_sidebar_top">
 
</asp:Content>

