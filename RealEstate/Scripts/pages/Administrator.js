$(function () {
    $("#btnConfirm").click(function () {
        var username = $(this).attr("data-id");
        var retVal = confirm("Are you sure do you want to delete?");
        if (retVal == true) {
            $.ajax({
                type: "POST",
                url: "ManageAdministrators.aspx/deleteAdministrator",
                data: "{ username:\"" + username + "\" }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == "success") {
                        alert("Record has been Deleted");
                        window.location.href = "ManageAdministrators.aspx";
                    } else {
                        alert("Something Went wrong. Please try again later.");                        
                    }
                }

            });

        } else {
            return false;
        }
    });
});