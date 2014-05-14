using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MailSubscription : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string email = Request["EMAIL"].ToString();
        string CType = Request["CustomerType"].ToString();
        int x=-1;
        DAL.FolksploreDAL InsertSubscription = new DAL.FolksploreDAL(System.Configuration.ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        x = InsertSubscription.InsertSubscriptionEmail(email, CType);
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Thank you " + email + "! You have been successfully added to our subscription list!');", true);
        EmailFunctions.SendEmail("sales@fokal.in", "code@fokal.in", "New subscription " + email, CType);
    }
}