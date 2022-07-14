document.addEventListener("DOMContentLoaded", function (event) {
    let regnrId = document.querySelector('#RegistrationNumberId').value;
    let regnrInput = document.querySelector('#' + regnrId);
    regnrInput.addEventListener("change", function () {
        try {
            document.querySelector('#ErrorSpan').innerHTML = '';
        } catch {
        }        
    });
});