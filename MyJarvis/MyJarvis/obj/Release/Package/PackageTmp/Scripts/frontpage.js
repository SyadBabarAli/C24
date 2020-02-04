//jQuery to collapse the stats on scroll
$(window).scroll(function () {
    if ($(".stats").offset().top > 90) {
        $(".stats-fixed").addClass("stats-collapse");
    } else {
        $(".stats-fixed").removeClass("stats-collapse");
    }
});

//jQuery for page scrolling feature - requires jQuery Easing plugin
$(function () {
    $('a.page-scroll').bind('click', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

$(document).ready(function () {
    TicketsTrend();
    T2OffPeakAvgResponseTime();
    T2OnSiteAvgResponseTime();
    T2OffPeakResponseSLAStatus();
    T2OnSiteResponseSLAStatus();
    T2CommunicationsAvgResolutionTime();
    T2GulshanAvgResolutionTime();
    T2NetworksAvgResolutionTime();
    T2OffPeakAvgResolutionTime();
    T2OffSiteAvgResolutionTime();
    T2OnSiteAvgResolutionTime();
    T2CentralAvgResolutionTime();
    T2CommunicationsSLAStatus();
    T2GulshanSLAStatus();
    T2NetworksSLAStatus();
    T2OffPeakSLAStatus();
    T2OffSiteSLAStatus();
    T2OnSiteSLAStatus();
    T2CentralSLAStatus();
})

function TicketsTrend() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/TicketsTrend",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data1 = [];
            var data2 = [];
            for (var i in Result) {
                var serie1 = new Array('', Result[i].Reported);
                data1.push(serie1);
                var serie2 = new Array('', Result[i].Resolved);
                data2.push(serie2);
            }
            DreawChart(data1, data2);
        },
        error: function (Result) {
            alert("Error");
        }
    });
}

function DreawChart(series1, series2) {
    var n = new Date();
    var d = n.getDate();
    var m = n.getMonth();
    var y = n.getYear();
    var h = n.getHours();

    $('#TicketsTrend').highcharts({
        xAxis: {
            plotBands: [{ // mark the weekend
                color: '#FFCDD2',
                from: Date.UTC(y, m, d, h),
                to: Date.UTC(y, m, d, h -24)
            }],
            tickInterval: 3600 * 1000,
            // one day
            type: 'datetime',
            dateTimeLabelFormats: { hour: '%H:%M', day: '%H:%M' }
        },
        colors: ['#E57373', '#81C784'],
        chart: {
            type: 'area'
        },
        tooltip: {
            xDateFormat: '<b>%H:%M</b>',
            shared: true
        },
        title: {
            text: ''
        },
        //tooltip: {
        //    pointFormat: '{series.name}: <b>{point.y}</b>'
        //},
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                },
            },
            area: {
                marker: {
                    enabled: false,
                    symbol: 'circle',
                    radius: 2,
                    states: {
                        hover: {
                            enabled: true
                        }
                    }
                }
            },
            series: {
                pointStart: Date.UTC(y, m, d),
                pointInterval: 3600 * 1000,
                type: 'area'
            }
        },
        yAxis: {
            title: {
                text: 'Number of Tickets'
            }
        },
        series: [{
            name: 'Reported',
            data: series1
        }, {
            name: 'Resolved',
            data: series2
        }]
    });
}

//function TicketsTrend() {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "WebService.asmx/TicketsTrend",
//        data: "{}",
//        dataType: "json",
//        success: function (Result) {
//            Result = Result.d;
//            var data1 = [];
//            var data2 = [];
//            for (var i in Result) {
//                var series1 = new Array(Result[i].Hour, Result[i].Reported);
//                data1.push(series1);
//                var series2 = new Array(Result[i].Hour, Result[i].Resolved);
//                data2.push(series2);
//            }
//            TicketsTrendChart(data1, data2);
//        },
//        error: function (Result) {
//            //alert("Error");
//        }
//    });
//}

