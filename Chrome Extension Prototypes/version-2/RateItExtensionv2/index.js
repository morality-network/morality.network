var logoBase64 = "data:image/png;base64,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";
var refreshBase = "data:image/png;base64,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";
var poweredby = '<svg id="Layer_1" data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 79.52246 13.03541"><defs><style>.cls-1,.cls-2{fill:#fff;}.cls-2{font-size:7.5461px;font-family:Lato-Regular, Lato;}.cls-3{letter-spacing:-0.01048em;}.cls-4{letter-spacing:-0.02304em;}.cls-5{letter-spacing:-0.03947em;}</style></defs><path class="cls-1" d="M55.23574.21227h2.01652V1.539h.03533a2.87166,2.87166,0,0,1,.911-1.07023A2.76222,2.76222,0,0,1,59.88791,0a2.58227,2.58227,0,0,1,2.65332,1.57432A3.00161,3.00161,0,0,1,63.691.3803,3.3598,3.3598,0,0,1,65.33615,0a3.26966,3.26966,0,0,1,1.43273.28306,2.50822,2.50822,0,0,1,.94643.77826A3.2083,3.2083,0,0,1,68.23706,2.22a6.09092,6.09092,0,0,1,.15926,1.424V8.703H66.27354V3.89158a3.934,3.934,0,0,0-.07067-.7517,1.80346,1.80346,0,0,0-.24773-.6368,1.25757,1.25757,0,0,0-.47753-.43343,1.6605,1.6605,0,0,0-.77839-.15926,1.75188,1.75188,0,0,0-.84016.18583,1.6412,1.6412,0,0,0-.566.4952,2.02945,2.02945,0,0,0-.3184.70759,3.36913,3.36913,0,0,0-.09736.80483V8.703H60.75464V3.644a2.1316,2.1316,0,0,0-.33607-1.26482,1.278,1.278,0,0,0-1.11446-.46876,2.02857,2.02857,0,0,0-.89329.17693,1.71765,1.71765,0,0,0-.60133.47766,1.89951,1.89951,0,0,0-.345.6898,3.07766,3.07766,0,0,0-.10613.81373V8.703H55.23574Z"/><path class="cls-1" d="M70.28879,8.57784A4.48859,4.48859,0,0,1,70.65142,6.747a4.277,4.277,0,0,1,.98176-1.40629,4.32639,4.32639,0,0,1,1.46819-.90219,5.27126,5.27126,0,0,1,3.60851,0,4.32766,4.32766,0,0,1,1.46819.90219A4.28284,4.28284,0,0,1,79.15983,6.747a4.4929,4.4929,0,0,1,.36263,1.83082,4.49378,4.49378,0,0,1-.36263,1.83082,4.28092,4.28092,0,0,1-.98176,1.40616,4.32766,4.32766,0,0,1-1.46819.90219,5.27126,5.27126,0,0,1-3.60851,0,4.32639,4.32639,0,0,1-1.46819-.90219,4.27511,4.27511,0,0,1-.98176-1.40616A4.48947,4.48947,0,0,1,70.28879,8.57784Zm2.12278,0a2.7548,2.7548,0,0,0,.168.95519,2.38948,2.38948,0,0,0,.4952.8136,2.50883,2.50883,0,0,0,3.66164,0,2.40008,2.40008,0,0,0,.49533-.8136,2.799,2.799,0,0,0,0-1.91039,2.4057,2.4057,0,0,0-.49533-.81373,2.50919,2.50919,0,0,0-3.66164,0,2.395,2.395,0,0,0-.4952.81373A2.75695,2.75695,0,0,0,72.41157,8.57784Z"/><path class="cls-1" d="M70.99728,10.32041s-2.88,1.06771-2.62713-2.023H66.27354s.50909,5.90051,5.49642,3.6246"/><text class="cls-2" transform="translate(0 9.62823)">P<tspan class="cls-3" x="4.53125" y="0">O</tspan><tspan x="10.49268" y="0">WERED </tspan><tspan class="cls-4" x="39.4209" y="0">B</tspan><tspan class="cls-5" x="44.12598" y="0">Y</tspan></text></svg>';
//AppId - visible: chrome://extensions/
var myid = chrome.runtime.id;
//var userInfo = getUserDetails();
var rateit = "https://localhost:44322/";

//For display
var commentsArray = [];
var usersArray = [];
var currentTab = createDiv("dft","dft");
var menuShowing = false;

