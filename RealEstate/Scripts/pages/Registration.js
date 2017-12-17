$(function () {

    var i = 0;

    $("#DropDownList1").change(function () {
        if ($("#DropDownList1").val() == "u") {           
            $("#company").hide();
        } else if ($("#DropDownList1").val() == "b") {
            $("#company").show();
            
        } else {
            $("#company").hide();            
        }

    });   
});