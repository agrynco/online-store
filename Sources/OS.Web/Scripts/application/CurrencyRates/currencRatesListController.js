function CurrencRatesListController(parentCategoryId)
{
    var $currenciesTable;

    var init = function()
    {
        $currenciesTable = $("#currencyRatesTable")
            .DataTable({
                ajax: "/api/currencyrates",
                columns: [
                    { data: "Id" },
                    { data: "Currency" },
                    { data: "DateOfRate" },
                    { data: "Rate" }
                ],
                order: [[2, "desc"]],
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
                        render: function(data, type, row)
                        {
                            moment.locale("uk");
                            var momentDate = moment(row.DateOfRate);
                            return momentDate.format("l") + " " + momentDate.format("LT");
                        }
                    },
                    {
                        targets: [3],
                        render: function(data, type, row)
                        {
                            return row.Rate;
                        }
                    },
                    {
                        targets: [4],
                        orderable: false,
                        render: function(data, type, row)
                        {
                            var $editTemplate = $("#editTeamplate");
                            var $editDom = $editTemplate.clone();
                            $editDom.find("a").attr("href", "currencyrates/edit/" + row.Id);

                            return $editDom.html();
                        }
                    },
                    {
                        targets: [5],
                        orderable: false,
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