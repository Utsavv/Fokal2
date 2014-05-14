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
    public class UserProfileManager
    {
        private static readonly UserProfileManager UserProfileManagerInstance = new UserProfileManager();

        private UserProfileManager()
        {
        }

        public static UserProfileManager GetInstance
        {
            get { return UserProfileManagerInstance; } //end of get
        }

        public Int32 SaveUserSocialBuildUp(SocialBuildUp UserSocialBuildUp)
        {
            return UserProfileDAO.GetInstance.SaveUserSocialBuildUp(Utility.Serialize(UserSocialBuildUp), UserSocialBuildUp.userId);
        }

        public Int32 SaveUserCameraDetails(CameraDetails UserCameraDetails)
        {
            return UserProfileDAO.GetInstance.SaveUserCameraDetails(Utility.Serialize(UserCameraDetails), UserCameraDetails.userId);
        }

        public Int32 SaveUserDocumentDetails(UserDocuments userDocuments)
        {
            return UserProfileDAO.GetInstance.SaveUserDocumentDetails(Utility.Serialize(userDocuments), userDocuments.UserId);
        }

        public Int32 SaveUserProfile(UserProfileDetails user)
        {
            return UserProfileDAO.GetInstance.SaveUserProfile(Utility.Serialize(user), user.UserId);
        }

        public User GetUserProfile(Int32 userId)
        {
            return UserProfileDAO.GetInstance.GetUserProfile(userId);
        }

        public int SaveUserAddress(UserAddress address)
        {
            return UserProfileDAO.GetInstance.SaveUserAddress(Utility.Serialize(address), address.UserId, address.AddressId);
        }

        public int DeleteAddress(Int32 UserId, Int32 AddressId)
        {
            return UserProfileDAO.GetInstance.DeleteAddress(UserId, AddressId);
        }

        public int UpdatePassword(Int32 UserId, string password)
        {
            return UserProfileDAO.GetInstance.UpdatePassword(UserId, password);
        }

        public bool ComparePassword(Int32 UserId, string oldPassword)
        {
            return UserProfileDAO.GetInstance.ComparePassword(UserId, oldPassword);
        }

        public int DeleteUserDocument(Int32 UserId, Int32 DocumentId)
        {
            return UserProfileDAO.GetInstance.DeleteUserDocument(UserId, DocumentId);
        }

        public DataTable GetRentHistoryDetails(Int32 UserId, Int32 InvoiceId)
        {
            return UserProfileDAO.GetInstance.GetRentHistoryDetails(UserId, InvoiceId);
        }

        public List<string> GetCitiesByState(string state)
        {
            return UserProfileDAO.GetInstance.GetCitiesByState(state);
        }

        public List<string> GetStates()
        {
            return UserProfileDAO.GetInstance.GetStates();
        }

        public void RequestDocumentsConfirmation(Int32 UserId)
        {
            UserProfileDAO.GetInstance.RequestDocumentsConfirmation(UserId);
        }
    }
}
