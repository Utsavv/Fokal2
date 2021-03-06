<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="..\PSPTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="VendorPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Vendor Poster" title="Vendor Poster" src="../images/BetterPhotography.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="eventName" runat="server">
    Better Photography 
</asp:Content>

<asp:Content ID="Service1"  ContentPlaceHolderID="eventDate" runat="server">
     Exhibition 
</asp:Content>

<asp:Content ID="Service5"  ContentPlaceHolderID="eventTime" runat="server">
    <%-- OPTIONAL - ANY OTHER EVENT IF THERE IS ONE --%>
<%--    <a>9:00 am</a>
    <span class="ghost">|</span>--%>
</asp:Content>

<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a >  Port Blair
    </a>
</asp:Content>
<asp:Content ID="vendorOrganizationType" ContentPlaceHolderID="vendorOrganizationType" runat="server">
    {{OrgType}}
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
     
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
     
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b> shruti
</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo2" runat="server">
    <%-- Any registration information goes here --%>
   <%-- Registration:  {{RegistrationModes}}--%>
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
    <%-- AddressLine1 --%>
     Network18 Media & Investments Ltd
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
    <%-- AddressLine2 --%>
     
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
     
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
     Port Blair
</asp:Content>

<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    <%-- Contact number If multiple do comma seperated --%>
 9971510317

</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
    <A HREF="http://www.shrut5i.com" target="_blank">www.shrut5i.com</a>
    <%--<a href="http://www.delhiphotographyclub.com/" target="_blank"> Delhi Photography Club</a>--%>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <A HREF="mailto:entries@fgfg.in">entries@fgfg.in</a>
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

