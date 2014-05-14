using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public UserProfileDetails userProfileDetails { get; set; }
        public List<UserDocuments> userDocuments { get; set; }
        public CameraDetails userCameraDetails { get; set; }
        public SocialBuildUp userSocialBuildUp { get; set; }
        public List<UserAddress> userAddress { get; set; }
        public DataTable userRentHistory { get; set; }
    }
}