function setRating(){
	var url = rateit + "api/Rating/GetRating";
	var commentData = {
		"encodedUrl": encodeURIComponent(window.location)
	};
	var auth = JSON.parse(getLocalToken());
    var cToken = ("Bearer "+ auth.access_token);
	
	$.ajax({
		type: "GET",
		url: url,
		data: commentData,
		headers: {"Authorization": cToken},
		async: true,
		success: function (data) {				
			var rating = data;			
			//alert("!-" + rating);
			$('#ulDiv').rateYo('rating', rating);
		},
		error: function (data) {
            alert("!-" +JSON.stringify(data));
		}        
    });
}
	
function setCommentUsers(page, searchTerm){
	alert("setCommentUsers()-Before@" + getLocalToken());
	var url = rateit + "api/Comment/GetComments";
	var commentData = {
		"page" : page,
		"encodedUrl": encodeURIComponent(window.location),
		"searchTerm": searchTerm
	};
	var auth = JSON.parse(getLocalToken());
    var cToken = ("Bearer "+ auth.access_token);
    alert("setCommentUsers()-After@ " + cToken);
			
	$.ajax({
		type: "GET",
		url: url,
		data: commentData,
		headers: {"Authorization": cToken},
		async: true,
		success: function (data) {	
			var comUsers = JSON.parse(data);				
		    commentsArray = comUsers.Comments;
			alert(commentsArray);
		    usersArray = comUsers.Users;
		    alert(usersArray);
			createCommentSection();
			createPaginationBar(comUsers.TotalComments, page);
			hideModal();
			//$('#for-logo').text(http.responseText);
		},
		error: function (data) {
            alert(JSON.stringify(data));
			commentsArray = [];
	        usersArray = [];
		    createCommentSection();
		}        
    });
}
	
function register(id){
	var url = rateit + "api/Account/RegisterUser";
	var regData = {
		"Name": myid,
		"Email": "n@n.n",
		"Password": encodeURIComponent($('#register-submit-pw').val()),
		"ConfirmPassword" : encodeURIComponent($('#register-submit-cpw').val())
	};

	$.ajax({
		type: "POST",
		url: url,
		data: regData,			
		contentType: "application/x-www-form-urlencoded",
		async: true,
		success: function (data) {
			//alert(JSON.stringify(data));
			$('#for-logo').text(JSON.stringify(data));
			$('.move-right-loading-r').hide(); 
		},
		error: function (data) {
			$('.move-right-loading-r').hide();
		}        
    });
}
	
function rate(rating){
	var url = rateit + "api/Rating/AddRating";
	var rateData = {
		"Rating": rating,
		"Site": encodeURIComponent(window.location)
	};
			
	var token = getLocalToken();
	var cToken = ("Bearer "+ JSON.parse(token).access_token);
	
	$.ajax({
		type: "POST",
		url: url,
	    data: rateData,
		contentType: "application/x-www-form-urlencoded",
        headers: {"Authorization": cToken},				
		async: true,
		success: function (data) {
		},
		error: function (data) {
     		//alert(JSON.stringify(data));	
		}        
	});
}
	
function getToken(id,password){	
	var isAuthorised = false;
	var loginData = {
		"username": id,
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
			setAppToken(JSON.stringify(data));	
            setLocalToken(JSON.stringify(data));	
			//if(data.access_token){
			hideModal();			
	    	isAuthorised = true;
			//}				
		},
		error: function (data) {
			isAuthorised = false;
			$('.move-right-loading-li').hide();
		}        
    });	
	return isAuthorised;
}
	
function setLocalToken(rawToken){
	window.localStorage.setItem("login_ri", rawToken);	
}
	
function setAppToken(rawToken){
	chrome.runtime.sendMessage({method:"setToken", token:rawToken},function(){});
}
	
function getLocalToken(){
	var token = window.localStorage.getItem("login_ri");
	if(token){
		return token;	
	}	
	else{
		return "[]";
	}
}

function doesTokenExist(){
	var token = getLocalToken();
	if(!token || token == "[]")
		return false;
	return true;
}

function initAppToken(){
	var token = "[]";
	chrome.runtime.sendMessage({method:"getToken"},function(token){
	  setLocalToken(token);
	});
}
	  
function createDiv(id, classVal, textVal){
	return $('<div />', {
            id: id,
			class: classVal,
			text: textVal
       });
}

