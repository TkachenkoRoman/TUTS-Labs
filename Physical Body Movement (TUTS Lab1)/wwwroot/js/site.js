﻿function drawChart() {
    $("#error").addClass("hide");
    $("#success").addClass("hide");
    $.get("/Home/GetChartData",
        {
            a1: $("#a1").val(),
            a2: $("#a2").val(),
            time: $("#time").val(),
            x0: $("#x0").val(),
            x1: $("#x1").val()
        },
        function (data) {
            if (!data.isValid) {
	            $("#error").toggle();
                $("#error")[0].textContent = "You entered wrong data. All values must be doubles";
	            $("#error").removeClass("hide");
                return;
            }

            var xAxis = data.x.slice();
            xAxis.unshift("x");
            var yAxis = data.y.slice();
            yAxis.unshift("dx/dt");
            c3.generate({
                bindto: "#chart",
                data: {
                    x: "x",
                    columns: [
                        xAxis,
                        yAxis
                        //["x", 0.01, 0.05, 0.1, 0.5, 1, 2],
                        //["dx/dt", 1, 2, 3, 4, 5, 6]
                    ]
                }
            });

            $("#success").toggle();
            $("#success")[0].textContent = "Total time is " + data.totalTime + " seconds";
            $("#success").removeClass("hide");
        }
    );
}