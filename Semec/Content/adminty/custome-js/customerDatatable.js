$(document).ready(function () {
    $("#customerDatatable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/State/GetState",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],            
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "stateID", "name": "stateID", "autoWidth": true },
            { "data": "stateName", "name": "stateName", "autoWidth": true },
            { "data": "stateType", "name": "stateType", "autoWidth": true },
            { "data": "countryID", "name": "countryID", "autoWidth": true },   
            
            {
                "render": function (data, type, full) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + full.stateID + "'); >Delete</a>"; }
            },
        ]
    });
});  

function DeleteCustomer(id) {
    alert(id);
}