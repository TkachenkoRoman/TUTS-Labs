function drawChart(funcNumber) {
    var title;
    switch (funcNumber) {
        case 0:
            title = "F(t)";
            break;
        case 1:
            title = "A(ω)";
	        break;
        default:
            title = "ϕ(ω)";
    }
    $("#error").addClass("hide");
    $.get("/Home/GetChartData",
        {
            a: $("#a").val(),
            k: $("#k").val(),
            type: $("input[name=type]:checked").val(),
            funcNumber: funcNumber
        },
        function (data) {
            if (!data.isValid) {
                $("#error").toggle();
                //var divForError = $("#error")[0];
                $("#error")[0].textContent = "You entered wrong data. All values must be doubles";
                $("#error").removeClass("hide");
                return;
            }

            var xAxis = data.x.slice();
            xAxis.unshift("x");
            var yAxis = data.y.slice();
            yAxis.unshift(title);
            var yInput = data.input.slice();
            yInput.unshift("Input [sin(t)]");
            c3.generate({
                bindto: "#chart",
                data: {
                    x: "x",
                    columns: [
                        xAxis,
                        yAxis,
                        yInput
                        //["x", 0.01, 0.05, 0.1, 0.5, 1, 2],
                        //["dx/dt", 1, 2, 3, 4, 5, 6]
                    ]
                }
            });
        }
    );
}