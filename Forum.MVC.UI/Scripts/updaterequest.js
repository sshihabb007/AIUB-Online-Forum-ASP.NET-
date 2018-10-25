$(document).ready(function () {
    $("#slt").change(function () {
        var select = $("#slt option: selected").text();
        if (select === "user_name" || select === "full_name" || select === "address") {
            $("#FieldValue").removeAttr("type");
            $("#FieldValue").removeAttr("readonly");
            $("#FieldValue").attr("type", "text");
            $("#FieldValue").removeClass("datetime");
            $("#FieldValue").removeClass("Phone");
            $("#FieldValue").removeClass("CGPA");
        }
        else if (select == "phone") {
            $("#FieldValue").removeAttr("type");
            $("#FieldValue").removeAttr("readonly");
            $("#FieldValue").attr("type", "text");
            $("#FieldValue").removeClass("datetime");
            $("#FieldValue").removeClass("CGPA");
            $("#FieldValue").addClass("Phone");
        }
        else if (select === "cgpa") {
            $("#FieldValue").removeAttr("type");
            $("#FieldValue").removeAttr("readonly");
            $("#FieldValue").attr("type", "text");
            $("#FieldValue").removeClass("datetime");
            $("#FieldValue").removeClass("Phone");
            $("#FieldValue").addClass("CGPA");
        }
    });
});
$(document).ready(function () {
    $(".CGPA").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });
});
$(".Phone").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^\d].+/, ""));
    if ((event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});