$(document).ready(function () {
    PendingTicketsStatus();
    ActiveTicketsStacked();
    UPTicketsStacked();
    VPTicketsStacked();
})

function PendingTicketsStatus() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/PendingTicketsStatus",
        data: "{}",
        dataType: "json",
        success: function (Result) {
            Result = Result.d;
            var data = [];
            for (var i in Result) {
                var serie = new Array(Result[i].Status, Result[i].Total);
                data.push(serie);
            }
            PendingTicketsStatusChart(data);
        },
        error: function (Result) {
            //alert("Error");
        }
    });
}

function PendingTicketsStatusChart(series) {

    $('#PendingTicketsStatus').highcharts({
        chart: {
            height: 322,
            //margin: [0, 0, 0, 0],
            //spacingTop: 0,
            //spacingBottom: 0,
            //spacingLeft: 0,
            //spacingRight: 0
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                },
                showInLegend: true
            }
        },
        series: [{
            type: 'pie',
            name: 'Status',
            data: series,
            innerSize: '70%'
        }]
    });
}

function ActiveTicketsStacked() {

    $.ajax({

        type: "POST",

        contentType: "application/json; charset=utf-8",

        url: "WebService.asmx/ActiveTicketsStacked",

        data: "{}",

        dataType: "json",

        success: function (Result) {


            Result = Result.d;


            var series = [];

            var categories = [];

            var Age1 = [];

            var Age2 = [];

            var Age3 = [];

            var Age4 = [];


            for (var i in Result) {

                categories.push(Result[i].SupportGroup);

                Age1.push(Result[i].Age1);

                Age2.push(Result[i].Age2);

                Age3.push(Result[i].Age3);

                Age4.push(Result[i].Age4);

            }

            series.push({

                name: 'Above 30 days',

                data: Age4

            },

                {

                    name: '16 to 30 days',

                    data: Age3

                },

                {

                    name: '6 to 15 days',

                    data: Age2

                },

                {

                    name: '3 to 5 days',

                    data: Age1

                },
                {
                    name: 'Show All'
                }

            );

            BindChart(categories, series);

        },

        error: function (xhr) {

            //alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

        }

    });

};

function BindChart(categories, series) {

    $('#StackedActiveTickets').highcharts({

        chart: {

            type: 'column'

        },

        xAxis: {

            categories: categories

        },

        legend: {

            itemStyle: {

                fontSize: '12px',

                font: '13px sans-serif'

            }

        },

        yAxis: {

            min: 0,

            title: {

                text: 'Number of Tickets'

            }

        },

        tooltip: {

            formatter: function () {

                return '<b>' + this.x + '</b><br/>' +

                    this.series.name + ': ' + this.y + '<br/>' +

                    'Total: ' + this.point.stackTotal;

            }

        },

        plotOptions: {

            column: {

                stacking: 'normal',

                dataLabels: {

                    enabled: true,

                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',

                    style: {

                        textShadow: '0 0 3px black'

                    },

                    formatter: function () {
                        if (this.y != 0) {
                            return this.y;
                        }
                    }

                }

            },
            series: {
                events: {
                    legendItemClick: function (event) {
                        var s = this.chart.series;
                        for (i = 0; i < s.length; i++) {
                            if (this.name == 'Show All' || this == s[i])
                                s[i].setVisible(true);
                            else
                                s[i].setVisible(false);
                        }
                        return false;
                    }
                }
            }

        },

        series: series

    });
};

function UPTicketsStacked() {

    $.ajax({

        type: "POST",

        contentType: "application/json; charset=utf-8",

        url: "WebService.asmx/UPTicketsStacked",

        data: "{}",

        dataType: "json",

        success: function (Result) {


            Result = Result.d;


            var series = [];

            var categories = [];

            var Age1 = [];

            var Age2 = [];

            var Age3 = [];

            var Age4 = [];


            for (var i in Result) {

                categories.push(Result[i].SupportGroup);

                Age1.push(Result[i].Age1);

                Age2.push(Result[i].Age2);

                Age3.push(Result[i].Age3);

                Age4.push(Result[i].Age4);

            }

            series.push({

                name: 'Above 30 days',

                data: Age4

            },

                {

                    name: '16 to 30 days',

                    data: Age3

                },

                {

                    name: '6 to 15 days',

                    data: Age2

                },

                {

                    name: '3 to 5 days',

                    data: Age1

                },
                {
                    name: 'Show All'
                }

            );

            BindChart1(categories, series);

        },

        error: function (xhr) {

            //alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

        }

    });

};

