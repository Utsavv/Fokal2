<%@ Page Language="C#" AutoEventWireup="true" CodeFile="..\EventTemplate.aspx.cs" Inherits="PublishEvents_Default" MasterPageFile="~/M_Events.master" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="eventPic" runat="server">
<img height="200" width="355" alt="Event Poster" title="Event Poster" src=".//images//banner.png" itemprop="image">
</asp:Content>

<asp:Content ID="Title"  ContentPlaceHolderID="eventName" runat="server">
Your Pictures - By The Beach - Photo Contest
</asp:Content>
<asp:Content ID="Date"  ContentPlaceHolderID="eventDate" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    06-05-2014
</asp:Content>

<%-- OPTION : Either time or End Date would come --%>

<asp:Content ID="EventTime"  ContentPlaceHolderID="eventTime" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    <a>00:00</a>
    <span class="ghost">|</span>
</asp:Content>

<asp:Content ID="City"  ContentPlaceHolderID="eventCity" runat="server">
    Port Blair
</asp:Content>
<asp:Content ID="Level"  ContentPlaceHolderID="eventLevel" runat="server">
<%-- Beginner, Amateur, Professional, For All--%>
    For All
</asp:Content>
<asp:Content ID="Theme"  ContentPlaceHolderID="eventTheme" runat="server">
<%-- General, Wildlife, Portrait, Cityscape, Landscape, Wedding, Fashion--%>
    General
</asp:Content>
<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
Show Off your best beach pictures

</asp:Content>

<asp:Content ID="OrganizerName"  ContentPlaceHolderID="eventOrganizerName" runat="server">
<%-- Add the local link of the vendor in href--%>

    <span class="itemprop" itemprop="name">Better Photography </span>
    
</asp:Content>
<asp:Content ID="RegistrationCharges"  ContentPlaceHolderID="eventRegistrationCharges" runat="server">
<%-- Add Rs. before the charges --%>
<%-- Write 'Free' for no charges --%>
    Rs. 0
</asp:Content>
<asp:Content ID="RegistrationRequirements"  ContentPlaceHolderID="eventRegistrationRequirements" runat="server">
<%-- Prior Registration Needed --%>
<%-- Walk-In --%>
    Registration Not Required
</asp:Content>
<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
Show off your best beach pictures and stand a chance to get printed in Better Photography magazine.
One winner with the best picture will also win our limited edition Pocket Guide collection (Comprising of 12 guides on various genres of photography).
<%--    <ul>
        <li>Sessions only on Sundays</li>
        <li>Important concepts explained in a more practical manner</li>
        <li>Combination of indoor and outdoor classes for hands on experience</li>
        <li>Small group to ensure individual attention to each participant</li>
        <li>Certificate of participation</li>
    </ul>--%>
</asp:Content>
<asp:Content ID="EventWebPage" ContentPlaceHolderID="eventPage" runat="server">
    <%-- Mention the external webpage of the event if any --%>
    <a href="http://betterphotography.in/contest-listing/your-pictures-by-the-beach-4/" target="_blank">Visit </a><a href="http://betterphotography.in/contest-listing/your-pictures-by-the-beach-4/">Event Page</a>
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
<%-- Any registration information goes here --%>
    Register by: 25-05-2014 00:00:00</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo2" runat="server">
<%-- Any registration information goes here --%>
    Registration: Online
</asp:Content>


<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
<%-- AddressLine1 --%>
    Online
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


</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">

    <span class="itemprop" itemprop="name">Better Photography </span>
    
&nbsp;
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <a href="mailto:entries@betterphotography.in"> entries@betterphotography.in</a>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">

    <A HREF="https://www.facebook.com/betterphotography" target="_blank">Better Photography  On FB</a>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">

    http://<A HREF="" target="_blank">Better Photography  On Google Plus</a>
</asp:Content>

<asp:Content ID="CourseContent" ContentPlaceHolderID="Content" runat="server">
    
    <%--<ul>
        <li>Know your camera and what it can do for you</li>
        <li>Use different lighting situations to create drama in photos</li>
        <li>Learn principles of composition and framing</li>
        <li>What and how do you click pictures to create the ‘WOW’ effect!</li>
        <li>No need of an expensive camera, any digital camera would do</li>
    </ul>--%>
</asp:Content>
