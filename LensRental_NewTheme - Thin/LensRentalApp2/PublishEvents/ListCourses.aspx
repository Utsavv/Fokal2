<%@ Page Title="Photography Tours | Fokal.in" Language="C#" MasterPageFile="~/m_other.master" AutoEventWireup="true" CodeFile="ListCourses.aspx.cs" Inherits="ListTours" %>
<asp:Content ID="PagePath" ContentPlaceHolderID="title" runat="server">
    <div style="height:30px; margin-left : 10px;">
            <small><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink> » Courses</small> 
       </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="Server">
<%--    <table>
        <tbody>
            <TR> <TD><p>eventStartDate <p></TD>
                
                 <TD colspan=3><B><A href=" eventLocalPagePath ">eventName </A></B></TD>;
                
                 <TD style="text-align:right;">  EventCity + </TD></TR>
                
                  <TR> <TD></TD><TD colspan=3> <small>Organizer : <A href=" VendorLocalPath "> + vendorName + </A></small></TD></TR>
                 <TR><TD></TD><TD colspan=3><small> eventShortDescription</small></TD></TR>
                 <TR><TD><br></TD></TR>

            
                </tbody>
           </table> --%>
    <h1>Photography Courses</h1>   
    <div id="searchContentDisplay" class="eventList">
        
      <%--  <ul>
            <li class="newTab">

            </li>
            <li>
                <div class=".smallimage">
                    <div class="img-logo">
                        <a href="#">
                             <img class="smallimage" src="http://www.fokal.in/images/logo-v2.jpg" />
                        </a>
                    </div>
                </div>
                <div class="expired">
                    <div class="pic">
                        <div class="dateSmallIcon">
                            <p>
                                Mon
                            </p>
                            <h2>
                                dd
                            </h2>
                        </div>
                    </div>
                </div>
                <div class="text" style="width:450px" >
                    <h5>
                        <a href="EventTemplate.aspx">Event Local Page Path</a>
                    </h5>
                    <p>
                        <span>
                            Organizer: 
                        </span>
                            Samsung
                    </p>
                </div>
            </li>
        </ul>--%>

    
      
                <asp:Panel ID="PanelSearchResult" runat="server">

                </asp:Panel>
        </div>
</asp:Content>
<asp:Content ID="SubscriptionVendor" ContentPlaceHolderID="SubscribeTo" runat="server">
    Photography Courses
</asp:Content>