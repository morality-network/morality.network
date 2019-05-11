$(document).ready(function(){
    
//	var alphabet = "abcdef".split("");
//	alphabet.each(function(letter) {
////	  $('.emotion-area').append('<img scr="img/1f60${letter}.png"');
//		console.log(letter);
//	});
    var root = document.querySelector('#chat-holder-ma').shadowRoot;
    var emotionArea = root.querySelector('.emotion-area');
	
	function ApndImgEmotion() {
		for (var i = 65; i <= 70; i++) {
			//$('.emotion-area').append(
            emotionArea.appendChild(
				'<img width="30px" height="30px" src="img/1f60' + String.fromCharCode(i).toLowerCase() + '.png">' + 
				'<img width="30px" height="30px" src="img/1f61' + String.fromCharCode(i).toLowerCase() + '.png">' + 
				'<img width="30px" height="30px" src="img/1f62' + String.fromCharCode(i).toLowerCase() + '.png">' + 
				'<img width="30px" height="30px" src="img/1f47' + String.fromCharCode(i).toLowerCase() + '.png">' +
				'<img width="30px" height="30px" src="img/1f49' + String.fromCharCode(i).toLowerCase() + '.png">'
			);
		}
		
		for (var i = 4; i <= 8; i++) {
			//$('.emotion-area').append(
			emotionArea.appendChild(
				'<img width="30px" height="30px" src="img/1f32' + i + '.png">'
			);
		}
		
		for (var i = 3; i <= 8; i++) {
			//$('.emotion-area').append(
			emotionArea.appendChild(
				'<img width="30px" height="30px" src="img/1f49' + i + '.png">'
			);
		}
		
		for (var i = 0; i <= 9; i++) {
			//$('.emotion-area').append(
			emotionArea.appendChild(
				'<img width="30px" height="30px" src="img/1f60' + i + '.png">'
			);
		}
		
		for (var i = 10; i <= 44; i++) {
			//$('.emotion-area').append(
			emotionArea.appendChild(
				'<img width="30px" height="30px" src="img/1f6' + i + '.png">'
			);
		}
		
		for (var i = 10; i <= 17; i++) {
			//$('.emotion-area').append(
			emotionArea.appendChild(
				'<img width="30px" height="30px" src="img/1f9' + i + '.png">'
			);
		}
	}
	
//	$(document).one('click' , '.emotion-Icon', function(e){
//		ApndImgEmotion();
//	});

    var emotionIcon = root.querySelector('.emotion-Icon');
    emotionIcon.addEventListener('click', function () { 
		alert("click1");
	});
	
	/*
	$(document).on('click' , '.emotion-Icon', function(e){
		var top = $(this).offset().top ,
			top = Math.floor(top),
			//emotionArea = $(this).find('.emotion-area');
			emotionAreaJQ = $(emotionArea);
		
		emotionAreaJQ.toggleClass('ShowImotion');
		
		if( top <= 160 ){
			emotionAreaJQ.toggleClass('top');
		}
		
		if(!eemotionAreaJQ.hasClass('ShowImotion')){
			$('.emotion-area').empty();
			emotionAreaJQ.removeClass('top');
		}else{
			ApndImgEmotion();
		}		
	});*/
	
    emotionArea.addEventListener('click', function (e) { 
	    e.stopPropagation();
		alert("click2");
	});
	
	/*
	$(document).on('click', '.emotion-area' ,function(e){
		e.stopPropagation();
	});*/
	
	var emotionAreaImg = root.querySelector('.emotion-area img');
    emotionAreaImg.addEventListener('click', function () { 
	    alert("click3");
	    var imgIcon = $(this).clone();
		$(this).parents('.emotion').find('.input').append(imgIcon);
		alert("click4");
	});
	
	/*
	$(document).on('click' , '.emotion-area img', function(e){
		var imgIcon = $(this).clone();
		$(this).parents('.emotion').find('.input').append(imgIcon);
	});*/
	
});













