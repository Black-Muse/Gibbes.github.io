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
var text = "Welcome to Alien Nations! Each player controls a deck of 5 unique cards. Press 'Begin' to initialize the deck.";
function insert(text) {
	"use strict";
	ctx.clearRect(0, 0, canvas.width, canvas.height);
	wrapText(text, ctx, 20, 30, maxWidth);
}
insert(text);

/** INIT PLAYER MATERIALS **/
var img1 = document.getElementById("img1");
var img2 = document.getElementById("img2");
var all_races = ["Asherog", "Buzari", "Leonid", "Rachnian", "Suronian"];
var inv1 = all_races.splice();
var inv2 = all_races.splice();
var card1 = all_races.length - 1;
var card2 = all_races.length - 1;
var reroll1 = false;
var reroll2 = false;
function init_inv() {
	"use strict";
	
	return all_races.slice();
}
function deactivate(button) {
	"use strict";
	button.style.background = "#eee";
	button.onmouseover = function () {button.style.backgroundColor = "#eee";};
	button.onmouseout = function () {button.style.backgroundColor = "#eee";};
}
function activate(button) {
	"use strict";
	button.style.background = "salmon";
	button.onmouseover = function () {button.style.backgroundColor = "lightsalmon";};
	button.onmouseout = function () {button.style.backgroundColor = "salmon";};
}
var button1 = document.getElementById("button1");
var button2 = document.getElementById("button2");
deactivate(button1);
deactivate(button2);


/** BEGIN/RESET FUNCTIONALITY **/
var inGame = false;
var control = document.getElementById("ctr");
control.addEventListener("click", function () {
	"use strict";
	
	if (!inGame) {
		deactivate(control);
		control.innerHTML = "Play";
		inGame = true;
		activate(button1);
		activate(button2);
		inv1 = init_inv();
		inv2 = init_inv();
		insert("May the best faction win! Either side needs to roll at least once before each battle commences.");
	}
});

/** ROLL FUNCTIONALITY **/
function roll(card, i) {
	"use strict";
	
	if (card === 1) {
		document.getElementById(all_races[card1] + "1").style.color = "#339";
		card1 = (card1 + 1) % all_races.length;
		if (inv1[card1] === all_races[card1]) {
			document.getElementById(all_races[card1] + "1").style.color = "#393";
			img1.src = "img/" + all_races[card1] + "-flip.jpg";
		} else {
			i--;
		}
	} else {
		document.getElementById(all_races[card2] + "2").style.color = "#339";
		card2 = (card2 + 1) % all_races.length;
		if (inv2[card2] === all_races[card2]) {
			document.getElementById(all_races[card2] + "2").style.color = "#393";
			img2.src = "img/" + all_races[card2] + ".jpg";
		} else {
			i--;
		}
	}
	if (i > 0) {
		setTimeout(function () {roll(card, i - 1);}, ((all_races.length * 3) - i) * 20);
	}
}
button1.addEventListener("click", function () {
	"use strict";
	if (inGame && reroll1 !== -1) {
		roll(1, Math.floor((Math.random() * 5) + 10));
		if (!reroll1) {
			if (reroll2) {activate(control);}
			reroll1 = true;
			button1.innerHTML = "Reroll";
		} else {
			reroll1 = -1;
			deactivate(button1);
		}
	}
});
button2.addEventListener("click", function () {
	"use strict";
	if (inGame && reroll2 !== -1) {
		roll(2, Math.floor((Math.random() * 5) + 10));
		if (!reroll2) {
			if (reroll1) {activate(control);}
			reroll2 = true;
			button2.innerHTML = "Reroll";
		} else {
			reroll2 = -1;
			deactivate(button2);
		}
	}
});
