document.addEventListener("DOMContentLoaded", function () {
    let clickableTRs = document.querySelectorAll('.clickableTR');

    clickableTRs.forEach(function (item) {
        item.addEventListener('click', function () {
            window.location.assign(item.getAttribute('myattribute'))
        });
    });
});
