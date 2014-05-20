<%@ Page Language="C#" AutoEventWireup="true" CodeFile="..\EventTemplate.aspx.cs" Inherits="PublishEvents_Default" MasterPageFile="~/M_Events.master" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="eventPic" runat="server">
<img width="968" alt="Event Poster" title="Event Poster" src="http://localhost:35475/publishevents/201405/./images/My-Community-My-Planet-Photo-Contest19000101.png" itemprop="image">
</asp:Content>

<asp:Content ID="Title"  ContentPlaceHolderID="eventName" runat="server">
My Community My Planet - Photo Contest
</asp:Content>
<asp:Content ID="Type"  ContentPlaceHolderID="eventType" runat="server">
Photography Event
</asp:Content>
<asp:Content ID="Date"  ContentPlaceHolderID="eventDate" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    Jan 1
</asp:Content>

<%-- OPTION : Either time or End Date would come --%>

<asp:Content ID="EventTime"  ContentPlaceHolderID="eventTime" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    <%--<a>00:00</a>
    <span class="ghost">|</span>--%>
</asp:Content>

<asp:Content ID="City"  ContentPlaceHolderID="eventCity" runat="server">
    Delhi
</asp:Content>
<asp:Content ID="Level"  ContentPlaceHolderID="eventLevel" runat="server">
<%-- Beginner, Amateur, Professional, For All--%>
    For All
</asp:Content>
<asp:Content ID="Theme"  ContentPlaceHolderID="eventTheme" runat="server">
<%-- General, Wildlife, Portrait, Cityscape, Landscape, Wedding, Fashion--%>
     Cityscape
</asp:Content>
<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
Send us your photographs of eco-friendly activities in your communities.

</asp:Content>

<asp:Content ID="OrganizerName"  ContentPlaceHolderID="eventOrganizerName" runat="server">
<%-- Add the local link of the vendor in href--%>

    <a href="http://localhost:35475/PSP/Pages/Span-Magazine.aspx" target="_blank">Span Magazine</a>
    
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
Send us your photographs of ecofriendly activities in your communities. The photographs should highlight the contest theme—“My Community, My Planet”—and depict how efforts by an individual or a group can contribute to the creation of a clean and healthy environment.
- Submit your Entries on http://span.state.gov/node/add/photo-contest
Prizes
1st prize: iPad mini
2nd prize: Nikon Coolpix L820
3rd prize: iPod Touch
We will also give one SPAN hamper each to
— The entry with the most likes
— The entry which scores highest on creativity
— The entry which scores highest on composition
— The entry which best depicts the theme
— The entry which scores highest on photo quality
— The entry which scores highest on originality

How to enter
— Photos must be submitted on the contest page. Please do not send entries by email or post.
— Files should be in .jpg, .gif, or .png format and not larger than 10 MB
Eligibility
— The contest is open to Indian citizens residing in India, aged 15 to 45 years.
— Employees of the U.S. Government and their families are not eligible for participation.
Judging criteria
Winners will be selected by a panel of judges including the Cultural Attaché of the U.S. Embassy; an official of the Earth Day Network, USA; SPAN magazine’s Art Director and Editor.
The criteria for judging are:
1. Creativity
2. Composition
3. Depicts the theme
4. Photo Quality
5. Originality

Read further rules here : http://span.state.gov/node/767

</asp:Content>
<asp:Content ID="EventWebPage" ContentPlaceHolderID="eventPage" runat="server">
    <%-- Mention the external webpage of the event if any --%>
    <a href="" target="_blank">Visit Event Page</a>
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
<%-- Any registration information goes here --%>
    Registration: Online
    Event Charges: Rs. 0
   </asp:Content>
<asp:Content ID="ContactPerson"  ContentPlaceHolderID="ContactPerson" runat="server">
    Chetna Khera
    
</asp:Content>
<asp:Content ID="vendorContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    011-2347-2135
    
</asp:Content>


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
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="EventContactNumber" runat="server">
<%-- Contact number If multiple do comma seperated --%>


</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">

    <span class="itemprop" itemprop="name">Span Magazine</span>
    
&nbsp;
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <a href="mailto:ezinespan@state.gov"> ezinespan@state.gov</a>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">

    
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">

    
</asp:Content>

<asp:Content ID="CourseContent" ContentPlaceHolderID="Content" runat="server">

    

</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    Photography Events
</asp:Content>