function addCSSLinks(file){
	var link = document.createElement("link");
	link.href = chrome.extension.getURL(file);
	link.type = "text/css";
	link.rel = "stylesheet";
	document.getElementsByTagName("head")[0].appendChild(link);
}

function addEvents(){
	  var windowid = "1";
        //Resize
        /*$(function () {
            $("#" + "id_" + windowid).resizable();
        });*/

        //Drag
        $("#chat-holder-ma").draggable({
            containment: "body",
			//cancel: "#chat-holder-ma"
			handle: "#root-div"
		});
	
        //Follow
        $.fn.scrollBottom = function () {
            return $(document).height() - this.scrollTop() - this.height();
        };

        var $el = $("#" + "id_" + windowid);
        var $window = $(window);

        $window.bind("scroll resize", function () {
            var gap = $window.height() - $el.height() - 10;
            var visibleFoot = 172 - $window.scrollBottom();
            var scrollTop = $window.scrollTop()

            if (scrollTop < 172 + 10) {
                $el.css({
                    top: (172 - scrollTop) + "px",
                    bottom: "auto"
                });
            } else if (visibleFoot > gap) {
                $el.css({
                    top: "auto",
                    bottom: visibleFoot + "px"
                });
            } else {
                $el.css({
                    top: 0,
                    bottom: "auto"
                });
            }
        });
		
		var pw = "Vs1-"+chrome.runtime.id;
			
		setTabSelection();
		checkForNewListeners();
		setFocusOnTextAreas();
		setPostWordCounter();
		initEmoji();
}

function openTab(tabId) {
        var root = document.querySelector('#root-div').shadowRoot;
        var itemSelected = root.querySelector('#' + tabId);
        var commentTab = root.querySelector('.comment-section');
        var statsTab = root.querySelector('.ri-moc-section');
        var profileTab = root.querySelector('.ri-profile-section');

        if (tabId === "cw-profile") {
            profileTab.style.display = 'block';
            commentTab.style.display = 'none';
            statsTab.style.display = 'none';
            root.querySelector('#cw-profile').classList.add("selected-tab");
            root.querySelector('#cw-chat').classList.remove("selected-tab");
            root.querySelector('#cw-stats').classList.remove("selected-tab");
        } else if (tabId === "cw-chat") {
            profileTab.style.display = 'none';
            commentTab.style.display = 'block';
            statsTab.style.display = 'none';
            root.querySelector('#cw-profile').classList.remove("selected-tab");
            root.querySelector('#cw-chat').classList.add("selected-tab");
            root.querySelector('#cw-stats').classList.remove("selected-tab");
        }
        else if (tabId === "cw-stats") {
            profileTab.style.display = 'none';
            commentTab.style.display = 'none';
            statsTab.style.display = 'block';
            root.querySelector('#cw-profile').classList.remove("selected-tab");
            root.querySelector('#cw-chat').classList.remove("selected-tab");
            root.querySelector('#cw-stats').classList.add("selected-tab");
        }
}

function setTabSelection(){
	var root = document.querySelector('#root-div').shadowRoot;
    var profile = root.querySelector('#cw-profile');
    profile.addEventListener('click', function () { openTab("cw-profile"); });
    var chat = root.querySelector('#cw-chat');
    chat.addEventListener('click', function () { openTab("cw-chat"); });
    var stats = root.querySelector('#cw-stats');
    stats.addEventListener('click', function () { openTab("cw-stats"); });
}

function setSubCommentLinks(querySelector){
	if(!querySelector){
		querySelector = 'div[loadsub-been=false] a';
	}
	//sub-comments-list
	var root = document.querySelector('#root-div').shadowRoot;
    var commentLists = root.querySelectorAll(querySelector);
	for(var i=0;i< commentLists.length;i++){
		$(commentLists[i]).parent().parent().attr("loadsub-been", "true");
		commentLists[i].addEventListener('click', function () { 
			var value = ($(this).parent().parent().attr("value")); 
			var id = '#sub-comments-' + value;
			var url = rateit + "ChatWindow/GetSubComments";
			$.ajax({
				type: "POST",
				url: url,
				data: {parentId: value},
				contentType: "application/x-www-form-urlencoded",
				//headers: {"Authorization": cToken},				
				success: function (data) {
					var section = root.querySelector(id);
					section.innerHTML = data;
					checkForNewListeners();
				}       
			});
		});
	}
}

