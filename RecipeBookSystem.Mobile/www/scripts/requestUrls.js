class CurrentAppPages {
    static get Host() { return "http://localhost:4400/" }
    static get IndexPage() { return CurrentAppPages.Host + "/index.html"; }
    static get ProductsPage() { return "products.html"; }
    static get ProductPage() { return "product.html"; }
}

class RequestURLs {
    static get Host() { return "http://recipentbook.azurewebsites.net" }
    static get UserRequestUrl() { return RequestURLs.Host + "/api/Users/GetUser"; }
    static get GetProductsUrl() { return RequestURLs.Host + "/api/Products/GetProducts"; }
    static get GetAllProductTypesUrl() { return RequestURLs.Host + "/api/ProductTypes/GetAllProductTypes"; }
    static get SearchProductByNameUrl() { return RequestURLs.Host + "/api/Products/SearchProductByName"; }
    static get AddProduct() { return RequestURLs.Host + "/api/Products/AddProduct"; }
    static get DeleteProduct() { return RequestURLs.Host + "/api/Products/DeleteProduct"; }
    static get GetDishes() { return RequestURLs.Host + "/api/Dishes/AddDish"; }
    static get DeleteDish() { return RequestURLs.Host + "/api/Dishes/DeleteDish"; }
}