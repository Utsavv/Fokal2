using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CheckOutManager
    {
        private static readonly CheckOutManager CheckOutManagerInstance = new CheckOutManager();

        private CheckOutManager()
        {
        }

        public static CheckOutManager GetInstance
        {
            get { return CheckOutManagerInstance; } //end of get
        }

        public CouponDetails GetCouponDetails(string CouponCode)
        {
            return CheckOutDAO.GetInstance.GetCouponDetails(CouponCode);
        }

        public string MakePurchaseOrder(CartDetails cart, Int32 UserId, string PhoneNo, string OrderID, string CustomerID)
        {
            return CheckOutDAO.GetInstance.MakePurchaseOrder(cart, UserId, PhoneNo, OrderID, CustomerID);
        }

        public string CheckCartAvailability(CartDetails cart)
        {
            return CheckOutDAO.GetInstance.CheckCartAvailability(cart);
        }

        public bool CheckDocumentsStatus(Int32 UserId)
        {
            return CheckOutDAO.GetInstance.CheckDocumentsStatus(UserId);
        }
    }
}
