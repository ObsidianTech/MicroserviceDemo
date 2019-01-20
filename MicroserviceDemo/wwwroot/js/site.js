$(document).ready(function () {

    var Picture = $("#Picture");

    var PictureName = $("#PictureName");

    var next = $("#next");

    var back = $("#back");

    var currentPic = 0;

    var Amount = 0;

    $.ajax({

        url: 'http://18.217.145.205:81/api/Pictures/',

        type: "GET",

        dataType: "json",

        processData: true,

        success: function (response) {

            console.log("success");

            loadPicture(response);

        }

    });

    $.ajax({

        url: 'http://18.217.145.205:81/api/Pictures/Amount',

        type: "GET",

        dataType: "json",

        processData: true,

        success: function (response) {

            console.log("amount");

            assignAmount(response);

        }

    });

    function loadPicture(data) {

        Picture.attr('src', `data:image/jpg;base64,${data.pictureFile}`);

        Picture.addClass("picture");

        PictureName.html(data.name);

        currentPic = data.id;

        checkAmount();

    };

    function assignAmount(data) {

        Amount = data;

    };

    function checkAmount() {
        if (currentPic == 1) {
            back.hide();
        };

        if (currentPic > 1) {
            back.show();
        };

        if (currentPic == Amount) {
            next.hide();
        };

        if (currentPic < Amount) {
            next.show();
        }
    };

    next.on("click", function () {

        var nextPic = currentPic + 1;

        $.ajax({

            url: 'http://18.217.145.205:81/api/Pictures/' + nextPic,

            type: "GET",

            dataType: "json",

            processData: true,

            success: function (response) {

                console.log("success");

                loadPicture(response);

            }

        });

    });

    back.on("click", function () {

        var nextPic = currentPic - 1;

        $.ajax({

            url: 'http://18.217.145.205:81/api/Pictures/' + nextPic,

            type: "GET",

            dataType: "json",

            processData: true,

            success: function (response) {

                console.log("success");

                loadPicture(response);

            }

        });

    });

});