<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="PSPTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Event Poster" title="Event Poster" src=".//images//banner.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="eventName" runat="server">
    {{VendorName}} 
</asp:Content>

<asp:Content ID="Service1"  ContentPlaceHolderID="eventDate" runat="server">
    {{ServiceType1}} 
</asp:Content>

<asp:Content ID="Service2"  ContentPlaceHolderID="eventCity" runat="server">
     {{ServiceType2}}
</asp:Content>

<asp:Content ID="Service3"  ContentPlaceHolderID="eventLevel" runat="server">

     {{ServiceType3}}
</asp:Content>
<asp:Content ID="Service4"  ContentPlaceHolderID="eventTheme" runat="server">

     {{ServiceType4}}
</asp:Content>

<asp:Content ID="Service5"  ContentPlaceHolderID="eventTime" runat="server">
    <%-- OPTIONAL - ANY OTHER EVENT IF THERE IS ONE --%>
<%--    <a>9:00 am</a>
    <span class="ghost">|</span>--%>
</asp:Content>

<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a >  {{VendorCity}}
    </a>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
     {{VendorShortDescription}}
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
     {{VendorDetailedDescription}}
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b> {{ContactPerson}}
</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo2" runat="server">
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

<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    <%-- Contact number If multiple do comma seperated --%>
 {{ContactNumber}}

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
            {{VendorLatestEventLocalLink1}}
        </li>
        <li>
            {{VendorLatestEventLocalLink2}}
        </li>
        <li>
            {{VendorLatestEventLocalLink3}}
        </li>
    </ul>
</asp:Content>
