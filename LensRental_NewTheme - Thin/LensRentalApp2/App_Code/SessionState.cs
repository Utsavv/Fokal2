using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ASPSnippets.FaceBookAPI;
using BLL;
using Model;


/// <summary>
/// Summary description for SessionState
/// </summary>
public static class SessionState
{
    public static string UserName
    {
        get
        {
            string username = string.Empty;
            if (HttpContext.Current.Session["UserName"] != null)
            {
                username = Convert.ToString(HttpContext.Current.Session["UserName"]);
            }
            return username;
        }
        set
        {
            HttpContext.Current.Session["UserName"] = value;
        }
    }

    public static string UserId
    {
        get
        {
            string userid = string.Empty;
            if (HttpContext.Current.Session["UserId"] != null)
            {
                userid = Convert.ToString(HttpContext.Current.Session["UserId"]);
            }
            return userid;
        }
        set
        {
            HttpContext.Current.Session["UserId"] = value;
        }
    }

    public static string RedirectPage
    {
        get
        {
            string redirectPage = string.Empty;
            if (HttpContext.Current.Session["redirectPage"] != null)
            {
                redirectPage = Convert.ToString(HttpContext.Current.Session["redirectPage"]);
            }
            return redirectPage;
        }
        set
        {
            HttpContext.Current.Session["redirectPage"] = value;
        }
    }

    public static Int32 LoginType
    {
        get
        {
            //1 - Facebook
            //2 - Twitter
            //3 - GMAIL
            //4 - App Login
            Int32 logintype = 0;
            if (HttpContext.Current.Session["LoginType"] != null)
            {
                logintype = Convert.ToInt32(HttpContext.Current.Session["LoginType"]);
            }
            return logintype;
        }
        set
        {
            HttpContext.Current.Session["LoginType"] = value;
        }
    }

    public static Int32 Id
    {
        get
        {
            Int32 Id = 0;
            if (HttpContext.Current.Session["Id"] != null)
            {
                Id = Convert.ToInt32(HttpContext.Current.Session["Id"]);
            }
            return Id;
        }
        set
        {
            HttpContext.Current.Session["Id"] = value;
        }
    }

    public static Int32 RegistrationLevel
    {
        get
        {
            //0 - Non Logged In
            //1 - Either FB or Google
            //2 - Application Login
            //3 - Application Login + Upload Doc
            Int32 logintype = 0;
            if (HttpContext.Current.Session["RegistrationLevel"] != null)
            {
                logintype = Convert.ToInt32(HttpContext.Current.Session["RegistrationLevel"]);
            }
            return logintype;
        }
        set
        {
            HttpContext.Current.Session["RegistrationLevel"] = value;
        }
    }

    public static string FBLogoutCode
    {
        get
        {
            string logoutcode = string.Empty;
            if (HttpContext.Current.Session["LogOutCode"] != null)
            {
                logoutcode = Convert.ToString(HttpContext.Current.Session["LogOutCode"]);
            }
            return logoutcode;
        }
        set
        {
            HttpContext.Current.Session["LogOutCode"] = value;
        }
    }

    public static void Logout()
    {
        SessionState.UserName = string.Empty;
        //SessionState.LoginType = 0;
        SessionState.UserId = "";
        SessionState.UserName = "";
        SessionState.Id = 0;
        SessionState.RedirectPage = string.Empty;
        SessionState.CartProducts = new CartDetails();
        SelectedProductsJSON = string.Empty;
        if (LoginType == 1)
        {
            SessionState.LoginType = 0;
            FaceBookConnect.Logout(FBLogoutCode);
            HttpContext.Current.Response.Redirect("Home.aspx");
        }
        else if (LoginType == 2)
        {
            SessionState.LoginType = 0;
            HttpContext.Current.Response.Redirect("Home.aspx");
        }
        else if (LoginType == 3)
        {
            SessionState.LoginType = 0;
            HttpContext.Current.Response.Redirect("Home.aspx");
        }
        else if (LoginType == 4)
        {
            SessionState.LoginType = 0;
            //SessionState.UserId = "";
            //SessionState.UserName = "";
            //SessionState.Id = 0;
            //SessionState.RedirectPage = string.Empty;
            //SessionState.CartProducts = new CartDetails();
            //SelectedProductsJSON = string.Empty;
            HttpContext.Current.Response.Redirect("Home.aspx");
        }
        SessionState.CartProducts = new CartDetails();
        SelectedProductsJSON = string.Empty;
    }

    public static int SaveLoginInfoInDB(FaceBookUser fbuser, string password)
    {
        return RegistrationManager.GetInstance.SaveFBUser(fbuser, password);
    }

