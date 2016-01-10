function Product(id, price, quantity)
{
    if (id == undefined)
    {
        throw "id can not be undefined";
    }

    if (price == undefined)
    {
        throw "price can not be undefined";
    }

    if (quantity == undefined)
    {
        throw new "quantity can not be undefined";
    }

    this.id = id;
    this.price = price;
    this.quantity = quantity;
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

    var indexOf = function (productId)
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

    var contains = function (productId)
    {
        return indexOf(productId) !== -1;
    }

    var getTotalAmount = function()
    {
        var result = 0;
        _products.forEach(function(product)
        {
            result = result + product.price * product.quantity;
        });
        return result;
    }

    var updateUI = function()
    {
        $("#basketCounter").html(_products.length);
        $("#basketTotalAmount").html(getTotalAmount());
        $(".btn-buy-product").each(function(index, el)
        {
            if (contains(parseInt($(el).attr("productId"))) === false)
            {
                $(el).show();
            }
        });
        $(".quantity").each(function(index, el)
        {
            $(el).val(_products[indexOf(parseInt($(el).attr("productId")))].quantity);
        });
    }

    var add = function (product)
    {
        if (indexOf(product.id) !== -1)
        {
            throw "Product with id = " + product.id + " is already in basket.";
        }

        _products.push(product);
    }

    var load = function ()
    {
        var consumerBasketCookie = $.cookie(_cookieKey);
        if (consumerBasketCookie != undefined)
        {
            var storedProducts = JSON.parse(consumerBasketCookie.toString());
            storedProducts.forEach(function (product)
            {
                add(new Product(parseInt(product.id), parseFloat(product.price), parseInt(product.quantity)));
            });
        }
    }

    var changeQuantityOn = function(productId, difference)
    {
        var product = _products[indexOf(productId)];
        product.quantity = product.quantity + difference;
        if (product.quantity < 0)
        {
            product.quantity = 0;
        }
    }

    var init = function ()
    {
        $(".btn-buy-product").click(function ()
        {
            var productId = parseInt($(this).attr("productId"));
            var productPrice = parseFloat($(this).attr("productPrice"));

            add(new Product(productId, productPrice, 1));
            $(this).hide();
            save();
            updateUI();
        });

        $("#consumerBasketLink").click(function ()
        {
            $("#consumerBasketRawData").val(JSON.stringify(_products));
            $("#frmConsumerBasket").submit();
        });

        $(".quantity-changer").click(function ()
        {
            var productId = parseInt($(this).attr("productId"));
            var diff = parseInt($(this).attr("diff"));
            changeQuantityOn(productId, diff);
            save();
            updateUI();
        });

        
    }

    load();
    init();
    updateUI();
}