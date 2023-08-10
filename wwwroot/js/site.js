$(document).ready(function () {
    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link');

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'));
            this.classList.add('active');
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink));

    // Your code to run since DOM is loaded and ready
});



/**************************************************************************** */
/**************************************************************************** */


//$(document).ready(function () {
//    var trigger = $('.hamburger'),
//        isClosed = false;

//    trigger.click(function () {
//        hamburger_cross();
//    });

//    function hamburger_cross() {

//        if (isClosed == true) {
//            overlay.hide();
//            trigger.removeClass('is-open');
//            trigger.addClass('is-closed');
//            isClosed = false;
//        } else {
//            overlay.show();
//            trigger.removeClass('is-closed');
//            trigger.addClass('is-open');
//            isClosed = true;
//        }
//    }

//    $('[data-toggle="offcanvas"]').click(function () {
//        $('#wrapper').toggleClass('toggled');
//    });
//});