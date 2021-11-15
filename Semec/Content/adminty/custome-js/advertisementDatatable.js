$(document).ready(function () {
    $("#cbtn-selectors").DataTable({
        //
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
            "url": "/Advertisement/GetIndex",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],            
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "AdvertisementID", "name": "AdvertisementID", "autoWidth": true },      
            
            {
                "data": "Picture", "name": "Picture",
               
                "render": function (data, type, full, meta) {
                    return "<img src='UploadFiles/" + full.Picture+"' height='50'/>";
                },                
                "orderable": false,
                "searchable": false
            },
            {
                "data": "StartDate", "name": "StartDate",

                "render": function (data, type, full, meta) {
                    return ConvertToDDMMYYYY(full.StartDate);
                }               
            },
            {
                "data": "EndDate", "name": "EndDate",

                "render": function (data, type, full, meta) {
                    return ConvertToDDMMYYYY(full.EndDate);
                }
            },
            { "data": "AdvertisementTitle", "name": "AdvertisementTitle", "autoWidth": true },          
            { "data": "FirmName", "name": "FirmName", "autoWidth": true },   
            
            {
                "render": function (data, type, full)
                {
                    return "<a href='Advertisement/Edit/" + full.AdvertisementID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-ui-edit'></i></a>";                        
                }
            },
            {
                "render": function (data, type, full) {
                    return "<a href='Advertisement/Edit/" + full.AdvertisementID + "' class='btn btn-danger btn-mini btn-outline-primary'><i class='icofont icofont-ui-close'></i></a>";        
                }
            },
           
        ]
    });
});  