//function TicketsTrendChart(series1, series2) {
//    $('#TicketsTrend').highcharts({
//        chart: {
//            type: 'area'
//        },
//        colors: ['#E57373', '#81C784'],
//        tooltip: {
//            pointFormat: '{series.name}: {point.y}',
//            formatter: function () {
//                var rV = this.x + ":00 <br />";
//                rV += '<span style="color:' + this.point.color + '">\u25CF</span> ' + this.series.name + ': <b> ' + this.y + '</b><br/>';
//                return rV;
//            }
//        },
//        plotOptions: {
//            area: {
//                marker: {
//                    enabled: true,
//                    symbol: 'circle',
//                    radius: 2,
//                    states: {
//                        hover: {
//                            enabled: true
//                        }
//                    }
//                }
//            },
//            series: {
//                enableMouseTracking: true
//            }
//        },
//        yAxis: {
//            title: {
//                text: 'Number of Tickets'
//            }
//        },
//        xAxis: {
//            labels: {
//                formatter: function () {
//                    return this.axis.defaultLabelFormatter.call(this) + ':00';
//                }
//            }
//        },
//        series: [{
//            name: 'Reported',
//            data: series1
//        },
//        {
//            name: 'Resolved',
//            data: series2
//        }]
//    });
//}

function T2OffPeakAvgResponseTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OffPeakAvgResponseTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2OffPeakAvgResponseTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OffPeakAvgResponseTimeChart(series) {
    $('#T2OffPeakAvgResponseTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        title: {
            text: ''
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 90,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 15,
                color: '#81C784'
            }, {
                from: 15,
                to: 30,
                color: '#FFF176'
            }, {
                from: 30,
                to: 90,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Response Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }
        //, {
        //    name: 'Target',
        //    data: [30],
        //    dataLabels: {
        //        x: 0, y: 60,
        //        format: 'SLA {y:.0f} Mins',
        //    },
        //    dial: {
        //        backgroundColor: 'transparent'
        //    }
        //}
        ]
    });
}

