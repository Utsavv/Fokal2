using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class RegistrationManager
    {
        private static readonly RegistrationManager RegistrationManagerInstance = new RegistrationManager();

        private RegistrationManager()
        {
        }

        public static RegistrationManager GetInstance
        {
            get { return RegistrationManagerInstance; } //end of get
        }

        public Int32 SaveFBUser(FaceBookUser fbUser, string password)
        {
            return RegistrationDAO.GetInstance.SaveFBUser(Utility.Serialize(fbUser), fbUser.Email, password);
        }

        public Int32 SaveGmailUser(GmailUser gmailuser, string password)
        {
            return RegistrationDAO.GetInstance.SaveGmailUser(Utility.Serialize(gmailuser), gmailuser.Email, password);
        }

        public Int32 RegisterUser(string firstName, string lastName, string password, string email)
        {
            return RegistrationDAO.GetInstance.RegisterUser(firstName, lastName, password, email);
        }

        public DataSet CheckLogin(string userName, string password)
        {
            return RegistrationDAO.GetInstance.CheckLogin(userName, password);
        }

        public DataSet GetUserDetailsFromActivationCode(Guid activationcode)
        {
            return RegistrationDAO.GetInstance.GetUserDetailsFromActivationCode(activationcode);
        }


        public bool CheckPassword(string userName)
        {
            return RegistrationDAO.GetInstance.CheckPassword(userName);
        }

        public string GetPassword(string userName)
        {
            return RegistrationDAO.GetInstance.GetPassword(userName);
        }

        public void SaveActivationCode(int UserId, Guid ActivationCode)
        {
            RegistrationDAO.GetInstance.SaveActivationCode(UserId, ActivationCode);
        }

        public void ActivateUser(Guid ActivationCode)
        {
            RegistrationDAO.GetInstance.ActivateUser(ActivationCode);
        }

        public string GetUserName(string password)
        {
            return RegistrationDAO.GetInstance.GetUserName(password);
        }

        public int GetUserId(string userName)
        {
            return RegistrationDAO.GetInstance.GetUserId(userName);
        }
    }
}
