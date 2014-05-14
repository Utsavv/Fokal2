using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using BLL;
using Model;
using DAL;

public partial class SearchEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
            
            DataSet ds = PerformSearch.GetServices();

            /*DDDestination.DataSource = ds.Tables[1];
            DDDestination.DataValueField = "area";
            DDDestination.DataTextField = "area";
            DDDestination.DataBind();
            */
            string accountActivated = Request.QueryString["AccountActivated"];
            if (!string.IsNullOrEmpty(accountActivated) && accountActivated == "true")
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Activation Successful!!! Happy Renting');openLoginPopup();", true);
            }
            else if (!string.IsNullOrEmpty(accountActivated) && accountActivated == "false")
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Password Changed Successfully');openLoginPopup();", true);
            }
        }
    }



    [WebMethod]
    public static void FireFBLogin()
    {
        FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FBAppId"];
        FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FBSecreatKey"];
        FaceBookConnect.Authorize("user_photos,email,user_location,user_birthday", "Home.aspx");
    }

    [WebMethod]
    public static void SetSelectedProductId(string products)
    {

    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        HtmlGenericControl table; 
        

        if (dropEvent.Text=="null")
            table= PerformSearch.GetHTMLTableForCategorySearch("Walk");
            
        else
            table = PerformSearch.GetHTMLTableForCategorySearch(dropEvent.Text);

        PanelSearchResult.Controls.Add(table);
        
    }


}

