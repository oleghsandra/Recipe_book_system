class ProductListClasses {
    static get ProductsCards() { return "products-cards" }
    static get CardWitProductItem() { return "card-with-product-item" }
    static get CardWitProductItemLayout() { return "card-with-product-item-layout" }
    static get ProductId() { return "products-id" }
    static get ProductName() { return "products-name" }
    static get ProductType() { return "products-type" }
    static get ProductImage() { return "products-image" }
    static get ProductProteins() { return "products-proteins" }
    static get ProductFats() { return "products-fats" }
    static get ProductCarbs() { return "products-carbs" }
    static get PagingLeft() { return "products-list-pagination-btn-left" }
    static get PagingRight() { return "products-list-pagination-btn-right" }
    static get DeleteProductBtn() { return "products-delete" }
}

class ProductListIds {
    static get SearchByName() { return "input-search-product" }
    static get BtnSearchByName() { return "btn-search-product" }
}

currentPageNumber = 1;
searchedProductName = "";

function bindProductPageControls() {
    $("." + ProductListClasses.PagingLeft).unbind('click', goToProductsLeftPage).click(goToProductsLeftPage);
    $("." + ProductListClasses.PagingRight).unbind('click', goToProductsRightPage).click(goToProductsRightPage);
    $("#" + ProductListIds.BtnSearchByName).unbind('click', searchByName).click(searchByName);
}

function deleteProduct(event) {
    var productId = $(event.target).parents().eq(1).find("." + ProductListClasses.ProductId).text();

    $.post(RequestURLs.DeleteProduct, { Id: productId }, function () {
        loadProducts();
    });
}

function initProductSearchControls(currentPageProductsCount) {
    $("." + ProductListClasses.PagingLeft).prop("disabled", searchedProductName !== "" || currentPageNumber <= 1);
    $("." + ProductListClasses.PagingRight).prop("disabled", searchedProductName !== "" || currentPageProductsCount === 0);
}

function searchByName() {
    searchedProductName = $("#" + ProductListIds.SearchByName).val();
    loadProducts();
}

function goToProductsLeftPage() {
    currentPageNumber--;
    loadProducts();
}

function goToProductsRightPage() {
    currentPageNumber++;
    loadProducts();
}

function loadProducts() {
    var layout = $("." + ProductListClasses.CardWitProductItemLayout).eq(0).clone();
    var productsListTab = $("#" + ProductListClasses.ProductsCards);
    var productsListTabClone = productsListTab.clone();
    productsListTabClone.empty();

    var callback = function (products) {
        var i = 1;
        var previousCard = null;
        initProductSearchControls(products.length);

        $.each(products, function (index, value) {
            var currentCard = layout.clone();
            currentCard.removeClass(ProductListClasses.CardWitProductItemLayout).show();
            productsListTabClone.append(currentCard);
            currentCard.find("." + ProductListClasses.ProductId).text(value.Id);
            currentCard.find("." + ProductListClasses.ProductName).text(value.Name);
            currentCard.find("." + ProductListClasses.ProductType).text(value.ProductTypeModel.Name);
            currentCard.find("." + ProductListClasses.ProductImage).attr('src', value.SmallPhotoLink);
            currentCard.find("." + ProductListClasses.ProductProteins).text(value.Proteins.toFixed(2));
            currentCard.find("." + ProductListClasses.ProductFats).text(value.Fats.toFixed(2));
            currentCard.find("." + ProductListClasses.ProductCarbs).text(value.Carbohydrates.toFixed(2));

            if (i % 2 === 0) {
                var tempRow = $("<div class='row'></div>");
                tempRow.append(previousCard);
                tempRow.append(currentCard);
                productsListTabClone.append(tempRow);
            }

            previousCard = currentCard;
            i++;
        });

        productsListTab.empty().replaceWith(productsListTabClone);
        $("." + ProductListClasses.DeleteProductBtn).click(deleteProduct);
    }

    if (searchedProductName !== "") {
        $.get(RequestURLs.SearchProductByNameUrl, { name: searchedProductName }, function (products) {
            callback(products);
        });
    }
    else {
        var param = {
            count: 10,
            pageNumber: currentPageNumber,
            sortColumnName: null,
            sortOrder: null,
            filterProductTypeId: null
        };

        $.get(RequestURLs.GetProductsUrl, param, function (products) {
            callback(products);
        });
    }
}

function loadProductsPage() {
    bindProductPageControls();
    searchedProductName = "";
    $("." + ProductListClasses.SearchByName).val("");
    currentPageNumber = 1;
    loadProducts();
}