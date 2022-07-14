document.addEventListener("DOMContentLoaded", function (event) {
    let regnr = document.querySelector('#RegistrationNumber');
    regnr.addEventListener("change", function () {
        document.getElementById('ErrorSpan').innerHTML = '';
    });
});