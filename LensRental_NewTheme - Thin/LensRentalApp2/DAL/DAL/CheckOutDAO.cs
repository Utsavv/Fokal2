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
    public class CheckOutDAO : BaseDAO
    {
        private static readonly CheckOutDAO CheckOutDAOInstance = new CheckOutDAO();

        private CheckOutDAO()
        {
        }

        public static CheckOutDAO GetInstance
        {
            get { return CheckOutDAOInstance; } //end of get
        }

        public CouponDetails GetCouponDetails(string CouponCode)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetCouponDetails");
            CouponDetails couponDetails = new CouponDetails();
            try
            {
                database.AddInParameter(command, "@couponCode", DbType.String, CouponCode);
                datasetInformation = database.ExecuteDataSet(command);

                if (datasetInformation != null && datasetInformation.Tables.Count > 0 && datasetInformation.Tables[0].Rows.Count > 0)
                {
                    couponDetails.CouponId = Convert.ToInt32(datasetInformation.Tables[0].Rows[0]["Id"]);
                    couponDetails.CouponCode = Convert.ToString(datasetInformation.Tables[0].Rows[0]["CouponCode"]);
                    couponDetails.DiscountPercent = Convert.ToInt32(datasetInformation.Tables[0].Rows[0]["DiscountPercent"]);
                    couponDetails.IsValid = Convert.ToBoolean(datasetInformation.Tables[0].Rows[0]["IsValid"]);
                    couponDetails.MaxDiscount = Convert.ToDouble(datasetInformation.Tables[0].Rows[0]["MaxDiscount"]);
                    couponDetails.ValidTillDate = Convert.ToDateTime(datasetInformation.Tables[0].Rows[0]["ValidToDate"]);
                    couponDetails.ValidFromDate = Convert.ToDateTime(datasetInformation.Tables[0].Rows[0]["ValidFromDate"]);
                    couponDetails.Comments = Convert.ToString(datasetInformation.Tables[0].Rows[0]["Comments"]);
                }
                return couponDetails;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetCouponDetails", ex);
                return couponDetails;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public string MakePurchaseOrder(CartDetails cart, Int32 UserId, string PhoneNo, string OrderID, string CustomerID)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_MakePurchaseOrder");
            try
            {
                database.AddInParameter(command, "@addressXML", DbType.Xml, Utility.Serialize(cart.ShippingAddress));
                database.AddInParameter(command, "@PhoneNo", DbType.String, PhoneNo);
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.AddInParameter(command, "@CouponId", DbType.Int32, cart.CouponDetails == null ? 0 : cart.CouponDetails.CouponId);
                database.AddInParameter(command, "@TotalAmount", DbType.Double, cart.GrandTotal);
                database.AddInParameter(command, "@TotalDiscount", DbType.Double, cart.TotalDiscount);
                database.AddInParameter(command, "@ShippingCharges", DbType.Double, cart.ShippingCharges);
                database.AddInParameter(command, "@BillingAmount", DbType.Double, (cart.GrandTotal + cart.ShippingCharges - cart.TotalDiscount));
                database.AddInParameter(command, "@ProductsCount", DbType.Int32, cart.SelectedProducts.Count);
                database.AddInParameter(command, "@OrderID", DbType.String, OrderID);
                database.AddInParameter(command, "@TempCustomerID", DbType.String, CustomerID);
                database.AddOutParameter(command, "@InvoiceId", DbType.Int32, 8);
                database.AddOutParameter(command, "@CustomerId", DbType.String, 10);
                database.ExecuteNonQuery(command);
                Int32 invoiceId = Convert.ToInt32(command.Parameters["@InvoiceId"].Value);
                string custID = Convert.ToString(command.Parameters["@CustomerId"].Value);
                foreach (selectedProduct product in cart.SelectedProducts)
                {
                    command = database.GetStoredProcCommand("sp_InsertInvoiceDetails");
                    database.AddInParameter(command, "@ProductId", DbType.Int32, product.productId);
                    database.AddInParameter(command, "@FromDate", DbType.DateTime, product.FromDate);
                    database.AddInParameter(command, "@ToDate", DbType.DateTime, product.ToDate);
                    database.AddInParameter(command, "@Qty", DbType.Int32, product.Qty);
                    database.AddInParameter(command, "@Price", DbType.Double, product.Price);
                    database.AddInParameter(command, "@InvoiceId", DbType.Int64, invoiceId);

                    database.ExecuteNonQuery(command);
                }
                return custID;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in MakePurchaseOrder", ex);
                return string.Empty;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public string CheckCartAvailability(CartDetails cart)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_CheckCartAvailability");
            string ErrorMessage = string.Empty;
            try
            {
                foreach (selectedProduct product in cart.SelectedProducts)
                {
                    command = database.GetStoredProcCommand("sp_CheckCartAvailability");
                    database.AddInParameter(command, "@ProductId", DbType.Int32, product.productId);
                    database.AddInParameter(command, "@FromDate", DbType.DateTime, product.FromDate);
                    database.AddInParameter(command, "@ToDate", DbType.DateTime, product.ToDate);
                    database.AddOutParameter(command, "@ProdCount", DbType.Int32, 8);
                    database.ExecuteNonQuery(command);
                    if (Convert.ToInt32(command.Parameters["@ProdCount"].Value) <= 0)
                    {
                        ErrorMessage += ErrorMessage == string.Empty ? product.ProductName : ", " + product.ProductName;
                    }
                }
                return ErrorMessage;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in CheckCartAvailability", ex);
                return string.Empty;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public bool CheckDocumentsStatus(Int32 UserId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DbCommand command = database.GetStoredProcCommand("sp_CheckDocumentsStatus");
            string ErrorMessage = string.Empty;
            try
            {
                command = database.GetStoredProcCommand("sp_CheckDocumentsStatus");
                database.AddInParameter(command, "@UserId", DbType.Int32, UserId);
                database.AddOutParameter(command, "@DocumentsCount", DbType.Int32, 8);
                database.ExecuteNonQuery(command);
                if (Convert.ToInt32(command.Parameters["@DocumentsCount"].Value) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in CheckDocumentsStatus", ex);
                return false;
            }
            finally
            {
                CloseCommand(command);
            }
        }
    }
}
