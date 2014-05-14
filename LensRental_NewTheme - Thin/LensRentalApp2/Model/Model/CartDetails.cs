using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CartDetails
    {
        public List<selectedProduct> SelectedProducts { get; set; }

        public UserAddress ShippingAddress { get; set; }

        public CouponDetails CouponDetails { get; set; }

        public double GrandTotal { get; set; }

        public double TotalDiscount { get; set; }

        public Int32 TotalProductPrice { get; set; }

        public Int32 ShippingCharges { get; set; }

        public string PhoneNo { get; set; }

        public Int32 UserId { get; set; }

    }

    public class selectedProduct
    {
        public Int32 productId { get; set; }
        public Int32 Qty { get; set; }
        public Int32 Price { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string FirstThumbImage { get; set; }
        public double HomeDeliveryCharges { get; set; }
        public Int32 ProductPrice { get; set; } 
    }

    public class JsonSelection
    {
        public Int32 ProductId { get; set; }
        public Int32 Qty { get; set; }
        //public DateTime FromDate { get; set; }
        public string FromDate { get; set; }
    }


}
