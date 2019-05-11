
(function ($) {
    "use strict";

    //Site Url
    //var rateit = "https://rateitapp.azurewebsites.net/";
    var rateit = "https://localhost:44322/";

    //Login Data
    var tokenKey = 'ri-li-tkn';
    var header = { Authorization: '' };

    //Functions
    function login(email, password) {
        var loginData = {
            "username": email,
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
                goToDash(2);
            },
            error: function (data) {
                alert(JSON.stringify(data));
            }
        });
    }

    function goToDash(id) {
         var url = '@Url.Action("Home", "Dashboard", new { id = "__id__" })';
         window.location.href = url.replace('__id__', id);
    }
   
    $('#login').click(function (e) {
        login($('#username').val(), $('#password').val());
    });
        

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
    /*==================================================================
    [ Focus input ]*/
    $('.input100').each(function(){
        $(this).on('blur', function(){
            if($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })    
    })
  
  
    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');
    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });

    $('.login100-form-btn').click(function () {
        
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    /*==================================================================
    [ Show pass ]*/
    var showPass = 0;
    $('.btn-show-pass').on('click', function(){
        if(showPass == 0) {
            $(this).next('input').attr('type','text');
            $(this).addClass('active');
            showPass = 1;
        }
        else {
            $(this).next('input').attr('type','password');
            $(this).removeClass('active');
            showPass = 0;
        }
        
    });


})(jQuery);