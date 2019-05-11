var logoBase64 = "data:image/png;base64,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";
var refreshBase = "data:image/png;base64,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";
var poweredby = '<svg id="Layer_1" data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 79.52246 13.03541"><defs><style>.cls-1,.cls-2{fill:#fff;}.cls-2{font-size:7.5461px;font-family:Lato-Regular, Lato;}.cls-3{letter-spacing:-0.01048em;}.cls-4{letter-spacing:-0.02304em;}.cls-5{letter-spacing:-0.03947em;}</style></defs><path class="cls-1" d="M55.23574.21227h2.01652V1.539h.03533a2.87166,2.87166,0,0,1,.911-1.07023A2.76222,2.76222,0,0,1,59.88791,0a2.58227,2.58227,0,0,1,2.65332,1.57432A3.00161,3.00161,0,0,1,63.691.3803,3.3598,3.3598,0,0,1,65.33615,0a3.26966,3.26966,0,0,1,1.43273.28306,2.50822,2.50822,0,0,1,.94643.77826A3.2083,3.2083,0,0,1,68.23706,2.22a6.09092,6.09092,0,0,1,.15926,1.424V8.703H66.27354V3.89158a3.934,3.934,0,0,0-.07067-.7517,1.80346,1.80346,0,0,0-.24773-.6368,1.25757,1.25757,0,0,0-.47753-.43343,1.6605,1.6605,0,0,0-.77839-.15926,1.75188,1.75188,0,0,0-.84016.18583,1.6412,1.6412,0,0,0-.566.4952,2.02945,2.02945,0,0,0-.3184.70759,3.36913,3.36913,0,0,0-.09736.80483V8.703H60.75464V3.644a2.1316,2.1316,0,0,0-.33607-1.26482,1.278,1.278,0,0,0-1.11446-.46876,2.02857,2.02857,0,0,0-.89329.17693,1.71765,1.71765,0,0,0-.60133.47766,1.89951,1.89951,0,0,0-.345.6898,3.07766,3.07766,0,0,0-.10613.81373V8.703H55.23574Z"/><path class="cls-1" d="M70.28879,8.57784A4.48859,4.48859,0,0,1,70.65142,6.747a4.277,4.277,0,0,1,.98176-1.40629,4.32639,4.32639,0,0,1,1.46819-.90219,5.27126,5.27126,0,0,1,3.60851,0,4.32766,4.32766,0,0,1,1.46819.90219A4.28284,4.28284,0,0,1,79.15983,6.747a4.4929,4.4929,0,0,1,.36263,1.83082,4.49378,4.49378,0,0,1-.36263,1.83082,4.28092,4.28092,0,0,1-.98176,1.40616,4.32766,4.32766,0,0,1-1.46819.90219,5.27126,5.27126,0,0,1-3.60851,0,4.32639,4.32639,0,0,1-1.46819-.90219,4.27511,4.27511,0,0,1-.98176-1.40616A4.48947,4.48947,0,0,1,70.28879,8.57784Zm2.12278,0a2.7548,2.7548,0,0,0,.168.95519,2.38948,2.38948,0,0,0,.4952.8136,2.50883,2.50883,0,0,0,3.66164,0,2.40008,2.40008,0,0,0,.49533-.8136,2.799,2.799,0,0,0,0-1.91039,2.4057,2.4057,0,0,0-.49533-.81373,2.50919,2.50919,0,0,0-3.66164,0,2.395,2.395,0,0,0-.4952.81373A2.75695,2.75695,0,0,0,72.41157,8.57784Z"/><path class="cls-1" d="M70.99728,10.32041s-2.88,1.06771-2.62713-2.023H66.27354s.50909,5.90051,5.49642,3.6246"/><text class="cls-2" transform="translate(0 9.62823)">P<tspan class="cls-3" x="4.53125" y="0">O</tspan><tspan x="10.49268" y="0">WERED </tspan><tspan class="cls-4" x="39.4209" y="0">B</tspan><tspan class="cls-5" x="44.12598" y="0">Y</tspan></text></svg>';

//AppId - visible: chrome://extensions/
var myid = chrome.runtime.id;
//var userInfo = getUserDetails();

//Main site
var rateit = "https://localhost:44322/";

//For display
var commentsArray = [];
var usersArray = [];
var currentTab = createDiv("dft","dft");

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
            console.log("!-" +JSON.stringify(data));
		}        
    });
}
	
