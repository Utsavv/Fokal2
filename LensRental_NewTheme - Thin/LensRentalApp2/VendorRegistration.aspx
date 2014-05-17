<%@ Page Title="Vendor Registration | Fokal.in" Language="C#" MasterPageFile="~/m_other.master" AutoEventWireup="true" CodeFile="VendorRegistration.aspx.cs" Inherits="Contact" EnableEventValidation="false" EnableViewState="true"%>
<asp:Content ID="headContent" ContentPlaceHolderID="headscript" runat="server">
    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
<script>
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

    $(function () {
        fillStates();
    });

    function fillStates() {

        $('#<%=ddlStates.ClientID %>').change(function () {
        var val = $(this).val();
        $('#SelectedState').val(val);
        fillCities(val);

    });


        $('#<%=ddlCity.ClientID %>').change(function () {
        var city = $(this).val();
        $('#SelectedCity').val(city);
    });

        
        $.ajax({
            type: "POST",
            async: false,
            url: "VendorRegistration.aspx/GetStates",
            contentType: 'application/json; charset=utf-8',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                if (result.hasOwnProperty("d")) {
                    var states = "";
                    for (var i = 0; i < result.d.length; i++)
                    {
                        
                        states += "<option value=" + result.d[i].replace(" ","_") + ">" + result.d[i] + "</option>";
                        if (i == 0) {
                            $('#SelectedState').val(result.d[i].replace(" ", "_"));
                            fillCities(result.d[i]);
                        }
                    }
                    
                    //$('#ddlStates').html(states);
                    $('#<%=ddlStates.ClientID %>').html(states);
                    //alert($('#<%=ddlStates.ClientID %>').name);

                }
            }
        });

        function fillCities(state) {
            state=state.replace("_", " ");
            
            $.ajax({
                type: "POST",
                async: false,
                url: "VendorRegistration.aspx/GetCities",
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
                            cities += "<option value=" + result.d[i].replace(" ", "_") + ">" + result.d[i] + "</option>";
                            if (i == 0) {
                                $('#SelectedCity').val(result.d[i].replace(" ", "_"));
                            }
                        }                        
                        //$('#ddlCity').html(cities);
                        $('#<%=ddlCity.ClientID %>').html(cities);
                    }
                }
            });
        }

    }
</script>
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
<h3> Register as a Photography Services Provider</h3>
 
