$(document).ready(function () {
    'use strict';

    /*-------------------------------------
    Header top closer
    -------------------------------------*/
    $('#header-top-close').on('click', function () {
        $('#header-top').slideUp();
    });

    /*-------------------------------------
    Header Search Toggle
    -------------------------------------*/
    $('.search-toggle').on('click', function (e) {
        e.preventDefault();
        $('.nav-search-wrap').slideToggle();
        $(this).children('.fa').toggleClass('fa-search fa-close');
    });

    $('.mobile-nav-search').on('click', function (e) {
        e.preventDefault();
        $('.mobile-nav-search-wrap').slideToggle();
        $(this).children('.fa').toggleClass('fa-search fa-close');
    });

    /*-------------------------------------
    Language Selector
    -------------------------------------*/
    $('.drop-block').on('click', function () {
        $(this).children('.dropblock-drop').slideToggle();
    });

    /*-------------------------------------
    Secondary Nav Toggle
    -------------------------------------*/
    $('.secondary-nav-toggle').on('click', function () {
        $('.secondary-menu').fadeToggle();
    });

    /*-----------------------------------
    Navbar
    -----------------------------------*/
    $('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
        var $el = $(this);
        var $parent = $(this).offsetParent(".dropdown-menu");
        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }
        var $subMenu = $(this).next(".dropdown-menu");
        $subMenu.toggleClass('show');

        $(this).parent("li").toggleClass('show');

        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-menu .show').removeClass("show");
        });

        if (!$parent.parent().hasClass('navbar-nav')) {
            $el.next().css({ "top": $el[0].offsetTop, "left": $parent.outerWidth() - 4 });
        }

        return false;
    });

    if ($(window).width() < 1200) {
        $(document).on('click', function (event) {
            var clickover = $(event.target);
            var _opened = $('#navbarSupportedContent').hasClass('show');
            if (_opened === true && !(clickover.is('.navbar-nav li, .navbar-nav .dropdown *'))) {
                $('button.navbar-toggler').trigger('click');
            }
        });
    }

    /*-------------------------------------
    NavFixed
    -------------------------------------*/

    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.cp-nav.style-1').addClass('fixed');
        } else {
            $('.cp-nav.style-1').removeClass('fixed');
        }
    });
    $(window).scroll(function () {
        if ($(this).scrollTop() > 500) {
            $('.cp-nav.style-2').addClass('fixed');
        } else {
            $('.cp-nav.style-2').removeClass('fixed');
        }
    });



    /*-------------------------------------
    Slider & Carousel
    -------------------------------------*/

    /*** Banner Slider ***/
    if ($('#banner-slider').length > 0) {
        $('#banner-slider').owlCarousel({
            singleItem: true,
            slideSpeed: 200,
            stopOnHover: true,
            //autoPlay: 3000,
            navigation: true,
            navigationText: ["<i class=\"fa fa-angle-left\"></i>", "<i class=\"fa fa-angle-right\"></i>"],
            pagination: false,
        });
    }

    /*** Slider Generic Single ***/
    $('.slider-generic-single').each(function () {
        $(this).owlCarousel({
            singleItem: true,
            slideSpeed: 200,
            stopOnHover: true,
            navigation: true,
            navigationText: ["<i class=\"fa fa-angle-left\"></i>", "<i class=\"fa fa-angle-right\"></i>"],
            pagination: false
        });
    });

    /*** Testimonial Carousel ***/
    if ($('#testimonial-carousel').length > 0) {
        $('#testimonial-carousel').owlCarousel({
            items: 3,
            itemsDesktop: [1199, 3],
            itemsDesktopSmall: [991, 3],
            itemsTablet: [767, 2],
            itemsMobile: [479, 1],
            slideSpeed: 200,
            autoPlay: 3000,
            stopOnHover: true,
            navigation: false,
            pagination: true
        });
    }

    if ($('#testimonial-carousel-2, #testimonial-carousel-3, #testimonial-carousel-4').length > 0) {
        $('#testimonial-carousel-2, #testimonial-carousel-3, #testimonial-carousel-4').owlCarousel({
            singleItem: true,
            slideSpeed: 200,
            autoPlay: 3000,
            stopOnHover: true,
            navigation: true,
            navigationText: ["<i class=\"fa fa-angle-left\"></i>", "<i class=\"fa fa-angle-right\"></i>"],
            pagination: false
        });
    }

    /*** Blog Carousel ***/
    $('.blog-carousel').each(function () {
        $(this).owlCarousel({
            items: 2,
            itemsDesktop: [1199, 2],
            itemsDesktopSmall: [991, 2],
            itemsTablet: [767, 2],
            itemsMobile: [479, 1],
            slideSpeed: 200,
            stopOnHover: true,
            navigation: true,
            navigationText: ["<i class=\"fa fa-angle-left\"></i>", "<i class=\"fa fa-angle-right\"></i>"],
            pagination: false
        });
    });

    /*** Sponsor Carousel ***/
    if ($('#sponsors-carousel').length > 0) {
        $('#sponsors-carousel').owlCarousel({
            items: 6,
            itemsDesktop: [1199, 6],
            itemsDesktopSmall: [991, 4],
            itemsTablet: [767, 3],
            itemsMobile: [479, 1],
            slideSpeed: 200,
            autoPlay: 3000,
            stopOnHover: true,
            navigation: false,
            pagination: true
        });
    }

    /*** Cause Carousel ***/
    $('.cause-carousel').each(function () {
        $(this).owlCarousel({
            items: 3,
            itemsDesktop: [1199, 3],
            itemsDesktopSmall: [991, 2],
            itemsTablet: [767, 2],
            itemsMobile: [620, 1],
            slideSpeed: 200,
            stopOnHover: true,
            navigation: true,
            navigationText: ["<i class=\"fa fa-angle-left\"></i>", "<i class=\"fa fa-angle-right\"></i>"],
            pagination: false
        });
    });

    /*** Event Carousel ***/
    $('.event-carousel').each(function () {
        $(this).owlCarousel({
            items: 3,
            itemsDesktop: [1199, 3],
            itemsDesktopSmall: [991, 2],
            itemsTablet: [767, 2],
            itemsMobile: [620, 1],
            slideSpeed: 200,
            stopOnHover: true,
            navigation: true,
            navigationText: ["<i class=\"fa fa-angle-left\"></i>", "<i class=\"fa fa-angle-right\"></i>"],
            pagination: false
        });
    });

    /*** Gallery Carousel ***/
    $('.gallery-carousel').each(function () {
        $(this).owlCarousel({
            items: 5,
            itemsDesktop: [1199, 4],
            itemsDesktopSmall: [991, 3],
            itemsTablet: [767, 2],
            itemsMobile: [479, 1],
            slideSpeed: 200,
            stopOnHover: true,
            navigation: true,
            navigationText: ["<i class=\"fa fa-angle-left\"></i>", "<i class=\"fa fa-angle-right\"></i>"],
            pagination: false
        });
    });

    /*-------------------------------------
    Countdown
    -------------------------------------*/
    //Countdown 1
    $('.countdown-1').each(function () {
        var endTime = $(this).data('time');
        $(this).countdown(endTime, function (tm) {
            var countTxt = '';
            var countDay = 565.487 - (565.487 / 365) * (tm.strftime('%D'));
            var countHour = 565.487 - (565.487 / 24) * (tm.strftime('%H'));
            var countMin = 565.487 - (565.487 / 60) * (tm.strftime('%M'));
            var countSec = 565.487 - (565.487 / 60) * (tm.strftime('%S'));
            countTxt += '<div class="col-lg-3 col-sm-6 col-xs-6"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount days">%D </span><span class="text">Days</span></span><svg height="200" width="200"><circle cx="100" cy="100" r="90" stroke-width="20" fill="none" stroke-dashoffset="' + countDay + '"/></svg></span></span></div>';
            countTxt += '<div class="col-lg-3 col-sm-6 col-xs-6"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount hours">%H</span><span class="text">Hours</span></span><svg height="200" width="200"><circle cx="100" cy="100" r="90" stroke-width="20" fill="none" stroke-dashoffset="' + countHour + '"/></svg></span></span></div>';
            countTxt += '<div class="col-lg-3 col-sm-6 col-xs-6"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount minutes">%M</span><span class="text">Minutes</span></span><svg height="200" width="200"><circle cx="100" cy="100" r="90" stroke-width="20" fill="none" stroke-dashoffset="' + countMin + '"/></svg></span></span></div>';
            countTxt += '<div class="col-lg-3 col-sm-6 col-xs-6"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount seconds">%S</span><span class="text">Seconds</span></span><svg height="200" width="200"><circle cx="100" cy="100" r="90" stroke-width="20" fill="none" stroke-dashoffset="' + countSec + '"/></svg></span></span></div>';

            $(this).html(tm.strftime(countTxt));
        });
    });

    //Countdown 2
    $('.countdown-2').each(function () {
        var endTime = $(this).data('time');
        $(this).countdown(endTime, function (tm) {
            var countTxt = '';
            countTxt += '<div class="col-3"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount days">%D </span><span class="text">Days</span></span></span></span></div>';
            countTxt += '<div class="col-3"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount hours">%H</span><span class="text">Hours</span></span></span></span></div>';
            countTxt += '<div class="col-3"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount minutes">%M</span><span class="text">Mins</span></span></span></span></div>';
            countTxt += '<div class="col-3"><span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount seconds">%S</span><span class="text">Secs</span></span></span></span></div>';

            $(this).html(tm.strftime(countTxt));
        });
    });

    //Countdown 3
    $('.countdown-3').each(function () {
        var endTime = $(this).data('time');
        $(this).countdown(endTime, function (tm) {
            var countTxt = '';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount days">%D </span><span class="text">Days</span></span></span></span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount hours">%H</span><span class="text">Hours</span></span></span></span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount minutes">%M</span><span class="text">Mins</span></span></span></span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount seconds">%S</span><span class="text">Secs</span></span></span></span>';

            $(this).html(tm.strftime(countTxt));
        });
    });

    //Widget Countdown
    $('.countdown-widget').each(function () {
        var endTime = $(this).data('time');
        $(this).countdown(endTime, function (tm) {
            var countTxt = '';
            var countDay = 201.062 - (201.062 / 365) * (tm.strftime('%D'));
            var countHour = 201.062 - (201.062 / 24) * (tm.strftime('%H'));
            var countMin = 201.062 - (201.062 / 60) * (tm.strftime('%M'));
            var countSec = 201.062 - (201.062 / 60) * (tm.strftime('%S'));
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount days">%D </span><span class="text">Days</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="' + countDay + '"/></svg></span></span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount hours">%H</span><span class="text">Hours</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="' + countHour + '"/></svg></span></span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount minutes">%M</span><span class="text">Min</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="' + countMin + '"/></svg></span></span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount seconds">%S</span><span class="text">Sec</span></span><svg><circle cx="35" cy="35" r="32" stroke-width="6" fill="none" stroke-dashoffset="' + countSec + '"/></svg></span></span>';

            $(this).html(tm.strftime(countTxt));
        });
    });

    /*** Countdown Compact ***/
    $('.countdown-compact').each(function () {
        var endTime = $(this).data('time');
        $(this).countdown(endTime, function (tm) {
            var countTxt = '';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount days">%D</span><span class="text">D</span></span></span>: </span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount hours">%H</span><span class="text">H</span></span></span>: </span>';
            countTxt += '<span class="section_count"><span class="section_count_data"><span class="count-data"><span class="tcount minutes">%M</span><span class="text">M</span></span></span></span><br/>Left';
            $(this).html(tm.strftime(countTxt));
        });
    });

    /*-------------------------------------
    Count To
    -------------------------------------*/
    function animateCountTo(ct) {
        if ($.fn.visible && $(ct).visible() && !$(ct).hasClass('animated')) {
            $(ct).countTo({
                speed: 2000
            });
            $(ct).addClass('animated');
        }
    }

    function initCountTo() {
        var counter = $('.count');
        counter.each(function () {
            animateCountTo(this);
        });
    }

    initCountTo();

    /*-------------------------------------
    Gallery Filter
    -------------------------------------*/
    // Portfolio Filter Style
    var $container = [$('#gallery-items-1'), $('#gallery-items-2'), $('#gallery-items-3'), $('#gallery-items-4')],
        $optionSets = [$('#gallery-filter-1'), $('#gallery-filter-2'), $('#gallery-filter-3'), $('#gallery-filter-4')];

    $.each($container, function () {
        if ($.fn.imagesLoaded && $(this).length > 0) {
            $(this).isotope({
                itemSelector: '.gallery-item',
                masonry: {
                    columnWidth: '.grid-sizer'
                }
            });
        }
    });

    $.each($optionSets, function () {
        if ($.fn.imagesLoaded && $(this).length > 0) {
            var thisControl = $(this).data('control');
            $(this).on('click', 'button', function () {
                var filterValue = $(this).attr('data-filter');
                $(this).siblings('button').removeClass('active');
                $(this).addClass('active');
                $('#' + thisControl).isotope({
                    filter: filterValue
                });
            });
        }
    });

    /*-------------------------------------
    Magnific Popup
    -------------------------------------*/
    $('.image-large').each(function () {
        $(this).magnificPopup({
            type: 'image',
            gallery: {
                enabled: true
            }
        });
    });

    $('.video-play, .open-map').each(function () {
        $(this).magnificPopup({
            type: 'iframe'
        });

        $.extend(true, $.magnificPopup.defaults, {
            iframe: {
                patterns: {
                    youtube: {
                        index: 'youtube.com/',
                        id: 'v=',
                        src: 'http://www.youtube.com/embed/%id%?autoplay=1'
                    }
                }
            }
        });
    });

    /*-----------------------------------
    Youtube Video
    -----------------------------------*/
    plyr.setup();

    /*-------------------------------------
    Animate Progress Bars
    -------------------------------------*/
    function animateProgressBar(pb) {
        if ($.fn.visible && $(pb).visible() && !$(pb).hasClass('animated')) {
            $(pb).css('width', $(pb).attr('aria-valuenow') + '%');
            $(pb).addClass('animated');
        }
    }

    function initProgressBar() {
        var progressBar = $('.progress-bar');
        progressBar.each(function () {
            animateProgressBar(this);
        });
    }

    initProgressBar();

    /*-------------------------------------
    Rounded Progressbar
    -------------------------------------*/
    function animateRoundedProgress(rpb) {
        if ($.fn.visible && $(rpb).visible() && !$(rpb).hasClass('animated') && !$(rpb).hasClass('small')) {
            $(rpb).css('stroke-dashoffset', 565.487 - (565.487 / 100) * $(rpb).attr('aria-valuenow'));
        } else if ($.fn.visible && $(rpb).visible() && !$(rpb).hasClass('animated') && $(rpb).hasClass('small')) {
            $(rpb).css('stroke-dashoffset', 220 - (220 / 100) * $(rpb).attr('aria-valuenow'));
        } else if ($.fn.visible && $(rpb).visible() && !$(rpb).hasClass('animated') && $(rpb).hasClass('banner-circle')) {
            $(rpb).css('stroke-dashoffset', 678.584 - (678.584 / 100) * $(rpb).attr('aria-valuenow'));
        }
    }

    function initRoundedProgress() {
        var roundedProgress = $('.progress-cicle');
        roundedProgress.each(function () {
            animateRoundedProgress(this);
        });
    }

    initRoundedProgress();


    /*-------------------------------------
    Custom Scrollbar
    -------------------------------------*/
    if (!(navigator.userAgent.search("Chrome") >= 0)) {
        $('.verticle-scroll').each(function () {
            $(this).jScrollPane();
        });
    }

    /*-------------------------------------
    comingsoon full height
    -------------------------------------*/
    function commingsoon() {
        if ($('#coming-soon-wrap').length > 0) {
            $('#coming-soon-wrap').css('height', $(window).height());
        }
    }

    commingsoon();

    /*-----------------------------------
    Contact Form
    -----------------------------------*/
    // Function for email address validation
    function isValidEmail(emailAddress) {
        var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);

        return pattern.test(emailAddress);

    }
    $("#contactForm").on('submit', function (e) {
        e.preventDefault();
        var data = {
            name: $("#name").val(),
            email: $("#email").val(),
            subject: $("#subject").val(),
            message: $("#message").val()
        };

        if (isValidEmail(data['email']) && (data['message'].length > 1) && (data['name'].length > 1) && (data['subject'].length > 1)) {
            $.ajax({
                type: "POST",
                url: "sendmail.php",
                data: data,
                success: function () {
                    $('#contactForm .input-success').delay(500).fadeIn(1000);
                    $('#contactForm .input-error').fadeOut(500);
                }
            });
        } else {
            $('#contactForm .input-error').delay(500).fadeIn(1000);
            $('#contactForm .input-success').fadeOut(500);
        }

        return false;
    });

    /*-----------------------------------
    Subscription
    -----------------------------------*/
    $(".subscription").ajaxChimp({
        callback: mailchimpResponse,
        url: "http://codepassenger.us10.list-manage.com/subscribe/post?u=6b2e008d85f125cf2eb2b40e9&id=6083876991" // Replace your mailchimp post url inside double quote "".  
    });

    function mailchimpResponse(resp) {
        if (resp.result === 'success') {

            $('.newsletter-success').html(resp.msg).fadeIn().delay(3000).fadeOut();

        } else if (resp.result === 'error') {
            $('.newsletter-error').html(resp.msg).fadeIn().delay(3000).fadeOut();
        }
    }

    /*-------------------------------------
    Scroll Events
    -------------------------------------*/
    $(window).on('scroll', function () {
        initCountTo();
        initProgressBar();
        initRoundedProgress();
    });

    /*-------------------------------------
    Windows Events
    -------------------------------------*/
    $(window).on('resize orientationchange', function () {
        commingsoon();
    });
});

/*-------------------------------------
Loader Wrap
-------------------------------------*/
$(window).on('load', function () {
    $("#loader-wrap").delay(200).fadeOut();
});
