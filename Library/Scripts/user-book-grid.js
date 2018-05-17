
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
                                url: 'Book/AddBook',
                                dataType: "json"
                            });
                    },

                    parameterMap: function (options, operation) {
                        if (operation !== "read" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                        if (operation !== "destroy" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                        if (operation !== "update" && options.models) {
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
                                    //  PublicHouses: { validation: { required: true }, editor: selector }
                                }
                        }
                }
        })


    $("#grid").kendoGrid
        ({
            dataSource: dataSource,

            pageable: true,
            height: 550,
            columns: [
                { field: "Name", title: "Book name" },
                { field: "Author", title: "Author" },
                { field: "YearOfPublishing", title: "YearOfPublishing" }]
            // { field: "PublicHouses", title: "Publishing by" },

            // { command: ["edit", "destroy"], title: "&nbsp;" }],
            //editable: "popup"
        })

    function selector(container, options) {
        $('<input name="PublicationHouses">').appendTo(container)
            .kendoMultiSelect({
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: '/PublicHouse/GetPublicationHouses',
                            dataType: "Json"
                        }
                    }
                }),
                dataTextField: "Name",
                dataValueField: "Id",
            });
    }
});