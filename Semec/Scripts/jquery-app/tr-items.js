﻿// Item Auto Complete
$(document).ready(function () {   
    $("#DealIn").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Dealers/ItemAutoComplete",
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
// for Add Trans Data
function PushRow() {
    itemid = $('#ItemID').val();
    if (itemid = "") {
        alert('Please select Item from list');
    }
    else {
        $.ajax({
            type: 'POST',
            url: "/Dealers/InsertRow",
            dataType: 'json',
            data: { iID: itemid },
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
        url: "/Dealers/DeleteRow",
        dataType: 'json',
        data: { iSer: serno },
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
        url: "/Dealers/FetchRow",
        dataType: 'json',
        data: { iID: itemid },
        success: function (data) {
            DisplayData(data);
        }
    });    
}