function setCommentUsers(page, searchTerm){
	var url = rateit + "api/Comment/GetComments";
	var commentData = {
		"page" : page,
		"encodedUrl": encodeURIComponent(window.location),
		"searchTerm": searchTerm
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
			var comUsers = JSON.parse(data);				
		    commentsArray = comUsers.Comments;
			alert(commentsArray);
		    usersArray = comUsers.Users;
		    alert(usersArray);
			createCommentSection();
			createPaginationBar(comUsers.TotalComments, page);
			hideModal();
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
			//Update star rating
		},
		error: function (data) {
     		console.log(JSON.stringify(data));	
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
			if(data.access_token){
				setAppToken(JSON.stringify(data));	
                setLocalToken(JSON.stringify(data));	
				hideModal();			
				isAuthorised = true;
			}
            else{
				//Show error
				console.log("Error getting token");
            }			
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

function initAppToken(){
	var token = "[]";
	chrome.runtime.sendMessage({method:"getToken"},function(token){
	  setLocalToken(token);
	});
}
	
//Please all ignore the fuckery below - I know how bad this is.. 
function createImageWH(img, classVal, height, width){
	return $('<img />', {
               src: img,	
			   class: classVal,
		       height: height,
		       width: width
            });
}
	
function createRadio(id, name, value){
	return $('<input />', {
            id: id,
			type: "radio",
			name: name,
			value: value
        });
}

function createLabel(forValue, name, title){
	return $('<label />', {
           for: "5-star",
    	   name: "rating",
		   title:title
        });
}
	
function createImage(img, classVal){
	return $('<img />', {
            src: img,
			class: classVal
       });
}


function createDiv(id, classVal){
	return $('<div />', {
			id: id,
			class: classVal
	});
}

function createTd(id, classVal){
	return $('<td />', {
            class: "main_element_class"
    });
}

function createUl(id, classVal){
	return $('<ul />', {
            id: id,
			class: classVal
    });
}
	
function createTextbox(id, placeholderVal, classVal){
	return $('<input />', {
            id: id,
			type: "text",
			class: classVal,
			placeholder: placeholderVal
    });
}

function createHidden(id, valueToAdd){
	return $('<input />', {
            id: id,
			type: "hidden",
			class: id,
			value: valueToAdd
    });
}

function createTextDiv(classVal, textVal, idVal){
	return $('<div />', {
		    id: idVal,
			class: classVal,
			text: textVal
    });
}
	

function createSpan(classVal, textValue){
	return $('<span />', {
			class: classVal,
			text: textValue
    });
}

function createSpanTxt(classVal, textValue){
	return $('<span />', {
			class: classVal,
			text: textValue
    });
}

function createSpanWithTitle(classVal, textValue, titleVal, idVal){
	return $('<span />', {
		    id: classVal + idVal,
			class: classVal,
			text: textValue,
			title: titleVal
    });
}
 
function createLink(id, hrefVal){
	return $('<a />', {
            id: id,
			href:hrefVal
    });
}

function createLinkText(id, hrefVal, textVal){
	return $('<a />', {
            id: id,
			href:hrefVal,
			text: textVal
    });
}
	
function createLink(id ,classVal ,hrefVal){
	return $('<a />', {
        id: id,
	    href:hrefVal,
		class: classVal
    });
}
	
function createPageLink(page, isPage){
	return $('<a />', {
		href : "javascript:goToPage("+page+");",
		class : isPage,
		text: page
	});
}

function createLi(classValue, titleVal, valueVal){
	return $('<li />', {
		class : classValue,
		title: titleVal,
		value: valueVal
	});
}

function createTextArea(idVal, classVal){
	return $('<textarea />', {
		id: idVal,
		placeholder: "Enter Text Here..",
		class: classVal
	});
}

function createSection(idVal, classVal){
	return $('<section />', {
		id: idVal,
		class : classVal
	});
}

function createIcon(classVal, textVal){
	return $('<i />', {
		class : classVal,
		text: textVal
	});
}

function createSpanStar(classVal){
	return $('<span />', {
		class : classVal
	});	
}

function createIdenticonSVG(){
	return $('<svg />', {
	    id: "mo-icon",
		class: "mo",
		width:"32",
		height: "32"
	});
}

function createDropdown(data, idVal, classVal){
	var s = $('<select />', {
		id: idVal,
		class: classVal
	});
	for(var val in data) {
		$('<option />', {value: val, text: data[val]}).appendTo(s);
	}
	return s;
}

function createStyleDiv(classVal, percent){
	return $('<div />', {
		class : classVal,
		style : ("width:" + percent + "%;")
	});	
}

function createEmojiTextArea(idVal, classVal){
	var emojiBox = $('<input />', {
		id: idVal,
		class: classVal,
		type: "email",
		maxlength: 50,
		style : ("width:" + 70 + "%;")
	});	
	emojiBox.prop('data-emojiable', true);
	return emojiBox;
}

function createSearchBox(){
	
	var i = $('<i />', {
		class: "fa"
	});
	i.addClass("fa-search");
	var searchTerm = $('<input />', {
	    type: "text",
		class: "searchTerm-cmt",
		placeholder: "Search Comments.."
	});
	searchTerm.append(i);
	return searchTerm;
}

function createCommentButtonBar(){
	var windowid = hashCode(window.location.host);
	var bar = createDiv("btn-bar" + windowid, "btn-bar");
	var filterAz = createSpan("cmt-filter-az", "");
	filterAz.addClass("small-btn");
	var icon1 = createIcon("material-icons", "sort_by_alpha");
	filterAz.append(icon1);
	var refresh = createSpan("cmt-refresh", "");
	refresh.addClass("small-btn");
	var icon2 = createIcon("material-icons", "loop");
	refresh.append(icon2);
	bar.append(filterAz);
	bar.append(refresh);
	return bar;
}

function createButtonPanel(id, img){
	var buttonPanel = $('<span />', {
	    id: id,
		class: "section-button"
	});
	var icon = $('<i />', {
		class: "fa"
	});
	icon.addClass(img);
	icon.addClass("tab-icons");
	buttonPanel.append(icon);
	return buttonPanel;
}

function createStyledButton(idVal, nameVal, valueVal){
	return $('<input />', {
		id: idVal,
		type: "button",
		name: nameVal,
		style: "display:block;",
		tabindex: 4,
		value: valueVal,
		class : "login-reg-ri"
	});
}
//End of pure fuckery

function subStrAfterChars(str, chr, pos) {
    if (pos === 'b') 
       return str.slice(str.indexOf(chr) + 1);
    else if (pos === 'a')
       return str.slice(0, str.indexOf(chr));
    else
        return str;
}

function createOpenPage(pageNum, searchVal, pageLab, title, isActive, id){
	
	var page = createDiv("ctrl-bar-page","ctrl-bar-page");
	var pageLabel = createSpanWithTitle("ctrl-bar-page-lab",subStrAfterChars(pageLab, '.', 'b'), pageLab, id);
	var cross = createTextDiv("ctrl-bar-cross","X", id);
	var pageNumber = createHidden("ctrl-bar-pagenum" ,pageNum);
	var hostAddress = createHidden("ctrl-bar-host" ,pageLab);
	var searchTerm = createHidden("ctrl-bar-searchval" ,searchVal);
	var titleVal = createHidden("ctrl-bar-title" ,title);
	page.append(pageLabel);
	page.append(cross);
	page.append(pageNumber);
	page.append(searchTerm);
	page.append(hostAddress);
	page.append(titleVal);
	if(isActive === true){
		page.addClass("active-border-ri");
		cross.addClass("disabled-cursor");
	}else{
		page.addClass("ctrl-bar-page-border");
	}
	return page;
}

function getAndAddPageIfNoExist(hostname, bottomBarPageContainer){
	var newOpenPageList = [];
	var exists = false;
	var savedIndex = -1;
	chrome.runtime.sendMessage({method:"getOpenPages"},function(openPages){
		newOpenPageList = openPages;
		for(var i =0;i<openPages.length;i++){		
			if(openPages[i].pagelabel == hostname){
				exists = true;	
                savedIndex = i;				
			}
		}
		if(exists == false){
			var title = $(document).find("title").text();
			newOpenPageList.unshift({ pagenumber:1, searchterm:"", pagelabel:hostname, pagetitle:title, isActve:true});
		}else{
			if((savedIndex > -1) && (newOpenPageList.length > 0)){
				//newOpenPageList = move(newOpenPageList, savedIndex, 0);
			}
		}
		
		var openPages = newOpenPageList;
		for	(var i = 0; i< openPages.length; i++){
			var pageData = openPages[i];
			var isActve = false;
			if(hostname === pageData.pagelabel){
				isActve = true;
			}
			bottomBarPageContainer.append(createOpenPage(pageData.pagenumber, pageData.searchterm, pageData.pagelabel, pageData.pagetitle, isActve, ('openPage' + i)));
		}
		return newOpenPageList;
	});
}

function removePage(hostname){
	var newOpenPageList = [];
	chrome.runtime.sendMessage({method:"getOpenPages"},function(openPages){
		for(var i =0;i<openPages.length;i++){		
		//alert(openPages[i].pagelabel + " : " + hostname);
			if(openPages[i].pagelabel != hostname){
				newOpenPageList.push(openPages[i]);					
			}
		}
		//set list in background
	    chrome.runtime.sendMessage({method:"setOpenPages", openPages:newOpenPageList},function(){});
	});
}

function createMainButton(classVal, btnText){
	return $('<div />', {
		class : classVal,
		type: "button",
		text: btnText,
		value: btnText
	});	
}

function createMocSection(hideOnCreate, profile){

	var mocSection = createDiv("ri-moc-section_"+profile.id, "ri-moc-section");
	var mocOverTime = createDiv("mo-over-time_"+profile.id, "mo-over-time");
	var mocHolder = createDiv("moc-ctrl-hldr"+ profile.id, "moc-ctrl-hldr");
	var mocAmount = createDiv("moc-ctrl-amt"+ profile.id, "moc-ctrl-amt");
	var mocBuy = createDiv("moc-ctrl-buy"+ profile.id, "moc-ctrl-buy");
	var mocWithdraw = createDiv("moc-ctrl-withdraw"+ profile.id, "moc-ctrl-withdraw");
	var mocGraphCtrl = createDiv("moc-ctrl-graph"+ profile.id, "moc-ctrl-graph");
	
	var buyAmount =createTextbox("moc-amt-ta_" + profile.id, "Amount..", "moc-amt-ta");
	var amountBtn = createSpan("moc-amt", "Buy");
	amountBtn.addClass("std-btn");
	mocAmount.append(buyAmount);
	mocAmount.append(amountBtn);
	
	var withdrawAmount =createTextbox("moc-amt-w-ta_" + profile.id, "Amount..", "moc-amt-w-ta");
	var wAmountBtn = createSpan("moc-amt-w", "Withdraw");
	wAmountBtn.addClass("std-btn");
	var data = {
		 'foo': 'bar',
         'foo2': 'baz'
	};
	var accDropdown = createDropdown(data, "moc-acc-dd_" + profile.id, "moc-acc-dd");
	mocWithdraw.append(withdrawAmount);
	mocWithdraw.append(accDropdown);
	mocWithdraw.append(wAmountBtn);

	
	var data2 = {
		 'foo': 'bar',
         'foo2': 'baz'
	};
	var typeDropdown = createDropdown(data2, "moc-typ-dd_" + profile.id, "moc-typ-dd");
	var data3 = {
		 'foo': 'bar',
         'foo2': 'baz'
	};
	var dateDropdown = createDropdown(data3, "moc-dat-dd_" + profile.id, "moc-dat-dd");
	mocGraphCtrl.append(dateDropdown);
	mocGraphCtrl.append(typeDropdown);
	
	mocHolder.append(mocAmount);
	mocHolder.append(mocBuy);
	mocHolder.append(mocWithdraw);
	
	mocSection.append(mocHolder);
	mocSection.append(mocGraphCtrl);
	mocSection.append(mocOverTime);
	
	//Chart init
    mocOverTime.sparkline([1,2,5,2,7,6,4,2,7,5,8,7,9], {
		type: 'line',
		width: '450px',
		height: '180px',
		lineColor: '#7f7f7f',
		lineWidth: 3,
		fillColor: false
	});
	
	if(hideOnCreate && hideOnCreate === true){
		//Hide the moc section
		mocSection.hide();
	}
	return mocSection;	
}

function createProfileSection(hideOnCreate, profile){
   
	var profileSection = createDiv("ri-profile-section_"+profile.id, "ri-profile-section");
	var circleProfilePic = createSpan("profile-pic");
	circleProfilePic.addClass("empty-profile");
	circleProfilePic.attr("id", "profile-pic_"+profile.id);
	var camIcon = createIcon("material-icons", "photo_camera");
	camIcon.addClass("cam-icon");
	circleProfilePic.append(camIcon);
	//var img = createDIv("profile-pic-img_" +profile.id, "profile-pic-img");
	
	var lastActiveLabel = createSpan( "last-active");
	lastActiveLabel.text("Last Active: " + profile.lastActive);
	lastActiveLabel.attr("id", "last-active_" + profile.id);
	
	var logout = createMainButton("logout-btn", "Logout");
	var update = createMainButton("update-btn", "Update");
	
	var textAreaLabel = createSpan("prof-desc-lab", "About Me: ");
	var textArea = createTextArea("prof-desc_" + profile.id, "prof-desc-ta");
	
	var email = createSpan("email-prof");
	var emailIcon = createIcon("material-icons", "email");
	emailIcon.addClass("base-icon");
	email.text(profile.email);
	email.append(emailIcon);

	var name = createSpan("name-prof");
	var nameIcon = createIcon("material-icons", "account_circle");
	name.text("Username: ");
	name.append(nameIcon);
	nameIcon.addClass("base-icon");
	var nameBox = createTextbox("name-prof-tb_"+profile.id, "Enter Username Here..", "name-prof-tb");
	nameBox.text(profile.name);
	
	var pw = createSpan("pw-prof");
	var pwIcon = createIcon("material-icons", "vpn_key");
	pw.text("Password: ");
	pw.append(pwIcon);
	pwIcon.addClass("base-icon");
	var pwBox = createTextbox("pw-prof-tb_"+profile.id, "Enter Password Here..", "pw-prof-tb");
	pwBox.text(profile.password);
	var visBox = createSpan("vis-icon");
	var visIcon = createIcon("material-icons", "visibility");
	visBox.append(visIcon);
	//profile.name);
	//name.attr("id", "name-prof_"+profile.id);
	
	var overall_rating = createSpan("overall-rating");
	var orIcon = createIcon("material-icons", "star_rate");
	overall_rating.text("Overall Rating: " + profile.overall_rating);
	overall_rating.append(orIcon);
	orIcon.addClass("base-icon");
	orIcon.addClass("str-icon");
	//overall_rating.attr("id", "overall-rating_"+profile.id);
	
	var overall_report = createSpan("overall-report");
	var orptIcon = createIcon("material-icons", "flag");
	overall_report.text("Overall Reported: " + profile.overall_report);
	overall_report.append(orptIcon);
	orptIcon.addClass("base-icon");
	//overall_report.attr("id", "overall-report_"+profile.id);
	
	var overall_rating_count = createSpan( "overall-rating-count");
	var orcIcon = createIcon("material-icons", "format_list_numbered");
	overall_rating_count.text("Overall Rating Count: " +profile.overall_rating_count);
	overall_rating_count.append(orcIcon);
	orcIcon.addClass("base-icon");
	//overall_rating_count.attr("id", "overall-rating-count_"+profile.id);
	
	var overall_comment_count = createSpan("overall-comment-count");
	var occIcon = createIcon("material-icons", "chat");
	overall_comment_count.text("Overall Comment Count: " + profile.overall_comment_count);
	overall_comment_count.append(occIcon);
	occIcon.addClass("base-icon");
	//overall_comment_count.attr("id", "overall-comment-count_"+profile.id);
	
	var profileSectionTop = createSpan("prof-section-top");
	
	
	profileSection.append(circleProfilePic);
	profileSection.append(lastActiveLabel);
	profileSection.append(logout);
	profileSection.append(profileSectionTop);
	
	profileSection.append(name);
	profileSection.append(nameBox);
	profileSection.append(pw);
	profileSection.append(pwBox);
	profileSection.append(visBox);

	profileSection.append(textAreaLabel);
	profileSection.append(textArea);
	profileSection.append(update);
	
	profileSectionTop.append(email);
	profileSectionTop.append(overall_rating);
	profileSectionTop.append(overall_report);
	profileSectionTop.append(overall_rating_count);
	profileSectionTop.append(overall_comment_count);
	
	if(hideOnCreate && hideOnCreate === true){
		//Hide the profile section
		profileSection.hide();
	}
	return profileSection;
}

function createStarRating(percent){
	var starBox = createDiv("star-ratings-css", "star-ratings-css");
	var topBox = createStyleDiv("star-ratings-css-top", percent);
	var bottomBox = createDiv("star-ratings-css-bottom", "star-ratings-css-bottom");
	var star = createSpan("star","★");
	starBox.append(topBox);
	starBox.append(bottomBox);
	topBox.append(createSpan("star","★"));
	topBox.append(createSpan("star","★"));
	topBox.append(createSpan("star","★"));
	topBox.append(createSpan("star","★"));
	topBox.append(createSpan("star","★"));	
	bottomBox.append(createSpan("star","★"));
	bottomBox.append(createSpan("star","★"));
	bottomBox.append(createSpan("star","★"));
	bottomBox.append(createSpan("star","★"));
	bottomBox.append(createSpan("star","★"));
	return starBox ;
}

function createCommentList(comments){
	var commentList = createDiv("cmt-list", "cmt-list");
	if(comments && comments.length){		
		for(var i = 0; i< comments.length; i++){
			var rawComment = comments[i];
			var comment = createCommentForList(rawComment);
			commentList.append(comment);
		}		
		return commentList;
	}
	return commentList;
}

function createCommentForList(comment){
	
	var windowid = hashCode(window.location.host);
	var userLabelText = comment.user_label;
	var cmtBody = comment.body;
	var timeStamp = comment.timestamp;
	
	var comment = createDiv("cmt-" + comment.id, "cmt-ri");
	var userLabel = createSpanTxt("user-label", userLabelText);
	
	var cmtButtonSection = createDiv("cmt-btn-set" + windowid, "cmt-btn-set");
	var tuBox = createSpan("mog-icon");
	var tuRate = createSpan("mog-icon-rate-up", comment.upvote_count);
	var tuIcon = createIcon("material-icons", "thumb_up");
	tuIcon.addClass("std-btn-icon");
	var tuPlusIcon = createIcon("material-icons", "exposure_plus_1");
	tuBox.append(tuIcon);
	tuIcon.title = "Up Vote";
	//tuBox.append(tuPlusIcon);
	cmtButtonSection.append(tuBox);
	cmtButtonSection.append(tuRate);
	
	var tdBox = createSpan("mog-icon");
	var tdRate = createSpan("mog-icon-rate-down", comment.downvote_count);
	var tdIcon = createIcon("material-icons", "thumb_down");
	tdIcon.title = "Down Vote";
	tdIcon.addClass("std-btn-icon");
	var tdPlusIcon = createIcon("material-icons", "exposure_plus_1");
	tdBox.append(tdIcon);
	//tdBox.append(tdPlusIcon);
	cmtButtonSection.append(tdBox);
	cmtButtonSection.append(tdRate);
	
	var mogBox = createSpan("mog-icon");
	var mogCount = createSpan("mog-icon-count", comment.moc);
	var mogIcon = createIcon("material-icons", "attach_money");
	mogIcon.title = "MoC";
	mogIcon.addClass("std-btn-icon");
	var mogPlusIcon = createIcon("material-icons", "exposure_plus_1");
	mogBox.append(mogIcon);
	//mogBox.append(mogPlusIcon);
	cmtButtonSection.append(mogBox);
	cmtButtonSection.append(mogCount);
	
	var flagBox = createSpan("mog-icon");
	var flagCount = createSpan("mog-icon-flag", comment.flag_count);
	var flagIcon = createIcon("material-icons", "flag");
	flagIcon.addClass("red-icon");
	flagIcon.addClass("std-btn-icon");
	flagBox.append(flagIcon);
	flagIcon.title = "Flag Comment";
	cmtButtonSection.append(flagBox);
	cmtButtonSection.append(flagCount);
	
	var mainTextBody = createSpanTxt("cmt-txt-bdy", cmtBody);
	var timeStamp = createSpanTxt("cmt-ts", timeStamp);
	comment.append(userLabel);
    comment.append(cmtButtonSection);
	comment.append(mainTextBody);
	comment.append(timeStamp);
	return comment;
}

//Comment tabs are built here
function createCommentSection(host, pageNum, searchTerm, title){
	var windowid = hashCode(window.location.host);
	var commentSection = createDiv("cmt-"+windowid, "comment-section");
	
	var controlBar = createDiv("cb-cmt-"+windowid, "comment-section-cb");
	var leftTextContainer = createDiv("ltc-cmt-"+windowid, "comment-section-ltc");
	var hostText = createDiv("host-cmt-"+windowid, "comment-section-host");
	var title = createSpan("comment-window-title", window.location.host);
	hostText.append(title);
	var hostDescription = createDiv("hdesc-cmt-"+windowid, "comment-section-hdesc");
	var desc = createSpan("comment-window-desc", "This is a test bit of info just to see what everything looks like");
	hostDescription.append(desc);
	
	controlBar.append(leftTextContainer);
	leftTextContainer.append(hostText);
	leftTextContainer.append(hostDescription);
	
	var rightTextContainer = createDiv("rtc-cmt-"+windowid, "comment-section-rtc");
	rightTextContainer.append(createSearchBox());
	rightTextContainer.append(createCommentButtonBar());
	
	controlBar.append(rightTextContainer);	
	commentSection.append(controlBar);
	
	var comments = createDiv("cmt-main"+windowid, "cmt-main");
	//For the moment add dummy data
	var commentsToDisplay = [
	{id: 2, user_label: "User Matt19123 Last Active: 12/04/18", moc: "0.0" , body: "This is going to be the first comment to dislay", timestamp: "11/04/18 12:24", downvote_count: "20", upvote_count: "2" , flag_count: 9},
	{id: 3, user_label: "User Matt19123 Last Active: 12/04/18", moc: "3346" , body: "ThisSecond comment here something blah blah first comment to dislay", timestamp: "11/04/18 12:29" , downvote_count: "35", upvote_count: "29", flag_count: 0},
	{id: 4, user_label: "User Matt19123 Last Active: 12/04/18", moc: "21" ,body: "ThisSecond comment here something blah blah first comment to dislay", timestamp: "11/04/18 12:32" , downvote_count: "6", upvote_count: "33", flag_count: 1},
	{id: 5, user_label: "User Matt19123 Last Active: 12/04/18", moc: "0.00000000002341" , body: "Th something blah blah first comment to dislay", timestamp: "11/04/18 12:39", downvote_count: "6", upvote_count: "3" , flag_count: 0},
	{id: 6, user_label: "User Matt19123 Last Active: 12/04/18", moc: "12.2" , body: "ThisSecond comment herfirst comment to dislay", timestamp: "11/04/18 12:46" , downvote_count: "12", upvote_count: "22", flag_count: 4}
	];
	var commentList = createCommentList(commentsToDisplay);
	comments.append(commentList);
	var post = createMainButton("post-btn", "Post");
	var commentPostHolder = createDiv("cmt-post-hdr"+windowid , "cmt-post-hdr");
	var writeCommentBox = createWriteCommentBox();
	commentPostHolder.append(writeCommentBox);
	commentPostHolder.append(post);
	
	commentSection.append(comments);
	commentSection.append(commentPostHolder);
	
	return commentSection;
}

function createWriteCommentBox(){
	var writeCommentBox = createDiv("cmt-write", "cmt-write");
	//var textArea = createTextArea("cmt-cb-w");
	var textArea = createEmojiTextArea("cmt-cb-w","cmt-cb-w");
	writeCommentBox.append(textArea);

	return writeCommentBox;
}

//Each chat window is built here
function buildChatWindow(windowid, host, pageNum, searchTerm, title){
	var windowid = hashCode(window.location.host);
	var chatWindow = createDiv("cw-main" + windowid, "cw-main");
	var contentBar = createDiv("cw-content-bar" + windowid, "cw-content-bar");
	var mainContentTab = createDiv("cw-tab" + windowid, "cw-tab");
	
	var chatSelection = createButtonPanel("cw-chat", "fa-comment-alt");
	var profileSelection = createButtonPanel("cw-profile", "fa-user");
	var settingsSelection = createButtonPanel("cw-settings", "fa-cog");
	var statsSelection = createButtonPanel("cw-stats", "fa-chart-bar");
	
	var ratingsSection = createDiv("cw-ratings" + windowid, "cw-ratings");
	var ratingBox = createDiv("cw-ratings-box" + windowid, "cw-ratings-box");
	var ratingText = createDiv("cw-ratings-text" + windowid, "cw-ratings-text");
	ratingsSection.append(ratingBox);
	ratingsSection.append(ratingText);
	
	ratingsSection.append(createStarRating(65));
	var voteCount = createSpan("vote-count", "(" + 200 + " Ratings)");
	ratingsSection.append(voteCount);
	
	var cmtSection = createCommentSection(host, pageNum, searchTerm, title);
	mainContentTab.append(cmtSection);
	var profile = {id:1, lastActive:"10/04/1990", email:"matt19sharp@gmail.com", 
			name: "Matt Sharp", overall_rating: 0, overall_report: 1, overall_rating_count: 4, 
			overall_comment_count: 67};
	mainContentTab.append(createProfileSection(true, profile));
	mainContentTab.append(createMocSection(true, profile));
	
	contentBar.append(chatSelection);
	contentBar.append(profileSelection);
	contentBar.append(settingsSelection);
	contentBar.append(statsSelection);
	contentBar.append(ratingsSection);
	
	chatWindow.append(contentBar);
	chatWindow.append(mainContentTab);
	
	return chatWindow;
}

function clearChatWindow(){
	$('.chat-window-ri').remove();
}

function clearChatWindowById(windowid){
	$('#' + windowid).remove();
}

function openChatWindow(host, pageNum, searchTerm, title){	
    var windowid = hashCode(window.location.host);
	console.log(JSON.stringify($('#' +"id_"+ windowid)));
	if(!$('#' +"id_"+ windowid).find(".chat-window-ri") ||  
	    $('#' +"id_"+ windowid).find(".chat-window-ri").length == 0){
		chatWindow = createDiv( "id_"+windowid,"chat-window-ri");
        chatWindow.append(buildChatWindow(windowid, host, pageNum, searchTerm, title));		 
		//Add chat window to document
	    $('body').append(chatWindow);
		//Add events to window		
		addEvents(windowid);
	}  
}

function addCSSLinks(file){
	var link = document.createElement("link");
	link.href = chrome.extension.getURL(file);
	link.type = "text/css";
	link.rel = "stylesheet";
	document.getElementsByTagName("head")[0].appendChild(link);
}

function openTab(tabId, eventItem){
	var speed = 150;
	var position = ["top", "left"];
	if(tabId === "cw-profile"){
		var mainTab = eventItem.parent().parent().parent();
		var openTab = mainTab.find(".comment-section");
		openTab.hide('size', { position }, speed);
		var mocTab =  mainTab.find(".ri-moc-section");
		mocTab.hide('size', { origin: position }, speed);
		var tabToOpen = mainTab.find(".ri-profile-section");
		tabToOpen.show('size', { origin: position }, speed);
	}else if(tabId === "cw-chat"){
		var mainTab = eventItem.parent().parent().parent();
		var mocTab =  mainTab.find(".ri-moc-section");
		mocTab.hide('size', { origin: position }, speed);
		var openTab =  mainTab.find(".ri-profile-section");
		openTab.hide('size', { origin: position }, speed);
		var tabToOpen = mainTab.find(".comment-section");
		tabToOpen.show('size', { origin: position }, speed);
	}
	else if(tabId === "cw-stats"){
		var mainTab = eventItem.parent().parent().parent();
		var mocTab =  mainTab.find(".ri-moc-section");
		mocTab.show('size', { origin: position }, speed);
		var openTab =  mainTab.find(".ri-profile-section");
		openTab.hide('size', { origin: position }, speed);
		var tabToOpen = mainTab.find(".comment-section");
		tabToOpen.hide('size', { origin: position }, speed);
	}
}

function addEvents(windowid){
	
	//Resize
	$( function() {
		 $("#" +"id_"+ windowid).resizable();
	 });
	 
	 //Drag
	$("#" +"id_"+ windowid).draggable ({
        containment : "body"
    });
	
	//Follow
	$.fn.scrollBottom = function() {
		return $(document).height() - this.scrollTop() - this.height();
	};
	
	$(document).ready(function(){
		var imgURL = 'chrome-extension://'+ myid +'/img/';
		 window.emojiPicker = new EmojiPicker({
          emojiable_selector: '#cmt-cb-w',
          assetsPath: imgURL,
          popupButtonClasses: 'material-icons pu-emj'
		 });
		 window.emojiPicker.discover();
		 $('.emoji-menu').css({top: (top - 360) + 'px'});
		 $('#cw-profile').click(function(){ openTab("cw-profile", $(this));});
		 $('#cw-chat').click(function(){ openTab("cw-chat", $(this)); });
		 $('#cw-stats').click(function(){ openTab("cw-stats", $(this)); });
	});
	
	var $el = $("#" +"id_"+ windowid);
	var $window = $(window);
	
	$window.bind("scroll resize", function() {
		var gap = $window.height() - $el.height() - 10;
		var visibleFoot = 172 - $window.scrollBottom();
		var scrollTop = $window.scrollTop()

		if(scrollTop < 172 + 10){
			$el.css({
				top: (172 - scrollTop) + "px",
				bottom: "auto"
			});
		}else if (visibleFoot > gap) {
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
}

function hashCode(str) {
  var hash = 0;
    if (str.length == 0) return hash;
    for (i = 0; i < str.length; i++) {
        char = str.charCodeAt(i);
        hash = ((hash<<5)-hash)+char;
        hash = hash & hash; // Convert to 32bit integer
    }
    return hash;
}

function createBottomBar(){
	var bottomBar = createDiv("ctrl-bar-bottom-ri","ctrl-bar-bottom-ri");
	var refreshAll = createImageWH(refreshBase, "ctrl-bar-refresh", 20, 20);
	var morCounterContain = createTextDiv("ctrl-bar-morcount-cn","");
	var morCounter = createTextDiv("ctrl-bar-morcount","Morality: 0", "ctrl-bar-morcount");
	
	var bottomBarPageContainer = createDiv("ctrl-bar-bottom-pc-ri","ctrl-bar-bottom-pc-ri");
	var bottomBarPagePoweredBy = createDiv("ctrl-bar-bottom-pb-ri","ctrl-bar-bottom-pb-ri");
    var navMenu = createDiv("ctrl-bar-nav-ri","arrow-down-ri");
	//var navMenuPopup = createDiv("ctrl-bar-nav-pu-ri","ctrl-bar-nav-pu-ri");
	
	var dropdown = createDiv("dropdown-ri","dropdown-ri");
	var dropbtn = createDiv("dropbtn-ri","dropbtn-ri");
	var dropcontent = createDiv("dropdown-content-ri","dropdown-content-ri");
	var hideOption = createLinkText("dropdown-option-ri","", "Hide Menu");
	
	dropdown.append(dropbtn);
	dropbtn.append(dropcontent);
	dropcontent.append(hideOption);
	
	morCounterContain.append(morCounter);

	var hostname = window.location.hostname;;
	getAndAddPageIfNoExist(hostname, bottomBarPageContainer);
	
	bottomBar.append(bottomBarPageContainer);
	bottomBar.append(refreshAll);
	bottomBar.append(morCounterContain);
	bottomBarPagePoweredBy.append(poweredby);
	bottomBar.append(bottomBarPagePoweredBy);
	bottomBar.append(navMenu);
	navMenu.append(dropdown);
	return bottomBar;
}

//Display app
function displayApp(){	  
 
    initAppToken();
    $('html').append(createBottomBar());
	/*$('html').append(createDiv("tst22","tst22"));
	var shadow = document.querySelector('#tst22').createShadowRoot();
    shadow.innerHTML(createBottomBar().html());*/
}

$( document ).ready(function() {
    $(".ctrl-bar-page").click(function(){
		var host = $(this).find(".ctrl-bar-host").val();
		var pageNum = $(this).find(".ctrl-bar-pagenum").val();
		var searchTerm = $(this).find(".ctrl-bar-searchval").val();
		var title = $(this).find(".ctrl-bar-title").val();
		openChatWindow(host, pageNum, searchTerm, title);
	});
	addCSSLinks("css/emoji.css");
	addCSSLinks("css/fontawesome.css");
	addCSSLinks("css/fa-regular.css");
	$("head").append("<link rel='stylesheet' href='https://fonts.googleapis.com/icon?family=Material+Icons' type='text/css' media='screen'>");
});


displayApp();