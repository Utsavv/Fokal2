﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventTemplate.aspx.cs" Inherits="PublishEvents_Default" MasterPageFile="~/M_Events.master" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="eventPic" runat="server">
<img width="968" alt="Event Poster" title="Event Poster" src="{{EventPic}}" itemprop="image">
</asp:Content>

<asp:Content ID="Title"  ContentPlaceHolderID="eventName" runat="server">
{{EventName}}
</asp:Content>
<asp:Content ID="Type"  ContentPlaceHolderID="eventType" runat="server">
Photography {{EventType}}
</asp:Content>
<asp:Content ID="Date"  ContentPlaceHolderID="eventDate" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    {{EventStartDate}}
</asp:Content>

<%-- OPTION : Either time or End Date would come --%>

<asp:Content ID="EventTime"  ContentPlaceHolderID="eventTime" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    <%--<a>{{EventStartTime}}</a>
    <span class="ghost">|</span>--%>
</asp:Content>

<asp:Content ID="City"  ContentPlaceHolderID="eventCity" runat="server">
    {{EventCity}}
</asp:Content>
<asp:Content ID="Level"  ContentPlaceHolderID="eventLevel" runat="server">
<%-- Beginner, Amateur, Professional, For All--%>
    {{EventAudienceLevel}}
</asp:Content>
<asp:Content ID="Theme"  ContentPlaceHolderID="eventTheme" runat="server">
<%-- General, Wildlife, Portrait, Cityscape, Landscape, Wedding, Fashion--%>
    {{EventTheme}}
</asp:Content>
<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
{{EventShortDescription}}

</asp:Content>

<asp:Content ID="OrganizerName"  ContentPlaceHolderID="eventOrganizerName" runat="server">
<%-- Add the local link of the vendor in href--%>

    <a href="{{VendorLocalName}}" target="_blank">{{VendorName}}</a>
    
</asp:Content>
<asp:Content ID="RegistrationCharges"  ContentPlaceHolderID="eventRegistrationCharges" runat="server">
<%-- Add Rs. before the charges --%>
<%-- Write 'Free' for no charges --%>
    Rs. {{EventFee}}
</asp:Content>
<asp:Content ID="RegistrationRequirements"  ContentPlaceHolderID="eventRegistrationRequirements" runat="server">
<%-- Prior Registration Needed --%>
<%-- Walk-In --%>
    {{EventPriorRegistrationRequirement}}
</asp:Content>
<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
{{EventDetailedDescription}}

</asp:Content>
<asp:Content ID="EventWebPage" ContentPlaceHolderID="eventPage" runat="server">
    <%-- Mention the external webpage of the event if any --%>
    <a href="{{EventPagePath}}" target="_blank">Visit Event Page</a>
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
<%-- Any registration information goes here --%>
    Registration: {{EventRegistrationMode}}
    Event Charges: Rs. {{EventFee}}
   {{EventRegistrationLastDate}}</asp:Content>
<asp:Content ID="ContactPerson"  ContentPlaceHolderID="ContactPerson" runat="server">
    {{VendorContactPerson}}
    
</asp:Content>
<asp:Content ID="vendorContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    {{VendorContactNumber}}
    
</asp:Content>


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
    {{City}}
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="EventContactNumber" runat="server">
<%-- Contact number If multiple do comma seperated --%>
{{EventContactNumber}}

</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">

    <span class="itemprop" itemprop="name">{{VendorWebName}}</span>
    
&nbsp;
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <a href="mailto:{{EMail}}"> {{EMail}}</a>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">

    {{VendorNameFB}}
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">

    {{VendorNameGooglePlus}}
</asp:Content>

<asp:Content ID="CourseContent" ContentPlaceHolderID="Content" runat="server">

    {{EventContent}}

</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    Photography {{EventType}}s
</asp:Content>