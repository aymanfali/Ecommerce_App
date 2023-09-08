// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("goToTop-btn").style.display = "block";
    } else {
        document.getElementById("goToTop-btn").style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function backToTopEvent() {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}

//////////////////////////////////////////////////////////////////////////////////////

var value = parseInt(document.getElementById("items-quantity").value, 10);
window.onload(
    () => {
        if (value == 1) {
            document.getElementById("qdecrement").disabled = true;
        } else {
            document.getElementById("qdecrement").disabled = false;
        }
    }
);

function increaseValue() {
    if (document.getElementById("qdecrement").disabled == true) {
        document.getElementById("qdecrement").disabled = false;
    }
    value = isNaN(value) ? 0 : value;
    value++;
    document.getElementById("items-quantity").value = value;
}

function decreaseValue() {
    value = isNaN(value) ? 0 : value;
    value < 1 ? value = 1 : '';
    if (value == 1) {
        document.getElementById("qdecrement").disabled = true;
    }
    else {
        value--;
    }
    document.getElementById("items-quantity").value = value;
}

function show_billing() {
    document.getElementById("billing-address").style.display = "block";
}

function hide_billing() {
    document.getElementById("billing-address").style.display = "none";
}