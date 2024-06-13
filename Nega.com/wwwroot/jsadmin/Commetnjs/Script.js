$(document).ready(function () {
    var blogggid = $("#BLOgid").val();
    if (blogggid) {
        Getall(blogggid);
    } else {
        console.log("Blog ID bulunamadı.");
    }

    $("#SUBbtn").on("click", function () {
        if ($("#CONtent").val() === null || $("#CONtent").val().length < 10) {
            $("#res").css("color", "red");
            $("#res").show().text("لطفا بعد از نوشتن کامنت امتحان کنید و کمترین تعداد کلمه ی مورد فبول 10 میباشد");
            setTimeout(function () {
                $("#res").css("display", "none");
            }, 5000); // 5 saniye
        } else {
            const c = {
                BlogId: $("#BLOgid").val(),
                Content: $("#CONtent").val()
            };

            $.ajax({
                url: '/BlogDet/CreateComment',
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(c),
                success: function (response) {
                    $("#res").show().text("کامنت ثبت شد");
                    $("#res").css("color", "green");
                    $("#CONtent").val(""); // İçeriği temizler
                    console.log("کامنت ثبت شد");
                    setTimeout(function () {
                        $("#res").css("display", "none");
                    }, 5000); // 5 saniye
                    Getall(c.BlogId);
                },
                error: function () {
                    $("#res").css("color", "red");
                    $("#res").text("بعد از ورود به سایت امتحان کنید").show();
                    setTimeout(function () {
                        $("#res").css("display", "none");
                    }, 5000); // 5 saniye
                }
            });
        }
    });
    function timeSince(date) {
        const seconds = Math.floor((new Date() - new Date(date)) / 1000);
        let interval = Math.floor(seconds / 31536000);

        if (interval >= 1) {
            return interval + " سال قبل";
        }
        interval = Math.floor(seconds / 2592000);
        if (interval >= 1) {
            return interval + " ماه قبل";
        }
        interval = Math.floor(seconds / 86400);
        if (interval >= 1) {
            return interval + " روز قبل";
        }
        interval = Math.floor(seconds / 3600);
        if (interval >= 1) {
            return interval + " ساعت قبل";
        }
        interval = Math.floor(seconds / 60);
        if (interval >= 1) {
            return interval + " دقیقه قبل";
        }
        return Math.floor(seconds) + " سانیه قبل";
    }
    function Getall(blogId) {
        console.log("Getall fonksiyonu çağrıldı, blogId:", blogId);
        $.ajax({
            url: "/BlogDet/GetBlogComments/",
            type: "GET",
            data: { blogId: blogId },
            success: function (response) {
                // Tüm mevcut yorumları temizle
                $("#GettComment").empty();
                console.log(response);
               
                response.forEach(function (item) {
                    
                    let list = `
                    <li style="width:100%;">
                        <div class="col-lg-12" style="float:inline-start">
                            <div class="row">
                                <div class="col-lg-2">
                                    <div class="author-thumb">
                                        <img src="/image/Pack/${item.userpic}" alt="">
                                    </div>
                                </div>
                                <div class="col-lg-10">
                                    <div class="right-content">
                                        <h4>${item.username} <span><small>${timeSince(item.date)}</small></span></h4>
                                        <p>${item.content}</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>`;
                    
                    $("#GettComment").append(list);
                });
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.error("Yorumlar alınırken bir hata oluştu: ", status, error);
                console.log(xhr.responseText); // Sunucu yanıtını kontrol et
                console.error('AJAX error:', status, error);
            }
        });
    }


});
