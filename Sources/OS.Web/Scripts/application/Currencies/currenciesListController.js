function CurrenciesListController(parentCategoryId)
{
    var $currenciesTable;

    var init = function()
    {
        $currenciesTable = $("#currenciesTable")
            .DataTable({
                ajax: "/api/currencies",
                columns: [
                    { data: "Id" },
                    { data: "Name" },
                    { data: "Symbol" },
                    { data: "Code" },
                    { data: "CodeISO" },
                    { data: "Country" },
                    { data: "IsMain" }
                ],
                columnDefs: [
                    {
                        targets: [7],
                        render: function(data, type, row)
                        {
                            var $editTemplate = $("#editTeamplate");
                            var $editDom = $editTemplate.clone();
                            $editDom.find("a").attr("href", "currencies/edit/" + row.Id);

                            return $editDom.html();
                        }
                    },
                    {
                        targets: [8],
                        render: function(data, type, row)
                        {
                            return "Видалити";
                        }
                    }
                ]
            });
    }

    $()
        .ready(function()
        {
            init();
        });
}