function T2OnSiteAvgResponseTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OnSiteAvgResponseTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2OnSiteAvgResponseTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OnSiteAvgResponseTimeChart(series) {
    $('#T2OnSiteAvgResponseTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 90,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 15,
                color: '#81C784'
            }, {
                from: 15,
                to: 30,
                color: '#FFF176'
            }, {
                from: 30,
                to: 90,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Response Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2OffPeakResponseSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OffPeakResponseSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2OffPeakResponseSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OffPeakResponseSLAStatusChart(series) {

    $('#T2OffPeakResponseSLAStatus').highcharts({

        chart: {
            height: 200
        },
        title: {
            text: ''
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2OnSiteResponseSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OnSiteResponseSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2OnSiteResponseSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OnSiteResponseSLAStatusChart(series) {

    $('#T2OnSiteResponseSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2CommunicationsAvgResolutionTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2CommunicationsAvgResolutionTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2CommunicationsAvgResolutionTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2CommunicationsAvgResolutionTimeChart(series) {
    $('#T2CommunicationsAvgResolutionTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            gauge: {
                wrap: false
            },
            series: {
                enableMouseTracking: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 240,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 120,
                color: '#81C784'
            }, {
                from: 120,
                to: 180,
                color: '#FFF176'
            }, {
                from: 180,
                to: 240,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Resolution Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2GulshanAvgResolutionTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2GulshanAvgResolutionTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2GulshanAvgResolutionTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2GulshanAvgResolutionTimeChart(series) {
    $('#T2GulshanAvgResolutionTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 240,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 120,
                color: '#81C784'
            }, {
                from: 120,
                to: 180,
                color: '#FFF176'
            }, {
                from: 180,
                to: 240,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Resolution Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2NetworksAvgResolutionTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2NetworksAvgResolutionTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2NetworksAvgResolutionTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2NetworksAvgResolutionTimeChart(series) {
    $('#T2NetworksAvgResolutionTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 240,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 120,
                color: '#81C784'
            }, {
                from: 120,
                to: 180,
                color: '#FFF176'
            }, {
                from: 180,
                to: 240,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Resolution Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2OffPeakAvgResolutionTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OffPeakAvgResolutionTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2OffPeakAvgResolutionTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OffPeakAvgResolutionTimeChart(series) {
    $('#T2OffPeakAvgResolutionTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 240,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 120,
                color: '#81C784'
            }, {
                from: 120,
                to: 180,
                color: '#FFF176'
            }, {
                from: 180,
                to: 240,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Resolution Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2OffSiteAvgResolutionTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OffSiteAvgResolutionTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2OffSiteAvgResolutionTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OffSiteAvgResolutionTimeChart(series) {
    $('#T2OffSiteAvgResolutionTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 240,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 120,
                color: '#81C784'
            }, {
                from: 120,
                to: 180,
                color: '#FFF176'
            }, {
                from: 180,
                to: 240,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Resolution Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2OnSiteAvgResolutionTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OnSiteAvgResolutionTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2OnSiteAvgResolutionTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OnSiteAvgResolutionTimeChart(series) {
    $('#T2OnSiteAvgResolutionTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 240,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 120,
                color: '#81C784'
            }, {
                from: 120,
                to: 180,
                color: '#FFF176'
            }, {
                from: 180,
                to: 240,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Resolution Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2CentralAvgResolutionTime() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2CentralAvgResolutionTime",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].SupportGroup, Result[i].Total);
                data.push(series);
            }
            T2CentralAvgResolutionTimeChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2CentralAvgResolutionTimeChart(series) {
    $('#T2CentralAvgResolutionTime').highcharts({
        chart: {
            type: 'gauge',
            height: 200
        },
        plotOptions: {
            series: {
                enableMouseTracking: false
            },
            gauge: {
                wrap: false
            }
        },
        pane: {
            startAngle: -150,
            endAngle: 150,
            background: [{
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#FFF'],
                        [1, '#333']
                    ]
                },
                borderWidth: 0,
                outerRadius: '109%'
            }, {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                        [0, '#333'],
                        [1, '#FFF']
                    ]
                },
                borderWidth: 1,
                outerRadius: '107%'
            }, {
                // default background
            }, {
                backgroundColor: '#DDD',
                borderWidth: 0,
                outerRadius: '105%',
                innerRadius: '103%'
            }]
        },
        yAxis: {
            min: 0,
            max: 180,
            minorTickInterval: 'auto',
            minorTickWidth: 1,
            minorTickLength: 10,
            minorTickPosition: 'inside',
            minorTickColor: '#666',
            tickPixelInterval: 30,
            tickWidth: 2,
            tickPosition: 'inside',
            tickLength: 10,
            tickColor: '#666',
            labels: {
                step: 2,
                rotation: 'auto'
            },
            title: {
                text: 'Time/Ticket',
                x: 0, y: 12
            },
            plotBands: [{
                from: 0,
                to: 60,
                color: '#81C784'
            }, {
                from: 60,
                to: 120,
                color: '#FFF176'
            }, {
                from: 120,
                to: 180,
                color: '#E57373'
            }]
        },
        series: [{
            name: 'Average Resolution Time',
            data: series,
            tooltip: {
                valueSuffix: ' Minutes'
            },
            dataLabels: {
                format: '{y:.0f} Mins',
            }
        }]
    });
}

function T2CommunicationsSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2CommunicationsSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2CommunicationsSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2CommunicationsSLAStatusChart(series) {

    $('#T2CommunicationsSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2GulshanSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2GulshanSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2GulshanSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2NetworksSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2NetworksSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
                T2NetworksSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2GulshanSLAStatusChart(series) {

    $('#T2GulshanSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2NetworksSLAStatusChart(series) {

    $('#T2NetworksSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2OffPeakSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OffPeakSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2OffPeakSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OffPeakSLAStatusChart(series) {

    $('#T2OffPeakSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2OffSiteSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OffSiteSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2OffSiteSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OffSiteSLAStatusChart(series) {

    $('#T2OffSiteSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2OnSiteSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2OnSiteSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2OnSiteSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2OnSiteSLAStatusChart(series) {

    $('#T2OnSiteSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}

function T2CentralSLAStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/T2CentralSLAStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var series = new Array(Result[i].Status, Result[i].Total);
                data.push(series);
            }
            T2CentralSLAStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function T2CentralSLAStatusChart(series) {

    $('#T2CentralSLAStatus').highcharts({

        chart: {
            height: 200
        },
        colors: ['#81C784', '#E57373'],
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    format: '<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.percentage:.1f}%</span>',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    },
                    distance: -60
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Total',
            data: series,
            innerSize: '70%'
        }]
    });
}