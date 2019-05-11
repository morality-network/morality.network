var identity;
var token = "[]";
var openPages = [];
//var rateit = "https://rateitapp.azurewebsites.net/";
var rateit = "https://localhost:44322/";
	
chrome.identity.getProfileUserInfo(function(userInfo) {		
	//console.log(JSON.stringify(userInfo));
	JSON.stringify(userInfo);
	identity = userInfo;
	registerApp(userInfo);
});
function registerApp(userInfo){
	var http = new XMLHttpRequest();
	var url = rateit + "api/Account/RegisterApp";
	var params = "Email="+userInfo.email+"&Name="+userInfo.email+"&Password=Vs1-"+chrome.runtime.id+"&ConfirmPassword=Vs1-"+chrome.runtime.id+"&CurrentAppId="+chrome.runtime.id;
	http.open("POST", url, true);
	//alert(params);
	//Send the proper header information along with the request
	http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
	http.onreadystatechange = function() {//Call a function when the state changes.				
	}
	http.send(params);
	
	//pageData.pagenumber, pageData.searchterm, pageData.pagelabel
	openPages.push({active:false,pagenumber:1,searchterm:"a",pagelabel:"www.google.co.uk", pagetitle:"Search Engine"});
}

chrome.runtime.onMessage.addListener(function(message,sender,sendResponse){
  if(message.method == "getToken"){
    //depending on how the word is stored you can do this in one of several ways
    // 1. If it is a global variable, we can just return it directly
    sendResponse(token);
    // 2. It needs to be retrieved asynchronously, in that case we do this
    //getWord(sendResponse);
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