function BindChart1(categories, series) {

    $('#StackedUPTickets').highcharts({

        chart: {

            type: 'column'

        },

        xAxis: {

            categories: categories

        },

        legend: {

            itemStyle: {

                fontSize: '12px',

                font: '13px sans-serif'

            }

        },

        yAxis: {

            min: 0,

            title: {

                text: 'Number of Tickets'

            }

        },

        tooltip: {

            formatter: function () {

                return '<b>' + this.x + '</b><br/>' +

                    this.series.name + ': ' + this.y + '<br/>' +

                    'Total: ' + this.point.stackTotal;

            }

        },

        plotOptions: {

            column: {

                stacking: 'normal',

                dataLabels: {

                    enabled: true,

                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',

                    style: {

                        textShadow: '0 0 3px black'

                    },

                    formatter: function () {
                        if (this.y != 0) {
                            return this.y;
                        }
                    }

                }

            },
            series: {
                events: {
                    legendItemClick: function (event) {
                        var s = this.chart.series;
                        for (i = 0; i < s.length; i++) {
                            if (this.name == 'Show All' || this == s[i])
                                s[i].setVisible(true);
                            else
                                s[i].setVisible(false);
                        }
                        return false;
                    }
                }
            }

        },

        series: series

    });
};

function VPTicketsStacked() {

    $.ajax({

        type: "POST",

        contentType: "application/json; charset=utf-8",

        url: "WebService.asmx/VPTicketsStacked",

        data: "{}",

        dataType: "json",

        success: function (Result) {


            Result = Result.d;


            var series = [];

            var categories = [];

            var Age1 = [];

            var Age2 = [];

            var Age3 = [];

            var Age4 = [];


            for (var i in Result) {

                categories.push(Result[i].SupportGroup);

                Age1.push(Result[i].Age1);

                Age2.push(Result[i].Age2);

                Age3.push(Result[i].Age3);

                Age4.push(Result[i].Age4);

            }

            series.push({

                name: 'Above 30 days',

                data: Age4

            },

                {

                    name: '16 to 30 days',

                    data: Age3

                },

                {

                    name: '6 to 15 days',

                    data: Age2

                },

                {

                    name: '3 to 5 days',

                    data: Age1

                },
                {
                    name: 'Show All'
                }

            );

            BindChart2(categories, series);

        },

        error: function (xhr) {

            //alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

        }

    });

};

function BindChart2(categories, series) {

    $('#StackedVPTickets').highcharts({

        chart: {

            type: 'column'

        },

        xAxis: {

            categories: categories

        },

        legend: {

            itemStyle: {

                fontSize: '12px',

                font: '13px sans-serif'

            }

        },

        yAxis: {

            min: 0,

            title: {

                text: 'Number of Tickets'

            }

        },

        tooltip: {

            formatter: function () {

                return '<b>' + this.x + '</b><br/>' +

                    this.series.name + ': ' + this.y + '<br/>' +

                    'Total: ' + this.point.stackTotal;

            }

        },

        plotOptions: {

            column: {

                stacking: 'normal',

                dataLabels: {

                    enabled: true,

                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',

                    style: {

                        textShadow: '0 0 3px black'

                    },

                    formatter: function () {
                        if (this.y != 0) {
                            return this.y;
                        }
                    }

                }

            },
            series: {
                events: {
                    legendItemClick: function (event) {
                        var s = this.chart.series;
                        for (i = 0; i < s.length; i++) {
                            if (this.name == 'Show All' || this == s[i])
                                s[i].setVisible(true);
                            else
                                s[i].setVisible(false);
                        }
                        return false;
                    }
                }
            }

        },

        series: series

    });
};