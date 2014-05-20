using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using DAL;
using System.Configuration;

public partial class Contact : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
            
            DataSet ds = PerformSearch.GetServices();
            DDServiceType.DataSource = ds.Tables[4];
            DDServiceType.DataValueField = "ServiceSubCategory";
            DDServiceType.DataTextField = "ServiceSubCategory";
            DDServiceType.DataBind();

            //DDDestination.DataSource = ds.Tables[1];
            //DDDestination.DataValueField = "area";
            //DDDestination.DataTextField = "area";
            //DDDestination.DataBind();

            //CBLTheme.DataSource = ds.Tables[2];
            ////CBLTheme.DataValueField ;

            //CBLTheme.DataTextField = "ServiceSubCategory";
            ////DDDestination.DataTextField = "area";
            //CBLTheme.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string services="";

        for (int i = 0; i < DDServiceType.Items.Count; i++)
            if (DDServiceType.Items[i].Selected)
                services += (DDServiceType.Items[i].Value + ",");

        services=services.Substring(0, services.Length - 1);

        FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        int InquiryResult = PerformSearch.InsertVendor(
            txtVendorName.Text,
            txtRegisteredEmail.Text,
            services,
            txtAddressLine1.Text,
            txtAddressLine2.Text,
            txtLandmark.Text,
            SelectedCity.Value,
            SelectedState.Value,
            txtPincode.Text,
            txtContactNumber.Text,
            txtContactPerson.Text,
            txtVendorShortDescription.Text,
            txtVendorLongDescription.Text,
            txtVendorWebPage.Text,
            txtVendorFacebookPage.Text,
            txtVendorGplusPage.Text
            );
        if (InquiryResult == 1)
        {
            string script = string.Format("alert('{0}');window.location = 'eventRegistration.aspx';", "Thanks for Registering with Fokal.in! You can now register your events!");
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", script, true /* addScriptTags */);
            EmailFunctions.SendEmail("register@fokal.in", "code@fokal.in", "New Vendor registration " + txtRegisteredEmail.Text, txtRegisteredEmail.Text);
        }
        else if (InquiryResult == -1)
        {
            string script = string.Format("alert('{0}');", txtRegisteredEmail.Text + ": This email is already registered with us!" );
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", script, true /* addScriptTags */);
            
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Error in Registration!!!')", true);
        }

        
    }

    [WebMethod]
    public static List<String> GetStates()
    {
        FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        return PerformSearch.GetStates();
        
    }

    [WebMethod]
    public static List<String> GetCities(string state)
    {
        FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        return PerformSearch.GetCities(state);
    }
}