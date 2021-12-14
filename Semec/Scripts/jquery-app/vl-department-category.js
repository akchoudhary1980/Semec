$(document).ready(function () { 
    $('form[id="departmentcategoryform"]').validate({
        rules: {
            DepartmentCategoryName: 'required',           
        },
        messages: {           
            DepartmentCategoryName: 'Please enter department category name !',           
        },
        submitHandler: function (form) {
            form.submit();           
        }
    });
});