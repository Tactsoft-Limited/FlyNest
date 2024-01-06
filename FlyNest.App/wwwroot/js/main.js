(function () {
    'use strict';


    /* ====Sticky Navbar Start==== */
    $(function () {
        var myNav = $('.navbar');
        $(window).scroll(function () {
            if ($(window).scrollTop() <= 50) { myNav.removeClass('sticky-nav'); } else { myNav.addClass('sticky-nav'); }
        })
    })
    /*====Sticky Navbar End====*/

    /*====Mobile Navigation Start====*/ // Get all the navigation links with dropdown
    const dropdownLinks = document.querySelectorAll('.mobile-navigation-menu li.dropdown> a');

    // Add click event listeners to the links
    dropdownLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            const parentListItem = this.parentElement;
            const dropdown = parentListItem.querySelector('ul.dropdown-menu');


            // Toggle the dropdown visibility
            dropdown.style.display = (dropdown.style.display === 'block') ? 'none' : 'block';


            // Toggle the plus/minus icon
            parentListItem.classList.toggle('open');
        });
    });
    /* ====Mobile Navigation End==== */






    /*====Button (Scrolling Bottom to Top) Start====*/
    var mybtn = document.getElementById('scroll-bottom-top');
    window.onscroll = function () { scrollFunction(); }; function scrollFunction() {
        if (document.body.scrollTop > 50
            ||
            document.documentElement.scrollTop > 50
        ) {
            mybtn.style.opacity = '1';
        }
        else {
            mybtn.style.opacity = '0';
        }
    }
    mybtn.addEventListener('click', topFunction);

    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }
    /* ====Button (Scrolling Bottom to Top) End==== */


    /* ==== Exclusive Offer Start ==== */
    $('#exclusive-offer, #explore-bd, #popular-destination').slick({
        dots: true,
        arrows: false,
        infinite: true,
        speed: 1000,
        adaptiveHeight: true,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
        autoplayHoverPause: true,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    dots: true,
                    autoplay: false
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    dots: true,
                    autoplay: false
                }
            }
        ]
    });
    /* ==== Exclusive Offer End ==== */














})()