<%@ Page Title="Vendor | Fokal.in" Language="C#" MasterPageFile="~/m_Vendor.master" AutoEventWireup="true" CodeFile="..\PSPTemplate.aspx.cs" Inherits="Home" %>

<asp:Content ID="VendorPicture"  ContentPlaceHolderID="vendorPic" runat="server">
    <img height="200" width="355" alt="Vendor Poster" title="Vendor Poster" src="http://localhost:35475/PSP/Pages/../images/Better-Photography.png" itemprop="image">
</asp:Content>

<asp:Content ID="VendorName"  ContentPlaceHolderID="vendorName" runat="server">
    Better Photography 
</asp:Content>

<asp:Content ID="Services"  ContentPlaceHolderID="vendorServiceType" runat="server">
     Event 
</asp:Content>


<asp:Content ID="Location"  ContentPlaceHolderID="eventOrganizerName" runat="server">
    <%-- Add the local link of the vendor in href--%>

    <a >  Mumbai
    </a>
</asp:Content>
<asp:Content ID="vendorOrganizationType" ContentPlaceHolderID="vendorOrganizationType" runat="server">
   <%-- {{OrgType}}--%>
</asp:Content>


<asp:Content ID="ShortDescription"  ContentPlaceHolderID="eventShortDescription" runat="server">
     Better Photography has been the leading photography magazine in India for 17 years now.
</asp:Content>


<asp:Content ID="EventDetails" ContentPlaceHolderID="eventDetails" runat="server">
     We are India's leading photography magazine with a strong presence in Sri Lanka, Nepal, Bhutan, Bangladesh, UAE, and Singapore for more than 16 years now. Our aim is to educate our readers on the art, science and techniques of photography. 
With a primary audience that includes serious enthusiasts and amateurs, the magazine covers a wide variety of content from techniques and equipment reviews and interviews. BP, as it is often affectionately called, is a hobbyist magazine whose priority is education in the art and science of photography.
</asp:Content>

<asp:Content ID="RegistrationHowTo"  ContentPlaceHolderID="ContactPerson" runat="server">
    <%-- Contact Person --%>
    <b>Contact Person: </b> Better Photography
</asp:Content>
<asp:Content ID="ContactNumber"  ContentPlaceHolderID="vendorContactNumber" runat="server">
    
 <b>Contact Number: </b>NA

</asp:Content>
<asp:Content ID="RegistrationHowTo2"  ContentPlaceHolderID="registrationHowTo" runat="server">
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
     New Era Mill Compound, Mogul Lane
</asp:Content>
<asp:Content ID="EventAddressLandmark"  ContentPlaceHolderID="eventAddressLandmark" runat="server">
    <%-- Near <Landmark> --%>
     Matunga (W)
</asp:Content>
<asp:Content ID="EventAddressCityState"  ContentPlaceHolderID="eventAddressCityState" runat="server">
    <%-- City, State--%>
     Mumbai
</asp:Content>


<asp:Content ID="VendorWebPage"  ContentPlaceHolderID="vendorWebPage" runat="server">
    
    <%--<a href="http://www.delhiphotographyclub.com/" target="_blank"> Delhi Photography Club</a>--%>
</asp:Content>
<asp:Content ID="VendorEmail"  ContentPlaceHolderID="vendorEmail" runat="server">
    <A HREF="mailto:entries@betterphotography.in">entries@betterphotography.in</a>
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
            <a href="http://localhost:35475/publishevents/201405/BetterPhotography_YourPicturesByTheBeachPhotoContest20140506.aspx" >Your Pictures - By The Beach (Photo Contest)</a>
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
    Better Photography
</asp:Content>

