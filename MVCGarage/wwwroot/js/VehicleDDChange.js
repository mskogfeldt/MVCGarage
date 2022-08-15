let VehicleDD = document.querySelector('#VehicleTypeId');

document.addEventListener("DOMContentLoaded", function (event) {
    VehicleDDChange();
});

function VehicleDDChange() {
    if (VehicleDD.options[VehicleDD.selectedIndex].value == 0)
        $('.collapse').toggle()
    else
        $('.collapse').hide();
}

VehicleDD.addEventListener('change', e => {
    VehicleDDChange();
});
