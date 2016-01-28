function ProductCategoriesListController(onEnterCategoryCallBack)
{
    var init = function()
    {
        $("a[action]").click(function ()
        {
            var categoryId = parseInt($(this).attr("param"));
            onEnterCategoryCallBack(categoryId);
        });
    };

    init();
}