function ProductCategoriesListController(parentCategoryId)
{
    var $categoriesTable;

    var buildApiUrl = function (parentCategoryId)
    {
        return "api/categories/" + parentCategoryId + "/subcategories";
    };

    this.deleteRecord = function(id)
    {
        if (confirmDelete())
        {
            $.ajax({
                method: "DELETE",
                url: "api/categories/" + id
            }).done(function(msg)
            {
                $categoriesTable.ajax.reload();
            });
        }
    };

    var togglePublish = function($sender, productCategoryId)
    {
        $.ajax({
            method: "PUT",
            url: "api/categories/" + productCategoryId + "/togglePublish"
        }).fail(function()
        {
            $categoriesTable.ajax.reload();
        });
    };

    var init = function ()
    {
        $categoriesTable = $("#categoriesTable").DataTable({
            ajax: buildApiUrl(parentCategoryId),
            rowReorder: true,
            columns: [
                { data: "Id" },
                { data: "Name" },
                { data: "Description" },
                { data: "Publish" },
                { data: "IsDeleted" }
            ],
            columnDefs: [
                {
                    targets: [1],
                    render: function (data, type, row)
                    {
                        return '<a href="ProductCategories?parentId=' + row.Id + '">' + data + '</a>';
                    }
                },
                {
                    targets: [3],
                    render: function(data, type, row)
                    {
                        var $publishSwitcherTemplate = $("#publishSwitcherTemplate");
                        return $publishSwitcherTemplate.html();
                    },
                    createdCell: function(td, cellData, rowData, row, col)
                    {
                        var $publishSwitcher = $(td).find(".publishSwitcher");
                        $publishSwitcher.bootstrapToggle(cellData === true ? "on" : "off").attr("productCategoryId", rowData.Id);
                        $publishSwitcher.change(function()
                        {
                            togglePublish($(this), $(this).attr("productCategoryId"));
                        });
                    }
                },
                {
                    render: function (data, type, row)
                    {
                        var $editTemplate = $("#editTeamplate");
                        var $editDom = $editTemplate.clone();
                        $editDom.find("a").attr("href", "ProductCategories/Edit/" + row.Id);

                        return $editDom.html();
                    },
                    targets: [4],
                    className: "delete-column"
                },
                {
                    render: function (data, type, row)
                    {
                        var $deleteTemplate = $("#deleteTeamplate");
                        var $deleteDom = $deleteTemplate.clone();
                        $deleteDom.find("span").attr("onclick", "return deleteProductCategory(" + row.Id + ")");

                        return $deleteDom.html();
                    },
                    targets: [5],
                    className: "delete-column"
                }
            ],
            order: [[1, "asc"]],
            language:
            {
                url: "scripts/datatables.translations/ukrainian.json"
            }
        });

        $categoriesTable.on("row-reorder", function(e, diff, edit)
        {
            alert(diff);
        });
    }

    $().ready(function ()
    {
        init();
    });
}