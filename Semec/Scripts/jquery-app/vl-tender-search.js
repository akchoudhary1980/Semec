$(document).ready(function () { 
    $('form[id="departmentform"]').validate({
        rules: {
            DepartmentName: 'required',           
        },
        messages: {           
            DepartmentName: 'Please enter department name !',           
        },
        submitHandler: function (form) {
            form.submit();           
        }
    });
});