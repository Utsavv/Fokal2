<%@ Page Language="C#" AutoEventWireup="true" CodeFile="..\EventTemplate.aspx.cs" Inherits="PublishEvents_Default" MasterPageFile="~/M_Events.master" %>

<asp:Content ID="EventPicture"  ContentPlaceHolderID="eventPic" runat="server">
<img width="968" alt="Event Poster" title="Event Poster" src="http://localhost:35475/PublishEvents/201405/./images/The-Basic-Photography-Course-Weekends-20140607.png" itemprop="image">
</asp:Content>

<asp:Content ID="Title"  ContentPlaceHolderID="eventName" runat="server">
The Basic Photography Course (Weekends)
</asp:Content>
<asp:Content ID="Type"  ContentPlaceHolderID="eventType" runat="server">
Photography Course
</asp:Content>
<asp:Content ID="Date"  ContentPlaceHolderID="eventDate" runat="server">
<%-- Date format 'DD Month'yy' like 29 April'14 --%>
    Jun 7
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
    Beginner
</asp:Content>
<asp:Content ID="Theme"  ContentPlaceHolderID="eventTheme" runat="server">
<%-- General, Wildlife, Portrait, Cityscape, Landscape, Wedding, Fashion--%>
     General
</asp:Content>
<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
Basic is aimed for rank beginners, who have either recently bought a camera and would like to improve their travel and family photographs. 

</asp:Content>

<asp:Content ID="OrganizerName"  ContentPlaceHolderID="eventOrganizerName" runat="server">
<%-- Add the local link of the vendor in href--%>

    <a href="http://localhost:35475/PSP/Pages/Udaan-School-of-Photography.aspx" target="_blank">Udaan School of Photography</a>
    
</asp:Content>
<asp:Content ID="RegistrationCharges"  ContentPlaceHolderID="eventRegistrationCharges" runat="server">
<%-- Add Rs. before the charges --%>
<%-- Write 'Free' for no charges --%>
    Rs. 4250
</asp:Content>
<asp:Content ID="RegistrationRequirements"  ContentPlaceHolderID="eventRegistrationRequirements" runat="server">
<%-- Prior Registration Needed --%>
<%-- Walk-In --%>
    Registration Required
</asp:Content>
<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
Day 1 -  	Discussing choices in photography as a profession. Understanding the camera and its components, Brief history of camera and photography, Understanding light, Understanding Film and digital Sensor, Understanding digital photography, Image recording and storage device. Understanding light.  Colour theory, Colour correction and White Balance
Day 2 - Review of Assignment, Demonstration of Colour correction and Custom White Balance. Understanding and controlling exposure. Using Aperture, Shutter and film speeds (ISO). Adjusting exposure and Exposure Compensation Basic understanding of Depth of Field. 
Day 3 - Review of Assignment, Internal light meter and types of metering. How to effectively use light meter.  Understanding lenses. Types and uses of lenses. Methods of focusing. Understanding and effectively using Depth of field (Theory)
Day 4 - Review of Assignment Understanding and effectively using Depth of field (Demonstrations).  Freezing motion. Understanding different light situations. Handling low light. Understanding flash and methods to creatively use flash.
Day 5 - Review of Assignment Handling difficult light situations. Creatively adjusting exposures. How to create silhouettes, pan effects, zoom bursts, etc 
Day 6 - Review of Assignment. Image Resolution and camera settings. RAW vs Jpeg. Photo editing. Basics of Adobe Photoshop. Basic rules of composition. Shooting techniques. Photographing people. Tips for candid photography. Photography on the field – thinking by yourself.  

</asp:Content>
<asp:Content ID="EventWebPage" ContentPlaceHolderID="eventPage" runat="server">
    <%-- Mention the external webpage of the event if any --%>
    <a href="http://www.udaan.org.in/basic.html" target="_blank">Visit Event Page</a>
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="registrationHowTo" runat="server">
<%-- Any registration information goes here --%>
    Registration: Online
    Event Charges: Rs. 4250
   </asp:Content>
<asp:Content ID="ContactPerson"  ContentPlaceHolderID="ContactPerson" runat="server">
    Udaan School
    
</asp:Content>
<asp:Content ID="vendorContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    9619315130 
    
</asp:Content>


<asp:Content ID="EventAddressLine1"  ContentPlaceHolderID="eventAddressLine1" runat="server">
<%-- AddressLine1 --%>
    "Saini Bhavan" No. T-806/C-2 (A-179 Pvt.),
</asp:Content>
<asp:Content ID="EventAddressLine2"  ContentPlaceHolderID="eventAddressLine2" runat="server">
<%-- AddressLine2 --%>
    situated at Sukhdev Market, Bhishma Pithamah Marg,
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
<%-- Near <Landmark> --%>
    Opposite A-Block Defence Colony,
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
<%-- City, State--%>
    Delhi
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="EventContactNumber" runat="server">
<%-- Contact number If multiple do comma seperated --%>


</asp:Content>
<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">

    <span class="itemprop" itemprop="name"><A HREF="http://www.udaan.org.in/" target="_blank">Udaan School of Photography</a></span>
    
&nbsp;
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <a href="mailto:enquiry.udaan.delhi@gmail.com"> enquiry.udaan.delhi@gmail.com</a>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">

    <A HREF="http://www.facebook.com/udaan.photoschool?ref=search#!/udaan.photoschool?v=wall&ref=search" target="_blank">Udaan School of Photography On FB</a>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">

    
</asp:Content>

<asp:Content ID="CourseContent" ContentPlaceHolderID="Content" runat="server">

    Class Timings: Sat and Sun at 3.30 pm to 6.30 pm

Course Fee for Basic Photography course

For Indian Students : Rs 4250*
For International Students : $ 100*

Course Fee for Basic & Advanced co

</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    Photography Courses
</asp:Content>
