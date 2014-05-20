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

public partial class Other : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
    }

      
    protected void btnSubscribe_Click1(object sender, EventArgs e)
    {
        string email = txtEmailAddress.Text;
        string CType = txtSignupType1.SelectedItem.Text;
        int x = -1;
        DAL.FolksploreDAL InsertSubscription = new DAL.FolksploreDAL(System.Configuration.ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        x = InsertSubscription.InsertSubscriptionEmail(email, CType);
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Thank you " + email + "! You have been successfully added to our subscription list!');", true);
        EmailFunctions.SendEmail("subscribe@fokal.in", "code@fokal.in", "New subscription " + email, CType);
    }
}
