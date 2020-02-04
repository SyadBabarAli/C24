$(function () { $('[data-toggle="tooltip"]').tooltip() })

//Side Nav
jQuery(document).ready(function ($) {
    var $side_nav_toggle = $('#side-nav-toggle'),
        $navigation = $('header');

    //open-close lateral menu clicking on the menu icon
    $side_nav_toggle.on('click', function (event) {
        event.preventDefault();

        $side_nav_toggle.toggleClass('is-clicked');
        $navigation.toggleClass('is-open', function () {
            // firefox transitions break when parent overflow is changed, so we need to wait for the end of the trasition to give the body an overflow hidden
            $('body').toggleClass('overflow-hidden');
        });
        $('#side-nav').toggleClass('is-open');

        //check if transitions are not supported - i.e. in IE9
        if ($('html').hasClass('no-csstransitions')) {
            $('body').toggleClass('overflow-hidden');
        }
    });
});

$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('#back-to-top').fadeIn();
        } else {
            $('#back-to-top').fadeOut();
        }
    });
    // scroll body to 0px on click
    $('#back-to-top').click(function () {
        $('#back-to-top').tooltip('hide');
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });

    $('#back-to-top').tooltip('show');

});

Highcharts.theme = {
    title: {
        text: ''
    },
    chart: {
        backgroundColor: 'rgba(255,255,255,0)'
    },
    colors: ['#FFB74D', '#A1887F', '#64B5F6', '#9575CD', '#E0E0E0'],
    exporting: {
        enabled: false
    },
    credits: {
        enabled: false
    },
    plotOptions: {
        series: {
            enableMouseTracking: true
        },
        gauge: {
            wrap: false
        }
    }
};

Highcharts.setOptions(Highcharts.theme);