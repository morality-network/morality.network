$(document).ready(function () {

    var headers = { Authorization: "" };
  
    //Chart init
    $("#sparkline").sparkline([1,2,5,2,7,6,4,2,7,5,8,7,9], {
    type: 'line',
    width: '520px',
    height: '125px',
    lineColor: '#7f7f7f',
    lineWidth: 3,
    fillColor: false
    });

    //Dropdown events
    $('#dd').on('click', function (event) {
        $(this).toggleClass('active');
        return false;
    });
    
});