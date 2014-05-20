using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using System.Configuration;
using oAuthExample;
using System.Xml;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using Model;
using BLL;
using System.Data;
using System.Net.Mail;

public partial class Fokal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
        }
        checkLoginStatus();
        if (SessionState.UserName != null && SessionState.UserName != string.Empty)
        {
            UserNameSpan.InnerHtml = SessionState.UserName;
            btnLogout.Visible = false;
            btnLogin.Visible = false;
            //btnLogin2.Visible = false;
            //btnUserProfile.Visible = true;
        }
        else
        {
            UserNameSpan.InnerHtml = "Guest";
            btnLogin.Visible = false;
            //btnLogin2.Visible = true;
            btnLogout.Visible = false;

            //btnUserProfile.Visible = false;
        }
    }



    protected void btnLogout_Click(object sender, EventArgs e)
    {
        SessionState.Logout();
    }

    private bool checkLoginStatus()
    {
        //FB Check
        string code = Request.QueryString["code"];
        if (!string.IsNullOrEmpty(code))
        {
            string data = FaceBookConnect.Fetch(code, "me");
            FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
            faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
            SessionState.UserName = faceBookUser.Name;
            SessionState.UserId = faceBookUser.Email;
            SessionState.FBLogoutCode = code;
            SessionState.LoginType = 1;
            string password = CheckExistingPassword(faceBookUser.Email, faceBookUser.Name);
            SessionState.Id = Convert.ToInt32(SessionState.SaveLoginInfoInDB(faceBookUser, Helper.Encryptdata(password)));
            string RedirectPage = String.IsNullOrEmpty(SessionState.RedirectPage) ? "Home.aspx" : SessionState.RedirectPage;
            Response.Redirect(RedirectPage);
            return true;
        }



        //GMAIL
        OpenIdRelyingParty openid = new OpenIdRelyingParty();
        var response = openid.GetResponse();

        if (response != null)
        {
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:
                    var fetchResponse = response.GetExtension<FetchResponse>();
                    Session["FetchResponse"] = fetchResponse;
                    var response2 = Session["FetchResponse"] as FetchResponse;

                    string lblemail = response2.GetAttributeValue(WellKnownAttributes.Contact.Email);
                    string lblname = GetFullname(response2.GetAttributeValue(WellKnownAttributes.Name.First), response2.GetAttributeValue(WellKnownAttributes.Name.Last));
                    string lblbirthdate = response2.GetAttributeValue(WellKnownAttributes.BirthDate.WholeBirthDate);
                    string lblphone = response2.GetAttributeValue(WellKnownAttributes.Contact.Phone.Mobile);
                    string lblgender = response2.GetAttributeValue(WellKnownAttributes.Person.Gender);
                    SessionState.UserId = lblemail;
                    SessionState.UserName = lblname;
                    SessionState.LoginType = 3;
                    GmailUser gmailUser = new GmailUser();
                    gmailUser.UserName = lblemail;
                    gmailUser.Email = lblemail;
                    gmailUser.First_Name = response2.GetAttributeValue(WellKnownAttributes.Name.First);
                    gmailUser.Last_Name = response2.GetAttributeValue(WellKnownAttributes.Name.Last);
                    gmailUser.Gender = lblgender;
                    string password = CheckExistingPassword(lblemail, response2.GetAttributeValue(WellKnownAttributes.Name.First));
                    SessionState.Id = SessionState.SaveLoginInfoInDB(gmailUser, Helper.Encryptdata(password));
                    string RedirectPage = String.IsNullOrEmpty(SessionState.RedirectPage) ? "Home.aspx" : SessionState.RedirectPage;
                    Response.Redirect(RedirectPage);
                    return true;
                case AuthenticationStatus.Canceled:
                    return false;
                case AuthenticationStatus.Failed:
                    return false;
            }
        }
        else
        {
            return false;

        }

        return false;
    }

    private static string GetFullname(string first, string last)
    {
        var _first = first ?? "";
        var _last = last ?? "";

        if (string.IsNullOrEmpty(_first) || string.IsNullOrEmpty(_last))
            return "";

        return _first + " " + _last;
    }

    protected void btngmaillogout_ServerClick(object sender, EventArgs e)
    {
        SessionState.Logout();
    }

    protected void btnLoginToGoogle_Command(object sender, CommandEventArgs e)
    {
        OpenIdRelyingParty openid = new OpenIdRelyingParty();
        string discoveryUri = e.CommandArgument.ToString();
        string RedirectPage = ConfigurationManager.AppSettings["LoginReturnPage"] + (String.IsNullOrEmpty(SessionState.RedirectPage) ? "Home.aspx" : SessionState.RedirectPage);
        var b = new UriBuilder(RedirectPage) { Query = "" };
        var req = openid.CreateRequest(discoveryUri, b.Uri, b.Uri);

        var fetchRequest = new FetchRequest();
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Person.Gender);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Phone.Mobile);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.BirthDate.WholeBirthDate);
        req.AddExtension(fetchRequest);
        req.RedirectToProvider();
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int registrationlevel = RegistrationManager.GetInstance.RegisterUser(txtFirstName.Text, txtLastName.Text, Helper.Encryptdata(txtPassword.Text), txtEmail.Text);
        if (registrationlevel != 0)
        {
            //SessionState.RegistrationLevel = 1;
            //SessionState.UserName = txtFirstName.Text + " " + txtLastName.Text;
            //SessionState.UserId = txtEmail.Text;
            //SessionState.LoginType = 4;
            //SessionState.Id = registrationlevel;
            Guid ActivationCode = Guid.NewGuid();
            RegistrationManager.GetInstance.SaveActivationCode(registrationlevel, ActivationCode);
            EmailFunctions.SendAccountActivationEmail(txtEmail.Text, txtFirstName.Text, txtPassword.Text, ActivationCode);
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Registration successful. Activation link has been sent to your Email Address. Please click on that to Activate your Profile');", true);
            //Response.Redirect("UserProfile.aspx");
        }
        else
        {
            lblMessage.Text = "This EmailId is already registered with us!!!";
            lblMessage.Visible = true;
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "openLoginPopup();", true);
        }
    }

    protected void btnFBLogin_Click(object sender, ImageClickEventArgs e)
    {
        FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FBAppId"];
        FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FBSecreatKey"];
        string RedirectPage = ConfigurationManager.AppSettings["LoginReturnPage"] + (String.IsNullOrEmpty(SessionState.RedirectPage) ? "Home.aspx" : SessionState.RedirectPage);
        FaceBookConnect.Authorize("user_photos,email,user_location,user_birthday", RedirectPage);

    }

    protected void tblLogin_Click(object sender, EventArgs e)
    {
       
        DataSet ds = RegistrationManager.GetInstance.CheckLogin(txtUserName.Text, Helper.Encryptdata(txtLoginPassword.Text));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Active"] != DBNull.Value ? ds.Tables[0].Rows[0]["Active"] : 0) <= 0)
            {
                SessionState.UserId = txtUserName.Text;
                SessionState.UserName = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                SessionState.LoginType = 4;
                SessionState.RegistrationLevel = Convert.ToInt32(ds.Tables[0].Rows[0]["RegistrationLevel"]);
                SessionState.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                string RedirectPage = String.IsNullOrEmpty(SessionState.RedirectPage) ? "Home.aspx" : SessionState.RedirectPage;
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "closeLoginPopup('" + RedirectPage + "');", true);
                //Response.Redirect(String.IsNullOrEmpty(SessionState.RedirectPage) ? "Home.aspx" : SessionState.RedirectPage);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Please Activate your account first by clicking on the Activation link send to your email address!!!');", true);
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Invalid UserName or Password!!!";
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "openLoginPopup();", true);
        }
    }

    private string CheckExistingPassword(string emailAddress, string FirstName)
    {

        bool IsPasswordExists = RegistrationManager.GetInstance.CheckPassword(emailAddress);
        if (!IsPasswordExists)
        {
            string tempPassword = GenerateRandomNumber();
            EmailFunctions.SendPasswordEmail(emailAddress, FirstName, tempPassword);

            return tempPassword;
        }
        else
        {
            return string.Empty;
        }
    }

    private string GenerateRandomNumber()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@#$%^*&";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, 8)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

    protected void lnkForgetPassword_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == string.Empty)
        {
            lblMessage.Text = "Please enter your UserName and then click forget Password";
            lblMessage.Visible = true;
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "openLoginPopup();", true);
        }
        else
        {
            string password = RegistrationManager.GetInstance.GetPassword(txtUserName.Text);
            if (password != "")
            {
                EmailFunctions.SendPasswordEmail(txtUserName.Text, txtUserName.Text, Helper.Decryptdata(password));
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Password has been sent to your EmailId!!');window.location ='Home.aspx';", true);
            }
            else
            {
                lblMessage.Text = "Invalid Email ID!!";
                lblMessage.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "openLoginPopup();", true);
            }
        }
    }


    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        string email = txtEmailAdd.Text;
        string CType = txtSignupType.SelectedItem.Text;
        int x = -1;
        DAL.FolksploreDAL InsertSubscription = new DAL.FolksploreDAL(System.Configuration.ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        x = InsertSubscription.InsertSubscriptionEmail(email, CType);
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Thank you " + email + "! You have been successfully added to our subscription list!');", true);
        EmailFunctions.SendEmail("subscribe@fokal.in", "code@fokal.in", "New subscription " + email, CType);
    }
}
