using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DAL
{
    public class FolksploreDAL
    {
        string _serviceName;
        int _DurationInDays, _Delta;
        string _destination, _theme;
        DateTime _targetDate;
        private string p;
        private string _ConnectionString = "Data Source=.;Initial Catalog=Folksplore;Integrated Security=True";

        //public PerformSearch(string serviceID, string destination = null, string theme = null, int DurationInDays = 0, DateTime? targetDate=null, int Delta=0)
        public FolksploreDAL(string connectionString)
        {
            _ConnectionString = connectionString; 
        }


        public int InsertSubscriptionEmail(string SubscriptionEmail, string CType)
        {
            int ret;
            string qry = "INSERT INTO [TblSubscriptionEmails]([SubscriptioEmail],CustomerType) VALUES ('" + SubscriptionEmail + "','" + CType + "')";
            SqlConnection con = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            
            ret = cmd.ExecuteNonQuery();
            return ret;

        }

        public System.Web.UI.HtmlControls.HtmlGenericControl GetHTMLTableForCategorySearch(string SearchType)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl table = new System.Web.UI.HtmlControls.HtmlGenericControl("Table");
            DataSet ds;
            string arg = SearchType;
            ds = this.GetSearchResults(arg, null, null, 0, null, 0);



            string HTML = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string eventName                = ds.Tables[0].Rows[i][2].ToString();
                string eventCity                = ds.Tables[0].Rows[i][3].ToString();
                string eventStartDate           = ds.Tables[0].Rows[i][4].ToString();
                string vendorName               = ds.Tables[0].Rows[i][5].ToString();
                string eventShortDescription    = ds.Tables[0].Rows[i][6].ToString();
                //string eventPage                = ds.Tables[0].Rows[i][7].ToString();
                string vendorLocalPagePath      = ds.Tables[0].Rows[i][8].ToString();
                string eventSubCategory         = ds.Tables[0].Rows[i][9].ToString();
                string eventLocalPagePath       = ds.Tables[0].Rows[i][10].ToString();
                string eventLevel               = ds.Tables[0].Rows[i][11].ToString();
                string eventTheme               = ds.Tables[0].Rows[i][12].ToString();
                string eventThumbImage          = ds.Tables[0].Rows[i][13].ToString();

                string path = eventLocalPagePath;
                string Eventdate = "";
                string VendorLocalPath = "";
                switch (String.IsNullOrEmpty(eventStartDate))
                {
                    case true: { Eventdate = "19000101"; break; }
                    default: { Eventdate = Convert.ToDateTime(eventStartDate).ToString("yyyyMMdd"); break; }
                }

                switch (String.IsNullOrEmpty(vendorLocalPagePath))
                {
                    case true: { VendorLocalPath = ""; break; }
                    default: { VendorLocalPath = vendorLocalPagePath; break; }
                }

                if (eventLocalPagePath.Length > 0 && eventLocalPagePath.Contains("http") == false)
                    path = "http://" + path;

                HTML += "<tr >";
                HTML += "<td class=\"imagebox\">";
                HTML += "<div class=\"image\">";
                HTML += "<a href=\"" + path + "\">"; //Event Local Page Path
                HTML += "<img  src=\"" + eventThumbImage + "\" />"; // Image path
                HTML += "</a>";
                HTML += "</div>";
                HTML += "</td>";
                HTML += "<td class=\"eventDetails\">";
                HTML += "<h2 >";
                HTML += "<a href=\"" + path + "\">" + eventName + "</a>";
                HTML += "</h2>";
                HTML += "<small >";
                HTML += "<span >";
                HTML += "Organizer: ";
                HTML += "</span>";
                HTML += "<a href=\"" + VendorLocalPath + "\">" + vendorName + "</a>";
                HTML += "</small>";
                HTML += "<div>";
                HTML += "<small>";
                HTML += "<span >";
                HTML += eventSubCategory; //Event Sub Category
                HTML += "</span> | <span >";
                if(String.IsNullOrEmpty(eventCity))
                    HTML += "Online"; 
                else
                    HTML += eventCity;
                HTML += "</span> | <span >";
                HTML += eventLevel; //Event Level
                HTML += "</span>"; 
                HTML += "</small>";
                HTML += "</div>";
                            
                HTML += "</td>";
                HTML += "<td class=\"dateContainer\">";
                HTML += "<div class=\"expired\">";
                HTML += "<div class=\"pic\">";
                HTML += "<div class=\"dateSmallIcon\">";
                HTML += "<p>";
                if(String.IsNullOrEmpty(eventStartDate))
                    HTML += DateTime.Now.ToString("MMM");
                else
                    HTML += Convert.ToDateTime(eventStartDate).ToString("MMM"); //Event Start Month in three letters
                HTML += "</p>";
                HTML += "<h2>";
                if (String.IsNullOrEmpty(eventStartDate))
                    HTML += DateTime.Now.Day.ToString();
                else
                    HTML += Convert.ToDateTime(eventStartDate).Day.ToString(); //Event Start day
                HTML += "</h2>";
                HTML += "</div></div></div>";
                HTML += "</td>";
                HTML += "</tr>";


            }
            table.InnerHtml = HTML;
            return table;


        
        }

        public System.Web.UI.HtmlControls.HtmlGenericControl GetHTMLTableForVendorSearch(string SearchType)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl table = new System.Web.UI.HtmlControls.HtmlGenericControl("Table");
            DataSet ds;
            string arg = SearchType;
            ds = this.GetVendorResults(arg, null, null, 0, null, 0);



            string HTML = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string vendorName = ds.Tables[0].Rows[i][1].ToString();
                string vendorCity = ds.Tables[0].Rows[i][2].ToString();
                string vendorShortDescription = ds.Tables[0].Rows[i][3].ToString();
                string vendorLocalPagePath = ds.Tables[0].Rows[i][4].ToString();
                string vendorSubCategory = ds.Tables[0].Rows[i][5].ToString();
                string vendorThumbImage = ds.Tables[0].Rows[i][6].ToString();

                string path = vendorLocalPagePath;
                
                string VendorLocalPath = "";


                switch (String.IsNullOrEmpty(vendorLocalPagePath))
                {
                    case true: { VendorLocalPath = ""; break; }
                    default: { VendorLocalPath = vendorLocalPagePath; break; }
                }

                if (vendorLocalPagePath.Length > 0 && vendorLocalPagePath.Contains("http") == false)
                    path = "http://" + path;

                HTML += "<tr >";
                HTML += "<td class=\"vendorimagebox\">";
                HTML += "<div class=\"vendorimage\">";
                HTML += "<a href=\"" + path + "\">"; //Vendor Local Page Path
                HTML += "<img  class=\"smallvendorimage\" src=\"" + vendorThumbImage + "\" />"; // Image path
                HTML += "</a>";
                HTML += "</div>";
                HTML += "</td>";
                HTML += "<td class=\"vendorDetails\">";
                HTML += "<h2 >";
                HTML += "<a href=\"" + path + "\">" + vendorName + "</a>";
                HTML += "</h2>";
                HTML += "<small >";
                HTML += "City: ";
                HTML += "<span >";
                HTML += vendorCity;
                HTML += "</span>";
                HTML += "</small>";
                HTML += "<div>";
                HTML += "<small >";
                HTML += "<span >";
                HTML += "</span>";
                HTML += vendorShortDescription;
                HTML += "</small>";
                HTML += "</div>";
                HTML += "<div>";
                HTML += "<small> <b> Organizes: Photography  </b>»";
                HTML += "<span >";
                HTML += vendorSubCategory; //Vendor Sub Category
                
                
                //HTML += "</span> | <span >";
                //HTML += eventLevel; //Event Level
                HTML += "</span>";
                HTML += "</small>";
                HTML += "</div>";

                HTML += "</td>";
                //HTML += "<td class=\"dateContainer\">";
                //HTML += "<div class=\"expired\">";
                //HTML += "<div class=\"pic\">";
                //HTML += "<div class=\"dateSmallIcon\">";
                //HTML += "<p>";
                //if (String.IsNullOrEmpty(eventStartDate))
                //    HTML += DateTime.Now.ToString("MMM");
                //else
                //    HTML += Convert.ToDateTime(eventStartDate).ToString("MMM"); //Event Start Month in three letters
                //HTML += "</p>";
                //HTML += "<h2>";
                //if (String.IsNullOrEmpty(eventStartDate))
                //    HTML += DateTime.Now.Day.ToString();
                //else
                //    HTML += Convert.ToDateTime(eventStartDate).Day.ToString(); //Event Start day
                //HTML += "</h2>";
                //HTML += "</div></div></div>";
                //HTML += "</td>";
                HTML += "</tr>";


            }
            table.InnerHtml = HTML;
            return table;



        }

        public string GenerateVendorPage(int VendorID, string pageToRead, string PagePathToWrite, string WebPath)
        {
            try
            {
                SqlConnection con = new SqlConnection(_ConnectionString);
                SqlCommand cmd = new SqlCommand("pGetVendorPageData", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Parameters.Add(new SqlParameter("@VendorID", VendorID));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
                String OPFile = "";

                string VendorName= ds.Tables[0].Rows[0][1].ToString();
                string VendorDescription= ds.Tables[0].Rows[0][2].ToString();
                string City= ds.Tables[0].Rows[0][3].ToString();
                string VendorDetailedDescription= ds.Tables[0].Rows[0][4].ToString();
                string ContactPerson= ds.Tables[0].Rows[0][5].ToString();
                string AddressLine1= ds.Tables[0].Rows[0][6].ToString();
                string AddressLine2= ds.Tables[0].Rows[0][7].ToString();
                string LandMark= ds.Tables[0].Rows[0][8].ToString();
                string State= ds.Tables[0].Rows[0][9].ToString();
                string PinCode= ds.Tables[0].Rows[0][10].ToString();
                string MobileNo= ds.Tables[0].Rows[0][11].ToString();
                string website= ds.Tables[0].Rows[0][12].ToString();
                string RegisteredEmail= ds.Tables[0].Rows[0][13].ToString();
                string FacebookLink= ds.Tables[0].Rows[0][14].ToString();
                string GooglePlusLink= ds.Tables[0].Rows[0][15].ToString();
                string Services = ds.Tables[0].Rows[0][16].ToString();

                string Event1 = ds.Tables[0].Rows[0][17].ToString();
                string EventLink1 = ds.Tables[0].Rows[0][18].ToString();

                string Event2 = ds.Tables[0].Rows[0][19].ToString();
                string EventLink2 = ds.Tables[0].Rows[0][20].ToString();

                string Event3 = ds.Tables[0].Rows[0][21].ToString();
                string EventLink3 = ds.Tables[0].Rows[0][22].ToString();

                string VendorNameCompressed = Regex.Replace(VendorName, "[^a-zA-Z0-9_.]+", "-", RegexOptions.Compiled);
                string VendorLargeImage = WebPath +"../images/" + VendorNameCompressed + ".png";
                string VendorThumbImage = WebPath + "../images/thumb-" + VendorNameCompressed + ".png";

                OPFile = PagePathToWrite + (VendorNameCompressed + ".aspx").Replace(" ", "-");

                StringBuilder readContents = new StringBuilder();
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(pageToRead, Encoding.UTF8))
                {
                    readContents.Append(streamReader.ReadToEnd());
                }
                readContents.Replace("CodeFile=\"PSPTemplate.aspx.cs\"", "CodeFile=\"..\\PSPTemplate.aspx.cs\"");
                readContents.Replace("{{VendorPic}}", VendorLargeImage);
                readContents.Replace("{{VendorName}}", VendorName);
                readContents.Replace("{{VendorShortDescription}}", VendorDescription);
                readContents.Replace("{{VendorCity}}", City);
                readContents.Replace("{{VendorDetailedDescription}}", VendorDetailedDescription);
                readContents.Replace("{{ContactPerson}}", ContactPerson);
                readContents.Replace("{{AddressLine1}}", AddressLine1);
                readContents.Replace("{{AddressLine2}}", AddressLine2);
                readContents.Replace("{{Landmark}}", LandMark);
                readContents.Replace("{{state}}", State);
                readContents.Replace("{{PinCode}}", PinCode);
                readContents.Replace("{{ContactNumber}}", MobileNo);
                if (String.IsNullOrEmpty(website))
                    readContents.Replace("{{VendorWebPage}}", "");
                else
                    readContents.Replace("{{VendorWebPage}}", CreateHyperLink(addHTTPToLink(website), website, true));
 
                readContents.Replace("{{VendorEmail}}", CreateHyperLink("mailto:" + RegisteredEmail, RegisteredEmail, false));
                
                readContents.Replace("{{ServiceType}}", Services);

                readContents.Replace("{{VendorLatestEventLocalLink1}}", EventLink1);
                readContents.Replace("{{VendorLatestEvent1}}", Event1);

                readContents.Replace("{{VendorLatestEventLocalLink2}}", EventLink2);
                readContents.Replace("{{VendorLatestEvent2}}", Event2);

                readContents.Replace("{{VendorLatestEventLocalLink3}}", EventLink3);
                readContents.Replace("{{VendorLatestEvent3}}", Event3);

                if (String.IsNullOrEmpty(FacebookLink))
                    readContents.Replace("{{VendorFBPageLink}}", "");
                else
                    readContents.Replace("{{VendorFBPageLink}}", CreateHyperLink(addHTTPToLink(FacebookLink), VendorName + " On FB", true));

                if (String.IsNullOrEmpty(GooglePlusLink))
                    readContents.Replace("{{VendorGooglePlusPageLink}}", "");
                else
                    readContents.Replace("{{VendorGooglePlusPageLink}}", CreateHyperLink(addHTTPToLink(GooglePlusLink), VendorName + " On Google Plus", true));


                System.IO.StreamWriter writetext = new System.IO.StreamWriter(OPFile);
                writetext.WriteLine(readContents.ToString());
                writetext.Close();

                OPFile = WebPath + (VendorNameCompressed + ".aspx").Replace(" ", "-");

                string qry = "UPDATE TblVendor SET LocalPagePath='" + OPFile + 
                    "',ThumbImagePath='" + VendorThumbImage +         
                    "',LargeImagePath='" + VendorLargeImage + 
                    "' WHERE VendorID=" + VendorID.ToString();


                con = new SqlConnection(_ConnectionString);
                con.Open();
                cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();

                con.Close();

                return OPFile;
            }
            catch (Exception ex)
            {
                Logger.Utility.WriteDebugData(ex.Message);
                return null;
            }

            return "";
        }

        public string GenerateEventPage(int EventID, string pageToRead,string PagePathToWrite, string WebPath)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(_ConnectionString);
                SqlCommand cmd = new SqlCommand("pGetEventPageData", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Parameters.Add(new SqlParameter("@EventID", EventID));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
                String OPFile = "";

                string EventName = ds.Tables[0].Rows[0][0].ToString();
                DateTime EventStartDate = Convert.ToDateTime(ds.Tables[0].Rows[0][1]);
                string City = ds.Tables[0].Rows[0][2].ToString();
                string EventLevel = ds.Tables[0].Rows[0][3].ToString();
                string ServiceTheme = ds.Tables[0].Rows[0][4].ToString();
                string EventSmallDescription = ds.Tables[0].Rows[0][5].ToString();
                string VendorName = ds.Tables[0].Rows[0][6].ToString();
                string VendorLocalPagePath = ds.Tables[0].Rows[0][7].ToString();
                string EventCharges = ds.Tables[0].Rows[0][8].ToString();
                string IsRegistrationRequired = ds.Tables[0].Rows[0][9].ToString();
                string EventLargeDescription = ds.Tables[0].Rows[0][10].ToString();
                string EventPagePath = ds.Tables[0].Rows[0][11].ToString();
                string EventRegistrationEndDate = ds.Tables[0].Rows[0][12].ToString();
                string AddressLine1 = ds.Tables[0].Rows[0][13].ToString();
                string AddressLine2 = ds.Tables[0].Rows[0][14].ToString();
                string LandMark = ds.Tables[0].Rows[0][15].ToString();
                string MobileNo = ds.Tables[0].Rows[0][16].ToString();
                string RegisteredEmail = ds.Tables[0].Rows[0][17].ToString();
                string FacebookLink = ds.Tables[0].Rows[0][18].ToString();
                string GooglePlusLink = ds.Tables[0].Rows[0][19].ToString();
                string EventComment = ds.Tables[0].Rows[0][20].ToString();
                string VendorWebPage = ds.Tables[0].Rows[0][21].ToString();
                string EventType = ds.Tables[0].Rows[0][23].ToString();
                string VendorContactNumber = ds.Tables[0].Rows[0][24].ToString();
                string VendorContactPerson = ds.Tables[0].Rows[0][25].ToString();
                
                string VendorNameCompressed = Regex.Replace(VendorName, "[^a-zA-Z0-9_.]+", "-", RegexOptions.Compiled);
                string EventNameCompressed = Regex.Replace(EventName, "[^a-zA-Z0-9_.]+", "-", RegexOptions.Compiled);
                OPFile = PagePathToWrite + (VendorNameCompressed + "-" + EventNameCompressed + EventStartDate.ToString("yyyyMMdd") + ".aspx").Replace(" ", "-");

                string EventLargeImage = WebPath + "./images/" + EventNameCompressed + EventStartDate.ToString("yyyyMMdd") + ".png";
                string EventThumbImage = WebPath + "./images/thumb-" + EventNameCompressed + EventStartDate.ToString("yyyyMMdd") + ".png";
                StringBuilder readContents = new StringBuilder();
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(pageToRead, Encoding.UTF8))
                {
                    readContents.Append(streamReader.ReadToEnd());
                }

                readContents.Replace("CodeFile=\"EventTemplate.aspx.cs\"", "CodeFile=\"..\\EventTemplate.aspx.cs\"");
                readContents.Replace("{{EventPic}}", EventLargeImage);
                readContents.Replace("{{EventName}}", EventName);
                readContents.Replace("{{EventType}}", EventType);
                readContents.Replace("{{EventStartDate}}", EventStartDate.ToString("MMM") + " " + EventStartDate.Day.ToString());
                readContents.Replace("{{EventStartTime}}", EventStartDate.ToString("HH:mm"));
                readContents.Replace("{{EventCity}}", City);
                readContents.Replace("{{EventAudienceLevel}}", EventLevel);
                readContents.Replace("{{EventPriorRegistrationRequirement}}", IsRegistrationRequired);
                readContents.Replace("{{EventShortDescription}}", EventSmallDescription);
                readContents.Replace("{{VendorName}}", VendorName);
                readContents.Replace("{{VendorLocalName}}", VendorLocalPagePath);
                readContents.Replace("{{EventFee}}", EventCharges);
                readContents.Replace("{{EventTheme}}", ServiceTheme);
                readContents.Replace("{{EventDetailedDescription}}", EventLargeDescription);
                readContents.Replace("{{EventPagePath}}", EventPagePath);
                if (String.IsNullOrEmpty(EventRegistrationEndDate) || EventRegistrationEndDate.Contains("1900"))
                    readContents.Replace("{{EventRegistrationLastDate}}", "");
                else
                    readContents.Replace("{{EventRegistrationLastDate}}", "Register By: " + EventRegistrationEndDate);

                readContents.Replace("{{EventRegistrationMode}}", "Online");
                readContents.Replace("{{AddressLine1}}", AddressLine1);
                readContents.Replace("{{AddressLine2}}", AddressLine2);
                readContents.Replace("{{Landmark}}", LandMark);
                readContents.Replace("{{City}}", City);
                readContents.Replace("{{EventContactNumber}}", MobileNo);
                readContents.Replace("{{EMail}}", RegisteredEmail);
                readContents.Replace("{{EventContent}}", EventComment);
                
                if (String.IsNullOrEmpty(VendorWebPage))
                    readContents.Replace("{{VendorWebName}}", VendorName);
                else
                    readContents.Replace("{{VendorWebName}}", CreateHyperLink(addHTTPToLink(VendorWebPage), VendorName, true));

                if (String.IsNullOrEmpty(FacebookLink))
                    readContents.Replace("{{VendorNameFB}}", "");
                else
                    readContents.Replace("{{VendorNameFB}}", CreateHyperLink(addHTTPToLink(FacebookLink), VendorName + " On FB", true));

                if (String.IsNullOrEmpty(GooglePlusLink))
                    readContents.Replace("{{VendorNameGooglePlus}}", "");
                else
                    readContents.Replace("{{VendorNameGooglePlus}}", CreateHyperLink(addHTTPToLink(GooglePlusLink), VendorName + " On Google Plus", true));
                readContents.Replace("{{VendorContactNumber}}", VendorContactNumber);
                readContents.Replace("{{VendorContactPerson}}", VendorContactPerson);

                //Create Page
                System.IO.StreamWriter writetext = new System.IO.StreamWriter(OPFile);
                writetext.WriteLine(readContents.ToString());
                writetext.Close();
                OPFile = WebPath + (VendorNameCompressed + "-" + EventNameCompressed + EventStartDate.ToString("yyyyMMdd") + ".aspx").Replace(" ", "-");
                
                string qry = "UPDATE TblEvent SET EventLocalPagePath='" + OPFile +
                    "',ThumbImagePath='" + EventThumbImage +
                    "',LargeImagePath='" + EventLargeImage + 
                    "' WHERE EventID=" + EventID.ToString();

                con = new SqlConnection(_ConnectionString);
                con.Open();
                cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();

                con.Close();

                return OPFile;
            }
            catch (Exception ex)
            {
                Logger.Utility.WriteDebugData(""+EventID.ToString()+" "+ ex.Message);
                return "Error";
            }
            return "OK";

        }

        static string addHTTPToLink(string link)
        { 
            if (!(link.Contains("http") || link.Contains("https"))) link="http://"+link;

            return link;
        }

        static string CreateHyperLink(String link, String text, bool newWindow)
        { 
            string str;
            
                if (newWindow)
                    str = "<A HREF=\"" + link + "\" target=\"_blank\">" + text + "</a>";
                else
                    str = "<A HREF=\"" + link + "\">" + text + "</a>";
           
            return str;
        }

        public List<string> GetStates()
        {
            SqlConnection con = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_GetStates", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();            
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            
            var states = new List<string>();
            try
            {
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        states.Add(Convert.ToString(dr["Name"]));
                    }
                }
                return states;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetStates", ex);
                return states;
            }
            finally
            {
                con.Close();
            }
            
        }

        public List<string> GetCities(string state)
        {
            SqlConnection con = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_GetCitiesByState", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.Add(new SqlParameter("@StateName", state));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;

            var cities = new List<string>();
            try
            {
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        cities.Add(Convert.ToString(dr["Name"]));
                    }
                }
                return cities;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetCities", ex);
                return cities;
            }
            finally
            {
                con.Close();
            }

        }


        public int InsertVendor(
           string VendorName,
           string registeredemail,
            string services,
           string AddressLine1 = null,
           string AddressLine2 = null,
           string LandMark = null,
           string City = null,
           string State = null,
           string PinCode = null,
           string MobileNo = null,
           string ContactPersonName = null,
           string VendorShortDescription = null,
           string VendorDescription = null,
           string Website = null,
           string FacebookLink = null,
           string GooglePlusLink = null,
           string AreaOfOperation = null,
           string LinkedInLink = null

               )
        {
            SqlConnection con = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("pInsertVendorDetails", con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Name", ContactPersonName));
                cmd.Parameters.Add(new SqlParameter("@Services", services));
                cmd.Parameters.Add(new SqlParameter("@AddressLine1", AddressLine1));
                cmd.Parameters.Add(new SqlParameter("@AddressLine2", AddressLine2));
                cmd.Parameters.Add(new SqlParameter("@LandMark", LandMark));
                cmd.Parameters.Add(new SqlParameter("@City", City));
                cmd.Parameters.Add(new SqlParameter("@State", State));
                //cmd.Parameters.Add(new SqlParameter("@Country",'INDIA'));
                cmd.Parameters.Add(new SqlParameter("@PinCode", PinCode));
                cmd.Parameters.Add(new SqlParameter("@MobileNo", MobileNo));
                cmd.Parameters.Add(new SqlParameter("@AreaOfOperation", AreaOfOperation));
                //cmd.Parameters.Add(new SqlParameter("@CreatedDateTime datetime=NULL
                cmd.Parameters.Add(new SqlParameter("@UserType", "vendor"));
                //cmd.Parameters.Add(new SqlParameter("@CompleteAddressLine nvarchar(564)=NULL
                //cmd.Parameters.Add(new SqlParameter("@Area varchar(250)=NULL
                cmd.Parameters.Add(new SqlParameter("@registeredEmail", registeredemail));
                cmd.Parameters.Add(new SqlParameter("@VendorName", VendorName));
                cmd.Parameters.Add(new SqlParameter("@VendorDescription", VendorShortDescription));
                cmd.Parameters.Add(new SqlParameter("@VendorDetailedDescription", VendorDescription));
                //,@VendorNotes nvarchar(MAX)=NULL
                //,@SocialProfileID int=NULL
                //,@LocalPagePath varchar(1024)=NULL

                cmd.Parameters.Add(new SqlParameter("@Website", Website));
                cmd.Parameters.Add(new SqlParameter("@FacebookLink", FacebookLink));
                //,@FlickrLink varchar(200)=NULL
                //,@PicasaLink varchar(200)=NULL
                //,@Px500Link varchar(200)=NULL
                cmd.Parameters.Add(new SqlParameter("@LinkedInLink", LinkedInLink));
                //,@TwitterLink varchar(200)=NULL
                //,@BbmPin varchar(20)=NULL
                cmd.Parameters.Add(new SqlParameter("@GooglePlusLink", GooglePlusLink));
                //,@BlogLink varchar(200)=NULL
                //,@Recognitions varchar(500)=NULL

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                string res=cmd.ExecuteScalar().ToString();
                if (res == "OK")
                {
                    Logger.Utility.WriteInfo(registeredemail + " Success");
                    return 1;
                }
                else if (res == "This email is already available in database.")
                {
                    Logger.Utility.HandleException(registeredemail + " insertion failed : Duplicate Email "+registeredemail);
                    return -1;
                }
                else
                {
                    Logger.Utility.HandleException(registeredemail + " insertion failed");
                    return 0;
                }
                
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException(registeredemail + " insertion failed : "+ex.Message);
                return 0;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return 0;
        }


        public int InsertEvent(
            string eventName, 
            string smallDescription, 
            string largeDescription, 
            int registrationCharges, 
            string audienceLevel, 
            string eventTheme, 
            string eventType, 
            DateTime? startDate=null,
            DateTime? endDate=null,
            int durationInDays = 0,
            int durationInHours=0,
            string vendorID=null,
            string eventComment = null,
            int isVirtualEvent = 0,
            string eventPagePath = null,
            int isRegistrationRequired = 0,

            string AddressLine1 = null,
           string AddressLine2 = null,
           string LandMark = null,
           string City = null,
           string State = null,
           string PinCode = null,
           string MobileNo = null,
           string ContactPersonName = null,
            DateTime? EventRegistrationStartDate = null,
            DateTime? EventRegistrationEndDate = null
            )
        {
            SqlConnection con = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("uspInsertEventDetails", con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@EventName", eventName));
                cmd.Parameters.Add(new SqlParameter("@EventSmallDescription", smallDescription));
                cmd.Parameters.Add(new SqlParameter("@EventLargeDescription", largeDescription));
                cmd.Parameters.Add(new SqlParameter("@EventCharges", registrationCharges));
                cmd.Parameters.Add(new SqlParameter("@EventLevel", audienceLevel));
                cmd.Parameters.Add(new SqlParameter("@Theme", eventTheme));
                cmd.Parameters.Add(new SqlParameter("@EventCategory", eventType));
                cmd.Parameters.Add(new SqlParameter("@EventStartDate", startDate));
                cmd.Parameters.Add(new SqlParameter("@EventEndDate", endDate));
                cmd.Parameters.Add(new SqlParameter("@DurationInDays", durationInDays));
                cmd.Parameters.Add(new SqlParameter("@DurationInHours", durationInHours));
                cmd.Parameters.Add(new SqlParameter("@VendorEmailID", vendorID));
                cmd.Parameters.Add(new SqlParameter("@EventComment", eventComment));
                cmd.Parameters.Add(new SqlParameter("@IsVirtualEvent", isVirtualEvent ));
                cmd.Parameters.Add(new SqlParameter("@EventPagePath", eventPagePath ));
                cmd.Parameters.Add(new SqlParameter("@isRegistrationRequired",isRegistrationRequired ));

                cmd.Parameters.Add(new SqlParameter("@Name", ContactPersonName));
                cmd.Parameters.Add(new SqlParameter("@AddressLine1", AddressLine1));
                cmd.Parameters.Add(new SqlParameter("@AddressLine2", AddressLine2));
                cmd.Parameters.Add(new SqlParameter("@LandMark", LandMark));
                cmd.Parameters.Add(new SqlParameter("@City", City));
                cmd.Parameters.Add(new SqlParameter("@State", State));                
                cmd.Parameters.Add(new SqlParameter("@PinCode", PinCode));
                cmd.Parameters.Add(new SqlParameter("@MobileNo", MobileNo));                

                cmd.Parameters.Add(new SqlParameter("@EventRegistrationStartDate", EventRegistrationStartDate));
                cmd.Parameters.Add(new SqlParameter("@EventRegistrationEndDate", EventRegistrationEndDate));

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                int ret;
                ret=Convert.ToInt32(cmd.ExecuteScalar());

                return ret;
            }
            catch (Exception ex)
            {
                Logger.Utility.WriteDebugData(ex.Message);
                return 0;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return 0;
        }

        public DataSet GetSearchResults(string serviceID, string destination = null, string theme = null, int DurationInDays = 0, DateTime? targetDate = null, int Delta = 0)
        {
            _serviceName = serviceID;
            _destination = destination;
            _theme = theme;
            if (DurationInDays > 0 && DurationInDays < 8)
                _DurationInDays = DurationInDays;

            if (targetDate != null) _targetDate = Convert.ToDateTime(targetDate); else _targetDate = Convert.ToDateTime("1900-01-01");
            _Delta = Delta;

            SqlConnection con= new SqlConnection(_ConnectionString);
            SqlCommand cmd= new SqlCommand("pSearchService", con);
            DataSet ds= new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd.Parameters.Add(new SqlParameter("@ServiceName", _serviceName));
                cmd.Parameters.Add(new SqlParameter("@Destination",_destination));
                cmd.Parameters.Add(new SqlParameter("@Theme", _theme));
                cmd.Parameters.Add(new SqlParameter("@DurationInDays", _DurationInDays));
                cmd.Parameters.Add(new SqlParameter("@TargetDate", _targetDate));
                cmd.Parameters.Add(new SqlParameter("@Delta", _Delta));    
           
                
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        public DataSet GetVendorResults(string serviceID, string destination = null, string theme = null, int DurationInDays = 0, DateTime? targetDate = null, int Delta = 0)
        {
            _serviceName = null;
            _destination = destination;
            //_theme = theme;
            

            SqlConnection con = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("pSearchVendor", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd.Parameters.Add(new SqlParameter("@ServiceName", _serviceName));
                cmd.Parameters.Add(new SqlParameter("@Destination", _destination));
                //cmd.Parameters.Add(new SqlParameter("@Theme",_theme));
                //cmd.Parameters.Add(new SqlParameter("@DurationInDays",_DurationInDays));
                //cmd.Parameters.Add(new SqlParameter("@TargetDate",_targetDate));
                //cmd.Parameters.Add(new SqlParameter("@Delta",_Delta));    


                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        public DataSet GetServices()
        {
            SqlConnection con= new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("pGetMasterData", con);
            DataSet ds= new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd.CommandType=CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }

        }

    }

   
}