</asp:Content>
<asp:Content ID="Vendorform" ContentPlaceHolderID="mainContent" runat="server">
                 
            
            <%--<form runat="server">--%>
                <div class="registrationForm">
                <table>
                    
                    <tr>
                        <td style="width: 200px">
                            <label for="vendorname">Company/Club Name</label>
                            <asp:RequiredFieldValidator ID="RfvClub" runat="server" ControlToValidate="txtVendorName" ErrorMessage="Name of your Club/Organization is Mandatory Field" ValidationGroup="VendorGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVendorName" runat="server" CssClass="eventinput-style" Width="250px"></asp:TextBox>
                           </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <label for="VendorWebPage">Website <br /><small>(You may mention your FB page)</small></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVendorWebPage" runat="server" CssClass="eventinput-style" placeholder="http://www.website.com" Width="250px"></asp:TextBox>
                          
                            <%--<asp:RegularExpressionValidator ID="RevWebSite" runat="server" ControlToValidate="txtVendorWebPage" ErrorMessage="Please provide website in format 'http://www.website.com'" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;amp;=]*)?" ValidationGroup="VendorGroup"><small>Please use format &#39;http://www.website.com&#39;</small></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                        </table>
                    </div>
                <div class="registrationForm">
                <table>
                    <tr>
                        <td>
                            <h5>Contact Details</h5>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <label for="ContactPerson">Contact Person</label>
                            <asp:RequiredFieldValidator ID="RfvMandatoryField" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="Contact Person is Mandatory" ValidationGroup="VendorGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactPerson" runat="server" CssClass="eventinput-style"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <label for="ContactNumber">Contact Number</label>
                            <asp:RequiredFieldValidator ID="RfvContactNumber" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="Contact Number is Mandatory" ValidationGroup="VendorGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="eventinput-style" ></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <label for="RegisteredEmail">Email Address<br> <small>Please use this email id while registering events</small></label>
                            <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ControlToValidate="txtRegisteredEmail" ErrorMessage="Email Address is Mandatory Field" ValidationGroup="VendorGroup" ForeColor="#990000">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRegisteredEmail" runat="server" CssClass="eventinput-style" ></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="RevEmail" runat="server" ControlToValidate="txtRegisteredEmail" ErrorMessage="Please provide email in format 'yourname@domain.com'" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" ValidationGroup="VendorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    </table>
                    </div>
                <div class="registrationForm">
                    <table>

                       <tr>
                        <td>
                            <h5>Address Details</h5>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <label for="txtEventVenue">Address</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="eventinput-style" placeholder="Address Line 1" Width="300px" ></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                            <td style="width: 200px"></td>
                            <td>
                                <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="eventinput-style" placeholder="Address Line 2" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                <label for="Landmark">Landmark</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLandmark" runat="server" CssClass="eventinput-style" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                <label for="State">State</label>
                                <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="State is required" ControlToValidate="ddlStates" ForeColor="#990000">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStates" runat="server" CssClass="eventinput-style">                                                                
                                </asp:DropDownList>
                                <%--<tr>
                        <td>
                            <label for="SourceOfInfo">How did you come to know about fokal.in?</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSourceOfInfo" runat="server" CssClass="eventinput-style" Width="250px"></asp:TextBox>
                           
                        </td>
                    </tr>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                <label for="Pincode">Pincode</label>
                            </td>
                       
                            <td>
                                <asp:TextBox ID="txtPincode" runat="server" CssClass="eventinput-style"></asp:TextBox>
                       
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                <label for="City">City</label>
                                <asp:RequiredFieldValidator ID="RfvCity" runat="server" ErrorMessage="City is required" ControlToValidate="ddlCity" ForeColor="#990000">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="eventinput-style">
                                    
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        </table>
                    </div>
                <div class="registrationForm">
                    <table>
                        <tr>
                            <td>
                                <h5>About</h5>
                            </td>
                        </tr>
                        <tr>
                        <td style="width: 200px">
                            <label for="EventType">Photography Services <br> <small>Please select atleast one</small></label>
                            <asp:CustomValidator ID="CVServices" runat="server" ClientValidationFunction="ValidateServiceList" ErrorMessage="Please select atleast one service" ValidationGroup="VendorGroup" ForeColor="#990000" >*</asp:CustomValidator>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="DDServiceType" runat="server" CssClass="eventinput-style" Height="17px" Width="161px"></asp:CheckBoxList>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <label for="VendorShortDescription">Brief descritption of your Company/club</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVendorShortDescription" runat="server" CssClass="eventinput-style" placeholder="Few lines for the users to understand what you do" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>    
                    <tr>
                        <td style="width: 200px">
                            <label for="VendorLongDescription">Detailed descritption of your Company/club</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVendorLongDescription" runat="server" CssClass="eventinput-style" placeholder="Describe the activities that you conduct. This is a good place to mention your USP which would help users understand your company/club better" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                        </table>
                    </div>
                <div class="registrationForm">
                    <table>
                    <tr>
                        <td>
                            <h5 >Connect Socially</h5><small>(Helps users connect with you)</small>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 200px">
                            <label for="VendorFacebookPage">Facebook Page </label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVendorFacebookPage" runat="server" CssClass="eventinput-style" Width="250px"></asp:TextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <label for="VendorGplusPage">Google+ Page</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVendorGplusPage" runat="server" CssClass="eventinput-style" Width="250px"></asp:TextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtRegisteredEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <label for="SourceOfInfo">How did you come to know about fokal.in?</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSourceOfInfo" runat="server" CssClass="eventinput-style" Width="250px"></asp:TextBox>
                           
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="width: 200px">
                            &nbsp;</td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ValidationGroup="VendorGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px"></td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CausesValidation="true" ValidationGroup="VendorGroup" OnClick="btnSubmit_Click" CssClass="submit-btn" /></td>
                    </tr>
                </table>
                    </div>
                 <asp:HiddenField ID="SelectedCity" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="SelectedState" runat="server" ClientIDMode="Static" />
        <%--   </form>--%>
          
</asp:Content>

