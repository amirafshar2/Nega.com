$(document).ready(function () {



    //$("#partbtn2").click(function () {
    //    var partt3 = $("#collapse1");
    //    if (partt3.is(":visible")) {
    //        partt3.hide();
    //        $(this).html('<i class="fa fa-plus"></i> Add New Package');
           
    //    } else {
    //        partt3.show();
    //        $(this).html("Cancel");
    //        var part4 = $("#parttot3");
    //        part4.show();
    //    }
    //});

  
    


    function showpart(coll, btn, partn) {
        $("#"+ btn).click(function () {
        var partt3 = $("#" + coll);
        var button = $("#" + btn);
        var part4 = $("#" + partn);

        if (partt3.is(":visible")) {
            partt3.hide();
            button.html('<i class="fa fa-plus"></i> Add New Page');
        } else {
            partt3.show();
            button.html("Cancel");
            part4.show();
            }
        });
    }

    // Fonksiyon çağrısı
    showpart("collapse1", "partbtn2", "parttot3");
    showpart("collapse2", "partbtn3", "parttot4");
    showpart("collapse3", "partbtn4", "parttot5");
    showpart("collapse5", "partbtn5", "parttot6");
    showpart("collapse6", "partbtn6", "parttot7");
    showpart("collapse7", "partbtn7", "parttot8");
    showpart("collapse8", "partbtn8", "parttot9");
    showpart("collapse9", "partbtn9", "parttot10");
    showpart("collapse10", "partbtn10", "partto");






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

    setupFileInputChangeHandler('logo',  'preview' );
    setupFileInputChangeHandler('logo2', 'preview2');
    setupFileInputChangeHandler('logo3', 'preview3');
    setupFileInputChangeHandler('logo4', 'preview4');
    setupFileInputChangeHandler('logo5', 'preview5');
    setupFileInputChangeHandler('logo6', 'preview6');
    setupFileInputChangeHandler('logo7', 'preview7');
    setupFileInputChangeHandler('logo8', 'preview8');
    setupFileInputChangeHandler('logo9', 'preview9');
    setupFileInputChangeHandler('logo10','preview10');




    $("#add-package-btn").click(function () {
        var pacadd = $("#pacadd");
        if (pacadd.is(":visible")) {
            pacadd.hide();
            $(this).val("Add New Page");
        } else {
            pacadd.show();
            $(this).val("Cancel");
        }
    });
});