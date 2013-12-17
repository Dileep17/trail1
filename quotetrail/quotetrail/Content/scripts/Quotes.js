
// talk to people how to implement a dropdown whose values are populated on demand
$(function () {
    $("#dropdownloader").mouseenter(function (e) {
        if ($("#dropdownloader").attr("data-update") == "false") {
            e.preventDefault();
            $.post("/Home/GetProjects", null, function(data) {
                var selected = $("#projects :selected").val();
                $("#projects").empty();
                $("#projects").append("<option>Select Project</option>");
                $.each(data, function(i, option) {
                    $("#projects").append("<option>" + option + "</option>");
                });
                $("#projects").val(selected);
                $("#dropdownloader").attr('data-update', "true");
            });
        }
    });

    // to udpate the Quotes display in UI
    $("#projects").change(function (e) {
        $.post("/Home/GetQuotes", $("#projects :selected").val(), function (data) {
            var json = $.parseJSON(data);
            var strinnerhtml = "<table style='width:100%'>";
            $.each(json.quotes,function (key,val) {
                strinnerhtml = strinnerhtml + "<tr><td>" + val.quote + "&nbsp-&nbsp" + val.quoted_by + "</td></tr>";
            });
            strinnerhtml = strinnerhtml + "</table>";
            $("#contentofquote").html(strinnerhtml);
        });
        $("#dropdownloader").attr('data-update', "false");
    });
});




        
        
       