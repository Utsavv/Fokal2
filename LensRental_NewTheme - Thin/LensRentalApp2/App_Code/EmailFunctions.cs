using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Summary description for EmailFunctions
/// </summary>
public class EmailFunctions
{
    public static readonly string HOSTNAME = Convert.ToString(ConfigurationManager.AppSettings["HOSTNAME"]);
    public static readonly Int32 PORT = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"]);
    public static readonly string FROMEMAILADDRESS = Convert.ToString(ConfigurationManager.AppSettings["FromEmailAddress"]);
    public static readonly string MAILUSERNAME = Convert.ToString(ConfigurationManager.AppSettings["MailUserName"]);
    public static readonly string MAILPASSWORD = Convert.ToString(ConfigurationManager.AppSettings["MailPassword"]);
    public static readonly string AppURL = "www.fokal.in";
    //public static readonly string AppURL = "Fokal.in/Demo";

    public static readonly bool sslEnable = false;

    public EmailFunctions()
    {

    }

    public static void SendPasswordEmail(string toEmailAddress, string FirstName, string Password)
    {

        MailMessage mail = new MailMessage();
        mail.To.Add(toEmailAddress);
        mail.CC.Add(FROMEMAILADDRESS);
        mail.From = new MailAddress(FROMEMAILADDRESS);
        mail.Subject = "Welcome to Fokal.in!!!";
        //string body = "<p >Dear " + FirstName + ",</p>    <p >        Thank you for signing up with us!</p>    <p >        Your account has been successfully created with the following credentials-</p>    <p >User Name: " + toEmailAddress + "</p>    <p >Password: " + Password + "</p>    <p ><b ><u><br /><a href = 'http://" + AppURL + "/ChangePassword.aspx?UserId=" + Convert.ToString(Helper.Encryptdata(Password)) + "'>Click here to Change Password</a> </u></b></p><p ><b ><u>Three Steps to Renting<o:p></o:p></u></b></p>    <ol>       <li>Access ‘<a href=\"www.fokal.in/UserProfile.aspx\">My Account’ to change your password and complete your contact information</a></li>            <li> Please don't forget to upload required documents under ‘<a href=\"www.fokal.in/UserProfile.aspx\">My Account’</a> </li>        <li> Place your rental order and click your heart out!</li>    </ol>    <p >        <b ><u>Other important Information</u></b></p>    <ul>    <li>Please go through our <u><a href=\"http://www.fokal.in/TermsNConditions.aspx\">Terms and Conditions</li>    <li><a href=\"http://www.fokal.in/FAQ1.aspx\">FAQ</a></u> section to answer your queries</li>    <li>Connect with us on <a href=\"https://www.facebook.com/FokalDotIn\">Facebook</a> and <a href=\"https://plus.google.com/+FokalIn\">Google+</li>     <li><a href=\"http://www.fokal.in/Contact.aspx\">Contact Us</a></li>   </ul>    <p >We are dedicated to provide you the best equipment renting experience and we are happy to serve you!</p>    <p >        Best Regards,</p>    <p ><a href=\"http://www.fokal.in\">Fokal.in</a></p>    <p >Rent.Click.<i>Smile</i></p>";
        string body = "<p >Dear " + FirstName + ",</p>    <p >        Thank you for signing up with us!</p>    <p >        Your account has been successfully created.    <u>Three Steps to Renting<o:p></o:p></u></b></p>    <ol>       <li>Access ‘<a href=\"www.fokal.in/UserProfile.aspx\">My Account’</a> to change your password and complete your contact information</li>            <li> Please don't forget to upload required documents under ‘<a href=\"www.fokal.in/UserProfile.aspx\">My Account’</a> </li>        <li> Place your rental order and click your heart out!</li>    </ol>    <p >        <b ><u>Other important Information</u></b></p>    <ul>    <li>Please go through our <u><a href=\"http://www.fokal.in/TermsNConditions.aspx\">Terms and Conditions</li>    <li><a href=\"http://www.fokal.in/FAQ1.aspx\">FAQ</a></u> section to answer your queries</li>    <li>Connect with us on <a href=\"https://www.facebook.com/FokalDotIn\">Facebook</a> and <a href=\"https://plus.google.com/+FokalIn\">Google+</li>     <li><a href=\"http://www.fokal.in/Contact.aspx\">Contact Us</a></li>   </ul>    <p >We are dedicated to provide you the best equipment renting experience and we are happy to serve you!</p>    <p >        Best Regards,</p>    <p ><a href=\"http://www.fokal.in\">Fokal.in</a></p>    <p >Rent.Click.<i>Smile</i></p>";
        mail.Body = body;
        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = HOSTNAME;//Or Your SMTP Server Address
        smtp.Port = PORT; //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential(MAILUSERNAME, MAILPASSWORD);
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = sslEnable;

        try
        {
            smtp.Send(mail);
        }
        catch (SmtpException ex)
        {
        }
        catch (Exception e)
        {
        }
        SendEmail(FROMEMAILADDRESS, FROMEMAILADDRESS, "New User : " + FirstName, "User Name: " + toEmailAddress);
    }

    

