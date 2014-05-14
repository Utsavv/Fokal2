<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="VendorSample.aspx.cs" Inherits="Home" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Event Poster" title="Event Poster" src=".//images//banner.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="eventName" runat="server">
    &lt;&lt;VendorName&gt;&gt;
</asp:Content>
<asp:Content ID="Service1"  ContentPlaceHolderID="eventDate" runat="server">

    Courses
</asp:Content>


<asp:Content ID="Service2"  ContentPlaceHolderID="eventCity" runat="server">
    Workshops
</asp:Content>
<asp:Content ID="Service3"  ContentPlaceHolderID="eventLevel" runat="server">

    Tours
</asp:Content>
<asp:Content ID="Service4"  ContentPlaceHolderID="eventTheme" runat="server">

    Exhibitions
</asp:Content>

<asp:Content ID="Service5"  ContentPlaceHolderID="eventTime" runat="server">
    <%-- OPTIONAL - ANY OTHER EVENT IF THERE IS ONE --%>
<%--    <a>9:00 am</a>
    <span class="ghost">|</span>--%>
</asp:Content>

<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a > New Delhi
    </a>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
    This is about you and about me. Photography is our common thread and that’s what this club is about. So whenever you want to know about the club, just add up your enthusiasm with other fellow enthusiasts and the sum will add up to what the Club is. 
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
    Founded in 2002 by Robert De Niro, Jane Rosenthal and Craig Hatkoff to spotlight the New York filmmaking community, the Tribeca Film Festival has become a destination for both locals and international filmmakers alike. Check our Tribeca Film Festival 2014 section, sponsored by Pepsi, for daily photo updates on this year's edition of the festival, running from April 16-27. You can also use our handy Mini-Guide to explore the feature films screening at Tribeca this year.
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b>Mr. Narender Kumar
</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo2" runat="server">
    <%-- Any registration information goes here --%>
    Registration: Online Payment/Check
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
    <%-- AddressLine1 --%>
    Hauz Khas Village
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
    <%-- AddressLine2 --%>
    Shikarpur Village
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
    Near IIT Delhi
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
    New Delhi
</asp:Content>

<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    <%-- Contact number If multiple do comma seperated --%>
+91 8826712162

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

