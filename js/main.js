/* Interactive Portion, by Michael Gibbes */


/** INIT CANVAS **/
var canvas = document.getElementById("notify");
var ctx = canvas.getContext('2d');

function wrapText(text, ctx, x, y, maxWidth) {
	"use strict";
	
	var words = text.split(' ');
	var line = "";
	var mes = 0;
	for (var i = 0; i < words.length; i++) {
		mes += ctx.measureText(words[i]).width;
		if (mes > maxWidth) {
			ctx.fillText(line, x, y);
			mes = 0;
			y += 25;
			line = words[i] + ' ';
		} else {
			line += words[i] + ' ';
		}
	}
	ctx.fillText(line, x, y);
}

ctx.font = 'bold 12pt Arial';
ctx.fillStyle = '#933';
var maxWidth = 200;
var text = "Welcome to Alien Nation! Each player controls a deck of 5 unique cards. Press 'Begin' to initialize the deck.";
wrapText(text, ctx, 20, 30, maxWidth);


/** INIT PLAYER MATERIALS **/
var inv1 = [];
var inv2 = [];
var all_races = ["Asherog", "Buzari", "Leonid", "Rachnian", "Suronian"];
function init_inv() {
	"use strict";
	
	return all_races.slice();
}


/** BEGIN/RESET FUNCTIONALITY **/
var inGame = false;
var control = document.getElementById("ctr");
control.addEventListener("click", function () {
	"use strict";
	
	if (!inGame) {
		control.innerHTML = "Restart";
		inGame = true;
	}
	inv1 = init_inv();
	inv2 = init_inv();
});
