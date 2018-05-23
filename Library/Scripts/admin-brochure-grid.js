
$(document).ready(function () {
    dataSource = new kendo.data.DataSource
        ({
            transport:
                {
                    read: function (options) {
                        $.ajax(
                            {
                                url: "/Brochure/GetBrochures",
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
                                url: "/Brochure/EditBrochure",
                                dataType: "json",
                                type: "POST",
                                data:
                                    {
                                        Brochure: options.data.models[0]
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
                                url: "/Brochure/Delete/" + options.data.models[0].Id,
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
                                url: "/Brochure/AddBrochure",
                                dataType: "json",
                                type: "POST",
                                data:
                                    {
                                        Brochure: options.data.models[0]
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
                                    TypeOfCover: { validation: { required: true } },
                                    NumberOfPages: { type: "number", validation: { required: true } },
                                }
                        }
                }
        })


    $("#grid").kendoGrid
        ({
            dataSource: dataSource,

            pageable: true,
            height: 550,
            toolbar: ["create"],
            columns: [
                { field: "Name", title: "Brochure name" },
                { field: "TypeOfCover", title: "TypeOfCover", template: typeOfCover, editor: selector},
                { field: "NumberOfPages", title: "NumberOfPages" },
                { command: ["edit", "destroy"], title: "&nbsp;" }],
            editable: "popup",
            edit: function (e) {
                if (e.model.isNew()) {
                    $(".k-window-title")[0].innerHTML = "Add brochure";
                    $(".k-button.k-button-icontext.k-primary.k-grid-update")[0].textContent = "Add";
                }

            }
        })
    
    function selector(container, options)
    {
        $('<input name="TypeOfCover">').appendTo(container)
            .kendoDropDownList({
                dataSource: [
                    { id: 1, name: "Hard" },
                    { id: 2, name: "Mild" }
                ],
                dataTextField: "name",
                dataValueField: "id",
                index: 2
            });
    }

    function typeOfCover(options)
    {
        if (options.TypeOfCover == 1)
        {
            return "Hard";
        }
        if (options.TypeOfCover == 2)
        {
            return "Mild";
        }
        return "Null";
    }
})