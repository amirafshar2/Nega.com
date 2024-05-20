$(document).ready(function () {
    $('#logo').on('change', function () {
        let fileName = $(this).val().split('\\').pop();
        $(this).next('.custom-file-label').addClass("selected").html(fileName);
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#preview').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });

    function setupFileInputChangeHandler(inputId, previewId) {
        $('#' + inputId).on('change', function () {
            let fileName = $(this).val().split('\\').pop();
            $(this).next('.custom-file-label').addClass("selected").html(fileName);
            if (this.files && this.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#' + previewId).attr('src', e.target.result);
                }
                reader.readAsDataURL(this.files[0]);
            }
        });
    }

    setupFileInputChangeHandler('logo1', 'preview1');


});