$(function () {
    $("#fromdate").datepicker({
});

$("#buy").on('click',function () {

    var bid = $('#bidtxt').val();
    var bowner = $('#busernametxt').val();
    var customer = $('#usernametxt').val();
    var bcost = $('#bcosttxt').val();
    var cashbox = $('#cashbox').val();   
    if (cashbox > bcost) {
        alert("You don't have sufficient amount in cash box");
    } else {
        $.ajax({
            type: "POST",
            url: "Buy_Rental.aspx/BuyBuilding",
            data: "{ bid:\"" + bid + "\",bowner:\"" + bowner + "\",customer:\"" + customer + "\",bcost:\"" + bcost + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    alert("You have successfully bought the building");
                    window.location.href = "CustomerHome.aspx";
                } else {
                    alert("Something Went wrong. Please try again later.");
                }
            }

        });
    }

});

$("#rental").click(function () {
    var bid = $("#bidtxt").val();
    var bowner = $("#busernametxt").val();
    var customer = $("#usernametxt").val();
    var brentalcost = $("#brentaltxt").val();
    var fromdate = $("#fromdate").val();
    var months = $("#months").val();
    var cashbox = $("#cashbox").val();
    var totalcost = brentalcost * months;
    if (fromdate.length == 0) {
        alert("Please select the from date");
    } else if (months.length == 0) {
        alert("Please enter the total months");
    } else if (cashbox < totalcost) {
        alert("You don't have sufficient amount in cash box");
    } else {
        $.ajax({
            type: "POST",
            url: "Buy_Rental.aspx/rentalBuilding",
            data: "{ bid:\"" + bid + "\",bowner:\"" + bowner + "\",customer:\"" + customer + "\",brentalcost:\"" + brentalcost + "\",fromdate:\"" + fromdate + "\",months:\"" + months + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    alert("You have successfully rented the building");
                    window.location.href = "CustomerHome.aspx";
                } else {
                    alert("Something Went wrong. Please try again later.");
                }
            }

        });
    }

});

});