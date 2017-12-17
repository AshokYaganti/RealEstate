$(function () {

    var i = 0;

    $("#BuildingType").change(function () {
        if ($("#BuildingType").val() == "s") {
            $("#sell").show();
            $("#rental").hide();
            $("#rental1").hide();
        } else if ($("#BuildingType").val() == "r") {
            $("#rental").show();
            $("#rental1").show();
            $("#sell").hide();
        } else {
            $("#sell").hide();
            $("#rental").hide();
            $("#rental1").hide();
        }

    });

//    $("#ImageButton1").on('click', function (e) {
//        e.preventDefault();
//        i++;
//        var row = '<tr>' +
//          '<td></td>' +
//          '<td><input type="file" ID="fileupload' + i + '" style="width:192px;"/></td>' +
//          '</tr>';
//        $('#addrequesttable tr:last').after(row);
//        $("#count").val(i);
//    });
});