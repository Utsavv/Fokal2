<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="SpanMagazine.aspx.cs" Inherits="Home" %>

<asp:Content ID="VendorPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Event Poster" title="Event Poster" src="./images/span_utube_banner2.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="eventName" runat="server">
    SPAN Magazine
</asp:Content>
<asp:Content ID="Service1"  ContentPlaceHolderID="eventDate" runat="server">

    Magazine | Photography Contests
</asp:Content>


<%--<asp:Content ID="Service2"  ContentPlaceHolderID="eventCity" runat="server">
    <span class="ghost">|</span>
    Workshops
</asp:Content>
<asp:Content ID="Service3"  ContentPlaceHolderID="eventLevel" runat="server">
    <span class="ghost">|</span>
    Tours
</asp:Content>
<asp:Content ID="Service4"  ContentPlaceHolderID="eventTheme" runat="server">
    <span class="ghost">|</span>
    Exhibitions
</asp:Content>--%>

<asp:Content ID="Service5"  ContentPlaceHolderID="eventTime" runat="server">
    <%-- OPTIONAL - ANY OTHER EVENT IF THERE IS ONE --%>
<%--    <a>9:00 am</a>
    <span class="ghost">|</span>--%>
</asp:Content>

<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a > New delhi
    </a>
</asp:Content>

<asp:Content ID="OrgType" ContentPlaceHolderID="vendorOrganizationType" runat="server">
    Government
</asp:Content>
<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
    Since 1960, SPAN has linked India and the United States, offering articles from writers in both countries.
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
    Since 1960, SPAN has linked India and the United States, offering articles from writers in both countries on culture, business, technology, education, health, social development, arts and achievements in U.S.-India relations. Beautiful photography and also articles from the best American publications are showcased in every issue of SPAN, which is published in English, Hindi and Urdu.
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b>Chetna Khera
</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo2" runat="server">
    <%-- Any registration information goes here --%>
    <%--Registration: Online Payment/Check--%>
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
    <%-- AddressLine1 --%>
    American Center
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
    <%-- AddressLine2 --%>
    24 Kasturba Gandhi Marg
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
    
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
    New Delhi
</asp:Content>

<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    <%-- Contact number If multiple do comma seperated --%>
011-23472135

</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
     <a href="http://span.state.gov/" target="_blank">Visit Webpage</a>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <a href="mailto:editorspan@state.gov"> editorspan@state.gov</a>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">
<a href="https://www.facebook.com/americancenternewdelhi?sk=wall" target="_blank">SPAN Magazine on Facebook</a>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">
<a href="https://plus.google.com/+spanmagazine" target="_blank">SPAN Magazine on Google Plus</a>
</asp:Content>

<asp:Content ID="upcomingEvents" ContentPlaceHolderID="UpcomingEvents" runat="server" >
    <ul>
        <li>
            <asp:HyperLink runat="server" ID="event1" NavigateUrl="~/PublishEvents/May2014/MyCommunityMyPlanetPhotoContest.aspx">Photo Contest - My Community, My Planet</asp:HyperLink>
        </li>
    </ul>
</asp:Content>
