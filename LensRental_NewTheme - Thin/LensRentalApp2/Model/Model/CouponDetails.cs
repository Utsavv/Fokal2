using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CouponDetails
    {
        public Int32 CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountPercent { get; set; }
        public DateTime ValidTillDate { get; set; }
        public DateTime ValidFromDate { get; set; }
        public bool IsValid { get; set; }
        public double MaxDiscount { get; set; }
        public string Comments { get; set; }
    }
}
