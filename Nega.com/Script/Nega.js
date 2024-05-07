{






    "Logging": {
        "LogLevel": {
            "Default": "Information",
                "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
$(document).ready(function () {



    function Package() {
        this.Name = "nn";
        this.Price = 1,05;
        this.Title = "dd";
        this.Content = "dd";
        this.Picture = File;
    }



    $("#PBtn").click(function () {
        if ($("#PName").val() !== "" && $("#PTitle").val() !== "" && $("#PPrice").val() !== "" && $("#PContent").val() !== "" && $("#PPic")[0].files[0] !== undefined) {

            var i = new Package();
            i.Name = $("#PName").val();
            i.Content = $("#PContent").val();
            i.Picture = $("#logo")[0].files[0];
            i.Price = $("#PPrice").val();
            i.Title = $("#PTitle").val();

            Create(i);
        }
        else {
            alert("Bilgileri Doldurun");
        }
    });

    function Create(a) {
        var formData = new FormData();
        formData.append("Name", a.Name);
        formData.append("Price", a.Price);
        formData.append("Title", a.Title);
        formData.append("Content", a.Content);
        formData.append("Picture", a.Picture);

        $.ajax({
            url: '/Admin/Package/Index',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function (xhr) {
                console.log('Ýstek gönderiliyor...');
                console.log(a);
            },
            success: function (data) {
                console.log(data);
                alert("Baþarýlý");
            },
            error: function (error) {
                console.error('Ýstek baþarýsýz oldu: ', error);
            }
        });
    }




    $('.custom-file-input').on('change', function () {
        let fileName = $(this).val().split('\\').pop();
        $(this).next('.custom-file-label').addClass("selected").html(fileName);
    });


















        //function Humen() {
        //    this.Name = "nn";
        //    this.Family = "mm";
        //    this.Age = 0;
        //}
        //var currentrow;



        //$("#ReadAll").click(function () {
        //    $('.Recor').remove();
        //    GetReadAll();

        //});







        //$("#SaveBtn").click(function () {
        //    if ($("#NameTxt").val() !== "" && $("#FamilyTxt").val() !== "" && $("#AgeTxt").val() !== "") {

        //        var i = new Humen();
        //        {
        //            i.Name = $("#NameTxt").val(),
        //                i.Family = $("#FamilyTxt").val(),
        //                i.Age = $("#AgeTxt").val()
        //        };
        //        Create(i);
        //    }
        //    else {
        //        alert("Bilgileri Doldurun");
        //    };
        //});
        //function Create(a) {
        //    $.ajax({
        //        url: '/Humen/Create',
        //        type: 'POST',
        //        data: { Name: a.Name, Family: a.Family, Age: a.Age },
        //        beforeSend: function (xhr) {

        //            console.log('Ýstek gönderiliyor...');

        //        },
        //        success: function (data) {
        //            console.log(data);
        //            alert(data);
        //            Text_Clear();
        //            $('.Recor').remove();
        //            GetReadAll();
        //        },
        //        error: function (error) {
        //            console.error('Ýstek baþarýsýz oldu: ', error);
        //        }
        //    });
        //    //$.get("/Humen/Create", a, function (Data) {
        //    //    alert(Data);
        //    //    Text_Clear();
        //    //    $('.Recor').remove();
        //    //    GetReadAll();
        //    //});
        //};
        //function ReadAll(all) {
        //    $.ajax({
        //        url: '/Humen/ReadAll',
        //        type: 'POST',
        //        beforeSend: function (xhr) {
        //            console.log("istek gönderildi...")
        //        },
        //        success: function (data) {
        //            console.log(data);
        //            all(data);

        //        },
        //        error: function (error) {
        //            console.error("istek baþarýsýz oldu");
        //        }
        //    });

        //    //$.get("/Humen/ReadAll", function (Data) {
        //    //    All(Data);
        //    //});
        //}

        //function GetReadAll() {
        //    ReadAll(function (Data) {

        //        for (var i in Data) {
        //            var rowData = Data[i];
        //            $('#RecordTbl').append('<div class=" col-12 col-xs-12 col-sm-12 col-md-10 col-l-6 col-xl-6 table-responsive Recor"> <table class=" table    table-hover " "><tr  style="cursor:pointer"  data-id="' + rowData.id + '" data-Name="' + rowData.Name + '" data-Family="' + rowData.Family + '" data-Age="' + rowData.Age + '" ><td>' + JSON.stringify(rowData.id) + '</td><td>' + JSON.stringify(rowData.Name) + '</td><td>' + JSON.stringify(rowData.Family) + '</td><td>' + JSON.stringify(rowData.Age) + '</td> <td><input type="button" value="Delete"  class="btn btn-danger mt-1 DelBtn" /><input type="button" value="Update" id="" class="btn btn-success m-1  UpBtn" /></td> </table></div>')
        //        }
        //    });
        //};

        //$("#RecordTbl").on('click', '.DelBtn', function () {
        //    var i = {};
        //    i.id = $(this).closest('tr').data("id");

        //    alert(i.id);
        //    i.Name = $(this).closest("tr").data("Name");
        //    i.Family = $(this).closest("tr").data("Family");
        //    i.Age = $(this).closest("tr").data("Age");
        //    var thiss = $(this);
        //    $.ajax({
        //        url: "/Humen/DeleteByÝd",
        //        type: "POST",
        //        data: { id: i.id },
        //        beforeSend: function (bfs) {
        //            console.log("istek gönderildi...");
        //        },
        //        success: function (data) {
        //            console.log(data);
        //            thiss.closest(".Recor").remove();

        //        },
        //        error: function (error) {
        //            console.log("istek baþarýsýz oldu");
        //        }
        //    });

        //    //$.get("/Humen/DeleteByÝd", i, function (data) {
        //    //    alert(data);
        //    //});


        //});


        //$("#RecordTbl").on('click', '.UpBtn', function () {

        //    currentrow = $(this).closest('table');
        //    if ($(this).val() == "Update") {
        //        var i = {};
        //        i.id = $(this).closest('tr').data('id');
        //        z = $(this).closest('tr').data('id');
        //        i.Name = $(this).closest("tr").data("name");
        //        i.Family = $(this).closest("tr").data("family");
        //        i.Age = $(this).closest("tr").data("age");
        //        $("#NameTxt").val(i.Name);
        //        $("#FamilyTxt").val(i.Family);
        //        $("#AgeTxt").val(i.Age);
        //        $(this).val("SaveChanges");
        //        $(".UpBtn").not($(this)).prop("disabled", true);
        //    }

        //    else if ($(this).val() == "SaveChanges") {
        //        if ($("#NameTxt").val() !== "" && $("#FamilyTxt").val() !== "" && $("#AgeTxt").val() !== "") {

        //            var i = {};
        //            i.id = $(this).closest('tr').data('id');
        //            i.Name = $("#NameTxt").val(),
        //                i.Family = $("#FamilyTxt").val(),
        //                i.Age = $("#AgeTxt").val()

        //            var thi = $(this);
        //            Update(i, function () {
        //                $(currentrow).find("td:eq(1)").text(i.Name);
        //                $(currentrow).find("td:eq(2)").text(i.Family);
        //                $(currentrow).find("td:eq(3)").text(i.Age);
        //                $("#NameTxt").val("");
        //                $("#FamilyTxt").val("");
        //                $("#AgeTxt").val("");
        //                $(thi).val("Update")
        //                $(".UpBtn").not($(this)).prop("disabled", false);
        //            });
        //        }
        //        else {
        //            alert("Bilgileri Doldurun");
        //        };
        //    }
        //});

        //function Update(i, callback) {
        //    //$.get("/Humen/Update", i, function (data) {
        //    //    alert(data);
        //    //    callback();
        //    //});
        //    $.ajax({
        //        url: "/Humen/Update",
        //        type: "POST",
        //        data: { id: i.id, Name: i.Name, Family: i.Family, Age: i.Age },
        //        beforeSend: function (bfs) {
        //            console.log("istek gönderildi...");

        //        },
        //        success: function (data) {
        //            console.log(data);

        //            callback();
        //        },
        //        error: function (error) {
        //            console.error("istek baþarýsýz oldu");
        //        }

        //    });
        //};









        //function GetReadAll() {
        //    ReadAll(function (Data) {
        //        for (var i in Data) {
        //            var rowData = Data[i]; // Satýr verilerini saklamak için

        //            // ...

        //            // Silme düðmesine sýnýf ekleyin ve data-* özelliði kullanarak satýr verilerini saklayýn
        //            $('#RecordTbl').append('<div class="w-50 table-responsive Recor"> <table class="table table-hover x"> <tr style="cursor:pointer" data-id="' + rowData.id + '" data-name="' + rowData.Name + '" data-family="' + rowData.Family + '" data-age="' + rowData.Age + '"><td>' + JSON.stringify(rowData.id) + '</td><td>' + JSON.stringify(rowData.Name) + '</td><td>' + JSON.stringify(rowData.Family) + '</td><td>' + JSON.stringify(rowData.Age) + '</td> <td><input type="button" value="Delete" class="btn btn-danger mt-1 DelBtn" /></td> <td><input type="button" value="Update" class="btn btn-success mt-1 UpBtn" /></td>  </table></div>');
        //        }
        //    });

        //    // Silme düðmesine týklama olayýný dinle
        //    $('#RecordTbl').on('click', '.DelBtn', function () {
        //        // Týklanan satýr verilerini al
        //        var id = $(this).closest('tr').data('id');
        //        var name = $(this).closest('tr').data('name');
        //        var family = $(this).closest('tr').data('family');
        //        var age = $(this).closest('tr').data('age');

        //        // Silme iþlemini gerçekleþtir
        //        // Burada silme iþlemi veya baþka bir iþlem yapabilirsiniz
        //        // Örneðin: DeleteRecord(id, name, family, age);

        //        // Silinen satýrý arayüzden kaldýrabilirsiniz
        //        $(this).closest('.Recor').remove();
        //    });

        //    // Diðer iþlemleri dinlemek için ayný mantýðý kullanabilirsiniz
        //    // $('#RecordTbl').on('click', '.UpBtn', function () {
        //    //     // ...
        //    // });
        //}


        //$("#SearchByÝd").click(function () {
        //    ReadByÝd($("#SearchTxt").val(), function () { alert(i.Name + " " + i.Family); });
        //});

        //function ReadByÝd(pid , callback ) {
        //    $.get("/Humen/ReadByÝd", { id: pid }, function (H) {
        //        i.Name = h.Name;
        //        i.Family = h.Family;
        //        i.Age = h.Age;
        //        i.id = h.id;
        //        callback();
        //    });
        //}
        //var Humen;
        //$("#SearchByÝd").click(function () {
        //    alert($("#SearchTxt").val());
        //    ReadByÝd($("#SearchTxt").val(), function (Humen) { alert(Humen.Name + " " + Humen.Family + " " + Humen.Age); });
        //});

        //function ReadByÝd(pid,  callback) {
        //    $.ajax({
        //        url: "/Humen/ReaDByÝd",
        //        type: "POST",
        //        data: { id: pid },
        //        beforeSend: function (bfs) {
        //            console.log("istek gönderildi...");

        //        },
        //        success: function (h) {
        //            console.log(h);
        //            Humen.Name = h.Name;
        //            Humen.Family = h.Family;
        //            Humen.Age = h.Age;
        //            Humen.id = h.id;
        //            callback();
        //        },
        //        error: function (error) {
        //            console.error("istek baþarýsýz oldu");
        //        }
        //    });




        //$.get("/Humen/ReadByÝd", { id: pid }, function (h) {
        //    i = {
        //        Name: h.Name,
        //        Family: h.Family,
        //        Age: h.Age,
        //        id: h.id
        //    };
        //    callback(i);
        //});
        /*}*/


        //var Humen = {}; // Humen'ý boþ bir nesne olarak tanýmla

        //$("#SearchByÝd").click(function () {
        //    alert($("#SearchTxt").val());
        //    ReadByÝd($("#SearchTxt").val(), function (Humen) {
        //        alert(Humen.Name + " " + Humen.Family + " " + Humen.Age);
        //    });
        //});

        //function ReadByÝd(pid, callback) {
        //    $.ajax({
        //        url: "/Humen/ReaDByÝd",
        //        type: "POST",
        //        data: { id: pid },
        //        beforeSend: function (bfs) {
        //            console.log("istek gönderildi...");
        //        },
        //        success: function (h) {
        //            console.log(h);
        //            // Humen nesnesinin özelliklerini doldur
        //            Humen.Name = h.Name;
        //            Humen.Family = h.Family;
        //            Humen.Age = h.Age;
        //            Humen.id = h.id;
        //            callback(Humen); // callback fonksiyonunu Humen nesnesi ile çaðýr
        //        },
        //        error: function (error) {
        //            console.error("istek baþarýsýz oldu");
        //        }
        //    });
        //}


        //function Text_Clear() {
        //    $("#NameTxt").val("");
        //    $("#FamilyTxt").val("");
        //    $("#AgeTxt").val("");
        //};



        
    });