    public static int SaveLoginInfoInDB(GmailUser gmailuser, string password)
    {
        return RegistrationManager.GetInstance.SaveGmailUser(gmailuser, password);
    }

    public static void CheckLogin(string url)
    {
    }

    public static string SelectedProductsJSON
    {
        get
        {
            string products = string.Empty;
            if (HttpContext.Current.Session["SelectedProductsJSON"] != null)
            {
                products = Convert.ToString(HttpContext.Current.Session["SelectedProductsJSON"]);
            }
            return products;
        }
        set
        {
            HttpContext.Current.Session["SelectedProductsJSON"] = value;
        }
    }

    public static CartDetails CartProducts
    {
        get
        {
            CartDetails cartProducts = new CartDetails();
            if (HttpContext.Current.Session["SelectionProductList"] != null)
            {
                cartProducts = HttpContext.Current.Session["SelectionProductList"] as CartDetails;
            }
            return cartProducts;
        }
        set
        {
            HttpContext.Current.Session["SelectionProductList"] = value;
        }
    }

    public static void updateCart(string selectedProducts)
    {
        try
        {
            CartDetails cart = new CartDetails();
            List<JsonSelection> _selectedProducts = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<JsonSelection>>(selectedProducts);
            List<product> _products = ProductManager.GetInstance.GetProducts();
            List<selectedProduct> selectionList = new List<selectedProduct>();
            List<DateTime> shippingDates = new List<DateTime>();
            Int32 grandTotal = 0;
            double shippingCharges = 0;
            Int32 totalProductPrice = 0;
            foreach (JsonSelection selection in _selectedProducts)
            {
                selectedProduct selProduct = new selectedProduct();
                foreach (product prod in _products)
                {
                    if (prod.ProductId == selection.ProductId)
                    {
                        selProduct.productId = prod.ProductId;
                        selProduct.Qty = selection.Qty;
                        selProduct.ProductName = prod.ProductName;
                        selProduct.ProductDetails = prod.ProductDetails;
                        selProduct.FromDate = Convert.ToDateTime(selection.FromDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        selProduct.ToDate = Convert.ToDateTime(selection.FromDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat).AddDays(selection.Qty - 1);
                        selProduct.FirstThumbImage = prod.Photos[0].thumbnail;
                        selProduct.HomeDeliveryCharges = prod.HomeDeliveryCharges;
                        selProduct.ProductPrice = prod.ProductPrice;
                        totalProductPrice += prod.ProductPrice;
                        foreach (Plans plan in prod.PriceRangePlans)
                        {
                            if (plan.minDay <= selection.Qty && plan.maxDay >= selection.Qty)
                            {
                                selProduct.Price = plan.Price;
                                grandTotal += plan.Price;
                                if (!(shippingDates.Contains(selProduct.FromDate) && shippingDates.Contains(selProduct.ToDate)))
                                {
                                    shippingCharges += Convert.ToInt32(prod.HomeDeliveryCharges);
                                    shippingDates.Add(selProduct.FromDate);
                                    shippingDates.Add(selProduct.ToDate);
                                }
                                break;
                            }
                            if (plan.minDay <= selection.Qty && plan.maxDay == 0)
                            {
                                selProduct.Price = selection.Qty * plan.Price;
                                grandTotal += selection.Qty * plan.Price;
                                if (!(shippingDates.Contains(selProduct.FromDate) && shippingDates.Contains(selProduct.ToDate)))
                                {
                                    shippingCharges += Convert.ToInt32(prod.HomeDeliveryCharges);
                                    shippingDates.Add(selProduct.FromDate);
                                    shippingDates.Add(selProduct.ToDate);
                                }
                            }
                        }
                    }
                }
                selectionList.Add(selProduct);
            }
            cart.SelectedProducts = selectionList;
            cart.ShippingCharges = Convert.ToInt32(shippingCharges);
            cart.GrandTotal = grandTotal;
            cart.TotalProductPrice = totalProductPrice;

            SessionState.CartProducts = cart;
        }
        catch (Exception ex)
        {
        }
    }

    public static void redeemCoupon()
    {
        if (SessionState.CartProducts != null && SessionState.CartProducts.CouponDetails != null && SessionState.CartProducts.CouponDetails.IsValid != false)
        {
            double discount = (SessionState.CartProducts.GrandTotal * SessionState.CartProducts.CouponDetails.DiscountPercent) / 100;
            if (SessionState.CartProducts.CouponDetails.MaxDiscount != 0)
            {
                discount = discount > SessionState.CartProducts.CouponDetails.MaxDiscount ? SessionState.CartProducts.CouponDetails.MaxDiscount : discount;
            }
            SessionState.CartProducts.TotalDiscount = discount;
        }
    }
}