$(document).ready(function () {    
    // for form validation
    $('form[id="itemform"]').validate({
        rules: {
            ItemName: 'required',           
        },
        messages: {           
            ItemName: 'Please enter item name !',           
        },
        submitHandler: function (form) {
            form.submit();           
        }
    });
});

function uploadPicture(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#logoPicture')
                .attr('src', e.target.result)
                .width(150)
                .height(100);
        };
        reader.readAsDataURL(input.files[0]);
    }
}