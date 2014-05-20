<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="..\PSPTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="VendorPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Vendor Poster" title="Vendor Poster" src="http://localhost:35475/PSP/Pages/../images/Darter-Photography.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="vendorName" runat="server">
    Darter Photography 
</asp:Content>

<asp:Content ID="Services"  ContentPlaceHolderID="vendorServiceType" runat="server">
     Walk | Tour | Event | Workshop 
</asp:Content>


<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a >  Bangalore
    </a>
</asp:Content>
<asp:Content ID="vendorOrganizationType" ContentPlaceHolderID="vendorOrganizationType" runat="server">
   <%-- {{OrgType}}--%>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
     Darter Photography offers a unique outdoor photography experience to exciting destinations across India.
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
     
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="ContactPerson" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b> Arun Bhat, Shreeram M V 
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    
 <b>Contact Number: </b>91-9880006460, 91-9740083260

</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Any registration information goes here --%>
   <%-- Registration:  {{RegistrationModes}}--%>
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
    <%-- AddressLine1 --%>
     
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
    <%-- AddressLine2 --%>
     
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
     
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
     Bangalore
</asp:Content>


<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
    
    <%--<a href="http://www.delhiphotographyclub.com/" target="_blank"> Delhi Photography Club</a>--%>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <A HREF="mailto:register@darter.in">register@darter.in</a>
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
            <a href="" ></a>
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
    Darter Photography
</asp:Content>

