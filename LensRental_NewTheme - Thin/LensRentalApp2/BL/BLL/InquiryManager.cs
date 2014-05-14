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
    public class InquiryManager
    {
        private static readonly InquiryManager InquiryManagerInstance = new InquiryManager();

        private InquiryManager()
        {
        }

        public static InquiryManager GetInstance
        {
            get { return InquiryManagerInstance; } //end of get
        }

        public Int32 InsertInquiry(string Name, string Email, string Subject, string Message)
        {
            return InquiryDAO.GetInstance.InsertInquiry(Name, Email, Subject, Message);
        }
    }
}
