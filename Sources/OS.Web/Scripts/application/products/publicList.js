function PublicProductListController()
{
    var viewMode;

    var saveState = function()
    {
        $.cookie("productListViewMode", viewMode);
    };

    var restoreState = function()
    {
        var cookie = $.cookie("productListViewMode");
        viewMode = cookie ? cookie : "cbp-vm-view-grid";
        $(".cbp-vm-switcher").addClass(viewMode);
        $(".cbp-vm-options a[data-view='" + viewMode + "']").addClass("cbp-vm-selected");
    };

    var init = function()
    {
        $(".cbp-vm-options a")
            .click(function()
            {
                viewMode = $(this).attr("data-view");
                saveState();
            });

        restoreState();
    };

    $()
        .ready(function()
        {
            init();
        });
}