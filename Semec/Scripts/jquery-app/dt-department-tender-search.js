$(document).ready(function () {
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
            "url": "/TenderSearchLink/GetIndex",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],            
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "TenderSearchLinkID", "name": "TenderSearchLinkID", "autoWidth": true },
            { "data": "State", "name": "State", "autoWidth": true },
            { "data": "City", "name": "City", "autoWidth": true },
            {
                "render": function (data, type, full)
                {
                    return "<a href='/TenderSearchManage/TenderSearchLink/Edit/" + full.TenderSearchLinkID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-ui-edit'></i></a>";
                }
            },
            {
                "render": function (data, type, full) {
                    return "<a href='/TenderSearchManage/TenderSearchLink/Delete/" + full.TenderSearchLinkID + "' class='btn btn-danger btn-mini btn-outline-primary'><i class='icofont icofont-ui-close'></i></a>";
                }
            },
           
        ]
    });
});  

