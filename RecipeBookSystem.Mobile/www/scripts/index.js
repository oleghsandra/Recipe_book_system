// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in cordova-simulate or on Android devices/emulators: launch your app, set breakpoints, 
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    document.addEventListener('deviceready', onDeviceReady.bind(this), false);

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);

        init();
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
        init();
    };

    function init() {
        $("#tabs li").unbind("click", navigate).click(navigate);
        $("#login-btn").unbind("click", login).click(login);
    }

    function navigate(elDom) {
        var el = $(elDom.currentTarget);
        $("#tabs li").removeClass("active");
        el.addClass("active");

        var link = $(el.find("a")[0]);
        var targetEl = $(link.attr("href"));
        targetEl.parent().children().removeClass("active");
        targetEl.addClass("active")
        var page = targetEl.attr("data-target-page");

        targetEl.load("./" + page, function () {
            if (page === CurrentAppPages.ProductsPage) {
                loadProductsPage();
            }
            else if (page === CurrentAppPages.ProductPage) {
                loadNewProductPage();
            }
        });
    }

    function login(event) {
        event.preventDefault();
        var login = $("#Username").val();
        var password = $("#Password").val();

        $.get(RequestURLs.UserRequestUrl, { login, password }, function (userInfo) {
            if (userInfo === null) {
                $("#dishes-tab-selector").hide();
                alert("Login or password is not correct");
            }
            else {
                $("#dishes-tab-selector").show().click();
            }
        });
    }
})();