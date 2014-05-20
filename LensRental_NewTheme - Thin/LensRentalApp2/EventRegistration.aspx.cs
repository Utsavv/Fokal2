using System;
using System.Globalization;
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

            CBLTheme.DataSource = ds.Tables[2];
            //CBLTheme.DataValueField ;

            CBLTheme.DataTextField = "ServiceTheme";
            //DDDestination.DataTextField = "area";
            CBLTheme.DataBind();

            //txtEventAudience.DataSource = ds.Tables[3];
            //txtEventAudience.DataValueField = "EventLevel";
            //txtEventAudience.DataTextField = "EventLevel";
            //txtEventAudience.DataBind();
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        int eventCharges = 0;
        DateTime dtEventRegistrationEndDate = DateTime.Now;

        try
        {
            dtEventRegistrationEndDate = Convert.ToDateTime(txtEventRegistrationLastDate.Text);
        }
        catch(Exception ex)
        {
            dtEventRegistrationEndDate = Convert.ToDateTime("1900-01-01");
        }


        try
        {
            eventCharges=Convert.ToInt32(txtEventRegistrationCharges.Text);
        }
        catch (Exception ex) { }

        string dtStr="";
        TimeSpan t;
        if(txtStartTime.Text.Length==0) t=new TimeSpan(0,0,0); 
        else
        {
            string[] tm= txtStartTime.Text.Split(':');
            t = new TimeSpan(Convert.ToInt32(tm[0]), Convert.ToInt32(tm[1]), 0);             
        }
        DateTime dtStart = DateTime.ParseExact(txtEventStartDate.Text, "dd/MM/yyyy", new CultureInfo("en-US", true));
        DateTime dtEnd;
        dtStart.Add(t);

        if (txtEventEndTime.Text.Length == 0) t = new TimeSpan(0, 0, 0);
        else
        {
            string[] tm = txtEventEndTime.Text.Split(':');
            t = new TimeSpan(Convert.ToInt32(tm[0]), Convert.ToInt32(tm[1]), 0);
        }

        try
        {
            dtEnd = DateTime.ParseExact(txtEventEndTime.Text, "dd/MM/yyyy", new CultureInfo("en-US", true));
            dtEnd.Add(t);
        }
        catch (Exception ex) { dtEnd = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", new CultureInfo("en-US", true)); }
        

        FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
        int InquiryResult = PerformSearch.InsertEvent
            (
            txtEventName.Text, 
            txtEventSmallDescrition.Text, 
            txtEventLongDescription.Text, 
            eventCharges, 
            txtEventAudience.Text, 
            CBLTheme.SelectedValue, 
            DDServiceType.SelectedValue,
            
            dtStart,
            dtEnd
            //0, //duration in days
            //0, //duration in hours
            //1, //vendor id
            //null, //event comments
            //0, //is virtual event
            //txtEventRegistrationRequired.SelectedValue //is registration required
            ,eventComment:txtComment.Text
            , eventPagePath: txtEventWebPage.Text
            ,AddressLine1:txtAddressLine1.Text
            ,AddressLine2:txtAddressLine2.Text
            ,LandMark:txtLandmark.Text
            ,City: SelectedCity.Value
            , State: SelectedState.Value
            ,PinCode: txtPincode.Text
            , vendorID: txtvendorEmailID.Text
            , EventRegistrationEndDate: dtEventRegistrationEndDate
            ,isVirtualEvent: Convert.ToInt32(ddlIsVirtualEvent.SelectedValue)
            );

        if (InquiryResult > 0)
        {            
            string Message = "Event has been successfully registered with us! It will appear on the website within next 24 hours! Thanks!";
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('" + Message + "'); window.location = 'home.aspx';", true);

            //string destinationPath = "";
            //destinationPath = Server.MapPath("/") + "PublishEvents/" + (DateTime.Now.Year * 100 + DateTime.Now.Month).ToString() + "/";
            //if (!System.IO.Directory.Exists(destinationPath)) System.IO.Directory.CreateDirectory(destinationPath);

            //PerformSearch.GenerateEventPage(
            //    Convert.ToInt32(InquiryResult),
            //    Server.MapPath("/") + "PublishEvents/EventTemplate.aspx",
            //    destinationPath);

            EmailFunctions.SendEmail("register@fokal.in", "code@fokal.in", "New Event registration "+InquiryResult.ToString(), "Vendorname = " + txtvendorEmailID.Text + ", EventName = " + txtEventName.Text);
        }
        
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "alert('Error in Saving Event!!!')", true);
        }
    }
    protected void txtEventAudience_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}