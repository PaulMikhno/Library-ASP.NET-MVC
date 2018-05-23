$(document).ready(function ()
{
    dataSource = new kendo.data.DataSource
        ({
            transport:
                {
                    read: function (options) {
                        $.ajax(
                            {
                                url: "/Magazine/GetMagazines",
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
                                url: "/Magazine/EditMagazine",
                                dataType: "json",
                                type: "POST",
                                data:
                                    {
                                        Magazine: options.data.models[0]
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
                                url: "/Magazine/Delete/" + options.data.models[0].Id,
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
                                url: "/Magazine/AddMagazine",
                                dataType: "json",
                                type: "POST",
                                data:
                                    {
                                        Magazine: options.data.models[0]
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
                                    Number: { validation: { required: true } },
                                    YearOfPublishing: { validation: { required: true } }
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
                { field: "Name", title: "Magazine name" },
                { field: "Number", title: "Number" },
                { field: "YearOfPublishing" }]
            
        })
});