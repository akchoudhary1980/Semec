// Get State List
function GetStateList() {    
    $(document).ready(function () {
        $("#State").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Share/StateAutoComplete",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.StateName, value: item.StateName, id: item.StateID };
                        }))
                    },
                })
            },
            select: function (event, ui) {
                // alert(ui.item.id);
                $("#State").val(ui.item.id);
                // $('#CusID').val(response);
            },
            messages: {
                noResults: "", results: ""
            }
        });
    })
}
// Get City List
function GetCityList() {  
    $(document).ready(function () {
        $("#City").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Share/CityAutoComplete",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.CityName, value: item.CityName, id: item.CityID };
                        }))
                    },
                })
            },
            select: function (event, ui) {
                // alert(ui.item.id);
                $("#City").val(ui.item.id);
                // $('#CusID').val(response);
            },
            messages: {
                noResults: "", results: ""
            }
        });
    })
}
// Get Area List
function GetAreaList() {  
    $(document).ready(function () {
        $("#Area").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Share/AreaAutoComplete",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.AreaName, value: item.AreaName, id: item.AreaID };
                        }))
                    },
                })
            },
            select: function (event, ui) {
                // alert(ui.item.id);
                $("#Area").val(ui.item.id);
                // $('#CusID').val(response);
            },
            messages: {
                noResults: "", results: ""
            }
        });
    })
}
// Get Main Category  List
function GetMainCategoryList(controlid,hiddenid) {
    $(document).ready(function () {
        $(controlid).autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Share/MainCategoryAutoComplete",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.CategoryName, value: item.CategoryName, id: item.MainCategoryID };
                        }))
                    },
                })
            },
            select: function (event, ui) {
                //alert(ui.item.id);
                //alert(ui.item.value);
                //alert(ui.item.label);
                $(hiddenid).val(ui.item.id);  
                //$(controlid).val(ui.item.id);                
            },
            messages: {
                noResults: "", results: ""
            }
        });
    })
}
// Get Sub Category  List
function GetSubCategoryList(ControlID) {
    $(document).ready(function () {
        $(ControlID).autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Share/SubCategoryAutoComplete",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.CategoryName, value: item.CategoryName, id: item.SubCategoryID };
                        }))
                    },
                })
            },
            select: function (event, ui) {
                // alert(ui.item.id);
                $(ControlID).val(ui.item.id);
                // $('#CusID').val(response);
            },
            messages: {
                noResults: "", results: ""
            }
        });
    })
}

// update dropdwon 
function UpdateDropDown(dp1,dp2) {
    $(document).ready(function () {
        $(dp1).on("change", function () {
            //
            var m1 = $(dp1).val();
            $.ajax({
                type: "POST",
                url: "/Listing/GetSubCategoryList",
                data: { "CatID": m1 },
                dataType: "json",
                success: function (data) {
                    $(dp2).empty(); // clear 
                    $(dp2).append($("<option/>").val("0").text("Select")); // Default Value 
                    $.each(data, function () {
                        $(dp2).append($("<option/>").val(this.SubCategoryID).text(this.CategoryName));
                    });
                },
                failure: function () {
                    alert("Failed!");
                }
            });
            //
        });
    });
}