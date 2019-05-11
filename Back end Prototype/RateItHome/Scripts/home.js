$(document).ready(function () {

    var headers = { Authorization: "" };
  
    //Chart init
    $("#sparkline").sparkline([1,2,5,2,7,6,4,2,7,5,8,7,9], {
    type: 'line',
    width: '500px',
    height: '110px',
    lineColor: '#7f7f7f',
    lineWidth: 3,
    fillColor: false
    });

    //Dropdown events
    $('#dd').on('click', function (event) {
        $(this).toggleClass('active');
        return false;
    });

    $(document.body).addClass('black-background');
});

function clearData() {
    var cookie = document.cookie.split(';');
    for (var i = 0; i < cookie.length; i++) {
        var chip = cookie[i],
            entry = chip.split("="),
            name = entry[0];

        document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    }
    location.reload();
}
