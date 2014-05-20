<%@ Page Title="Event Registration | Fokal.in" Language="C#" MasterPageFile="~/m_other.master" AutoEventWireup="true" CodeFile="EventRegistration.aspx.cs" EnableEventValidation="false" Inherits="Contact" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<asp:Content ID="headscript" ContentPlaceHolderID="headscript" runat="Server">
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
 <%-- <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>--%>

  <script>
      $(function () {
          $("input[id$=txtEventStartDate]").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("input[id$=txtEventEndDate]").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("input[id$=EventRegistrationLastDate]").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          
          fillStates();
      });

    function ValidateServiceList(source, args) {
        var chkListModules = document.getElementById('<%=DDServiceType.ClientID %>');
        var chkListinputs = chkListModules.getElementsByTagName("input");
        for (var i = 0; i < chkListinputs.length; i++) {
            if (chkListinputs[i].checked) {
                args.IsValid = true;
                return;
            }
        }
        args.IsValid = false;
    };


    function fillStates() {

        $('#ddlStates').change(function () {
            var val = $(this).val();
            $('#SelectedState').val(val);
            fillCities(val);

        });


        $('#ddlCity').change(function () {
            var city = $(this).val();
            $('#SelectedCity').val(city);
        });

        
        $.ajax({
            type: "POST",
            async: false,
            url: "EventRegistration.aspx/GetStates",
            contentType: 'application/json; charset=utf-8',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                if (result.hasOwnProperty("d")) {
                    var states = "";
                    for (var i = 0; i < result.d.length; i++) {                        
                        states += "<option value=" + result.d[i].replace(" ", "_") + ">" + result.d[i] + "</option>";
                        if (i == 0) {
                            $('#SelectedState').val(result.d[i].replace(" ", "_"));
                            fillCities(result.d[i]);
                        }
                    }
                    
                    $('#ddlStates').html(states);
                    

                }
            }
        });

        function fillCities(state) {
            state = state.replace("_", " ");
            $.ajax({
                type: "POST",
                async: false,
                url: "EventRegistration.aspx/GetCities",
                data: "{state :'" + state + "'  }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    if (result.hasOwnProperty("d")) {
                        var cities = "";
                        for (var i = 0; i < result.d.length; i++) {
                            cities += "<option value=" + result.d[i] + ">" + result.d[i] + "</option>";
                            if (i == 0) {
                                $('#SelectedCity').val(result.d[i]);
                            }
                        }                        
                        $('#ddlCity').html(cities);
                    }
                }
            });
        }

    }
</script>

  
    <style type="text/css">
        .auto-style1 {
            width: 24%;
        }
    </style>

  
</asp:Content>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
<h3>Event Reigstration Form</h3>
    <p>Please <a href="/vendorregistration.aspx" target="_blank">register as service provider</a> first, if not already done. Thanks!</p>
</asp:Content>


