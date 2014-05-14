using paytm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;


/// <summary>
/// Summary description for PaytmIntegration
/// </summary>
public class SendRequest
{
    private string conString = ConfigurationManager.ConnectionStrings["CentalDbConnectionString"].ToString();
    public string HFMID = "VMhQzN91717517445033";//test env data VMhQzN91717517445033
    public string HFCHANNELID = "WEB";
    public string HFINDUSTRYTYPEID = "Retail";
    public string HFWEBSITE = "drizzlingholidays";
    public string Method = "post";
    private byte[] key = new byte[0];
    private byte[] IV = new byte[8]
    {
      (byte) 18,
      (byte) 52,
      (byte) 86,
      (byte) 120,
      (byte) 144,
      (byte) 171,
      (byte) 205,
      (byte) 239
    };
    private SqlConnection connToDb;
    private SqlCommand command;
    private SqlDataAdapter sda;

    public string GenarateCheckSum(string orderId, string CustomerId, double txnAmount)
    {
        return CheckSum.generateCheckSum("QooMtG019fX9pI6U", new Dictionary<string, string>()
      {
        {
          "MID",
          "drizzl55597593897853"
        },
        {
          "ORDER_ID",
          orderId
        },
        {
          "CUST_ID",
          CustomerId
        },
        {
          "TXN_AMOUNT",
          string.Concat((object) txnAmount)
        },
        {
          "INDUSTRY_TYPE_ID",
          "Retail"
        },
        {
          "CHANNEL_ID",
          "WEB"
        },
        {
          "WEBSITE",
          "drizzlingholidays"
        }
      });
    }

    public bool verifychecksum(string checkSum, string orderId, string CustomerId, double TxnAmount)
    {
        return CheckSum.verifyCheckSum("QooMtG019fX9pI6U", new Dictionary<string, string>()
      {
        {
          "MID",
          "drizzl55597593897853"
        },
        {
          "ORDER_ID",
          orderId
        },
        {
          "CUST_ID",
          CustomerId
        },
        {
          "TXN_AMOUNT",
          string.Concat((object) TxnAmount)
        },
        {
          "INDUSTRY_TYPE_ID",
          "Retail"
        },
        {
          "CHANNEL_ID",
          "WEB"
        },
        {
          "WEBSITE",
          "drizzlingholidays"
        }
      }, checkSum);
    }

    public int SendDetails(double TxnAmount)
    {
        int num = 0;
        string randomCustomerId = this.CreateRandomCustomerId(10);
        string str1 = this.GenrateOrderId(10);
        string str2 = this.GenarateCheckSum(str1, randomCustomerId, TxnAmount);
        if (this.verifychecksum(str2, str1, randomCustomerId, TxnAmount))
            num = this.paymentRequestsEntry(str1, randomCustomerId, TxnAmount, str2);
        return num;
    }

    public string CreateRandomCustomerId(int PasswordLength)
    {
        this.connToDb = new SqlConnection(this.conString);
        this.connToDb.Open();
        string str1 = "0123456789abc";
        Random random = new Random();
        char[] chArray = new char[PasswordLength];
        int length = str1.Length;
        for (int index = 0; index < PasswordLength; ++index)
            chArray[index] = str1[(int)((double)str1.Length * random.NextDouble())];
        DataTable dataTable = new DataTable();
        string str2 = "select * from  tblpaymentRequestsDetails where CUSTID='" + (object)chArray + "'";
        SqlCommand sqlCommand = new SqlCommand(str2, this.connToDb);
        this.sda = new SqlDataAdapter(str2, this.connToDb);
        this.sda.Fill(dataTable);
        if (dataTable.Rows.Count != 0)
            this.CreateRandomCustomerId(10);
        this.connToDb.Close();
        return new string(chArray);
    }

    public string GenrateOrderId(int PasswordLength)
    {
        this.connToDb = new SqlConnection(this.conString);
        this.connToDb.Open();
        string str1 = "0123456789";
        Random random = new Random();
        char[] chArray = new char[PasswordLength];
        int length = str1.Length;
        for (int index = 0; index < PasswordLength; ++index)
            chArray[index] = str1[(int)((double)str1.Length * random.NextDouble())];
        DataTable dataTable = new DataTable();
        string str2 = "select * from tblpaymentRequestsDetails where ORDERID='" + (object)chArray + "'";
        SqlCommand sqlCommand = new SqlCommand(str2, this.connToDb);
        this.sda = new SqlDataAdapter(str2, this.connToDb);
        this.sda.Fill(dataTable);
        if (dataTable.Rows.Count != 0)
            this.GenrateOrderId(10);
        this.connToDb.Close();
        return new string(chArray);
    }

