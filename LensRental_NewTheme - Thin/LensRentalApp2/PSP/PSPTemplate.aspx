﻿<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="PSPTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="VendorPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Vendor Poster" title="Vendor Poster" src="{{VendorPic}}" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="vendorName" runat="server">
    {{VendorName}} 
</asp:Content>

<asp:Content ID="Services"  ContentPlaceHolderID="vendorServiceType" runat="server">
    {{ServiceType}} 
</asp:Content>


<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a >  {{VendorCity}}
    </a>
</asp:Content>
<asp:Content ID="vendorOrganizationType" ContentPlaceHolderID="vendorOrganizationType" runat="server">
   <%-- {{OrgType}}--%>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
     {{VendorShortDescription}}
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
     {{VendorDetailedDescription}}
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="ContactPerson" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b> {{ContactPerson}}
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    
 <b>Contact Number: </b>{{ContactNumber}}

</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Any registration information goes here --%>
   <%-- Registration:  {{RegistrationModes}}--%>
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
    <%-- AddressLine1 --%>
     {{AddressLine1}}
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
    <%-- AddressLine2 --%>
     {{AddressLine2}}
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
     {{Landmark}}
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
     {{VendorCity}}
</asp:Content>


<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
    {{VendorWebPage}}
    <%--<a href="http://www.delhiphotographyclub.com/" target="_blank"> Delhi Photography Club</a>--%>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    {{VendorEmail}}
    <%--<a href="mailto:hi@delhiphotographyclub.com"> hi@delhiphotographyclub.com</a>--%>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">
    {{VendorFBPageLink}}
    <%--<a href="http://www.facebook.com/fokaldotin" target="_blank">Delhi Photography Club on Facebook</a>--%>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">
    {{VendorGooglePlusPageLink}}
    <%--<a href="http://www.facebook.com/fokaldotin" target="_blank">DPC on Google Plus</a>--%>
</asp:Content>

<asp:Content ID="upcomingEvents" ContentPlaceHolderID="UpcomingEvents" runat="server" >
    <ul>
        <li>
            <a href="{{VendorLatestEventLocalLink1}}" >{{VendorLatestEvent1}}</a>
        </li>
        <li>
            <a href="{{VendorLatestEventLocalLink2}}" >{{VendorLatestEvent2}}</a>
        </li>
        <li>
            <a href="{{VendorLatestEventLocalLink3}}" >{{VendorLatestEvent3}}</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    {{VendorName}}
</asp:Content>
