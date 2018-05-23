
$(document).ready(function () {
    dataSource = new kendo.data.DataSource
        ({
            transport:
                {
                    read: function (options) {
                        $.ajax(
                            {
                                url: "/Book/GetBooks",
                                dataType: "Json",
                                success: function (result) {
                                    options.success(result);
                                },
                                error: function (result) {
                                    options.error(result);
                                }
                            });
                    },
                    update: function (options) {
                       
                        $.ajax(
                            {
                                url: "/Book/EditBook",
                                dataType: "json",
                                type: "POST",
                                
                                data:
                                    {
                                        Book: options.data.models[0]
                                    },
                                success: function (result) {
                                    options.success(result);
                                },
                                error: function (result) {
                                    options.error(result);
                                }
                            });

                    },
                    destroy: function (options) {
                        $.ajax(
                            {
                                url: "/Book/Delete/" + options.data.models[0].Id,
                                success: function (result) {
                                    options.success(result);
                                },
                                error: function (result) {
                                    options.error(result);
                                }
                            });
                    },
                    create: function (options) {

                        $.ajax(
                            {
                                url: "/Book/AddBook",
                                dataType: "json",
                                type: "POST",
                                data:
                                    {
                                        Book: options.data.models[0]
                                    },
                                success: function (result) {
                                    options.success(result);
                                },
                                error: function (result) {
                                    options.error(result);
                                }
                            });
                    },

                    parameterMap: function (options, operation) {
                        if (operation !== "read" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                        if (operation !== "destroy" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }

                    }
                },
            batch: true,
            pageSize: 20,
            schema:
                {
                    model:
                        {
                            id: "Id",
                            fields:
                                {
                                    Id: { type: "number", editable: false },
                                    Name: { validation: { required: true } },
                                    Author: { validation: { required: true } },
                                    YearOfPublishing: { validation: { required: true } },
                                    PublicHouses: { validation: { required: true } }
                                }
                        }
                }
        })

   
    $("#grid").kendoGrid
        ({
           
            dataSource: dataSource,
            pageable: true,
            height: 500,
            toolbar: ["create"],
            columns: [

                { field: "Name", title: "Book name" },

                { field: "Author", title: "Author" },

                { field: "YearOfPublishing", title: "YearOfPublishing" },

                { field: "PublicHouses", title: "Publication Houses", template: publicHouses, editor: selector },

                { command: ["edit", "destroy"], title: "&nbsp;" }
            ],

            editable: "popup",
            edit: function(e)
            {
                if (e.model.isNew())
                {
                    $(".k-window-title")[0].innerHTML = "Add book";
                    $(".k-button.k-button-icontext.k-primary.k-grid-update")[0].textContent = "Add";
                }
               
            }
        })

    function selector(container, options) {
        $('<input name="PublicHouses">').appendTo(container)
            .kendoMultiSelect({
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: '/Book/GetPublicHouses',
                            dataType: "Json"
                        }
                    }
                }),
                dataTextField: "Name",
                dataValueField: "Id",
            });
    }
});

function publicHouses(options)
{
    if (options.PublicHouses)
    {
        return options.PublicHouses.map(x => x.Name).join(",");
    }
}