function addListenersToLoadMoreLinks(querySelector){
	if(!querySelector){
		querySelector = 'div[loadmore-been=false] a';
	}
	var root = document.querySelector('#root-div').shadowRoot;
    var loadMore = root.querySelectorAll(querySelector);
	
	for(var i=0;i< loadMore.length;i++){
		$(loadMore[i]).parent().attr("loadmore-been", "true");
		loadMore[i].addEventListener('click', function () { 
			var loadMoreItem = $(this);
            var value = ($(this).attr("value"));			
			var currentPage = root.querySelector("#CurrentPage");//$(root.querySelector("#CurrentPage")).val();
            var perPage = root.querySelector("#PerPage");//$(root.querySelector("#PerPage")).val();	
		    var pageId = root.querySelector("#CurrentPageId");//$(root.querySelector("#CurrentPageId")).val();
		    var url = rateit + "ChatWindow/GetMoreComments";
			$.ajax({
				type: "POST",
				url: url,
				data: {siteId: pageId.value, commentId: value, pageNum: currentPage.value, perPage: perPage.value},
				contentType: "application/x-www-form-urlencoded",
				//headers: {"Authorization": cToken},				
				success: function (data) {
					//Update page data
					var existing = parseInt(currentPage.value);
					if(!existing) existing = 0;
					root.querySelector("#CurrentPage").value = (existing + 1);			
					//Append new data & remove load more
					loadMoreItem.parent().parent().append(data);		
					loadMoreItem.parent().remove();
					checkForNewListeners();
				}       
			});			
	    });
	}
	
}

function checkForNewListeners(){
	setSubCommentLinks();
	addListenersToCommentContent("span[ru-been=false]", "RateUp", "ru-been");
    addListenersToCommentContent("span[rd-been=false]", "RateDown", "rd-been");
	addListenersToCommentContent("span[flag-been=false]", "Flag", "flag-been");
	addListenersToReplyButtons("span[init=false]", "init");
	addListenersToLoadMoreLinks();
}

function addListenersToReplyButtons(querySelector, attr){
    var root = document.querySelector('#root-div').shadowRoot;
    var commentLists = root.querySelectorAll(querySelector);
	for(var i=0;i< commentLists.length;i++){
		$(commentLists[i]).attr(attr, "true");
		commentLists[i].addEventListener('click', function () { 
			var value = ($(this).attr("value")); 	
			alert(value);
			//
		});
	}
}

function setPostWordCounter(){
    var root = document.querySelector('#root-div').shadowRoot;
	var commentBox = root.querySelector("#cmt-cb-w");
	var wordCounter = root.querySelector("#word-counter");
	var currentCount = commentBox.innerText.length;
	commentBox.addEventListener('keydown', function () { 	
        currentCount = commentBox.innerText.length;	
		wordCounter.innerText = (currentCount + "/" + 250);
	});
	commentBox.addEventListener('keyup', function () { 
	    currentCount = commentBox.innerText.length;
		wordCounter.innerText = (currentCount + "/" + 250);
	});
	commentBox.addEventListener('keypress', function () { 
	    currentCount = commentBox.innerText.length;
		wordCounter.innerText = (currentCount + "/" + 250);
	});
	commentBox.addEventListener('click', function (e) { 
	    e.stopPropagation();
	});
}

//Shadow root text areas need an event for focus wrapped round it
function setFocusOnTextAreas(){
	var root = document.querySelector('#root-div').shadowRoot;
	var commentBox = root.querySelector("#cmt-cb-w");
	commentBox.addEventListener('click', function () { 
		this.focus();
	});
	var searchBox = root.querySelector(".searchTerm-cmt");
	searchBox.addEventListener('click', function () { 
		this.focus();
	});
}

function postComment(){	
    var root = document.querySelector('#root-div').shadowRoot;
    var commentBox = root.querySelector("#");
	
    var url = rateit + "ChatWindow/AddComment";
    var content = "";
	var commentId = 
	$.ajax({
			type: "POST",
			url: url,
			data: {commentId: value, content: content, siteName: encodeURIComponent(window.location)},
			contentType: "application/x-www-form-urlencoded",
		    //headers: {"Authorization": cToken},				
			success: function (data) {
				//var section = root.querySelector(id);
				//section.innerHTML = data;
				//setSubCommentLinks(id + " a");
				alert(data);
			}       
	});
}

