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
    public class InquiryDAO : BaseDAO
    {
        private static readonly InquiryDAO InquiryDAOInstance = new InquiryDAO();

        private InquiryDAO()
        {
        }

        public static InquiryDAO GetInstance
        {
            get { return InquiryDAOInstance; } //end of get
        }

        public int InsertInquiry(string Name, string Email, string Subject, string Message)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_InsertInquiry");
            try
            {
                database.AddInParameter(command, "@Name", DbType.String, Name);
                database.AddInParameter(command, "@Email", DbType.String, Email);
                database.AddInParameter(command, "@Subject", DbType.String, Subject);
                database.AddInParameter(command, "@Message", DbType.String, Message);
                database.ExecuteNonQuery(command);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in InsertInquiry", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }
    }
}
