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
            "url": "/Reports/GetNoWebsite",
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
            {
                "data": "Logo", "name": "Logo",

                "render": function (data, type, full, meta) {
                    return "<img src='../UploadFiles/" + full.Logo + "' height='50'/>";
                },
                "orderable": false,
                "searchable": false
            },

            { "data": "Company", "name": "Company", "autoWidth": true },
            { "data": "Brand", "name": "Brand", "autoWidth": true },

            { "data": "CP1", "name": "CP1", "autoWidth": true },
            { "data": "MobileCP1", "name": "MobileCP1", "autoWidth": true },
            { "data": "Website", "name": "Website", "autoWidth": true },

            {
                "render": function (data, type, full) {
                    return "<a href='/DealersManage/Dealers/View/" + full.DealersID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-eye-alt'></i></a>";
                }
            },
            {
                "render": function (data, type, full)
                {
                    return "<a href='/DealersManage/Dealers/Edit/" + full.DealersID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-ui-edit'></i></a>";
                }
            },
            {
                "render": function (data, type, full) {
                    return "<a href='/DealersManage/Dealers/Delete/" + full.DealersID + "' class='btn btn-danger btn-mini btn-outline-primary'><i class='icofont icofont-ui-close'></i></a>";
                }
            },
           
        ]
    });
});  

