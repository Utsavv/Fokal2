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
    public class PaymentManager
    {
        private static readonly PaymentManager PaymentManagerInstance = new PaymentManager();

        private PaymentManager()
        {
        }

        public static PaymentManager GetInstance
        {
            get { return PaymentManagerInstance; } //end of get
        }


        //string MID = nvc["MID"].ToString(); // This is a unique merchant Id provided to merchant by Paytm at the time of merchant creation
        //string TXNID = nvc["TXNID"].ToString(); // This is an unique Paytm transaction Id that is issued by Paytm for each valid transaction request received from the merchant.
        //string ORDERID = nvc["ORDERID"].ToString(); //This is the application transaction Id that was sent by merchant to Paytm at the time of transaction request
        //string BANKTXNID = nvc["BANKTXNID"].ToString(); // The transaction Id sent by the bank (NULL or empty string if the transaction doesn't reaches to the bank)
        //string CURRENCY = nvc["CURRENCY"].ToString(); // Currency used for transaction.
        //string STATUS = nvc["STATUS"].ToString(); //This contains the transaction status and has only two values:
        //string RESPCODE = nvc["RESPCODE"]; //This is a numeric transaction response code. “01” implies successful transaction. All other codes refer to a transaction failure with each code representing a different reason for failure. Refer to sheet mentioned in end of this document.
        //string RESPMSG = nvc["RESPMSG"].ToString(); //This contains a short description of the transaction status. In case of a failed transaction the message will describe the potential reason for the failure.
        //string TXNDATE = nvc["TXNDATE"].ToString(); // Date of transaction.
        //string GATEWAYNAME = nvc["GATEWAYNAME"].ToString(); //The gateway used by Paytm (ICICI/CITI etc).
        //string BANKNAME = nvc["BANKNAME"]; //This is a numeric transaction response code. “01” implies successful transaction. All other codes refer to a transaction failure with each code representing a different reason for failure. Refer to sheet mentioned in end of this document.
        //string PAYMENTMODE = nvc["PAYMENTMODE"].ToString(); //The payment mode used for transaction.
        //decimal TXNAMOUNT = Convert.ToDecimal(nvc["TXNAMOUNT"]);

        public DataSet UpdatePaymentRequestDetails(string Status, string OrderId)
        {
            return PaymentDAO.GetInstance.UpdatePaymentRequestDetails(Status, OrderId);
        }
    }
}
