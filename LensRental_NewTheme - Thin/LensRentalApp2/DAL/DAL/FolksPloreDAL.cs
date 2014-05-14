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

                string path = ds.Tables[0].Rows[i][7].ToString();
                string Eventdate = "";
                string VendorLocalPath = "";
                switch (String.IsNullOrEmpty(ds.Tables[0].Rows[i][4].ToString()))
                {
                    case true: { Eventdate = "19000101"; break; }
                    default: { Eventdate = Convert.ToDateTime(ds.Tables[0].Rows[i][4]).ToString("yyyyMMdd"); break; }
                }

                switch (String.IsNullOrEmpty(ds.Tables[0].Rows[i][8].ToString()))
                {
                    case true: { VendorLocalPath = ""; break; }
                    default: { VendorLocalPath = ds.Tables[0].Rows[i][8].ToString(); break; }
                }

                if (ds.Tables[0].Rows[i][7].ToString().Length > 0 && ds.Tables[0].Rows[i][7].ToString().Contains("http") == false)
                    path = "http://" + path;

                //Event Name as title
                HTML += "<TR> <TD>" + ds.Tables[0].Rows[i][4].ToString() + "</TD>";
                //Event Local Path
                HTML += " <TD colspan=3><B><A href=\""+ds.Tables[0].Rows[i][10].ToString()+"\">"
                                                                                + ds.Tables[0].Rows[i][2].ToString() + "</A></B></TD>";
                //Event City
                HTML += "<TD style=\"text-align:right; \">" + ds.Tables[0].Rows[i][3].ToString() + "</TR>";
                //Organizer
                HTML += " <TR> <TD></TD><TD colspan=3> <A href=\"" + VendorLocalPath + "\">" + ds.Tables[0].Rows[i][5].ToString() + "</A></TD>";
                // Event Date
                //HTML += " <TD> " + ds.Tables[0].Rows[i][4].ToString() + "</TD></TR>";
                //Event Description
                HTML += "<TR><TD></TD><TD colspan=3> " + ds.Tables[0].Rows[i][6].ToString() + "</TD></TR>";
                //Website Path
                HTML += "<TR><TD></TD><TD colspan=3><small>Registration Details | <A HREF=\"" + path + "\" target=\"_blank\">Visit Website</A>" + "</small></TD></TR>";
                HTML += "<TR><TD><br>" + " " + "</TD></TR>";
            }
            table.InnerHtml = HTML;
            return table;


        
        }



        public void GenerateEventPage(int EventID, string pageToRead,string PagePathToWrite, string WebPath)
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
                string LocalPagePath = ds.Tables[0].Rows[0][7].ToString();
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

                VendorName = Regex.Replace(VendorName, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                EventName = Regex.Replace(EventName, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                OPFile = PagePathToWrite + (VendorName + "_" + EventName + EventStartDate.ToString("yyyyMMdd") + ".aspx").Replace(" ", "");
                
                StringBuilder readContents = new StringBuilder();
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(pageToRead, Encoding.UTF8))
                {
                    readContents.Append(streamReader.ReadToEnd());
                }
                readContents.Replace("CodeFile=\"EventTemplate.aspx.cs\"", "CodeFile=\"..\\EventTemplate.aspx.cs\"");

                readContents.Replace("{{EventName}}", EventName);
                readContents.Replace("{{EventStartDate}}", EventStartDate.ToString("dd/MM/yyyy"));
                readContents.Replace("{{EventStartTime}}", EventStartDate.ToString("HH:mm"));
                readContents.Replace("{{EventCity}}", City);
                readContents.Replace("{{EventAudienceLevel}}", EventLevel);
                readContents.Replace("{{EventPriorRegistrationRequirement}}", IsRegistrationRequired);
                readContents.Replace("{{EventShortDescription}}", EventSmallDescription);
                readContents.Replace("{{VendorName}}", VendorName);
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
                    readContents.Replace("{{VendorName}}", VendorName);
                else
                    readContents.Replace("{{VendorName}}", addHTTPToLink(CreateHyperLink(VendorWebPage, VendorName, true)));

                if (String.IsNullOrEmpty(FacebookLink))
                    readContents.Replace("{{VendorNameFB}}", "");
                else
                    readContents.Replace("{{VendorNameFB}}", addHTTPToLink(CreateHyperLink(FacebookLink, VendorName + " On FB", true)));

                if (String.IsNullOrEmpty(GooglePlusLink))
                    readContents.Replace("{{VendorNameGooglePlus}}", "");
                else
                    readContents.Replace("{{VendorNameGooglePlus}}", addHTTPToLink(CreateHyperLink(GooglePlusLink, VendorName + " On Google Plus", true)));

                System.IO.StreamWriter writetext = new System.IO.StreamWriter(OPFile);
                writetext.WriteLine(readContents.ToString());
                writetext.Close();
                OPFile = WebPath + (VendorName + "_" + EventName + EventStartDate.ToString("yyyyMMdd") + ".aspx").Replace(" ", "");
                string qry = "UPDATE TblEvent SET EventLocalPagePath='" + OPFile + "' WHERE EventID=" + EventID.ToString();

                con = new SqlConnection(_ConnectionString);
                con.Open();
                cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                Logger.Utility.WriteDebugData(""+EventID.ToString()+" "+ ex.Message);
            }
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
                str="<A HREF=\"" + link + "\" target=\"_blank\">" + text + "</a>";
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
            SqlCommand cmd = new SqlCommand("uspInsertVendorDetails", con);
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
                //cmd.Parameters.Add(new SqlParameter("@UserType smallint=1
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
                cmd.Parameters.Add(new SqlParameter("@Theme",_theme));
                cmd.Parameters.Add(new SqlParameter("@DurationInDays",_DurationInDays));
                cmd.Parameters.Add(new SqlParameter("@TargetDate",_targetDate));
                cmd.Parameters.Add(new SqlParameter("@Delta",_Delta));    
           
                
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
