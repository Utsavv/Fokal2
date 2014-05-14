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
    public class PaymentDAO : BaseDAO
    {
        private static readonly PaymentDAO PaymentDAOInstance = new PaymentDAO();

        private PaymentDAO()
        {
        }

        public static PaymentDAO GetInstance
        {
            get { return PaymentDAOInstance; } //end of get
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
                Logger.Utility.HandleException("Error in Save User Profile", ex);
                return 0;
            }
            finally
            {
                CloseCommand(command);
            }
        }



        public DataSet  UpdatePaymentRequestDetails(string Status, string OrderId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_UpdatePaymentRequestDetails");
            DataSet datasetInformation = new DataSet();
            try
            {
                database.AddInParameter(command, "@Status", DbType.String, Status);
                database.AddInParameter(command, "@OrderId", DbType.String, OrderId);
                datasetInformation = database.ExecuteDataSet(command);
                return datasetInformation;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in UpdatePaymentRequestDetails", ex);
                return datasetInformation;
            }
            finally
            {
                CloseCommand(command);
            }
        }
    }
}
