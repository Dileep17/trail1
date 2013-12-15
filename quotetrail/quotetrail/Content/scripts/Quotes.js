$(function () {
    $("#dropdownloader").mouseenter(function (e) {
        e.preventDefault();
        $.post("/Home/GetProjects", null, function (data) {
            $("#projects").empty();
            $("#projects").append("<option>Select Project</option>");
            $.each(data, function (i, option) {
                $("#projects").append("<option>" + option + "</option>");
            });
        });
    });
});

        
        
       