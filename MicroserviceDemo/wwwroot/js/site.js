$(document).ready(function () {

    var Picture = $("#Picture");

    var PictureName = $("#PictureName");



    $.ajax({

        url: 'http://18.217.145.205:81/api/Pictures/2',

        type: "GET",

        dataType: "json",

        processData: true,

        success: function (response) {

            console.log("success");

            loadPicture(response);

        }

    });



    function loadPicture(data) {

        Picture.attr('src', `data:image/jpg;base64,${data.pictureFile}`);
        Picture.addClass("picture");
    };

});