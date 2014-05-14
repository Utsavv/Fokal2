<%@ Page Title="Events | Fokal.in" Language="C#" MasterPageFile="~/m_Events.master" AutoEventWireup="true" CodeFile="EventSample.aspx.cs" Inherits="Home" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="eventPic" runat="server">
<img height="200" width="355" alt="Event Poster" title="Event Poster" src=".//images//banner.png" itemprop="image">
</asp:Content>

<asp:Content ID="Title"  ContentPlaceHolderID="eventName" runat="server">
Beginner's Photography Workshop
</asp:Content>
<asp:Content ID="Date"  ContentPlaceHolderID="eventDate" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    29 April'14
</asp:Content>

<%-- OPTION : Either time or End Date would come --%>

<asp:Content ID="EventTime"  ContentPlaceHolderID="eventTime" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    <a>9:00 am</a>
    <span class="ghost">|</span>
</asp:Content>

<asp:Content ID="City"  ContentPlaceHolderID="eventCity" runat="server">
    Noida
</asp:Content>
<asp:Content ID="Level"  ContentPlaceHolderID="eventLevel" runat="server">
<%-- Beginner, Amateur, Professional, For All--%>
    Beginner
</asp:Content>
<asp:Content ID="Theme"  ContentPlaceHolderID="eventTheme" runat="server">
<%-- General, Wildlife, Portrait, Cityscape, Landscape, Wedding, Fashion--%>
    General
</asp:Content>
<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
Bought a camera recently or finally decided to learn photography? You are at the right place!

</asp:Content>

<asp:Content ID="OrganizerName"  ContentPlaceHolderID="eventOrganizerName" runat="server">
<%-- Add the local link of the vendor in href--%>

    <a href="\vendors\vendorsample.aspx">
        <span class="itemprop" itemprop="name">Delhi Photography Club</span>
    </a>
</asp:Content>
<asp:Content ID="RegistrationCharges"  ContentPlaceHolderID="eventRegistrationCharges" runat="server">
<%-- Add Rs. before the charges --%>
<%-- Write 'Free' for no charges --%>
    Rs. 6600
</asp:Content>
<asp:Content ID="RegistrationRequirements"  ContentPlaceHolderID="eventRegistrationRequirements" runat="server">
<%-- Prior Registration Needed --%>
<%-- Walk-In --%>
    Prior Registration Needed
</asp:Content>
<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
DPC organizes Beginners Workshops on Photography, exclusively for those who want to use photography as a medium to express themselves creatively.
This photography workshop is unique in many ways
    <ul>
        <li>Sessions only on Sundays</li>
        <li>Important concepts explained in a more practical manner</li>
        <li>Combination of indoor and outdoor classes for hands on experience</li>
        <li>Small group to ensure individual attention to each participant</li>
        <li>Certificate of participation</li>
    </ul>
</asp:Content>
<asp:Content ID="EventWebPage" ContentPlaceHolderID="eventPage" runat="server">
    <%-- Mention the external webpage of the event if any --%>
    <a href="http://www.delhiphotographyclub.com" target="_blank">Visit Webpage</a>
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
<%-- Any registration information goes here --%>
    Register by: 23 Apr'14
</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo2" runat="server">
<%-- Any registration information goes here --%>
    Registration: Online Payment/Check
</asp:Content>


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

<asp:Content ID="CourseContent" ContentPlaceHolderID="Content" runat="server">
    <h2>Photo Contest Rules</h2>
    <p class="rtecenter"><span style="color:#006400;"><span style="font-size:28px;">Rules</span></span></p>
<p>— Entries will be published on the SPAN website after approval by the moderator. Contest entries will be moderated during business hours (Monday to Friday, 8:30 a.m. to 5 p.m.) on working days. Entries submitted after business hours, on weekends or holidays will be moderated on the next working day.</p>
<p>— Contestants may submit up to five photos but only one photo will be eligible for a prize.</p>
<p>— The photo caption should explain the activity in the photograph and mention where it was taken.</p>
<p>— The person submitting the photo will be considered the contestant and will be the only person eligible to receive the prize.</p>
<p>— The entry must be the original work of the contestant.</p>
<p>— No copyrighted or plagiarized material may be submitted. Such entries will be disqualified.</p>
<p>— The photograph should not be significantly retouched: nothing in the photographs (people, animals, scenery, objects, etc.) may be altered, removed, augmented or rearranged. Changing the colors significantly in the image is not permitted. Cropping is permitted, as is modest darkening or lightening of parts of the image.</p>
<p>— Submissions should not have any visible watermarks, signatures, or personally identifiable information.</p>
<p>— The photograph must be shot in India.</p>
<p>— Once a photo is submitted, it is considered a final submission and may not be modified or edited, or replaced.</p>
</asp:Content>