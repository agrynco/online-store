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
            columns: [
                { data: "Order" , className: "reorder" },
                { data: "Id" },
                { data: "Name" },
                { data: "Description" },
                { data: "Publish" },
                { data: "IsDeleted" }
            ],
            columnDefs: [
                
                {
                    targets: [1],
                    render: function(data, type, row)
                    {
                        return data;
                    }
                },
                {
                    targets: [2],
                    render: function (data, type, row)
                    {
                        return '<a href="ProductCategories?parentId=' + row.Id + '">' + data + '</a>';
                    }
                },
                {
                    targets: [4],
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
                    targets: [5],
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
                    targets: [6],
                    className: "delete-column"
                }
            ],
            rowReorder: {
                dataSrc: "Order"
            },
            language:
            {
                url: "scripts/datatables.translations/ukrainian.json"
            }
        });

        $categoriesTable.on("row-reorder", function(e, diff, edit)
        {
            var ordersData = [];

            for (var i = 0; i < diff.length; i++)
            {
                ordersData.push( {
                    OldOrder: diff[i].oldData,
                    NewOrder: diff[i].newData
                });
            }

            if (diff.length > 0)
            {
                $.ajax({
                    type: "POST",
                    url: "api/categories/" + parentCategoryId + "/reorder",
                    dataType: "json",
                    contentType: 'application/json',
                    data: JSON.stringify(ordersData)
                }).done(function (msg)
                {
                    $categoriesTable.ajax.reload();
                }).fail(function(a, b, c)
                {
                    debugger;
                });
            }
        });
    }

    $().ready(function ()
    {
        init();
    });
}