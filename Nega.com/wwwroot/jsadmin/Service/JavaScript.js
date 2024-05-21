$(document).ready(function () {



    function showclas(btn, clas) {
        $("#" + btn).click(function () {
            var b = $("#" + btn);
            var c = $("#" + clas);
            if (c.is(":visible")) {
                c.hide();
                b.html("Add New Page");
            } else {
                c.show();
                b.html("Cancel");

            }
        });

    }

    showclas("btnid", "boxcon");












});