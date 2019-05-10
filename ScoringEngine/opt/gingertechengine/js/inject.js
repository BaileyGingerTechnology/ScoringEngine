function replaceText(title, file) {
    document.getElementById('InjectName').textContent = title;
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.onreadystatechange = function () {
        if (rawFile.readyState === 4) {
            if (rawFile.status === 200 || rawFile.status == 0) {
                var allText = rawFile.responseText;
                document.getElementById('InjectContent').textContent = allText;
            }
        }
    }
    rawFile.send(null);
}

$(document).ready(function () {
    $.getJSON("js/injects.json",
        function (json) {
            var tr;
            // Append each row to html table
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + json[i].title + "</td>");
                if (json[i].good == true) {
                    tr.append("<td><font color='green'>" + json[i].good + "</font></td>");
                }
                else if (json[i].good == false) {
                    tr.append("<td><font color='red'>" + json[i].good + "</font></td>");
                }
                tr.append("<td>" + json[i].asof + "</td>");
                $('table').append(tr);
            }
        });
});
