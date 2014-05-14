function formatCurrency(value) {
    try {
        return value.toFixed(2);
    }
    catch (err) {
        return value() + ".00";
    }
}

function formatHomeDelivery(value) {
    try {
        if (parseInt(value) <= 0) {
            return "Free Shipping & PickUp ";
        }
        else {
            return "Shipping & PickUp Charges (with each order) - ";
        }
    }
    catch (err) {
        if (parseInt(value()) <= 0) {
            return "Free Shipping & PickUp ";
        }
        else {
            return "Shipping & PickUp Charges (with each order) - ";
        }
    }
}

function formatForCart(value) {
    try {
        if (parseInt(value) <= 0) {
            return "0";
        }
        else {
            return value;
        }
    }
    catch (err) {
        if (parseInt(value()) <= 0) {
            return "0";
        }
        else {
            return value();
        }
    }
}

function formatQty(value, qty) {
    return qty + " x " + formatCurrency(value);
}

function formatSavings(value) {
    return "You can save " + formatCurrency(value()) + "on this product";
}

function createFilterCheckBoxValue(filterId, filterValue) {
    return filterId() + "-" + filterValue;
}

function TotalPrice(value, qty) {
    return qty() * value;
}


ko.bindingHandlers.minDate = {
    update: function (element, valueAccessor) {
        alert("minDate");
        var value = ko.utils.unwrapObservable(valueAccessor()),
        current = $(element).datepicker("option", "minDate", value);
    }
}

ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize datepicker with some optional options
        var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($(element).datepicker("getDate"));
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).datepicker("destroy");
        });

    },
    update: function (element, valueAccessor) {

        var value = ko.utils.unwrapObservable(valueAccessor()),
            current = $(element).datepicker("getDate");

        if (value - current !== 0) {
            $(element).datepicker("setDate", value);
        }
    }
};


var filterItem = function (featureId, featureName, featureValues) {
    var self = this;
    self.FeatureId = ko.observable(featureId);
    self.FeatureName = ko.observable(featureName);
    self.FeatureValue = ko.observableArray(featureValues);
}
// This is our product Mode
var product = function (photos, secondaryfeatures, primaryfeatures, name, price, details, id, offerprice, isAdded, rating, displayImage, qty, pricerangeplans, fromDate, featureId, featureValue, smallDescription, homeDeliveryCharges) {
    var self = this;
    self.Photos = ko.observableArray(photos);
    //self.FromDate = ko.observable(new Date());
    self.FromDate = ko.observable(fromDate);
    self.DisplayImage = ko.observable(displayImage);
    self.ProductName = ko.observable(name);
    self.ProductPrice = ko.observable(price);
    self.ProductDetails = ko.observable(details);
    self.ProductId = ko.observable(id);
    self.isAdded = ko.observable(isAdded);
    self.rating = ko.observable(rating);
    self.PriceOffered = ko.observable(offerprice);
    self.Qty = ko.observable(qty).extend({ numeric: 0 });;
    self.PrimaryFeatures = ko.observableArray(primaryfeatures);
    self.SecondaryFeatures = ko.observableArray(secondaryfeatures);
    self.PriceRangePlans = ko.observableArray(pricerangeplans);
    self.DisplayText = ko.observable("3 Day Rental");
    self.FeatureId = ko.observable(featureId);
    self.FeatureValue = ko.observable(featureValue);
    self.SmallDescription = ko.observable(smallDescription);
    self.HomeDeliveryCharges = ko.observable(homeDeliveryCharges);

    self.Savings = ko.computed(function () {
        return self.ProductPrice() - self.PriceOffered();
    });
    self.TotalDisplayAmount = ko.computed(function () {
        var total = self.Qty() * self.PriceOffered();
        $.each(self.PriceRangePlans(), function (i, val) {
            if (self.Qty() >= val.minDay && self.Qty() <= val.maxDay) {
                total = val.Price;
            }
        });
        return total;

    });

    //self.url = ko.observable("ProductDetails.aspx?pId=" + id);
    self.url = ko.observable("ProductDetails.aspx");



    ko.extenders.numeric = function (target, precision) {
        //create a writeable computed observable to intercept writes to our observable
        var result = ko.computed({
            read: target,  //always return the original observables value
            write: function (newValue) {
                var current = target(),
                    roundingMultiplier = Math.pow(10, precision),
                    newValueAsNum = isNaN(newValue) ? 0 : parseFloat(+newValue),
                    valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

                //only write if it changed
                if (valueToWrite !== current) {
                    target(valueToWrite);
                } else {
                    //if the rounded value is the same, but a different value was written, force a notification for the current field
                    if (newValue !== current) {
                        target.notifySubscribers(valueToWrite);
                    }
                }
            }
        }).extend({ notify: 'always' });

        //initialize with current value to make sure it is rounded appropriately
        result(target());

        //return the new computed observable
        return result;
    };



};

