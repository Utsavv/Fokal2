<%@ Page Language="C#" AutoEventWireup="true" CodeFile="..\EventTemplate.aspx.cs" Inherits="PublishEvents_Default" MasterPageFile="~/M_Events.master" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="eventPic" runat="server">
<img width="968" alt="Event Poster" title="Event Poster" src="http://localhost:35475/publishevents/201405/./images/YourPicturesByTheBeachPhotoContest.png" itemprop="image">
</asp:Content>

<asp:Content ID="Title"  ContentPlaceHolderID="eventName" runat="server">
Your Pictures - By The Beach (Photo Contest)
</asp:Content>
<asp:Content ID="Type"  ContentPlaceHolderID="eventType" runat="server">
Photography http://fokal.in/PublishEvents/201405/BetterPhotography_YourPictures-ByTheBeach(PhotoContest)20140506.aspx
</asp:Content>
<asp:Content ID="Date"  ContentPlaceHolderID="eventDate" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    06-05-2014
</asp:Content>

<%-- OPTION : Either time or End Date would come --%>

<asp:Content ID="EventTime"  ContentPlaceHolderID="eventTime" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    <%--<a>00:00</a>
    <span class="ghost">|</span>--%>
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
General

</asp:Content>

<asp:Content ID="OrganizerName"  ContentPlaceHolderID="eventOrganizerName" runat="server">
<%-- Add the local link of the vendor in href--%>

    <a href="Better Photography" target="_blank">Show Off your best beach pictures</a>
    
</asp:Content>
<asp:Content ID="RegistrationCharges"  ContentPlaceHolderID="eventRegistrationCharges" runat="server">
<%-- Add Rs. before the charges --%>
<%-- Write 'Free' for no charges --%>
    Rs. 
</asp:Content>
<asp:Content ID="RegistrationRequirements"  ContentPlaceHolderID="eventRegistrationRequirements" runat="server">
<%-- Prior Registration Needed --%>
<%-- Walk-In --%>
    0
</asp:Content>
<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
Registration Not Required

</asp:Content>
<asp:Content ID="EventWebPage" ContentPlaceHolderID="eventPage" runat="server">
    <%-- Mention the external webpage of the event if any --%>
    <a href="Show off your best beach pictures and stand a chance to get printed in Better Photography magazine.
One winner with the best picture will also win our limited edition Pocket Guide collection (Comprising of 12 guides on various genres of photography)." target="_blank">Visit Event Page</a>
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
<%-- Any registration information goes here --%>
    Registration: Online
    Event Charges: Rs. 
   Register By: http://betterphotography.in/contest-listing/your-pictures-by-the-beach-4/</asp:Content>
<asp:Content ID="ContactPerson"  ContentPlaceHolderID="ContactPerson" runat="server">

    
</asp:Content>
<asp:Content ID="vendorContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    {{VendorContactNumber}}
    
</asp:Content>


<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
<%-- AddressLine1 --%>
    01-01-1900 00:00:00
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
<%-- AddressLine2 --%>
    Online
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
<%-- Near <Landmark> --%>
    
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
<%-- City, State--%>
    Port Blair
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="EventContactNumber" runat="server">
<%-- Contact number If multiple do comma seperated --%>


</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">

    <span class="itemprop" itemprop="name"><A HREF="http://Rules
1. You can submit multiple photos in any contest. However, photos need to be uploaded only one at a time.
2. Photos submitted must be at least 640 pixels on the shorter side, and no more than " target="_blank">Show Off your best beach pictures</a></span>
    
&nbsp;
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <a href="mailto:"> </a>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">

    <A HREF="http://entries@betterphotography.in" target="_blank">Show Off your best beach pictures On FB</a>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">

    
</asp:Content>

<asp:Content ID="CourseContent" ContentPlaceHolderID="Content" runat="server">

    

</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    Photography http://fokal.in/PublishEvents/201405/BetterPhotography_YourPictures-ByTheBeach(PhotoContest)20140506.aspxs
</asp:Content>
