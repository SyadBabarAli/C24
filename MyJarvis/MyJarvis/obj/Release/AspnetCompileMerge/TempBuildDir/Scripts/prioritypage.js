$(function () {
    $('#priority-spline2016').highcharts({
        chart: {
            type: 'spline'
        },
        xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
        },
        yAxis: {
            title: {
                text: 'Number of Tickets'
            },
            labels: {
                formatter: function () {
                    return this.value;
                }
            }
        },
        tooltip: {
            crosshairs: true,
            shared: true
        },
        plotOptions: {
            spline: {
                marker: {
                    radius: 4,
                    lineColor: '#666666',
                    lineWidth: 1
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
                },
                enableMouseTracking: true
            }
        },
        series: [{
            name: 'Database/PS Infrastructure',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0]

        }, {
            name: 'Email and collaboration',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0]
        }, {
            name: 'SAHL Issue',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 1, 0, 0, 0, 0, 0, 2, 0]
        }, {
            name: 'HIS',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 0, 0, 2, 1, 1, 0, 1, 0]
        }, {
            name: 'Data Center',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0]
        }, {
            name: 'Network Support',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0]
        }, {
            name: 'Telephony',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0]
        }, {
            name: 'Website Support',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0]
        }, {
            name: 'Show All'
        }]
    });
});

$(function () {
    // Create the chart
    $('#priority-column2016').highcharts({
        chart: {
            type: 'column'
        },
        xAxis: {
            type: 'category'
        },
        yAxis: {
            title: {
                text: 'Number of Tickets'
            }

        },
        legend: {
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    format: ''
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b> of total<br/>'
        },

        series: [{
            name: 'Category',
            colorByPoint: true,
            data: [{
                name: 'Database/PS Infrastructure',
                y: 3,
                drilldown: 'Database/PS Infrastructure'
            }, {
                name: 'Email and collaboration',
                y: 2,
                drilldown: 'Email and collaboration'
            }, {
                name: 'SAHL Issue',
                y: 3,
                drilldown: 'SAHL Issue'
            }, {
                name: 'HIS',
                y: 5,
                drilldown: 'HIS'
            }, {
                name: 'Data Center',
                y: 1,
                drilldown: 'Data Center'
            }, {
                name: 'Network Support',
                y: 1,
                drilldown: 'Network Support'
            }, {
                name: 'Telephony',
                y: 1,
                drilldown: 'Telephony'
            }, {
                name: 'Website Support',
                y: 1,
                drilldown: 'Website Support'
            }]
        }],
        drilldown: {
            series: [{
                name: 'Database/PS Infrastructure',
                id: 'Database/PS Infrastructure',
                data: [{
                    name: 'Oracle (HIS)',
                    y: 3,
                    drilldown: "Database"
                }]
            }, {
                name: 'Database',
                id: 'Database',
                data: [
                    [
                        'Database',
                        2
                    ], [
                        'IT Systems',
                        1
                    ]
                ]
            }, {
                name: 'Email and collaboration',
                id: 'Email and collaboration',
                data: [{
                    name: 'User Mailbox',
                    y: 2,
                    drilldown: "User Mailbox"
                }]
            }, {
                name: 'User Mailbox',
                id: 'User Mailbox',
                data: [
                    [
                        'IT Messaging',
                        2
                    ]
                ]
            }, {
                name: 'SAHL Issue',
                id: 'SAHL Issue',
                data: [{
                    name: 'Application Servers Issue',
                    y: 3,
                    drilldown: "Application Servers Issue"
                }]
            }, {
                name: 'Application Servers Issue',
                id: 'Application Servers Issue',
                data: [
                    [
                        'IT Systems',
                        3
                    ]
                ]
            }, {
                name: 'HIS',
                id: 'HIS',
                data: [{
                    name: 'Outpatient Management System (OPMS)',
                    y: 4,
                    drilldown: "Outpatient Management System (OPMS)"
                }, {
                    name: 'Pharmacy System (PHA)',
                    y: 1,
                    drilldown: "Pharmacy System (PHA)"
                }]
            }, {
                name: 'Outpatient Management System (OPMS)',
                id: 'Outpatient Management System (OPMS)',
                data: [
                    [
                        'IT HIS Team 1',
                        4
                    ]
                ]
            }, {
                name: 'Pharmacy System (PHA)',
                id: 'Pharmacy System (PHA)',
                data: [
                    [
                        'IT HIS Team 1',
                        1
                    ]
                ]
            }, {
                name: 'Data Center',
                id: 'Data Center',
                data: [{
                    name: 'Servers – Hardware',
                    y: 1,
                    drilldown: "Servers – Hardware"
                }]
            }, {
                name: 'Servers – Hardware',
                id: 'Servers – Hardware',
                data: [
                    [
                        'DataCenter',
                        1
                    ]
                ]
            }, {
                name: 'Network Support',
                id: 'Network Support',
                data: [{
                    name: 'Internet',
                    y: 1,
                    drilldown: "Internet"
                }]
            }, {
                name: 'Internet',
                id: 'Internet',
                data: [
                    [
                        'IT Networks',
                        1
                    ]
                ]
            }, {
                name: 'Telephony',
                id: 'Telephony',
                data: [{
                    name: 'VoIP',
                    y: 1,
                    drilldown: "VoIP"
                }]
            }, {
                name: 'VoIP',
                id: 'VoIP',
                data: [
                    [
                        'IT Communications',
                        1
                    ]
                ]
            }, {
                name: 'Website Support',
                id: 'Website Support',
                data: [{
                    name: 'AKU EDU',
                    y: 1,
                    drilldown: "AKU EDU"
                }]
            }, {
                name: 'AKU EDU',
                id: 'AKU EDU',
                data: [
                    [
                        'IT Web',
                        1
                    ]
                ]
            }]
        }
    });
});

