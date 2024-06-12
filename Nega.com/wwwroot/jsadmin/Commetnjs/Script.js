$(document).ready(function () {


    $("#subbtn").on("click", function () {
        console.log("btn");
        //const commentData = {
        //    blogId: $("#blogid").val(),
        //    content: $("#content").val()
        //};

        //$.ajax({
        //    url: '@Url.Action("CreateComment", "BlogDet")', // AJAX isteğinin doğru URL'si
        //    type: "POST",
        //    contentType: "application/json",
        //    data: JSON.stringify(commentData),
        //    success: function (response) {
        //        $("#res").show().text("کامنت ثبت شد");
        //        $("#res").css("color", "green");
        //        $("#content").val(""); // İçeriği temizler
        //        console.log("کامنت ثبت شد");
        //        setTimeout(function () {
        //            $("#res").css("display", "none");
        //        }, 10000); // 10 saniye
        //    },
        //    error: function () {
        //        $("#res").css("color", "red");
        //        $("#res").text("لطفا بعد امتحان کنید").show();
        //        setTimeout(function () {
        //            $("#res").css("display", "none");
        //        }, 10000); // 10 saniye
        //    }
        //});
    });


    function Getall(blogId) {
        $.ajax({
            url: "/BlogDet/GetBlogComments",
            type: "GET",
            data: { blogId: blogId }, // blogId'yi veri olarak iletecek
            success: function (response) {
                // Yanıtı burada işle, yorumları UI ile güncelle
                console.log(response); // Test için, yanıtı konsola yazdır
            },
            error: function () {
                // Herhangi bir hata durumunda işle
            }
        });
    }







});
