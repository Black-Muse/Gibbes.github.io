/*jshint strict:false */

/** INIT START SCREEN **/
var aliens = [];
for (var i = 1; i <= 10; i++) {
	aliens.push(document.getElementById("b" + i));
}
var extra_card = "";


/** BEGIN FUNCTION **/
function begin(elem) {
	"use strict";
	
	extra_card = elem.className;
	document.getElementById("header").innerHTML = "<h1>Alien Nations</h1>";
	elem.parentNode.parentNode.removeChild(elem.parentNode);
	
	var test = document.createElement("test");

	test.innerHTML = 
		'<div class="grid">'+
			'<div id = "b1" class="Asherog">Asherog<br>Destroyer<img src="img/Asherog.jpg"></div>'+
			'<div id = "b2" class="Arka">Arka<br>Scholar<img src="img/Arka.jpg"></div>'+
			'<div id = "b3" class="Astren">Astren<br>Creator<img src="img/Astren.jpg"></div>'+
			'<div id = "b4" class="Benusi">Benusi<br>Trucker<img src="img/Benusi.jpg"></div>'+
			'<div id = "b5" class="Buzari">Buzari<br>Merchant<img src="img/Buzari.jpg"></div>'+
			'<div id = "b6" class="Charn">Charn<br>Telepath<img src="img/Charn.jpg"></div>'+
			'<div id = "b7" class="Leonid">Leonid<br>Slaver<img src="img/Leonid.jpg"></div>'+
			'<div id = "b8" class="Rachnian">Rachnian<br>Pirate<img src="img/Rachnian.jpg"></div>'+
			'<div id = "b9" class="Suronian">Suronian<br>Warrior<img src="img/Suronian.jpg"></div>'+
			'<div id = "b10" class="Thuvix">Thuvix<br>Mechanic<img src="img/Thuvix.jpg"></div>'+
		'</div>';
	
	document.getElementById("body").insertBefore(test, document.getElementById("footer"));
}

/** ADD LISTENERS **/
aliens[0].addEventListener("click", function() {begin(aliens[0]);});
aliens[1].addEventListener("click", function() {begin(aliens[1]);});
aliens[2].addEventListener("click", function() {begin(aliens[2]);});
aliens[3].addEventListener("click", function() {begin(aliens[3]);});
aliens[4].addEventListener("click", function() {begin(aliens[4]);});
aliens[5].addEventListener("click", function() {begin(aliens[5]);});
aliens[6].addEventListener("click", function() {begin(aliens[6]);});
aliens[7].addEventListener("click", function() {begin(aliens[7]);});
aliens[8].addEventListener("click", function() {begin(aliens[8]);});
aliens[9].addEventListener("click", function() {begin(aliens[9]);});