var CartViewModel = function () {

    // for avoiding the need to track this altogether
    var self = this;

    self.isCommonDate = ko.observable(false);
    self.CommonDate = ko.observable(new Date());
    self.CommonQty = ko.observable(3);
    self.availableproducts = ko.observableArray(); // ALL available products
    self.availableVisibleProducts = ko.observableArray();
    self.selectedproducts = ko.observableArray();
    self.productListToSaveQuantityAndDate = ko.observableArray();
    self.selectedproductsClone = ko.observableArray();
    // Products Added to Cart by User
    self.DetailedViewProduct = ko.observable();    // when user clicks on any product then this will hold that particular Product Details 
    //var testprimaryFeatures = ko.observableArray();
    self.DisplayProductCountText = ko.observable("3 Day Rental")
    self.RentalDaysList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30];
    self.SelectedRentalDay = ko.observable(3);
    //Fill Arrays  from Cookie or server
    self.isFilteredData = ko.observable(false);
    self.filterItemList = ko.observableArray();
    self.SelectedFilterArray = ko.observableArray();
    self.SelectedFilterArray.push("ALL Products");



    $.ajax({
        type: "POST",
        async: false,
        url: "Home.aspx/GetData",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            var d = new Date();
            d.setDate(d.getDate() + 6);
            var curr_date = d.getDate();
            var curr_month = d.getMonth() + 1; //Months are zero based
            var curr_year = d.getFullYear();
            var curr_Date = curr_date + "/" + curr_month + "/" + curr_year;
            $.each(result.d, function (i, val) {
                self.availableproducts.push(new product(val.Photos, val.SecondaryFeatures, val.PrimaryFeatures, val.ProductName, val.ProductPrice, val.ProductDetails, val.ProductId, val.PriceOffered, false, val.rating, val.DisplayImage, 3, val.PriceRangePlans, curr_Date, val.FeatureId, val.FeatureValue, val.SmallDescription, val.HomeDeliveryCharges));
            });
        }
    });

    $.ajax({
        type: "POST",
        async: false,
        url: "Home.aspx/GetFilterData",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            $.each(result.d, function (i, val) {
                self.filterItemList.push(new filterItem(val.FilterId, val.FilterName, val.FilterValues));
            });
        }
    });


    var sp = getCookie("SELECTEDPRODUCTLIST");
    if (sp !== undefined && sp !== null) {
        $.each(sp, function (i, val) {
            self.selectedproducts.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), parseInt(val.Qty()), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
            $.each(self.availableproducts(), function (i, pv) {
                if (val.ProductId() === pv.ProductId()) {
                    pv.isAdded(true);
                }
            });
        });
    }

    if (window.location.toString().indexOf("ProductDetails.aspx") != -1) {
        $.ajax({
            type: "POST",
            async: false,
            url: "ProductDetails.aspx/GetSelectedProductId",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                //alert(result);
                $.each(self.availableproducts(), function (i, val) {
                    if (val.ProductId() === result.d) {
                        self.DetailedViewProduct = val;
                    }
                });
            }
        });

        //if (pv !== undefined && pv !== null) {
        //    $.each(self.availableproducts(), function (i, val) {
        //        if (val.ProductId() === pv.ProductId) {
        //            self.DetailedViewProduct = val;
        //        }
        //    });
        //}
    }


    $.each(self.availableproducts(), function (i, val) {
        self.availableVisibleProducts.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), val.Qty(), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
    });

    // It will be called when user click on any product to go to product details page
    // It stores product information into DetailedViewProduct and then redirect
    self.GetDetailedViewProduct = function (item) {
        $.each(self.availableproducts(), function (i, val) {
            if (val.ProductId() === item.ProductId()) {
                self.DetailedViewProduct = self.availableproducts()[i];
            }
        });
        $.ajax({
            type: "POST",
            async: false,
            url: "ProductDetails.aspx/SetSelectedProductId",
            data: "{productId : '" + item.ProductId() + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                //alert(result);
            }
        });

        //setproductCookie("PRODUCTVIEW", ko.toJSON(self.DetailedViewProduct), 1);
        window.location = self.DetailedViewProduct.url();
    };

    //This method will be called when user clicks Add To Cart
    //It will populate selectedProducts Array
    self.AddProductToCart =
        function (product) {
            product.isAdded(true);
            self.selectedproducts.push(product);
            setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
            $.each(self.availableproducts(), function (i, val) {
                if (val.ProductId() === product.ProductId()) {
                    val.isAdded(true);
                }
            });
            //setCookie("AVAILABLEPRODUCTLIST", ko.toJSON(self.availableproducts), 365);
        };


    //This method will be called when user clicks CheckOut Cart    
    self.CheckOutProducts = function (item) {
        window.location = "ShowCart.aspx";
    };


    //This method will be called when user clicks Remomve From Cart
    //It will update selectedProducts Array
    self.RemoveProductFromCart =
        function (product) {

            product.isAdded(false);
            self.selectedproducts.remove(function (item) {
                return item.ProductId() === product.ProductId()
            });

            setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
            $.each(self.availableproducts(), function (i, val) {
                if (val.ProductId() === product.ProductId()) {
                    val.isAdded(false);
                }
            });
            $.each(self.availableVisibleProducts(), function (i, val) {
                if (val.ProductId() === product.ProductId()) {
                    val.isAdded(false);
                }
            });
            //setCookie("AVAILABLEPRODUCTLIST", ko.toJSON(self.availableproducts), 365);
        };

    //This method will be called when user clicks Update in Cart
    //It will update Qty in selectedProducts Array
    self.UpdateProductInCart =
        function (product) {
            self.selectedproducts.remove(function (item) {
                return item.ProductId() === product.ProductId()
            });
            self.selectedproducts.push(product);
            setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
        };

    self.ChangeQty =
        function (product) {
            $.each(self.selectedproducts(), function (i, val) {
                if (val.ProductId() === product.ProductId()) {
                    val.Qty(product.Qty());
                }
            });
            setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
        };

    self.ChangeFromDate =
        function (product) {
            setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
        };


    self.ChangeAllQty =
        function (product) {
            $.each(self.selectedproducts(), function (i, val) {
                val.Qty(self.CommonQty());
            });
            setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
        };

    var rentalperiod = getproductCookie("RentalPeriod");
    if (rentalperiod != null && rentalperiod != undefined) {
        self.SelectedRentalDay(rentalperiod);
        $.each(self.availableproducts(), function (i, val) {
            val.Qty(rentalperiod);
            val.DisplayText(rentalperiod + " Day Rental");
        });
        $.each(self.availableVisibleProducts(), function (i, val) {
            val.Qty(rentalperiod);
            val.DisplayText(rentalperiod + " Day Rental");
        });
        self.DisplayProductCountText(rentalperiod + " Day Rental");
    }

    self.SelectedRentalDay.subscribe(function (updated) {
        setproductCookie('RentalPeriod', updated, 30);
        $.each(self.availableproducts(), function (i, val) {
            val.Qty(updated);
            val.DisplayText(updated + " Day Rental");
        });
        $.each(self.availableVisibleProducts(), function (i, val) {
            val.Qty(updated);
            val.DisplayText(updated + " Day Rental");
        });
        self.DisplayProductCountText(updated + " Day Rental");
        var sp = getCookie("SELECTEDPRODUCTLIST");
        if (sp !== undefined && sp !== null) {
            self.selectedproducts.removeAll();
            $.each(sp, function (i, val) {
                self.selectedproducts.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), parseInt(val.Qty()), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
            });
        }
    });



    self.isCommonDate.subscribe(function (updated) {
        if (updated == true) {
            if (self.selectedproducts() != undefined) {
                $.each(self.selectedproducts(), function (i, val) {
                    self.productListToSaveQuantityAndDate.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), parseInt(val.Qty()), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
                });
            }
            $.each(self.selectedproducts(), function (i, val) {
                val.FromDate(self.CommonDate());
                val.Qty(self.CommonQty());
            });


        }
        else {
            $.each(self.selectedproducts(), function (i, prodx) {
                $.each(self.productListToSaveQuantityAndDate(), function (i, prody) {
                    if (prodx.ProductId() == prody.ProductId()) {
                        prodx.FromDate(prody.FromDate());
                        prodx.Qty(prody.Qty());
                    }
                });

            });
            //self.CommonDate(new Date());
            //self.CommonQty(1);
        }
        setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
    });

    self.isFilteredData.subscribe(function (updated) {
        alert("Hi");
    });

    self.changeFilter =
        function (id, value, name) {
            self.SelectedFilterArray.removeAll();
            var selection = false;
            self.availableVisibleProducts.removeAll();
            $('input[type=checkbox]').each(function () {
                if (this.checked == true) {
                    selection = true;
                    self.SelectedFilterArray.push($(this).attr("value"));
                }
            });

            if (selection == false) {
                $.each(self.availableproducts(), function (i, val) {
                    self.availableVisibleProducts.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), val.Qty(), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
                });
                self.SelectedFilterArray.push("ALL Products");
            }
            else {
                $.each(self.availableproducts(), function (i, val) {
                    $.each(val.PrimaryFeatures(), function (j, feature) {
                        $("input:checked").each(function () {
                            if (feature.featureName == $(this).attr("value")) {
                                var isAlreadyAdded = false;
                                $.each(self.availableVisibleProducts(), function (i, item) {
                                    if (item.ProductId() == val.ProductId()) {
                                        isAlreadyAdded = true;
                                    }
                                });
                                if (!isAlreadyAdded) {
                                    self.availableVisibleProducts.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), val.Qty(), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
                                }
                            }
                        });
                    });
                });
            }
            return true;
        };


    self.removeFilter =
        function (id) {
            $('input[type=checkbox]').each(function () {
                if ($(this).attr("value") == id) {
                    this.checked = false;
                    self.SelectedFilterArray.remove($(this).attr("value"));
                }
            });
            var selection = false;
            self.availableVisibleProducts.removeAll();
            $('input[type=checkbox]').each(function () {
                if (this.checked == true) {
                    selection = true;
                }
            });

            if (selection == false) {
                $.each(self.availableproducts(), function (i, val) {
                    self.availableVisibleProducts.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), val.Qty(), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
                });
                self.SelectedFilterArray.removeAll();
                self.SelectedFilterArray.push("ALL Products");
            }
            else {
                $.each(self.availableproducts(), function (i, val) {
                    $.each(val.PrimaryFeatures(), function (j, feature) {
                        $("input:checked").each(function () {
                            if (feature.featureName == $(this).attr("value")) {
                                var isAlreadyAdded = false;
                                $.each(self.availableVisibleProducts(), function (i, item) {
                                    if (item.ProductId() == val.ProductId()) {
                                        isAlreadyAdded = true;
                                    }
                                });
                                if (!isAlreadyAdded) {
                                    self.availableVisibleProducts.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), val.Qty(), val.PriceRangePlans(), val.FromDate(), val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
                                }
                            }
                        });
                    });
                });
            }
            return true;
        };

    self.CommonDate.subscribe(function (updated) {
        $.each(self.selectedproducts(), function (i, val) {
            val.FromDate(self.CommonDate());
        });
        setCookie("SELECTEDPRODUCTLIST", ko.toJSON(self.selectedproducts), 365);
    });


    // This is a property to get sum of all product prices in the cart
    self.grandTotal = ko.computed(function () {
        var total = 0;
        //$.each(self.selectedproducts(), function () { total += this.PriceOffered() * this.Qty() })
        //$.each(self.selectedproducts(), function () { total += this.TotalDisplayAmount() + this.HomeDeliveryCharges() })
        $.each(self.selectedproducts(), function () { total += this.TotalDisplayAmount() })
        return total;
    });


    // This is a property to get sum of all discounst of products in the cart
    self.totalSavings = ko.computed(function () {
        var total = 0;
        $.each(self.selectedproducts(), function () { total += this.Savings() })
        return total;
    });

    // This is a property to get count of products in the cart
    self.selectedProductsCount = ko.computed(function () {
        return self.selectedproducts().length + " Item(s)";
    });




    function setCookie(c_name, value, exdays) {

        var edited = "[";
        $.each(JSON.parse(value), function (i, val) {
            edited += '{"ProductId":"' + val.ProductId + '",';
            edited += '"FromDate":"' + val.FromDate + '",';
            edited += '"Qty":"' + val.Qty + '"},';
        });
        edited = edited.slice(0, -1);
        edited += "]";


        $.ajax({
            type: "POST",
            async: false,
            url: "Home.aspx/SetSelectedProductsJSON",
            data: "{products : '" + edited + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {

            }
        });
    }

    function getCookie(c_name) {

        var jsonResult = [];
        var products = [];
        $.ajax({
            type: "POST",
            async: false,
            url: "Home.aspx/GetSelectedProductsJSON",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                jsonResult = JSON.parse(result.d == "" ? '[]' : result.d);
            }
        });

        $.each(jsonResult, function (i, pv) {
            $.each(self.availableproducts(), function (i, val) {
                if (pv.ProductId == val.ProductId()) {
                    products.push(new product(val.Photos(), val.SecondaryFeatures(), val.PrimaryFeatures(), val.ProductName(), val.ProductPrice(), val.ProductDetails(), val.ProductId(), val.PriceOffered(), val.isAdded(), val.rating(), val.DisplayImage(), parseInt(pv.Qty), val.PriceRangePlans(), pv.FromDate, val.FeatureId(), val.FeatureValue(), val.SmallDescription(), val.HomeDeliveryCharges()));
                }
            });
        });

        return products;
    }

};


ko.applyBindings(new CartViewModel());


function setproductCookie(c_name, value, exdays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + exdays);
    var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
    var x = c_value.length;
    document.cookie = c_name + "=" + c_value;
}

function getproductCookie(c_name) {
    var c_value = document.cookie;
    var c_start = c_value.indexOf(" " + c_name + "=");
    if (c_start == -1) {
        c_start = c_value.indexOf(c_name + "=");
    }
    if (c_start == -1) {
        c_value = null;
    }
    else {
        c_start = c_value.indexOf("=", c_start) + 1;
        var c_end = c_value.indexOf(";", c_start);
        if (c_end == -1) {
            c_end = c_value.length;
        }
        c_value = unescape(c_value.substring(c_start, c_end));
    }
    if (c_value != undefined && c_value != "") {
        return JSON.parse(c_value);
    }
    if (c_name === "PRODUCTVIEW")
        setproductCookie(c_name, "", -1);
    return c_value;
    //createCookie(name, "", -1);
}