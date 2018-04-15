class ProductFormIds {
    static get NewProductForm() { return "new-product-form" }
    static get SubmitNewProduct() { return "submit-new-product" }
    static get ProductsTabSelector() { return "products-tab-selector" }
    static get ProductType() { return "product-type" }
}

function bindNewProductPageControls() {
    $("#" + ProductFormIds.SubmitNewProduct).unbind("click")
        .click(function () {
            event.preventDefault();
            var form = $("#" + ProductFormIds.NewProductForm);

            $.post(RequestURLs.AddProduct, form.serialize(), function () {
                $("#" + ProductFormIds.ProductsTabSelector).click();
            });
        });
}

function loadProductTypes() {
    $.get(RequestURLs.GetAllProductTypesUrl, { }, function (productTypes) {
        $.each(productTypes, function (i, type) {
            $("#" + ProductFormIds.ProductType).append($('<option>', {
                value: type.Id,
                text: type.Name
            }));
        });
    });
}

function loadNewProductPage() {
    bindNewProductPageControls();
    loadProductTypes();
}