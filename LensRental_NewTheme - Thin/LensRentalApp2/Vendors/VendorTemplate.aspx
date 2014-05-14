<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="VendorTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="eventPic" runat="server">
    <img height="200" width="355" alt="Event Poster" title="Event Poster" src=".//images//banner.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="eventName" runat="server">
    &lt;&lt;VendorName&gt;&gt;
</asp:Content>
<asp:Content ID="Service1"  ContentPlaceHolderID="eventDate" runat="server">

    &lt;&lt;ServiceType1&gt;&gt;
</asp:Content>


<asp:Content ID="Service2"  ContentPlaceHolderID="eventCity" runat="server">
    &lt;&lt;ServiceType2&gt;&gt;
</asp:Content>
<asp:Content ID="Service3"  ContentPlaceHolderID="eventLevel" runat="server">

    &lt;&lt;ServiceType3&gt;&gt;
</asp:Content>
<asp:Content ID="Service4"  ContentPlaceHolderID="eventTheme" runat="server">

    &lt;&lt;ServiceType4&gt;&gt;
</asp:Content>

<asp:Content ID="Service5"  ContentPlaceHolderID="eventTime" runat="server">
    <%-- OPTIONAL - ANY OTHER EVENT IF THERE IS ONE --%>
<%--    <a>9:00 am</a>
    <span class="ghost">|</span>--%>
</asp:Content>

<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a > &lt;&lt;VendorCity&gt;&gt;
    </a>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
    &lt;&lt;VendorShortDescription&gt;&gt;
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
    &lt;&lt;VendorDetailedDescription&gt;&gt;
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b>&lt;&lt;ContactPerson&gt;&gt;
</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo2" runat="server">
    <%-- Any registration information goes here --%>
    Registration: &lt;&lt;RegistrationModes&gt;&gt;
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
    <%-- AddressLine1 --%>
    &lt;&lt;AddressLine1&gt;&gt;
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
    <%-- AddressLine2 --%>
    &lt;&lt;AddressLine2&gt;&gt;
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
    &lt;&lt;Landmark&gt;&gt;
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
    &lt;&lt;VendorCity&gt;&gt;
</asp:Content>

<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    <%-- Contact number If multiple do comma seperated --%>
&lt;&lt;ContactNumber&gt;&gt;

</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
    <a href="http://www.delhiphotographyclub.com/" target="_blank"> Delhi Photography Club</a>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <a href="mailto:hi@delhiphotographyclub.com"> hi@delhiphotographyclub.com</a>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">
    <a href="http://www.facebook.com/fokaldotin" target="_blank">Delhi Photography Club on Facebook</a>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">
    <a href="http://www.facebook.com/fokaldotin" target="_blank">DPC on Google Plus</a>
</asp:Content>

