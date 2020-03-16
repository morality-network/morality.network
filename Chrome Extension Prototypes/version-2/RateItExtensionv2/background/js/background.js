var identity;
var token = "[]";
var openPages = [];
var rateit = "https://localhost:44322/";
	
chrome.identity.getProfileUserInfo(function(userInfo) {	
	identity = userInfo;
	if(userInfo.email != ""){
		registerApp(userInfo);
	}
	else{
		alert("Please log in to your Google account and then refresh this app. You may also need to sync your settings (on your browser) before you can register!");
	}
});

function registerApp(userInfo){
	var http = new XMLHttpRequest();
	var url = rateit + "api/Account/RegisterApp";
	var params = "Email="+userInfo.email+"&Name="+userInfo.email+"&Password=Vs1-"+chrome.runtime.id+"&ConfirmPassword=Vs1-"+chrome.runtime.id+"&CurrentAppId="+chrome.runtime.id;
	http.open("POST", url, true);
	//alert(params);
	//Send the proper header information along with the request
	http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
	http.onreadystatechange = function(data) {//Call a function when the state changes.		   		
	}
	http.send(params);
	//openPages.push({active:false,pagenumber:1,searchterm:"a",pagelabel:"www.google.co.uk", pagetitle:"Search Engine"});
}

chrome.runtime.onMessage.addListener(function(message,sender,sendResponse){
  if(message.method == "getToken"){
    sendResponse(token);
    return true;
    // This passes the ability to reply to the function where we get the info
    // Once we have the info we can just use sendResponse(word); like before
  }else if(message.method == "setToken"){
	 token = message.token;
	 sendResponse(true);
	 return true;
  }
  //The openPages is to keep a track at what user has viewed and let the user reopen if need be
  else if(message.method == "getOpenPages"){
	 sendResponse(openPages);
	 return true;
  }
  else if(message.method == "setOpenPages"){
	 openPages = message.openPages;
	 //alert(openPages.length);
	 sendResponse(true);
	 return true;
  }
  else if(message.method == "getUserInfo"){
	 sendResponse(identity);
	 return true;
  }
});
