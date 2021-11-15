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
            { "data": "advertisementID", "name": "advertisementID", "autoWidth": true },      
            
            {
                "data": "picture", "name": "picture",               
                "render": function (data, type, full, meta) {
                    return "<img src='UploadFiles/" + full.picture+"' height='50'/>";
                },                
                "orderable": false,
                "searchable": false
            },
            {
                "data": "startDate", "name": "startDate", "autoWidth": true,
                "render": function (data, type, full, meta) {
                    return ConvertToDDMMYYYY(full.startDate);
                }               
            },
            {
                "data": "endDate", "name": "endDate", "autoWidth": true,
                "render": function (data, type, full, meta) {
                    return ConvertToDDMMYYYY(full.endDate);
                }
            },
            { "data": "advertisementTitle", "name": "advertisementTitle", "autoWidth": true },  
            
            { "data": "firmName", "name": "firmName", "autoWidth": true },   
            
            {
                "render": function (data, type, full)
                {
                    return "<a href='Advertisement/Edit/" + full.advertisementID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-ui-edit'></i></a>";                        
                }
            },
            {
                "render": function (data, type, full) {
                    return "<a href='Advertisement/Edit/" + full.advertisementID + "' class='btn btn-danger btn-mini btn-outline-primary'><i class='icofont icofont-ui-close'></i></a>";        
                }
            },
           
        ]
    });
});  

function ConvertToDDMMYYYY(dateString) {
    //alert(dateString);
    date = new Date(dateString);
    year = date.getFullYear();
    month = date.getMonth() + 1;
    dt = date.getDate();

    if (dt < 10) {
        dt = '0' + dt;
    }
    if (month < 10) {
        month = '0' + month;
    }
    var result = dt + '-' + month + '-' + year;
    return result;
}
function ConvertToIndian(num) {
    result = new Number(num).toLocaleString("hi-IN", { maximumFractionDigits: 2, style: 'currency', currency: 'INR' });
    return result;
}

