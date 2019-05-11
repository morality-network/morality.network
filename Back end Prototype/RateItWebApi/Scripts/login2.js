$(document).ready(function () {

    //Site Url
    //var rateit = "https://rateitapp.azurewebsites.net/";
    var rateit = "https://localhost:44322/";

    //Login Data
    var tokenKey = 'ri-li-tkn';
    var header = {Authorization:''};

    //Functions
    function login(email, password){
        var loginData = {
            "username": encodeURIComponent(email),
            "password": encodeURIComponent(password),
            "grant_type": "password"
        };
        var url = rateit + "Token";
        $.ajax({
            type: "POST",
            url: url,
            data: loginData,
            contentType: "application/x-www-form-urlencoded",
            async: false,
            success: function (data) {
                alert("getToken:" + JSON.stringify(data));
                sessionStorage.setItem(tokenKey, JSON.stringify(data));         		
            },
            error: function (data) {
                alert(JSON.stringify(data));
            }
        });
    }

    function isLoggedIn() {
        var token = sessionStorage.getItem(tokenKey);
        if (token) {
            headerr.Authorization = 'Bearer ' + token;
            return true;
        }
        return false;
    }

    function logout() {
        sessionStorage.setItem(tokenKey, "");
    }

    //Events
    $('.login100-form-btn').click(function () {
        alert('Clicked');
    });

});