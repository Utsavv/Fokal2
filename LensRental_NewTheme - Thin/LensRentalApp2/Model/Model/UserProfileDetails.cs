using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserProfileDetails
    {
        public Int32 UserId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string secondaryemail { get; set; }
        public string gender { get; set; }
        public string dateOfBirth { get; set; }
        public string mobileNumber { get; set; }
        public string telephoneNumber { get; set; }
        public string communicationEmail { get; set; }
        public int DocumentsVerified { get; set; }        
        //public string companyaddress { get; set; }
        //public string companyphone { get; set; }
        //public string extension { get; set; }
    }
}