function addListenersToCommentContent(querySelector, extension, attr){
	var root = document.querySelector('#root-div').shadowRoot;
    var commentLists = root.querySelectorAll(querySelector);
	for(var i=0;i< commentLists.length;i++){
		$(commentLists[i]).attr(attr, "true");
		commentLists[i].addEventListener('click', function () { 
			var value = ($(this).attr("value")); 	
			var url = rateit + "ChatWindow/" + extension;
			$.ajax({
				type: "POST",
				url: url,
				data: {commentId: value},
				contentType: "application/x-www-form-urlencoded",
				//headers: {"Authorization": cToken},				
				success: function (data) {
					//var section = root.querySelector(id);
					//section.innerHTML = data;
					//setSubCommentLinks(id + " a");
					alert(data);
				}       
			});
		});
	}
}

function initEmoji(){  
    var root = document.querySelector('#root-div').shadowRoot;
    var emotionArea = root.querySelector('.emotion-area');
	function ApndImgEmotion() {
		for (var i = 65; i <= 70; i++) {
			$(emotionArea).append(
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f60') + String.fromCharCode(i).toLowerCase() + '.png">' + 
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f61') + String.fromCharCode(i).toLowerCase() + '.png">' + 
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f62') + String.fromCharCode(i).toLowerCase() + '.png">' + 
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f47') + String.fromCharCode(i).toLowerCase() + '.png">' +
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f49') + String.fromCharCode(i).toLowerCase() + '.png">'
			);
		}
		for (var i = 4; i <= 8; i++) {
			$(emotionArea).append(
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f32') + i + '.png">'
			);
		}
		for (var i = 3; i <= 8; i++) {
			$(emotionArea).append(
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f49') + i + '.png">'
			);
		}
		for (var i = 0; i <= 9; i++) {
			$(emotionArea).append(
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f60') + i + '.png">'
			);
		}
		for (var i = 10; i <= 44; i++) {
			$(emotionArea).append(
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f6') + i + '.png">'
			);
		}
		for (var i = 10; i <= 17; i++) {
			$(emotionArea).append(
				'<img width="30px" height="30px" contenteditable="true" src="' + chrome.extension.getURL('img/1f9') + i + '.png">'
			);
		}
	}

    var emotionIcon = root.querySelector('.emotion-Icon');
	var commentBox = root.querySelector('#cmt-cb-w');
	var haventAlreadyAddedListener = true;
    emotionIcon.addEventListener('click', function () {   
        if(menuShowing === false){
			ApndImgEmotion();
			menuShowing = true;
			$(emotionArea).show();				
			var emotionAreaImg = root.querySelectorAll('.emotion-area img');
			if(emotionAreaImg){
				for(var i=0;i<emotionAreaImg.length;i++){
					emotionAreaImg[i].addEventListener('click', function () {				
						var imgIcon = $(this).clone();
						$(commentBox).append(imgIcon);
					});
				}
			}
		}			
		else {
			$(emotionArea).html("");
			menuShowing = false;
			$(emotionArea).hide();	
		}
	});

    emotionArea.addEventListener('click', function (e) { 
	    e.stopPropagation();
	});
	
	commentBox.addEventListener('click', function () {	
        //Sort the caret out!!!!
	});	
}

function launchWindow(data){
	
	addCSSLinks("css/fontawesome.css");
	addCSSLinks("css/fa-regular.css");
	$('head').append('<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">');
			
	$('html').append(data);
	var chatWindow = createDiv("chat-holder-ma","chat-window-ri");		
	$('html').append(chatWindow);		
			
	var rootDiv = createDiv("root-div","root-div");
	chatWindow.append(rootDiv);
			
	var host = document.querySelector('#root-div');
    var root = host.createShadowRoot();
    var template = document.querySelector('#main-chat-window');
    root.appendChild(document.importNode(template.content, true));
	
    root.querySelector("#login-div").querySelectorAll("input").forEach(function(x){$(x).attr("value","test@test.com");});
	
    addEvents();
}

//Display app
function displayApp(){	
    //https://localhost:44322/  
	var url = rateit + "ChatWindow/Index";

	$.ajax({
		type: "POST",
		url: url,
	    data: { encodedUrl:encodeURIComponent(window.location) },
		contentType: "application/x-www-form-urlencoded",
        //headers: {"Authorization": cToken},				
		async: true,
		success: function (data) {
			launchWindow(data);
		},
		error: function (data) {
     		console.log(data);
		}        
	});
}

displayApp();