    public static void SendAccountActivationEmail(string toEmailAddress, string FirstName, string Password, Guid ActivationCode)
    {

        MailMessage mail = new MailMessage();
        mail.To.Add(toEmailAddress);
      //  mail.CC.Add(FROMEMAILADDRESS);
        mail.From = new MailAddress(FROMEMAILADDRESS);
        mail.Subject = "Welcome to Fokal.in!!!";
        string body = "<p >Dear " + FirstName + ",</p>    <p >        Thank you for signing up with us!</p>    <p >        Your account has been successfully created with the following credentials-</p>    <p >User Name: " + toEmailAddress + "</p>    <p >Password: " + Password + "</p>    <p ><b ><u><br /><a href = 'http://" + AppURL + "/Fokal_Activation.aspx?ActivationCode=" + Convert.ToString(ActivationCode) + "'>Click here to activate your account.</a> </b></u>";
        //<p ><b ><u>Three Steps to Renting<o:p></o:p></u></b></p>    <ol>       <li>Access ‘<a href=\"www.fokal.in/UserProfile.aspx\">My Account’ </a>to change your password and complete your contact information</li>            <li> Please don't forget to upload required documents under ‘<a href=\"www.fokal.in/UserProfile.aspx\">My Account’</a> </li>        <li> Place your rental order and click your heart out!</li>    </ol>    <p >        <b ><u>Other important Information</u></b></p>    <ul>    <li>Please go through our <u><a href=\"http://www.fokal.in/TermsNConditions.aspx\">Terms and Conditions</li>    <li><a href=\"http://www.fokal.in/FAQ1.aspx\">FAQ</a></u> section to answer your queries</li>    <li>Connect with us on <a href=\"https://www.facebook.com/FokalDotIn\">Facebook</a> and <a href=\"https://plus.google.com/+FokalIn\">Google+</li>     <li><a href=\"http://www.fokal.in/Contact.aspx\">Contact Us</a></li>   </ul>    <p >We are dedicated to provide you the best equipment renting experience and we are happy to serve you!</p>    <p >        Best Regards,</p>    <p ><a href=\"http://www.fokal.in\">Fokal.in</a></p>    <p >Rent.Click.<i>Smile</i></p>
        mail.Body = body;
        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = HOSTNAME;//Or Your SMTP Server Address
        smtp.Port = PORT; //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential(MAILUSERNAME, MAILPASSWORD);
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = sslEnable;

        try
        {
            smtp.Send(mail);
        }
        catch (SmtpException ex)
        {
        }
        catch (Exception e)
        {
        }
        SendEmail(FROMEMAILADDRESS, FROMEMAILADDRESS, "New User : " + FirstName, "User Name: " + toEmailAddress);
    }


    public static void SendDocumentReviewEmail(string UserName, Int32 UserId)
    {

        MailMessage mail = new MailMessage();
        mail.To.Add(FROMEMAILADDRESS);
        mail.From = new MailAddress(FROMEMAILADDRESS);
        mail.Subject = "Welcome to Fokal.in!!!";

        string Body = "Hi Administrator, <br/><br/>  Please Review Documents of :- <br/><b>UserName :- </b> " + UserName + "<br/><b>UserId :- </b>" + Convert.ToString(UserId) + "<br/><br/><br/> Happy Renting!!!<br/><br/> Thanks, <br/>Fokal.in Sales";
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = HOSTNAME;//Or Your SMTP Server Address
        smtp.Port = PORT; //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential(MAILUSERNAME, MAILPASSWORD);
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = sslEnable;
        try
        {
            smtp.Send(mail);
        }
        catch (SmtpException ex)
        {
        }
        catch (Exception e)
        {
        }
    }

    public static void SendEmail(string ToEmail, string FromEmail, String Subject, String BodyText)
    {

        MailMessage mail = new MailMessage();
        mail.To.Add(ToEmail);
        mail.From = new MailAddress(FromEmail);
        mail.Subject = Subject;

        string Body = BodyText;
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = HOSTNAME;//Or Your SMTP Server Address
        smtp.Port = PORT; //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential(MAILUSERNAME, MAILPASSWORD);
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = sslEnable;
        try
        {
            smtp.Send(mail);
        }
        catch (SmtpException ex)
        {
        }
        catch (Exception e)
        {
        }
    }
}