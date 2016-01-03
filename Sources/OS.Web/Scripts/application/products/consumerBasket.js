function Product(id, price)
{
    if (id == undefined)
    {
        throw "id can not be undefined";
    }

    if (price == undefined)
    {
        throw "price can not be undefined";
    }

    this.id = id;
    this.price = price;
}

function ConsumerBasket()
{
    var _cookieKey = "ConsumerBasket";
    var _products = new Array();

    var save = function ()
    {
        var productsToStore = JSON.stringify(_products);
        $.cookie(_cookieKey, productsToStore);
    }

    var indexof = function (productId)
    {
        for (var i = 0; i < _products.length; i++)
        {
            if (_products[i].id === productId)
            {
                return i;
            }
        }
        return -1;
    }

    var add = function (product)
    {
        if (indexof(product.id) !== -1)
        {
            throw "Product with id = " + product.id + " is already in basket.";
        }

        _products.push(product);
        save();
    }

    var load = function ()
    {
        var consumerBasketCookie = $.cookie(_cookieKey);
        if (consumerBasketCookie != undefined)
        {
            var storedProducts = JSON.parse(consumerBasketCookie.toString());
            storedProducts.forEach(function (product)
            {
                add(new Product(parseInt(product.id), parseFloat(product.price)));
            });
        }
    }

    var init = function ()
    {
        $(".btn-buy-product").click(function ()
        {
            add(new Product($(this).attr("productId"), $(this).attr("productPrice")));
            $(this).hide();
        });
    }

    this.contains = function (productId)
    {
        return indexof(productId) !== 1;
    }

    load();
    init();
}