<asp:Content ID="Vendorform" ContentPlaceHolderID="mainContent" runat="server">
    <div id="registrationforms">
            <%--          <br /><br /><br />--%>
                <div class="registrationForm" >
                
                <table>
                    <tr>
                        <td >
                            <label for="vendoremailID">Registered Email ID</label>
                            <asp:RequiredFieldValidator ID="rfvVendorName" Display="Dynamic" ControlToValidate="txtvendoremailID" runat="server" ErrorMessage="Please enter registered email ID" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RevEmail" runat="server" ControlToValidate="txtvendorEmailID" ErrorMessage="Please provide in format 'name@domain.com'" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" ValidationGroup="VendorGroup" Font-Size="Smaller"></asp:RegularExpressionValidator>

                        </td>
                        <td style="height: 26px" >
                            <asp:TextBox ID="txtvendorEmailID" runat="server" CssClass="eventinput-style"></asp:TextBox>
                            
                        </td>
                    </tr>
                     </table>
                    </div>
                <div class="registrationForm">
                <table>
                    <tr>
                        <td>
                            <h5>About Event</h5>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="EventName">Event Name</label>
                            <asp:RequiredFieldValidator ID="RfvEventName" Display="Dynamic" ControlToValidate="txtEventName" runat="server" ErrorMessage="Please  enter Event Name" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtEventName" runat="server" CssClass="eventinput-style"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <label for="EventSmallDescrition">Two line description</label>
                            <asp:RequiredFieldValidator ID="RfvEventType3" Display="Dynamic" ControlToValidate="txtEventSmallDescrition" runat="server" ErrorMessage="Please provide brief description"   ValidationGroup="EventGroup" ForeColor="#990000" >*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEventSmallDescrition" runat="server" CssClass="eventinput-style" Height="51px"  TextMode="MultiLine" MaxLength="400" placeholder="Brief Description mentioning what users would achieve from the event"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>

                    <tr>
                        <td >
                            <label for="EventType">Event Type</label>
                            <asp:RequiredFieldValidator ID="RfvEventType" Display="Dynamic" ControlToValidate="DDServiceType" runat="server" ErrorMessage="Please select Event Type" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDServiceType" runat="server" CssClass="eventinput-style"></asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <label for="EventTheme">Event Theme</label>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="CBLTheme" runat="server" CssClass="eventinput-style" ></asp:CheckBoxList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <label for="EventAudience">Event Target Audience</label>
                            <asp:RequiredFieldValidator ID="RfvEventType0" Display="Dynamic" ControlToValidate="txtEventAudience" runat="server" ErrorMessage="Please select Event Target Audience" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="txtEventAudience" runat="server" CssClass="eventinput-style"  >
                                <asp:ListItem Text="Beginner" Value="Beginner"></asp:ListItem>
                                <asp:ListItem Text="Advanced" Value="Advanced"></asp:ListItem>
                                <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem>
                                <asp:ListItem Text="Everyone" Value="Everyone"></asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <label for="EventLongDescription">Complete descritption</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEventLongDescription" runat="server" CssClass="eventinput-style" Height="100px" Width="300px"  TextMode="MultiLine" placeholder="Please describe the event in detail"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                        </tr>
                        <tr>
                        <td >
                            <label for="txtComment">Additional Information</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" runat="server" CssClass="eventinput-style" Height="100px" Width="300px"  TextMode="MultiLine" placeholder="If you have any thing else to share"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                        </tr>
                                     </table>
                    </div>
                <div class="registrationForm">
                <table>
                    <tr><td>
                        <h5>Date & Venue</h5>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <label for="EventStartDate">Event Start Date</label>
                            <asp:RequiredFieldValidator ID="rfvEventStartDate" Display="Dynamic" ControlToValidate="txtEventStartDate" runat="server" ErrorMessage="Please enter start date" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtEventStartDate" runat="server" CssClass="eventinput-style"   ></asp:TextBox>
                           
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                        </tr>
                    <tr>
                        <td>Start Time</td>
                         <td>
                            <asp:TextBox ID="txtStartTime" runat="server" CssClass="eventinput-style" placeholder="HH:MM like 17:00" ></asp:TextBox>
                          </td>
                    </tr>
                     <tr>
                        <td >
                            <label for="EventEndDate">Event End Date <br><small>For one day event, enter start date</small></label>
                            <asp:RequiredFieldValidator ID="rfvEventEndDate" Display="Dynamic" ControlToValidate="txtEventEndDate" runat="server" ErrorMessage="Please enter Event End Date" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEventEndDate" runat="server" CssClass="eventinput-style" ></asp:TextBox>
                            </td>
                         </tr>
                         <tr>
                         <td>End Time</td>
                        <td>
                            <asp:TextBox ID="txtEventEndTime" runat="server" CssClass="eventinput-style" placeholder="HH:MM like 17:00"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <label for="EventIsVirtual">Is it an Online Event?</label>
                            
                        </td>
                        <td style="height: 26px">
                            <asp:DropDownList ID="ddlIsVirtualEvent" runat="server" CssClass="eventinput-style"   placeholder="Select">
                                <asp:ListItem Text="No" Value=0></asp:ListItem>
                                <asp:ListItem Text="Yes" Value=1></asp:ListItem>
                            </asp:DropDownList>
                           
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                        </tr>
                    <tr>
                        <td >
                            <label for="txtEventVenue">Event Venue</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="eventinput-style"  placeholder="Address Line 1"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="eventinput-style" placeholder="Address Line 2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <label for="Landmark">Landmark</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLandmark" runat="server" CssClass="eventinput-style" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <label for="State">State</label>
                            <asp:RequiredFieldValidator ID="RfvEventType1" Display="Dynamic" ControlToValidate="ddlStates" runat="server" ErrorMessage="Please select State" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStates" runat="server" CssClass="eventinput-style" ClientIDMode="Static">
                                    
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </td>
                            </tr>
                        <tr>
                            <td >
                                <label for="City">City</label>
                            <asp:RequiredFieldValidator ID="RfvEventType2" Display="Dynamic" ControlToValidate="txtEventAudience" runat="server" ErrorMessage="Please select City" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="height: 26px">
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="eventinput-style" ClientIDMode="Static">                                                                       
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                    <tr>
                            <td >
                                <label for="Pincode">Pincode</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPincode" runat="server" CssClass="eventinput-style"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>

                          </table>
                    </div>
                <div class="registrationForm" id="registration details">
                <table>
                    <tr>
                        <td>
                            <h5>Registration Requirements</h5>
                        </td>
                    </tr>
                    
                   <tr>
                     <td >
                         <label for="EventRegistrationRequired">Is Registration Required?</label>
                            <asp:RequiredFieldValidator ID="RfvEventType4" Display="Dynamic" ControlToValidate="txtEventRegistrationRequired" runat="server" ErrorMessage="Please select City" ValidationGroup="EventGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>

                     </td>
                     <td>
                         <asp:DropDownList ID="txtEventRegistrationRequired" runat="server" DataTextField="txtEventRegistrationRequired" DataValueField="id" CssClass="eventinput-style" >
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                            </asp:DropDownList>

                     </td>
                     </tr>
                    <tr>
                        <td >
                            <label for="EventRegistrationCharges">Registration Charges <br /><small>(In INR, 0 for No Fees)</small></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEventRegistrationCharges" runat="server" CssClass="eventinput-style" ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            
                            <label for="EventRegistrationLastDate">Last Date of Registration</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEventRegistrationLastDate" runat="server" CssClass="eventinput-style" ></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td >
                            <label for="EventWebPage">Event Webpage<br /><small>(Share web or FB Page)</small></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEventWebPage" runat="server" CssClass="eventinput-style"  ></asp:TextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>

                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CausesValidation="true" ValidationGroup="EventGroup" OnClick="btnSubmit_Click" CssClass="submit-btn" />
                            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ValidationGroup="EventGroup" />
                        </td>
                    </tr>
                    
                </table>
                        </div>
                <asp:HiddenField ID="SelectedCity" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="SelectedState" runat="server" ClientIDMode="Static" />
            <%--</form>--%>
  <%--          <br /><br /><br />--%>
        </div>
</asp:Content>


