$(document).ready(function () {
    $("#dtTable").dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,

        "ajax": {
            "url": "/Desgination/GetIndex",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],            
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "DesginationID", "name": "DesginationID"  },
            { "data": "DesginationName", "name": "DesginationName", "autoWidth": true },
            { "data": "Remark", "name": "Remark", "autoWidth": true },
            {
                "render": function (data, type, full)
                {
                    return "<a href='/DealersManage/Desgination/Edit/" + full.DesginationID + "' class='btn btn-success btn-mini btn-outline-primary'><i class='icofont icofont-ui-edit'></i></a>";
                }
            },
            {
                "render": function (data, type, full) {
                    return "<a href='/DealersManage/Desgination/Delete/" + full.DesginationID + "' class='btn btn-danger btn-mini btn-outline-primary'><i class='icofont icofont-ui-close'></i></a>";
                }
            },
           
        ]
    });
});  

