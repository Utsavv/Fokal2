<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="..\PSPTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="VendorPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Vendor Poster" title="Vendor Poster" src="http://localhost:35475/PSP/Pages/../images/Span-Magazine.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="vendorName" runat="server">
    Span Magazine 
</asp:Content>

<asp:Content ID="Services"  ContentPlaceHolderID="vendorServiceType" runat="server">
     Event 
</asp:Content>


<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a >  Delhi
    </a>
</asp:Content>
<asp:Content ID="vendorOrganizationType" ContentPlaceHolderID="vendorOrganizationType" runat="server">
   <%-- {{OrgType}}--%>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
     Since 1960, SPAN has linked India and the United States, offering articles from writers in both countries.
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
     Since 1960, SPAN has linked India and the United States, offering articles from writers in both countries on culture, business, technology, education, health, social development, arts and achievements in U.S.-India relations. Beautiful photography and also articles from the best American publications are showcased in every issue of SPAN, which is published in English, Hindi and Urdu.
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="ContactPerson" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b> Chetna Khera
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    
 <b>Contact Number: </b>011-2347-2135

</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Any registration information goes here --%>
   <%-- Registration:  {{RegistrationModes}}--%>
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
    <%-- AddressLine1 --%>
     American Center
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
    <%-- AddressLine2 --%>
     24 Kasturba Gandhi Marg,
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
     
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
     Delhi
</asp:Content>


<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
    
    <%--<a href="http://www.delhiphotographyclub.com/" target="_blank"> Delhi Photography Club</a>--%>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <A HREF="mailto:ezinespan@state.gov">ezinespan@state.gov</a>
    <%--<a href="mailto:hi@delhiphotographyclub.com"> hi@delhiphotographyclub.com</a>--%>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">
    
    <%--<a href="http://www.facebook.com/fokaldotin" target="_blank">Delhi Photography Club on Facebook</a>--%>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">
    
    <%--<a href="http://www.facebook.com/fokaldotin" target="_blank">DPC on Google Plus</a>--%>
</asp:Content>

<asp:Content ID="upcomingEvents" ContentPlaceHolderID="UpcomingEvents" runat="server" >
    <ul>
        <li>
            <a href="http://localhost:35475/publishevents/201405/Span-Magazine-My-Community-My-Planet-Photo-Contest19000101.aspx" >My Community My Planet - Photo Contest</a>
        </li>
        <li>
            <a href="" ></a>
        </li>
        <li>
            <a href="" ></a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    Span Magazine
</asp:Content>

