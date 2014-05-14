using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Base;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Model;

namespace DAL
{
    public class RegistrationDAO : BaseDAO
    {
        private static readonly RegistrationDAO RegistrationDAOInstance = new RegistrationDAO();

        private RegistrationDAO()
        {
        }

        public static RegistrationDAO GetInstance
        {
            get { return RegistrationDAOInstance; } //end of get
        }

        public Int32 SaveFBUser(string fbUserXML, string Email, string password)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveFBUser");
            try
            {
                database.AddInParameter(command, "@fbUserXML", DbType.Xml, fbUserXML);
                database.AddInParameter(command, "@UserName", DbType.String, Email);
                database.AddInParameter(command, "@Password", DbType.String, password);
                database.AddOutParameter(command, "@ReturnId", DbType.Int32, 8);
                database.ExecuteNonQuery(command);
                return Convert.ToInt32(command.Parameters["@ReturnId"].Value);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in SaveFBUser", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }




        public Int32 SaveGmailUser(string gmailUserXML, string Email, string password)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveGmailUser");
            try
            {
                database.AddInParameter(command, "@gmailUserXML", DbType.Xml, gmailUserXML);
                database.AddInParameter(command, "@UserName", DbType.String, Email);
                database.AddInParameter(command, "@Password", DbType.String, password);
                database.AddOutParameter(command, "@ReturnId", DbType.Int32, 8);
                database.ExecuteNonQuery(command);
                return Convert.ToInt32(command.Parameters["@ReturnId"].Value);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in SaveGmailUser", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }


        public Int32 RegisterUser(string firstName, string lastName, string password, string email)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_RegisterUser");
            try
            {
                database.AddInParameter(command, "@firstName", DbType.String, firstName);
                database.AddInParameter(command, "@lastName", DbType.String, lastName);
                database.AddInParameter(command, "@password", DbType.String, password);
                database.AddInParameter(command, "@email", DbType.String, email);
                database.AddOutParameter(command, "@IsRegistered", DbType.Int32, 4);
                database.ExecuteNonQuery(command);
                return Convert.ToInt32(command.Parameters["@IsRegistered"].Value);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in RegisterUser", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public DataSet CheckLogin(string userName, string password)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_CheckLogin");
            try
            {
                database.AddInParameter(command, "@userName", DbType.String, userName);
                database.AddInParameter(command, "@password", DbType.String, password);
                datasetInformation = database.ExecuteDataSet(command);
                return datasetInformation;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in CheckLogin", ex);
                return datasetInformation;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public bool CheckPassword(string userName)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_CheckPassword");
            try
            {
                database.AddInParameter(command, "@userName", DbType.String, userName);
                database.AddOutParameter(command, "@IsPasswordAvailable", DbType.Boolean, 2);
                database.ExecuteNonQuery(command);
                return Convert.ToBoolean(command.Parameters["@IsPasswordAvailable"].Value);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in CheckPassword", ex);
                return false;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public string GetPassword(string userName)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_GetPassword");
            try
            {
                database.AddInParameter(command, "@UserName", DbType.String, userName);
                database.AddOutParameter(command, "@Password", DbType.String, 100);
                database.ExecuteNonQuery(command);
                return Convert.ToString(command.Parameters["@Password"].Value);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetPassword", ex);
                return "";
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public void SaveActivationCode(int userId, Guid ActivationCode)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_SaveActivationCode");
            try
            {
                database.AddInParameter(command, "@UserId", DbType.Int32, userId);
                database.AddInParameter(command, "@ActivationCode", DbType.Guid, ActivationCode);
                database.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in Saving Activation Code", ex);
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public DataSet GetUserDetailsFromActivationCode(Guid ActivationCode)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetUserDetailsFromActivationCode");
            try
            {
                database.AddInParameter(command, "@ActivationCode", DbType.Guid, ActivationCode);

                datasetInformation = database.ExecuteDataSet(command);
                return datasetInformation;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetUserDetailsFromActivationCode", ex);
                return datasetInformation;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public void ActivateUser(Guid ActivationCode)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_ActivateUser");
            try
            {
                database.AddInParameter(command, "@ActivationCode", DbType.Guid, ActivationCode);
                database.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in Activating User", ex);
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public string GetUserName(string userName)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_GetUserName");
            try
            {
                database.AddInParameter(command, "@Password", DbType.String, userName);
                database.AddOutParameter(command, "@UserName", DbType.String, 100);
                database.ExecuteNonQuery(command);
                return Convert.ToString(command.Parameters["@UserName"].Value);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetUserName", ex);
                return "";
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public int GetUserId(string userName)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_GetUserId");
            try
            {
                database.AddInParameter(command, "@UserName", DbType.String, userName);
                database.AddOutParameter(command, "@UserId", DbType.Int32, 4);
                database.ExecuteNonQuery(command);
                return Convert.ToInt32(command.Parameters["@UserId"].Value != DBNull.Value ? command.Parameters["@UserId"].Value : 0);
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetUserName", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }
    }
}
