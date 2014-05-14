<%@ Page Title="Contact Us | Fokal.in" Language="C#" MasterPageFile="~/m_Other.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>


<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">

            <h2>Contact Information</h2>
                <table   cellspacing="5px" cellpadding="5px" width="560" >
                    <tr>
                        <td rowspan="1" valign="top" width="30%" >Email</td>
                        <td><a href="mailto:sales@fokal.in" target="_top">sales@fokal.in</a></td>
                    </tr>
                    <tr>
                        <td valign="top" class="border-top">Call Us</td>
                        <td style=" border-top: 1px solid #EEEEEE;">9971510317</td>
                    </tr>
                    <tr>
                        <td rowspan="2" class="border-top" valign="top">Hours</td>
                        <td style=" border-top: 1px solid #EEEEEE;">9:00am-5:00pm Monday-Saturday</td>
                    </tr>
                    <tr>
                        <td width="360">Closed on Sunday</td>
                    </tr>
                    <tr>
                        <td rowspan="2" class="border-top">Social</td>
                        <td style=" border-top: 1px solid #EEEEEE;">Find us on <a href="https://www.facebook.com/FokalDotIn" target="_blank">Facebook</a></td>
                    </tr>
                    <tr>
                        <td width="360">Find us on <a href="https://www.google.com/+FokalIn" target="_blank">Google Plus</a></td>
                    </tr>
                </table>
    <br>
            <h3><span>F</span>or <span>A</span>ny <span>I</span>nquiries, <span>P</span>lease <span>F</span>ill <span>o</span>ut <span>T</span>he <span>F</span>orm <span>B</span>elow.</h3>
            <form runat="server">
                <table>
                    <tr>
                        <td>
                            <label for="name"><span>N</span>ame:</label></td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="input-style" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtNameValidator" Display="Dynamic" ControlToValidate="txtName" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                      </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="email"><span>E</span>mail <span>A</span>ddress:</label></td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-style" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtEmailValidator" Display="Dynamic" ControlToValidate="txtEmail" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="correctEmailValidator" Display="Dynamic" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email" ValidationGroup="InquiryGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                      </td>

                    </tr>
                    <tr>
                        <td>
                            <label for="email"><span>C</span>ontact <span>N</span>umber:</label></td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="input-style" Width="250px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="txtPhoneValidator" Display="Dynamic" ControlToValidate="txtPhone" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="subject"><span>S</span>ubject:</label></td>
                        <td>
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="input-style" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtSubjectValidator" Display="Dynamic" ControlToValidate="txtSubject" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="message"><span>M</span>essage:</label></td>
                        <td>
                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="input-style" Width="250px" Height="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtMessageValidator" Display="Dynamic" ControlToValidate="txtMessage" runat="server" ErrorMessage="*" ValidationGroup="InquiryGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Send" CausesValidation="true" ValidationGroup="InquiryGroup" OnClick="btnSubmit_Click" CssClass="submit-btn" /></td>
                    </tr>
                </table>

            </form>

</asp:Content>

