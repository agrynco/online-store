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
            }).done(function (msg)
            {
                $categoriesTable.ajax.reload();
            });
        }
    }

    var init = function()
    {
        $categoriesTable = $("#categoriesTable").DataTable({
            ajax: buildApiUrl(parentCategoryId),
            columns: [
                { data: "Id" },
                { data: "Name" },
                { data: "Description" },
                { data: "Publish" }
            ],
            columnDefs: [
            {
                targets: [1],
                render: function(data, type, row)
                {
                    return '<a href="ProductCategories?parentId=' + row.Id + '">' + data + '</a>';
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
    }
    
    $().ready(function()
    {
        init();
    });
}