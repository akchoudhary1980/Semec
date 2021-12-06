﻿$(document).ready(function () {
    $("#cbtn-selectors1").dataTable({
        //
        "pageLength": 10,
        dom: 'Bfrtip',
        buttons: [{
            extend: 'copyHtml5',
            exportOptions: {
                columns: [0, ':visible']
            }
        }, {
            extend: 'excelHtml5',
            exportOptions: {
                columns: ':visible'
            }
        }, {
            extend: 'pdfHtml5',
            exportOptions: {
                columns: [0, 1, 2, 5]
            }
        }, 'colvis'],
        //
        "processing": true,
        "serverSide": true,
        "filter": true,

        "ajax": {
            "url": "/Dealers/GetIndex",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],            
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "DealersID", "name": "DealersID", "autoWidth": true },
            { "data": "Company", "name": "Company", "autoWidth": true },
            { "data": "Brand", "name": "Brand", "autoWidth": true },
            {
                "render": function (data, type, full) {
                    return "<a href='/EmdManage/Dealers/View/" + full.DealersID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-eye-alt'></i></a>";
                }
            },
            {
                "render": function (data, type, full)
                {
                    return "<a href='/EmdManage/Dealers/Edit/" + full.DealersID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-ui-edit'></i></a>";
                }
            },
            {
                "render": function (data, type, full) {
                    return "<a href='/EmdManage/Dealers/Delete/" + full.DealersID + "' class='btn btn-danger btn-mini btn-outline-primary'><i class='icofont icofont-ui-close'></i></a>";
                }
            },
           
        ]
    });
});  

