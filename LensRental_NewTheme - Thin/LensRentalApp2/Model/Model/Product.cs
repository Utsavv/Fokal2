using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDetails { get; set; }
        public int PriceOffered { get; set; }
        public int rating { get; set; }
        public List<feature> PrimaryFeatures { get; set; }
        public List<feature> SecondaryFeatures { get; set; }
        public List<Images> Photos { get; set; }
        public string DisplayImage { get; set; }
        public List<Plans> PriceRangePlans { get; set; }
        public int FeatureId { get; set; }
        public string FeatureValue { get; set; }
        public string SmallDescription { get; set; }
        public double HomeDeliveryCharges { get; set; }
    }

    public class feature
    {
        public int featureId { get; set; }
        public string featureName { get; set; }
    }

    public class Images
    {
        public int imageId { get; set; }
        public string small { get; set; }
        public string thumbnail { get; set; }
        public string large { get; set; }
    }

    public class Plans
    {
        public int priceId { get; set; }
        public int minDay { get; set; }
        public int maxDay { get; set; }
        public int Price { get; set; }
    }
}
