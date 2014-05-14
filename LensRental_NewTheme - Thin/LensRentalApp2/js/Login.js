function closeLoginPopup(redirectUrl) {
    window.parent.location.href = redirectUrl;
    //self.close();
}

function openLoginPopup() {
    $("#btnLogin").fancybox({
        parent: "form:first",
        openEffect: 'none',
        closeEffect: 'none',
        minHeight: '400',
        minWidth: '200',
        autoSize: 'false',
        border: '0',
        afterClose: function () {
            if (window.location.toString().indexOf('UserProfile.aspx') != -1) {
                window.location = "/home.aspx";
            }
            debugger;
            $("#lblMessage").text('');
        }
    }).trigger('click');
}

$(document).ready(function () {
    $(".fancybox").fancybox({
        parent: "form:first",
        openEffect: 'none',
        closeEffect: 'none',
        minHeight: '400',
        minWidth: '850',
        autoSize: 'false',
        border: '0',
        afterClose: function () {
            if (window.location.toString().indexOf('UserProfile.aspx') != -1) {
                window.location = "home.aspx";
            }
            debugger;
            $("#lblMessage").text('');

        }
    });

    $('#checkOutBasket').click(function (event) {
        var cobPopUp = $('#checkOutBasketPopup');
        event.stopPropagation();
        cobPopUp.toggle();
        $("#checkOutBasketCollapsed").toggleClass('down-arrow');
    });

    $(document).click(function (e) {
        var cobPopUp = $('#checkOutBasketPopup');
        if (cobPopUp.has($(e.target)).length > 0)
            return;
        if (cobPopUp.is(":visible")) {
            cobPopUp.hide();
            $("#checkOutBasketCollapsed").toggleClass('down-arrow');
        }
    });
    $('.layer_filters label, .token-input-token-facebook').live('click', function (e) {
        e.preventDefault;
        $('figure.box').each(function (i) {
            i++;
            if (i % 3 == 0) {
                $(this).addClass('lastbox')
            }
        });

    });
    $('figure.box').each(function (i) {
        i++;
        if (i % 3 == 0) {
            $(this).addClass('lastbox')
        }
    });

    $('.navigation li').hover(function () {
        if ($(this).find('.sub-category').is(':visible')) {
            $(this).addClass('active')
        } else {
            $(this).removeClass('active')
        }
    });
    var boxW = $('.sub-category li.float-left').outerWidth();

    $('.nav-link').each(function () {
        var lengthBox = $(this).find('.sub-category li.float-left').length;
        $(this).find('.sub-category').width((boxW * lengthBox) + 60);
    })



    $('figure.box').eq(0).removeClass('lastbox');
    $('.tradus-checkoutflow-container .tradus-green-circle').next('span').removeClass('green-active')
    $('.tradus-checkoutflow-container .blue-back-circle').next('span').removeClass('blue-active')
    $('.tradus-checkoutflow-container .tradus-green-circle').each(function () {
        $(this).next('span').addClass('green-active')
    })
    $('.tradus-checkoutflow-container .blue-back-circle').each(function () {
        $(this).next('span').addClass('blue-active')
    })

});
//function openColorBox() {
//    //$.colorbox({ href: "Login.aspx" });
//    $("#btnLogin").modal({ width: 950, height: 500 }).open();
//}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function showimage() {
    var i = document.getElementById("imggoogle");
    i.src = "images/google_sign_out.png";
    i.style.border = "1px solid white";
}