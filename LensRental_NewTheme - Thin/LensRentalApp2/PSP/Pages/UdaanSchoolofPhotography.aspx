<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="..\PSPTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="VendorPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Vendor Poster" title="Vendor Poster" src="http://localhost:35475/PSP/Pages/../images/UdaanSchoolofPhotography.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="vendorName" runat="server">
    Udaan School of Photography 
</asp:Content>

<asp:Content ID="Services"  ContentPlaceHolderID="vendorServiceType" runat="server">
     Workshop | Course 
</asp:Content>


<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a >  Delhi
    </a>
</asp:Content>
<asp:Content ID="vendorOrganizationType" ContentPlaceHolderID="vendorOrganizationType" runat="server">
   <%-- {{OrgType}}--%>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
     Udaan aims to add wings to your dreams in photography, irrespective of your final destination with your camera. 
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
     The one thing that binds students at Udaan is - passion for photography. Every student of Udaan, whatever his or her final aspiration, will be tutored by leading working professionals. The courses in Udaan have been designed to meet the needs of photography-enthusiasts at different levels of learning and expertise -- from those who are interested in shooting good family photographs or landscapes to cutting-edge, world-class professionals. 

</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="ContactPerson" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b> Udaan School
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    
 <b>Contact Number: </b>9619315130 

</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo" runat="server">
    <%-- Any registration information goes here --%>
   <%-- Registration:  {{RegistrationModes}}--%>
</asp:Content>

<%-- CONTACT DETAILS AND SOCIAL PROFILE --%>
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


<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
    <A HREF="http://www.udaan.org.in/" target="_blank">http://www.udaan.org.in/</a>
    <%--<a href="http://www.delhiphotographyclub.com/" target="_blank"> Delhi Photography Club</a>--%>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <A HREF="mailto:enquiry.udaan.delhi@gmail.com">enquiry.udaan.delhi@gmail.com</a>
    <%--<a href="mailto:hi@delhiphotographyclub.com"> hi@delhiphotographyclub.com</a>--%>
</asp:Content>
<asp:Content ID="VendorFacebookPage"  ContentPlaceHolderID="vendorFacebookPage" runat="server">
    <A HREF="http://www.facebook.com/udaan.photoschool?ref=search#!/udaan.photoschool?v=wall&ref=search" target="_blank">Udaan School of Photography On FB</a>
    <%--<a href="http://www.facebook.com/fokaldotin" target="_blank">Delhi Photography Club on Facebook</a>--%>
</asp:Content>
<asp:Content ID="VendorGooglePage"  ContentPlaceHolderID="vendorGooglePage" runat="server">
    
    <%--<a href="http://www.facebook.com/fokaldotin" target="_blank">DPC on Google Plus</a>--%>
</asp:Content>

<asp:Content ID="upcomingEvents" ContentPlaceHolderID="UpcomingEvents" runat="server" >
    <ul>
        <li>
            <a href="http://localhost:35475/publishevents/201405/UdaanSchoolofPhotography-TheBasicPhotographyCourseWeekends20140607.aspx" >The Basic Photography Course (Weekends)</a>
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
    Udaan School of Photography
</asp:Content>

