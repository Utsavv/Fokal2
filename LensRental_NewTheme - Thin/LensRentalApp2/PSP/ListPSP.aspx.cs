using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using BLL;
using Model;
using DAL;

public partial class ListTours : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            FolksploreDAL PerformSearch = new FolksploreDAL(ConfigurationManager.ConnectionStrings["Folksplore"].ToString());
            HtmlGenericControl table = PerformSearch.GetHTMLTableForVendorSearch("PSP");
            PanelSearchResult.Controls.Add(table);
        }
    }


    
    //[WebMethod]
    //public static List<product> GetData()
    //{
    //    List<product> _products = ProductManager.GetInstance.GetProducts();
    //    return _products;
    //}

    //[WebMethod]
    //public static List<FilterProductFeature> GetFilterData()
    //{
    //    List<FilterProductFeature> _products = ProductManager.GetInstance.GetFilterProductData();
    //    return _products;
    //}

    //[WebMethod]
    //public static string GetSelectedProductsJSON()
    //{
    //    return SessionState.SelectedProductsJSON;
    //}

    //[WebMethod]
    //public static void SetSelectedProductsJSON(string products)
    //{
    //    try
    //    {
    //        if (products.Length < 3) // Check for empty string or string containing only "["
    //        {
    //            products = string.Empty;
    //        }

    //        List<JsonSelection> _selectedProducts = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<JsonSelection>>(products);
    //        if (_selectedProducts == null)
    //            _selectedProducts = new List<JsonSelection>();
    //        foreach (JsonSelection prod in _selectedProducts)
    //        {
    //            if (prod.FromDate.Length > 10)
    //            {
    //                string year = prod.FromDate.Substring(0, 4);
    //                string month = prod.FromDate.Substring(5, 2);
    //                string date = prod.FromDate.Substring(8, 2);
    //                DateTime d = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(date));
    //                d = d.AddDays(1);
    //                //d = d.AddDays(6);
    //                prod.FromDate = d.Day + "/" + d.Month + "/" + d.Year;

    //            }
    //        }

    //        var s = new System.Web.Script.Serialization.JavaScriptSerializer();
    //        products = s.Serialize(_selectedProducts);
    //        SessionState.SelectedProductsJSON = products;
    //        SessionState.updateCart(products);
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    [WebMethod]
    public static void FireFBLogin()
    {
        FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FBAppId"];
        FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FBSecreatKey"];
        FaceBookConnect.Authorize("user_photos,email,user_location,user_birthday", "Home.aspx");
    }

    [WebMethod]
    public static void SetSelectedProductId(string products)
    {

    }



}

