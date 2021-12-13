// Item Auto Complete
$(document).ready(function () {   
    $("#DealIn").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/DealersManage/Dealers/ItemAutoComplete",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.ItemName, value: item.ItemName, id: item.ItemID };
                    }))
                },
            })
        },
        select: function (event, ui) {           
            $("#ItemID").val(ui.item.id); // hidden
        }
    });
})

// for add Trans Data
function PushRow() {
    var itemid = $('#ItemID').val();
    
    if (itemid = "") {
        alert('Please select Item from list');
    }
    else {
        $.ajax({
            type: 'POST',
            url: '/DealersManage/Dealers/InsertRow',
            dataType: 'json',
            data: { 'ID': $('#ItemID').val(), "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() },
            success: function (data) {
                DisplayData(data);
            }
        });
    }
}

// for Remove Trans Data
function PopRow(serno) {
    $.ajax({
        type: 'POST',
        url: "/DealersManage/Dealers/DeleteRow",
        dataType: 'json',
        data: { iSer: serno, "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() },
        success: function (data) {
            DisplayData(data);
        }
    });
}
// for Display Data-- > 
function DisplayData(data) {
    var counter = 0;
    $("#dtTable tbody tr").remove();
    var items = '';
    $.each(data, function (i, item) {
        counter = counter + 1;
        var rows = "<tr>"
            + "<td>" + counter + "</td>"
            + "<td>" + item.ItemName + "</td>"
            + "<td><button type='button' id=" + item.SerNo + " onclick='PopRow(this.id)' class='btn btn-danger btn-mini btn-outline-primary'><i class='icofont icofont-ui-close'></i></button></td>"
            + "</tr>";
        $('#dtTable tbody').append(rows);
    });
    // Clear Item
    $('#DealIn').val("");
}
// for Looad Data on Edit-- > 
function LoadRow(itemid) {
    $.ajax({
        type: 'POST',
        url: "/DealersManage/Dealers/FetchRow",
        dataType: 'json',
        data: { iID: itemid },
        success: function (data) {
            DisplayData(data);
        }
    });    
}


// for Add Trans Data
function PushItem() {
    var itemname = $('#ItemName').val();  
    if (!itemname.trim()) {
        $('#item').text('Please enter item name !');
    }
    else {       
        $.ajax({
            type: 'POST',
            url: "/DealersManage/Dealers/InsertItem",
            dataType: 'json',
            data: { 'ItemName': $('#ItemName').val(), "__RequestVerificationToken": $('input[name=__RequestVerificationToken]').val() },
            success: function (response) {
                alert('Item Added Successfully !');
                $('#large-Modal').modal('hide');  
                // logic for set value
                var myArray = response.split('^');
                $('#ItemID').val(myArray[0]);  
                $('#DealIn').val(myArray[1]);
                $('#ItemName').val("");
            }
        });
    }
}

function ShowModel() {
    $('#large-Modal').modal('show');
}

function ShowZoomModel(name, mobile) {
    $('#cpname').text(name); 

    $('#part1').text(mobile.substring(0, 2)); 
    $('#part2').text(mobile.substring(2, 4)); 
    $('#part3').text(mobile.substring(4, 6)); 
    $('#part4').text(mobile.substring(6, 8)); 
    $('#part5').text(mobile.substring(8,10));

    $('#zoom-Modal').modal('show');
}

