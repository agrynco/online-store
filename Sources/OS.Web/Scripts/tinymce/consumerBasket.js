function Product(id, price, quantity, categoryId)
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
    this.categoryId = categoryId;
}

function ConsumerBasket()
{
    var _cookieKey = "ConsumerBasket";
    var _products = new Array();

    var save = function()
    {
        var productsToStore = JSON.stringify(_products);
        $.cookie(_cookieKey, productsToStore, { path: "/" });
    }

    var indexOf = function(productId)
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

    var contains = function(productId)
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
        return result.toFixed(2);
    }

    var updateUI = function()
    {
        $("#basketCounter").html(_products.length);
        $("#basketTotalAmount").html(getTotalAmount());
        $(".btn-buy-product")
            .each(function(index, el)
            {
                if (contains(parseInt($(el).attr("productId"))) === false)
                {
                    $(el).show();
                }
            });
        $(".quantity")
            .each(function(index, el)
            {
                $(el).val(_products[indexOf(parseInt($(el).attr("productId")))].quantity);
            });

        if (_products.length > 0)
        {
            $("#no-products-to-buy").hide();
            $("#tableConsumerBasket").show();
        } else
        {
            $("#tableConsumerBasket").hide();
            $("#no-products-to-buy").show();
        }
    }

    var add = function(product)
    {
        if (indexOf(product.id) !== -1)
        {
            throw "Product with id = " + product.id + " is already in basket.";
        }

        _products.push(product);
    }

    var load = function()
    {
        var consumerBasketCookie = $.cookie(_cookieKey);
        if (consumerBasketCookie != undefined)
        {
            var storedProducts = JSON.parse(consumerBasketCookie.toString());
            storedProducts.forEach(function(product)
            {
                add(new Product(parseInt(product.id), parseFloat(product.price), parseInt(product.quantity)));
            });
        }
    }

    var getNormalizedProductQuantiy = function(quantity)
    {
        if (quantity < globalSettings.consumerBasket.minProducts)
        {
            return globalSettings.consumerBasket.minProducts;
        }
        if (quantity > globalSettings.consumerBasket.maxProducts)
        {
            return globalSettings.consumerBasket.maxProducts;
        }
        return quantity;
    }

    var changeQuantityOn = function(productId, difference)
    {
        var index = indexOf(productId);
        var product = _products[index];
        product.quantity = getNormalizedProductQuantiy(product.quantity + difference);

        if (product.quantity === 0)
        {
            if (confirm("Ви впевненні що хочете відмовитися від покупки товару?") === true)
            {
                $(".ordered-product-row[productId='" + product.id + "']").remove();
                _products.splice(index, 1);
            } else
            {
                product.quantity = 1;
            }
        }
    }

    var init = function()
    {
        load();

        $(".btn-buy-product")
            .click(function()
            {
                var productId = parseInt($(this).attr("productId"));
                var productPrice = parseFloat($(this).attr("productPrice"));
                var categoryId = parseInt($(this).attr("categoryId"));

                add(new Product(productId, productPrice, 1, categoryId));
                $(this).hide();
                save();
                updateUI();
                return true;
            });

        $("#consumerBasketLink")
            .click(function()
            {
                $("#consumerBasketRawData").val(JSON.stringify(_products));
                $("#frmConsumerBasket").submit();
            });

        $(".quantity-changer")
            .click(function()
            {
                var productId = parseInt($(this).attr("productId"));
                var diff = parseInt($(this).attr("diff"));
                changeQuantityOn(productId, diff);
                save();
                updateUI();
            });

        $(".quantity")
            .change(function()
            {
                var index = indexOf(parseInt($(this).attr("productId")));
                var currentInputValue = parseInt($(this).val());
                _products[index].quantity = currentInputValue;
                changeQuantityOn(_products[index].id, 0);

                save();
                updateUI();
            });

        updateUI();
    }

    init();
}