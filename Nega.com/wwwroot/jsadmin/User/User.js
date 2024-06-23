



$(document).ready(function () {
    $('#myForm').on('submit', function (event) {
        if ($("#PName").val() === "" || $("#Family").val() === "" || $("#Email").val() === "" || $("#UserName").val() === "" || $("#Password").val() === "" || $("#ConfirmPassword").val() === "") {
            event.preventDefault(); // Formun submit edilmesini engelle
            $("#wrong").html("fill in information");
            setTimeout(function () {
                $("#wrong").css("display", "none");
            }, 5000); // 5 saniye
        }
    });
   
});






