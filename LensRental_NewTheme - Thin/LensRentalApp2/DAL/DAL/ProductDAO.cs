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
using Logger;

namespace DAL
{
    public class ProductDAO : BaseDAO
    {
        private static readonly ProductDAO ProductDAOInstance = new ProductDAO();

        private ProductDAO()
        {
        }

        public static ProductDAO GetInstance
        {
            get { return ProductDAOInstance; } //end of get
        }

        public List<product> GetProducts()
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetProducts");
            List<product> productList = new List<product>();
            try
            {
                datasetInformation = database.ExecuteDataSet(command);

                if (datasetInformation != null && datasetInformation.Tables.Count > 4)
                {
                    foreach (DataRow dr in datasetInformation.Tables[0].Rows)
                    {
                        product objProduct = new product();
                        objProduct.ProductId = Convert.ToInt32(dr["ProductId"]);
                        objProduct.ProductName = Convert.ToString(dr["ProductName"]);
                        objProduct.ProductPrice = Convert.ToInt32(dr["ProductPrice"] != DBNull.Value ? dr["ProductPrice"] : 0);
                        objProduct.ProductDetails = Convert.ToString(dr["ProductDetails"] != DBNull.Value ? dr["ProductDetails"] : "");
                        objProduct.HomeDeliveryCharges = Convert.ToDouble(dr["HomeDeliveryCharges"] != DBNull.Value ? dr["HomeDeliveryCharges"] : 0);
                        objProduct.PriceOffered = Convert.ToInt32(dr["PriceOffered"] != DBNull.Value ? dr["PriceOffered"] : 0);
                        objProduct.rating = Convert.ToInt32(dr["Rating"] != DBNull.Value ? dr["Rating"] : 0);
                        objProduct.FeatureId = Convert.ToInt32(dr["FeatureId"] != DBNull.Value ? dr["FeatureId"] : 0);
                        objProduct.FeatureValue = Convert.ToString(dr["FeatureValue"] != DBNull.Value ? dr["FeatureValue"] : "");
                        objProduct.SmallDescription = Convert.ToString(dr["SmallDescription"] != DBNull.Value ? dr["SmallDescription"] : "");


                        List<feature> primaryFeatures = new List<feature>();
                        foreach (DataRow featureRows in datasetInformation.Tables[2].Rows)
                        {
                            if (Convert.ToInt32(dr["ProductId"]) == Convert.ToInt32(featureRows["ProductId"]))
                            {
                                feature objFeature = new feature();
                                objFeature.featureId = Convert.ToInt32(featureRows["FeatureId"]);
                                objFeature.featureName = Convert.ToString(featureRows["FeatureName"]);
                                primaryFeatures.Add(objFeature);
                            }
                        }

                        objProduct.PrimaryFeatures = primaryFeatures;

                        List<feature> secondaryFeatures = new List<feature>();
                        foreach (DataRow featureRows in datasetInformation.Tables[3].Rows)
                        {
                            if (Convert.ToInt32(dr["ProductId"]) == Convert.ToInt32(featureRows["ProductId"]))
                            {
                                feature objFeature = new feature();
                                objFeature.featureId = Convert.ToInt32(featureRows["FeatureId"]);
                                objFeature.featureName = Convert.ToString(featureRows["FeatureName"]);
                                secondaryFeatures.Add(objFeature);
                            }
                        }

                        objProduct.SecondaryFeatures = secondaryFeatures;

                        List<Plans> productPlans = new List<Plans>();
                        foreach (DataRow planRow in datasetInformation.Tables[4].Rows)
                        {
                            if (Convert.ToInt32(dr["ProductId"]) == Convert.ToInt32(planRow["ProductId"]))
                            {
                                Plans objPlan = new Plans();
                                objPlan.priceId = Convert.ToInt32(planRow["PriceId"]);
                                objPlan.minDay = Convert.ToInt32(planRow["MinDay"]);
                                objPlan.maxDay = Convert.ToInt32(planRow["MaxDay"]);
                                objPlan.Price = Convert.ToInt32(planRow["Price"]);
                                productPlans.Add(objPlan);
                            }
                        }

                        objProduct.PriceRangePlans = productPlans;

                        List<Images> productImages = new List<Images>();
                        foreach (DataRow imageRow in datasetInformation.Tables[1].Rows)
                        {
                            if (Convert.ToInt32(dr["ProductId"]) == Convert.ToInt32(imageRow["ProductId"]))
                            {
                                Images objImage = new Images();
                                objImage.imageId = Convert.ToInt32(imageRow["ImageId"]);
                                objImage.small = Convert.ToString(imageRow["SmallImagePath"]);
                                objImage.thumbnail = Convert.ToString(imageRow["ThumbnailImagePath"]);
                                objImage.large = Convert.ToString(imageRow["LargeImagePath"]);
                                productImages.Add(objImage);

                                if (imageRow["IsDisplay"] != DBNull.Value && Convert.ToInt32(imageRow["IsDisplay"]) == 1)
                                {
                                    objProduct.DisplayImage = objImage.small;
                                }
                            }
                        }

                        objProduct.Photos = productImages;
                        productList.Add(objProduct);
                    }
                }
                return productList;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Exception in Fetching Products Data ", ex);
                return productList;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public List<FilterProductFeature> GetFilterProductData()
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetFilterProductData");
            List<FilterProductFeature> filterList = new List<FilterProductFeature>();
            try
            {
                datasetInformation = database.ExecuteDataSet(command);

                if (datasetInformation != null && datasetInformation.Tables.Count > 0)
                {
                    foreach (DataRow dr in datasetInformation.Tables[0].Rows)
                    {
                        var prevobject = filterList.Where(x => x.FilterId == Convert.ToInt32(dr["FeatureId"])).ToList();
                        if (prevobject.Count > 0)
                        {
                            foreach (FilterProductFeature item in filterList)
                            {
                                if (item.FilterId == Convert.ToInt32(dr["FeatureId"]))
                                {
                                    item.FilterValues.Add(Convert.ToString(dr["FeatureValue"]));
                                }
                            }
                        }
                        else
                        {
                            FilterProductFeature obj = new FilterProductFeature();
                            obj.FilterId = Convert.ToInt32(dr["FeatureId"]);
                            obj.FilterName = Convert.ToString(dr["FeatureName"]);
                            obj.FilterValues = new List<string>() { Convert.ToString(dr["FeatureValue"]) };
                            filterList.Add(obj);
                        }
                    }
                }
                return filterList;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetFilterProductData", ex);
                return filterList;
            }
            finally
            {
                CloseCommand(command);
            }
        }

        public DataSet GetProductPrimaryFeatures(int ProductId)
        {
            Database database = DBInstance.GetCentralServerInstance;
            DataSet datasetInformation = new DataSet();
            DbCommand command = database.GetStoredProcCommand("sp_GetProductPrimaryFeatures");
            try
            {
                database.AddInParameter(command, "@ProductId", DbType.Int32, ProductId);
                datasetInformation = database.ExecuteDataSet(command);
                return datasetInformation;
            }
            catch (Exception ex)
            {
                Logger.Utility.HandleException("Error in GetProductPrimaryFeatures", ex);
                return datasetInformation;
            }
            finally
            {
                CloseCommand(command);
            }
        }

    }
}
