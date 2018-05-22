
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
                        debugger;
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
                        debugger;
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
            editable: "popup"
        })


    var data = [
        { text: "Hard", value: 1 },
        { text: "Mild", value: 2 },
        
    ];

    function selector(container, options)
    {
        $('<select id="TypeOfCover">').appendTo(container)
            .kendoDropDownList({
                
                dataTextField: "text",
                dataValueField: "value",
                dataSource: [
                    { text: "Hard", value: 1 },
                    { text: "Mild", value: 2 },

                ],
                index: 0,
                suggest: true,
               // change: onChange
            });
      
    }

    //function onChange()
    //{
    //    var value = $("#TypeOfCover").val();
    //    $("#TypeOfCover")
    //        .toggleClass("Hard", value == "1")
    //        .toggleClass("Mild", value == "2");

    //};

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