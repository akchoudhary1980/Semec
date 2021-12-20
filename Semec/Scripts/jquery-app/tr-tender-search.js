// Item Auto Complete
$(document).ready(function () {   
    GetStateList();
    GetCityList();

    $("#DepartmentName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/TenderSearchManage/TenderSearchLink/DepartmentAutoComplete",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.DepartmentName, value: item.DepartmentName, id: item.DepartmentID };
                    }))
                },
            })
        },
        select: function (event, ui) {           
            $("#DepartmentID").val(ui.item.id); // hidden
        }
    });
})
// Item Auto Complete
$(document).ready(function () {
    $("#DepartmentCategoryName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/TenderSearchManage/TenderSearchLink/DepartmentCategoryAutoComplete",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.DepartmentCategoryName, value: item.DepartmentCategoryName, id: item.DepartmentCategoryID };
                    }))
                },
            })
        },
        select: function (event, ui) {
            $("#DepartmentCategoryID").val(ui.item.id); // hidden
        }
    });
})


// edit 
$(document).ready(function () {   
    // Department 
    $.ajax({
        type: 'POST',
        url: "/TenderSearchManage/TenderSearchLink/GetDepartmentName",
        dataType: 'json',
        data: { 'DepartmentID': $('#DepartmentID').val(), "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() },
        success: function (response) {           
            $('#DepartmentName').val(response);
        }
    });

    // Department Category 
    $.ajax({
        type: 'POST',
        url: "/TenderSearchManage/TenderSearchLink/GetDepartmentCategoryName",
        dataType: 'json',
        data: { 'DepartmentCategoryID': $('#DepartmentCategoryID').val(), "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() },
        success: function (response) {
            $('#DepartmentCategoryName').val(response);
        }
    });

})




function uploadPicture(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#logoPicture')
                .attr('src', e.target.result)
                .width(150)
                .height(100);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
function DepModel() {
    $('#dep-Modal').modal('show');
}
function DepCatModel() {
    $('#depcat-Modal').modal('show');
}
// for department
function PushDepartment() {
    var dep = $('#Department').val();  
    if (!dep.trim()) {
        $('#errormessage').text('Please enter department name !');
    }
    else {       
        $.ajax({
            type: 'POST',
            url: "/TenderSearchManage/TenderSearchLink/InsertDepartment",
            dataType: 'json',
            data: { 'DepartmentName': $('#Department').val(), "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() },
            success: function (response) {
                alert('Department Added Successfully !');
                $('#dep-Modal').modal('hide');  
                // logic for set value
                var myArray = response.split('^');
                $('#DepartmentID').val(myArray[0]);  
                $('#DepartmentName').val(myArray[1]);
                $('#Department').val("");
            }
        });
    }
}
// for department
function PushDepartmentCategory() {
    var depcat = $('#DepartmentCategory').val();
    if (!depcat.trim()) {
        $('#errormessage').text('Please enter department category !');
    }
    else {
        $.ajax({
            type: 'POST',
            url: "/TenderSearchManage/TenderSearchLink/InsertDepartmentCategory",
            dataType: 'json',
            data: { 'DepartmentCategoryName': $('#DepartmentCategory').val(), "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() },
            success: function (response) {
                alert('Department Category Added Successfully !');
                $('#depcat-Modal').modal('hide');
                // logic for set value
                var myArray = response.split('^');
                $('#DepartmentCategoryID').val(myArray[0]);
                $('#DepartmentCategoryName').val(myArray[1]);
                $('#DepartmentCategory').val("");
            }
        });
    }
}


// Logic for dropdon

$(document).ready(function () {
    // Call
    GetDropDown("ddlCustomers", "/TenderSearchManage/TenderSearchLink/AjaxMethod");

    // Defination 
    function GetDropDown(Name, Method) {

        var ddName = $("#" + Name);
        ddName.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');

        $.ajax({
            type: "POST",
            url: Method, 
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (response) {                
                // initail value 
                ddName.empty().append('<option selected="selected" value="0">Select</option>');
                // through Loop 
                $.each(response, function () {
                    ddName.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
        });        
    }
    // Fundtion End 

})