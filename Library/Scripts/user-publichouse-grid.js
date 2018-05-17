$(document).ready(function () {
    dataSource = new kendo.data.DataSource
        ({
            transport:
                {
                    read: function (options) {
                        $.ajax(
                            {
                                url: "/PublicHouse/GetPublicationHouses", 
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
                                url: "/PublicHouse/EditPublicHouse",
                                dataType: "json",
                                type: "POST",
                                data:
                                    {
                                        PublicHouse: options.data.models[0]
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
                                url: "/PublicHouse/Delete/" + options.data.models[0].Id,
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
                                url: "/PublicHouse/AddPublicHouse",
                                dataType: "json",
                                type: "POST",
                                data:
                                    {
                                        PublicHouse: options.data.models[0]
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
                        if (operation !== "update" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                        if (operation !== "create" && options.models) {
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
                                    Address: { validation: { required: true } },

                                }
                        }
                }
        })


    $("#grid").kendoGrid
        ({
            dataSource: dataSource,

            pageable: true,
            height: 550,
            // toolbar: ["create"],
            columns: [
                { field: "Name", title: "Name" },
                { field: "Address", title: "Address" }]
            // { command: ["edit", "destroy"], title: "&nbsp;" }],
            // editable: "popup"
        })
});