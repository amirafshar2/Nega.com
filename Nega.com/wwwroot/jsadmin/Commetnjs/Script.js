$(document).ready(function () {
    var blogId = $("#BLOgid").val();
    if (blogId) {
        Getall(blogId);
    } else {
        console.log("Blog ID bulunamadı.");
    }

    $("#SUBbtn").on("click", function () {
        var content = $("#CONtent").val();
        if (content === null || content.length < 10) {
            $("#res").css("color", "red");
            $("#res").show().text("لطفا بعد از نوشتن کامنت امتحان کنید و کمترین تعداد کلمه ی مورد فبول 10 میباشد");
            setTimeout(function () {
                $("#res").css("display", "none");
            }, 5000); // 5 saniye
        } else {
            const comment = {
                BlogId: $("#BLOgid").val(),
                Content: content
            };

            $.ajax({
                url: '/BlogDet/CreateComment',
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(comment),
                success: function (response) {
                    $("#res").show().text("کامنت ثبت شد");
                    $("#res").css("color", "green");
                    $("#CONtent").val(""); // İçeriği temizler
                    console.log("کامنت ثبت شد");
                    setTimeout(function () {
                        $("#res").css("display", "none");
                    }, 5000); // 5 saniye
                    Getall(comment.BlogId);
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
        return Math.floor(seconds) + " ثانیه قبل";
    }

    function Getall(blogId) {
        console.log("Getall fonksiyonu çağrıldı, blogId:", blogId);
        $.ajax({
            url: "/BlogDet/GetBlogComments",
            type: "GET",
            data: { blogId: blogId },
            success: function (response) {
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
                                    <div class="col-lg-8">
                                        <div class="right-content">
                                            <h4>${item.username} <span><small>${timeSince(item.date)}</small></span></h4>
                                            <p>${item.content}</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div  style="color: #2ac2b6;">   <a  style="color: #2ac2b6;" class="btn btn-twitter toggle-comments" data-comment-id="${item.id}"><i class="fa fa-reply-all" aria-hidden="true"></i><small>پاسخ ها</small></a> </div>
                                        <div style="color: #2ac2b6;">  <a  style="color: #2ac2b6;" class="btn btn-twitter toggle-comments-Add" data-comment-id="${item.id}">  <i class="fa fa-reply" aria-hidden="true"></i><small>درج پاسخ </small></a></div>
                                    </div>
                                </div>
                                <div id="REPlay_${item.id}">
                                </div>
                                <div id="REPlayadd_${item.id}">
                                </div>
                            </div>
                        </li>`;
                    $("#GettComment").append(list);
                });
                console.log(response);

                $(".toggle-comments").off("click").on("click", function (e) {
                    e.preventDefault();
                    const commentId = $(this).data("comment-id");
                    GetReplay_bay_Commentid(commentId);
                });

                $(".toggle-comments-Add").off("click").on("click", function (e) {
                    e.preventDefault();
                    const commentId = $(this).data("comment-id");
                    const target = $(`#REPlayadd_${commentId}`);
                    var replayAdd = `
                        <div class="row">
                            <div class="col-lg-10 m-4">
                                <textarea rows="6" class="repcontent${commentId}" placeholder="پاسخ کامنت را بنویسید" required></textarea>
                                <input type="text" hidden class="comentidd${commentId}" value="${commentId}" />
                            </div>
                            <div class="col-lg-10">
                                <button class="repbtn" data-comment-id="${commentId}" style="background-color: #5fc3b1; cursor:pointer;" class="btn">ذخیره</button>
                            </div>
                            <div id="resr_${commentId}" style="display: none;" class="m-2"></div>
                        </div>`;

                    if (target.html().trim() === "") {
                        target.hide().html(replayAdd).fadeIn(500);
                    } else {
                        target.fadeOut(500, function () {
                            $(this).empty().show();
                        });
                    }
                });

                $(document).off("click", ".repbtn").on("click", ".repbtn", function (e) {
                    e.preventDefault();
                    const commentId = $(this).data("comment-id");
                    const content = $(`.repcontent${commentId}`).val();
                    AddReplay(commentId, content);
                });

            },
            error: function (xhr, status, error) {
                console.error("Yorumlar alınırken bir hata oluştu: ", status, error);
                console.log(xhr.responseText);
            }
        });
    }

    function AddReplay(commentId, content) {
        if (content === null || content.length < 10) {
            $("#resr_" + commentId).css("color", "red");
            $("#resr_" + commentId).show().text("لطفا بعد از نوشتن کامنت امتحان کنید و کمترین تعداد کلمه ی مورد فبول 10 میباشد");
            setTimeout(function () {
                $("#resr_" + commentId).css("display", "none");
            }, 5000); // 5 saniye
        } else {
            console.log(commentId);
            console.log(content);
            const replayData = {
                CommentId: commentId,
                Content: content
            };
            console.log("Sending data:", JSON.stringify(replayData));
            $.ajax({
                url: '/BlogDet/CreateReplay/',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(replayData),
                success: function (response) {
                    console.log("Replay added successfully:", response);
                    GetReplay_bay_Commentid(commentId);
                },
                error: function (xhr, status, error) {
                    console.error("Error adding replay:", status, error);
                    $("#resr_" + commentId).css("color", "red");
                    $("#resr_" + commentId).show().text("پس از ورود به سایت دوباره تلاش کنید");
                    setTimeout(function () {
                        $("#resr_" + commentId).css("display", "none");
                    }, 5000); // 5 saniye
                }
            });
        }
    }

    function GetReplay_bay_Commentid(commentId) {
        $.ajax({
            url: "/BlogDet/GetCommentReplay",
            type: "GET",
            data: { id: commentId },
            success: function (response) {
                console.log(response);
                let replyContent = '';
                if (response.length == 0) {
                    replyContent += `
                        <div style="margin:3% 19% 0% 0%;" class="reply-container">
                            <div class="author-thumb">
                                 <p>اولین پاسخ را شما درج کنید</p>
                            </div>
                         </div>`;
                    $(`#REPlay_${commentId}`).hide().html(replyContent).fadeIn(500);
                    setTimeout(function () {
                        $(`#REPlay_${commentId}`).fadeOut(500, function () {
                            $(this).empty().show();
                        });
                    }, 5000);
                } else {
                    response.forEach(function (reply) {
                        replyContent += `
                            <div style="margin:3% 19% 0% 0%;" class="reply-container">
                                <div class="author-thumb">
                                    <img src="/image/Pack/${reply.userpic}" alt="">
                                </div>
                                <div class="right-content">
                                    <h4>${reply.username}<span style="margin: 0% 6%;">${timeSince(reply.createdAt)}</span></h4>
                                    <p>${reply.content}</p>
                                </div>
                            </div>`;
                    });
                    $(`#REPlay_${commentId}`).hide().html(replyContent).fadeIn(500);
                }
            },
            error: function (xhr, status, error) {
                console.error("Yorumlar alınırken bir hata oluştu: ", status, error);
                console.log(xhr.responseText);
            }
        });
    }
});