    public int paymentDetailsEntry(string TXNId, string BANKTXNID, string ORDERID, Decimal TXNAMOUNT, string STATUS, string TXNTYPE, string GATEWAYNAME, string RESPCODE, string RESPMSG, string BANKNAME, string MID, string PAYMENTMODE, double REFUNDAMT)
    {
        this.connToDb = new SqlConnection(this.conString);
        this.connToDb.Open();
        this.command = new SqlCommand("sp_paymentDetailsEntry", this.connToDb);
        this.command.CommandType = CommandType.StoredProcedure;
        this.command.Parameters.Add("@TXNId", SqlDbType.VarChar).Value = (object)TXNId;
        this.command.Parameters.Add("@BANKTXNID", SqlDbType.VarChar).Value = (object)BANKTXNID;
        this.command.Parameters.Add("@ORDERID", SqlDbType.VarChar).Value = (object)ORDERID;
        this.command.Parameters.Add("@TXNAMOUNT", SqlDbType.Decimal).Value = (object)TXNAMOUNT;
        this.command.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = (object)STATUS;
        this.command.Parameters.Add("@TXNTYPE", SqlDbType.VarChar).Value = (object)TXNTYPE;
        this.command.Parameters.Add("@GATEWAYNAME", SqlDbType.VarChar).Value = (object)GATEWAYNAME;
        this.command.Parameters.Add("@RESPCODE", SqlDbType.VarChar).Value = (object)RESPCODE;
        this.command.Parameters.Add("@RESPMSG", SqlDbType.VarChar).Value = (object)RESPMSG;
        this.command.Parameters.Add("@BANKNAME", SqlDbType.VarChar).Value = (object)BANKNAME;
        this.command.Parameters.Add("@MID", SqlDbType.VarChar).Value = (object)MID;
        this.command.Parameters.Add("@PAYMENTMODE", SqlDbType.VarChar).Value = (object)PAYMENTMODE;
        this.command.Parameters.Add("@REFUNDAMT", SqlDbType.VarChar).Value = (object)REFUNDAMT;
        int num = this.command.ExecuteNonQuery();
        this.connToDb.Close();
        return num;
    }

    public int paymentRequestsEntry(string ORDERID, string CUSTID, double TXNAMOUNT, string CHECKSUMHASH)
    {
        this.connToDb = new SqlConnection(this.conString);
        this.connToDb.Open();
        string str1 = "drizzl55597593897853";//VMhQzN91717517445033
        string str2 = "WEB";
        string str3 = "Retail";
        string str4 = "drizzlingholidays";
        this.command = new SqlCommand("sp_paymentRequestsDetailsEntry", this.connToDb);
        this.command.CommandType = CommandType.StoredProcedure;
        this.command.Parameters.Add("@MID", SqlDbType.VarChar).Value = (object)str1;
        this.command.Parameters.Add("@ORDERID", SqlDbType.VarChar).Value = (object)ORDERID;
        this.command.Parameters.Add("@CUSTID", SqlDbType.VarChar).Value = (object)CUSTID;
        this.command.Parameters.Add("@TXNAMOUNT", SqlDbType.VarChar).Value = (object)TXNAMOUNT;
        this.command.Parameters.Add("@CHANNELID", SqlDbType.VarChar).Value = (object)str2;
        this.command.Parameters.Add("@INDUSTRYTYPEID", SqlDbType.VarChar).Value = (object)str3;
        this.command.Parameters.Add("@WEBSITE", SqlDbType.VarChar).Value = (object)str4;
        this.command.Parameters.Add("@CHECKSUMHASH", SqlDbType.VarChar).Value = (object)CHECKSUMHASH;
        int num = this.command.ExecuteNonQuery();
        this.connToDb.Close();
        return num;
    }

    public string PostUrl()
    {
        return "https://secure.paytm.in/oltp-web/processTransaction";
    }

    public string PostData(string OrderId, string CustomerId, double txnAmount)
    {
        string str1 = "";
        string str2 = "<input type=\"hidden\" id=\"MID\" name=\"MID\" runat=\"server\" value=\"drizzl55597593897853\"/>";
        string CHECKSUMHASH = this.GenarateCheckSum(OrderId, CustomerId, txnAmount);
        string str3 = string.Concat(new object[4]
      {
        (object) (str2 + "<input type=\"hidden\" id=\"ORDER_ID\" runat=\"server\"   name=\"ORDER_ID\"  value=\"" + OrderId + "\"/>" + "<input type=\"hidden\" id=\"CUST_ID\" runat=\"server\"  name=\"CUST_ID\"  value=\"" + CustomerId + "\"/>"),
        (object) "<input type=\"hidden\" id=\"TXN_AMOUNT\" runat=\"server\"   name=\"TXN_AMOUNT\"  value=\"",
        (object) txnAmount,
        (object) "\"/>"
      }) + "<input type=\"hidden\" id=\"CHANNEL_ID\"  runat=\"server\"  name=\"CHANNEL_ID\"  value=\"WEB\" />" + "<input type=\"hidden\" id=\"INDUSTRY_TYPE_ID\" runat=\"server\"   name=\"INDUSTRY_TYPE_ID\"  value=\"Retail\" />" + "<input type=\"hidden\" id=\"WEBSITE\"  name=\"WEBSITE\" runat=\"server\"   value=\"drizzlingholidays\"/>" + "<input type=\"hidden\" id=\"CHECKSUMHASH\"  name=\"CHECKSUMHASH\" runat=\"server\"    value=\"" + CHECKSUMHASH + "\"/>";
        if (this.paymentRequestsEntry(OrderId, CustomerId, txnAmount, CHECKSUMHASH) > 0)
            str1 = ((object)str3).ToString();
        return str1;
    }

    public string Decrypt(string stringToDecrypt, string sEncryptionKey)
    {
        byte[] numArray = new byte[stringToDecrypt.Length + 1];
        try
        {
            this.key = Encoding.UTF8.GetBytes(sEncryptionKey);
            DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] buffer = Convert.FromBase64String(stringToDecrypt);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, cryptoServiceProvider.CreateDecryptor(this.key, this.IV), CryptoStreamMode.Write);
            cryptoStream.Write(buffer, 0, buffer.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string Encrypt(string stringToEncrypt, string SEncryptionKey)
    {
        try
        {
            this.key = Encoding.UTF8.GetBytes(SEncryptionKey);
            DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, cryptoServiceProvider.CreateEncryptor(this.key, this.IV), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            return Convert.ToBase64String(memoryStream.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}