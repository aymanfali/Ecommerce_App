//$(document).addEventListener(function () {
//    /*===== LINK ACTIVE =====*/
//    const linkColor = document.querySelectorAll('.nav_link');

//    function colorLink() {
//        if (linkColor) {
//            linkColor.forEach(l => l.classList.remove('active'));
//            this.classList.add('active');
//        }
//    }
//    linkColor.forEach(l => l.addEventListener('click', colorLink));

//    // Your code to run since DOM is loaded and ready
//});

// Get the container element
var btnContainer = document.getElementById("navbar");

// Get all buttons with class="btn" inside the container
var btns = btnContainer.getElementsByClassName("nav_link");

// Loop through the buttons and add the active class to the current/clicked button
for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click", function () {
        var current = document.getElementsByClassName("active");
        current[0].className = current[0].className.replace(" active", "");
        this.className += " active";
    });
}

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