$(function () {
    $('#priority-spline2017').highcharts({
        chart: {
            type: 'spline'
        },
        xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
        },
        yAxis: {
            title: {
                text: 'Number of Tickets'
            },
            labels: {
                formatter: function () {
                    return this.value;
                }
            }
        },
        tooltip: {
            crosshairs: true,
            shared: true
        },
        plotOptions: {
            spline: {
                marker: {
                    radius: 4,
                    lineColor: '#666666',
                    lineWidth: 1
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
                },
                enableMouseTracking: true
            }
        },
        series: [{
            name: 'Telephony',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 1,
                marker: {
                    symbol: 'square'
                }
            }, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0]
        }, {
            name: 'HIS',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0]
        }, {
            name: 'One45',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
        }, {
            name: 'Network Support',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0]
        }, {
            name: 'SAHL Issue',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 2, 2, 1, 0, 1, 0, 0, 0, 0]
        }, {
            name: 'Database/PS Infrastructure',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0]

        }, {
            name: 'Email and collaboration',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0]
        }, {
            name: 'Data Center',
            marker: {
                symbol: 'square'
            },
            data: [{
                y: 0,
                marker: {
                    symbol: 'square'
                }
            }, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0]
        }, {
            name: 'Show All'
        }]
    });
});

$(function () {
    // Create the chart
    $('#priority-column2017').highcharts({
        chart: {
            type: 'column'
        },
        xAxis: {
            type: 'category'
        },
        yAxis: {
            title: {
                text: 'Number of Tickets'
            }

        },
        legend: {
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    format: ''
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b> of total<br/>'
        },

        series: [{
            name: 'Category',
            colorByPoint: true,
            data: [{
                name: 'Telephony',
                y: 3,
                drilldown: 'Telephony'
            }, {
                name: 'HIS',
                y: 3,
                drilldown: 'HIS'
            }, {
                name: 'One45',
                y: 1,
                drilldown: 'One45'
            }, {
                name: 'Network Support',
                y: 3,
                drilldown: 'Network Support'
            }, {
                name: 'SAHL Issue',
                y: 6,
                drilldown: 'SAHL Issue'
            }, {
                name: 'Database/PS Infrastructure',
                y: 2,
                drilldown: 'Database/PS Infrastructure'
            }, {
                name: 'Email and collaboration',
                y: 3,
                drilldown: 'Email and collaboration'
            }, {
                name: 'Data Center',
                y: 2,
                drilldown: 'Data Center'
            }]
        }],
        drilldown: {
            series: [{
                name: 'Telephony',
                id: 'Telephony',
                data: [{
                    name: 'EPABX',
                    y: 3,
                    drilldown: "EPABX"
                }]
            }, {
                name: 'EPABX',
                id: 'EPABX',
                data: [
                    [
                        'IT Communications',
                        3
                    ]
                ]
            }, {
                name: 'HIS',
                id: 'HIS',
                data: [{
                    name: 'Outpatient Management System (OPMS)',
                    y: 3,
                    drilldown: "Outpatient Management System (OPMS)"
                }]
            }, {
                name: 'Outpatient Management System (OPMS)',
                id: 'Outpatient Management System (OPMS)',
                data: [
                    [
                        'IT HIS Team 1',
                        3
                    ]
                ]
            }, {
                name: 'One45',
                id: 'One45',
                data: [{
                    name: 'Profile Management',
                    y: 1,
                    drilldown: "Profile Management"
                }]
            }, {
                name: 'Profile Management',
                id: 'Profile Management',
                data: [
                    [
                        'One45',
                        1
                    ]
                ]
            }, {
                name: 'Network Support',
                id: 'Network Support',
                data: [{
                    name: 'Internet',
                    y: 2,
                    drilldown: "Internet"
                }, {
                    name: 'Wireless',
                    y: 1,
                    drilldown: "Wireless"
                }]
            }, {
                name: 'Internet',
                id: 'Internet',
                data: [
                    [
                        'IT Networks',
                        2
                    ]
                ]
            }, {
                name: 'Wireless',
                id: 'Wireless',
                data: [
                    [
                        'IT T2 Networks',
                        1
                    ]
                ]
            }, {
                name: 'SAHL Issue',
                id: 'SAHL Issue',
                data: [{
                    name: 'Application Servers Issue',
                    y: 6,
                    drilldown: "Application Servers Issue"
                }]
            }, {
                name: 'Application Servers Issue',
                id: 'Application Servers Issue',
                data: [
                    [
                        'IT Systems',
                        6
                    ]
                ]
            }, {
                name: 'Database/PS Infrastructure',
                id: 'Database/PS Infrastructure',
                data: [{
                    name: 'Oracle (HIS)',
                    y: 2,
                    drilldown: "Database"
                }]
            }, {
                name: 'Database',
                id: 'Database',
                data: [
                    [
                        'Database',
                        2
                    ]
                ]
            }, {
                name: 'Email and collaboration',
                id: 'Email and collaboration',
                data: [{
                    name: 'User Mailbox',
                    y: 2,
                    drilldown: "User Mailbox"
                }, {
                    name: 'Exchange',
                    y: 1,
                    drilldown: "Exchange"
                }]
            }, {
                name: 'User Mailbox',
                id: 'User Mailbox',
                data: [
                    [
                        'IT Messaging',
                        2
                    ]
                ]
            }, {
                name: 'Exchange',
                id: 'Exchange',
                data: [
                    [
                        'IT Messaging',
                        1
                    ]
                ]
            }, {
                name: 'Data Center',
                id: 'Data Center',
                data: [{
                    name: 'Print Servers',
                    y: 2,
                    drilldown: "Print Servers"
                }]
            }, {
                name: 'Print Servers',
                id: 'Print Servers',
                data: [
                    [
                        'IT Systems',
                        2
                    ]
                ]
            }]
        }
    });
});