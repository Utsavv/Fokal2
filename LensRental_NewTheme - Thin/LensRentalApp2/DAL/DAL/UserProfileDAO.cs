using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL.Base;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Model;

namespace DAL
{
    public class UserProfileDAO : BaseDAO
    {
        private static readonly UserProfileDAO UserProfileDAOInstance = new UserProfileDAO();

        private UserProfileDAO()
        {
        }

        public static UserProfileDAO GetInstance
        {
            get { return UserProfileDAOInstance; } //end of get
        }

        public Int32 SaveUserSocialBuildUp(string UserXML, Int32 UserId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveUserSocialBuildUp");
            try
            {
                database.AddInParameter(command, "@UserXML", DbType.Xml, UserXML);
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in SaveUserSocialBuildUp", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public Int32 SaveUserCameraDetails(string UserXML, Int32 UserId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveUserCameraDetails");
            try
            {
                database.AddInParameter(command, "@UserXML", DbType.Xml, UserXML);
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in SaveUserCameraDetails", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public Int32 SaveUserDocumentDetails(string UserXML, Int32 UserId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveUserDocuments");
            try
            {
                database.AddInParameter(command, "@UserXML", DbType.Xml, UserXML);
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in SaveUserDocumentDetails", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public int SaveUserProfile(string UserXML, Int32 UserId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveUserProfile");
            try
            {
                database.AddInParameter(command, "@UserXML", DbType.Xml, UserXML);
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in SaveUserProfile", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public User GetUserProfile(Int32 userId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetUserDetailsByUserId");
            User userObj = new User();
            try
            {
                database.AddInParameter(command, "@userId", DbType.Int32, userId);
                datasetInformation = database.ExecuteDataSet(command);

                if (datasetInformation != null && datasetInformation.Tables.Count > 4)
                {
                    UserProfileDetails userDetails = new UserProfileDetails();
                    userDetails.UserId = userId;
                    if (datasetInformation.Tables[0].Rows.Count > 0)
                    {
                        userDetails.firstName = Convert.ToString(datasetInformation.Tables[0].Rows[0]["FirstName"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["FirstName"] : "");
                        userDetails.lastName = Convert.ToString(datasetInformation.Tables[0].Rows[0]["LastName"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["LastName"] : "");
                        userDetails.userName = Convert.ToString(datasetInformation.Tables[0].Rows[0]["UserName"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["UserName"] : "");
                        userDetails.password = Convert.ToString(datasetInformation.Tables[0].Rows[0]["Password"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["Password"] : "");
                        userDetails.gender = Convert.ToString(datasetInformation.Tables[0].Rows[0]["Gender"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["Gender"] : "");
                        userDetails.secondaryemail = Convert.ToString(datasetInformation.Tables[0].Rows[0]["SecondaryEmailAddress"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["SecondaryEmailAddress"] : "");
                        userDetails.dateOfBirth = Convert.ToString(datasetInformation.Tables[0].Rows[0]["DateOfBirth"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["DateOfBirth"] : "");
                        userDetails.mobileNumber = Convert.ToString(datasetInformation.Tables[0].Rows[0]["MobileNumber"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["MobileNumber"] : "");
                        userDetails.telephoneNumber = Convert.ToString(datasetInformation.Tables[0].Rows[0]["TelephoneNumber"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["TelephoneNumber"] : "");
                        userDetails.communicationEmail = Convert.ToString(datasetInformation.Tables[0].Rows[0]["CommunicationEmail"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["CommunicationEmail"] : "");
                        userDetails.DocumentsVerified = Convert.ToInt32(datasetInformation.Tables[0].Rows[0]["DocumentsVerified"] != DBNull.Value ? datasetInformation.Tables[0].Rows[0]["DocumentsVerified"] : 0);
                        //userDetails.companyname = Convert.ToString(datasetInformation.Tables[0].Rows[0]["CompanyName"]);
                        //userDetails.companyaddress = Convert.ToString(datasetInformation.Tables[0].Rows[0]["CompanyAddress"]);
                        //userDetails.companyphone = Convert.ToString(datasetInformation.Tables[0].Rows[0]["CompanyPhone"]);
                        //userDetails.extension = Convert.ToString(datasetInformation.Tables[0].Rows[0]["Extension"]);
                    }
                    userObj.userProfileDetails = userDetails;


                    SocialBuildUp userSocialLinks = new SocialBuildUp();
                    userSocialLinks.userId = userId;
                    if (datasetInformation.Tables[1].Rows.Count > 0)
                    {
                        userSocialLinks.FacebookLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["FacebookLink"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["FacebookLink"] : "");
                        userSocialLinks.FlickrLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["FlickrLink"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["FlickrLink"] : "");
                        userSocialLinks.PicasaLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["PicasaLink"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["PicasaLink"] : "");
                        userSocialLinks.PX500Link = Convert.ToString(datasetInformation.Tables[1].Rows[0]["Px500Link"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["Px500Link"] : "");
                        userSocialLinks.LinkedInLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["LinkedInLink"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["LinkedInLink"] : "");
                        userSocialLinks.TwitterLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["TwitterLink"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["TwitterLink"] : "");
                        userSocialLinks.BBMPin = Convert.ToString(datasetInformation.Tables[1].Rows[0]["BbmPin"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["BbmPin"] : "");
                        userSocialLinks.GooglePlusLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["GooglePlusLink"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["GooglePlusLink"] : "");
                        userSocialLinks.PersonalWebsiteLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["PersonalWebsite"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["PersonalWebsite"] : "");
                        userSocialLinks.BlogLink = Convert.ToString(datasetInformation.Tables[1].Rows[0]["BlogLink"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["BlogLink"] : "");
                        userSocialLinks.Recognitions = Convert.ToString(datasetInformation.Tables[1].Rows[0]["Recognitions"] != DBNull.Value ? datasetInformation.Tables[1].Rows[0]["Recognitions"] : "");
                    }
                    userObj.userSocialBuildUp = userSocialLinks;

                    CameraDetails userCameraDetails = new CameraDetails();
                    userCameraDetails.userId = userId;
                    if (datasetInformation.Tables[2].Rows.Count > 0)
                    {
                        userCameraDetails.Camera = Convert.ToString(datasetInformation.Tables[2].Rows[0]["CameraDetails"] != DBNull.Value ? datasetInformation.Tables[2].Rows[0]["CameraDetails"] : "");
                        userCameraDetails.Lenses = Convert.ToString(datasetInformation.Tables[2].Rows[0]["Lenses"] != DBNull.Value ? datasetInformation.Tables[2].Rows[0]["Lenses"] : "");
                        userCameraDetails.Accessories = Convert.ToString(datasetInformation.Tables[2].Rows[0]["Accessories"] != DBNull.Value ? datasetInformation.Tables[2].Rows[0]["Accessories"] : "");
                        userCameraDetails.Tripod = Convert.ToString(datasetInformation.Tables[2].Rows[0]["Tripod"] != DBNull.Value ? datasetInformation.Tables[2].Rows[0]["Tripod"] : "");
                        userCameraDetails.FavouriteSubject = Convert.ToString(datasetInformation.Tables[2].Rows[0]["FavouriteSubject"] != DBNull.Value ? datasetInformation.Tables[2].Rows[0]["FavouriteSubject"] : "");
                        userCameraDetails.WishList = Convert.ToString(datasetInformation.Tables[2].Rows[0]["WishList"] != DBNull.Value ? datasetInformation.Tables[2].Rows[0]["WishList"] : "");
                    }
                    userObj.userCameraDetails = userCameraDetails;

                    List<UserDocuments> userDocuments = new List<UserDocuments>();
                    foreach (DataRow dr in datasetInformation.Tables[3].Rows)
                    {
                        UserDocuments doc = new UserDocuments();
                        doc.UserId = userId;
                        doc.DocumentId = Convert.ToInt32(dr["DocumentId"] != DBNull.Value ? dr["DocumentId"] : 0);
                        doc.DocumentName = Convert.ToString(dr["DocumentName"] != DBNull.Value ? dr["DocumentName"] : "");
                        doc.DocumentPath = Convert.ToString(dr["DocumentPath"] != DBNull.Value ? dr["DocumentPath"] : "");
                        doc.DocumentType = Convert.ToString(dr["DocumentType"] != DBNull.Value ? dr["DocumentType"] : "");
                        doc.DocumentSubType = Convert.ToString(dr["DocumentSubType"] != DBNull.Value ? dr["DocumentSubType"] : "");
                        userDocuments.Add(doc);

                    }

                    userObj.userDocuments = userDocuments;

                    List<UserAddress> address = new List<UserAddress>();
                    foreach (DataRow dr in datasetInformation.Tables[4].Rows)
                    {
                        UserAddress userAddress = new UserAddress();
                        userAddress.UserId = userId;
                        userAddress.AddressId = Convert.ToInt32(dr["AddressId"] != DBNull.Value ? dr["AddressId"] : 0);
                        userAddress.Name = Convert.ToString(dr["Name"] != DBNull.Value ? dr["Name"] : "");
                        userAddress.AddressLine1 = Convert.ToString(dr["AddressLine1"] != DBNull.Value ? dr["AddressLine1"] : "");
                        userAddress.AddressLine2 = Convert.ToString(dr["AddressLine2"] != DBNull.Value ? dr["AddressLine2"] : "");
                        userAddress.landmark = Convert.ToString(dr["LandMark"] != DBNull.Value ? dr["LandMark"] : "");
                        userAddress.city = Convert.ToString(dr["City"] != DBNull.Value ? dr["City"] : "");
                        userAddress.state = Convert.ToString(dr["State"] != DBNull.Value ? dr["State"] : "");
                        userAddress.country = Convert.ToString(dr["Country"] != DBNull.Value ? dr["Country"] : "");
                        userAddress.pinCode = Convert.ToString(dr["PinCode"] != DBNull.Value ? dr["PinCode"] : "");
                        userAddress.MobileNo = Convert.ToString(dr["MobileNo"] != DBNull.Value ? dr["MobileNo"] : "");
                        address.Add(userAddress);
                    }
                    userObj.userAddress = address;

                    userObj.userRentHistory = datasetInformation.Tables[5];
                }
                return userObj;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetUserProfile", ex);
                return userObj;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public int SaveUserAddress(string userXML, int userId, int addressId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveUserAddress");
            try
            {
                database.AddInParameter(command, "@UserXML", DbType.Xml, userXML);
                database.AddInParameter(command, "@UserId", DbType.Int32, userId);
                database.AddInParameter(command, "@AddressId", DbType.Int32, addressId);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in SaveUserAddress", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public int DeleteAddress(Int32 UserId, Int32 AddressId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_DeleteUserAddress");
            try
            {
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.AddInParameter(command, "@AddressId", DbType.Int32, AddressId);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in DeleteAddress", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public int UpdatePassword(Int32 UserId, string password)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_ChangePassword");
            try
            {
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.AddInParameter(command, "@Password", DbType.String, password);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in UpdateAddress", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public bool ComparePassword(Int32 UserId, string oldPassword)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_ComparePassword");
            try
            {
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.AddInParameter(command, "@Password", DbType.String, oldPassword);
                database.AddOutParameter(command, "@IsSame", DbType.Boolean, 1);
                database.ExecuteNonQuery(command);
                return Convert.ToBoolean(command.Parameters["@IsSame"].Value);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in CheckAddress", ex);
                return false;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public int DeleteUserDocument(Int32 UserId, Int32 DocumentId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_DeleteUserDocument");
            try
            {
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.AddInParameter(command, "@DocumentId", DbType.Int32, DocumentId);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in DeleteUserDocument", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public DataTable GetRentHistoryDetails(Int32 userId, Int32 InvoiceId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetRentHistoryDetails");
            try
            {
                database.AddInParameter(command, "@userId", DbType.Int32, userId);
                database.AddInParameter(command, "@invoiceId", DbType.Int32, InvoiceId);
                datasetInformation = database.ExecuteDataSet(command);
                if (datasetInformation != null && datasetInformation.Tables.Count > 0)
                {
                    return datasetInformation.Tables[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetRentHistoryDetails", ex);
                return null;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public List<string> GetCitiesByState(string state)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetCitiesByState");
            var cities = new List<string>();
            try
            {
                database.AddInParameter(command, "@StateName", DbType.String, state);
                datasetInformation = database.ExecuteDataSet(command);
                if (datasetInformation != null && datasetInformation.Tables.Count > 0 && datasetInformation.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in datasetInformation.Tables[0].Rows)
                    {
                        cities.Add(Convert.ToString(dr["Name"]));
                    }
                }
                return cities;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetCitiesByState", ex);
                return cities;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public List<string> GetStates()
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetStates");
            var cities = new List<string>();
            try
            {
                datasetInformation = database.ExecuteDataSet(command);
                if (datasetInformation != null && datasetInformation.Tables.Count > 0 && datasetInformation.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in datasetInformation.Tables[0].Rows)
                    {
                        cities.Add(Convert.ToString(dr["Name"]));
                    }
                }
                return cities;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetStates", ex);
                return cities;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public void RequestDocumentsConfirmation(Int32 UserId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_RequestDocumentsConfirmation");
            try
            {
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in RequestDocumentsConfirmation", ex);
            }
            finally
            {
                CloseCommand(command);
            }
        }
    }
}
