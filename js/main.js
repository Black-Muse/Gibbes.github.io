/* Interactive Portion, by Michael Gibbes */


/** INIT CANVAS **/
var canvas = document.getElementById("notify");
var ctx = canvas.getContext('2d');

function wrapText(text, ctx, x, y, maxWidth, lineHeight) {
	"use strict";
	
	var words = text.split(' ');
	var line = "";
	var mes = 0;
	for (var i = 0; i < words.length; i++) {
		mes += ctx.measureText(words[i]).width;
		if (mes > maxWidth) {
			ctx.fillText(line, x, y);
			mes = 0;
			y += lineHeight;
			line = words[i] + ' ';
		} else {
			line += words[i] + ' ';
		}
	}
	ctx.fillText(line, x, y);
}

ctx.font = 'bold 12pt Arial';
ctx.fillStyle = '#933';
var maxWidth = 175;
var text = "Welcome to Alien Nations! Each player controls a deck of 5 unique cards. Press 'Begin' to initialize the deck.";
function insert(text) {
	"use strict";
	ctx.clearRect(0, 0, canvas.width, canvas.height);
	wrapText(text, ctx, 20, 30, maxWidth, 15);
}
wrapText(text, ctx, 20, 30, maxWidth, 25);

/** INIT PLAYER MATERIALS **/
var img1 = document.getElementById("img1");
var img2 = document.getElementById("img2");
var all_races = ["Asherog", "Buzari", "Leonid", "Rachnian", "Suronian"];
var inv1 = all_races.splice();
var inv2 = all_races.splice();
var p1cards = 5;
var p2cards = 5;
var card1 = all_races.length - 1;
var card2 = all_races.length - 1;
var reroll1 = false;
var reroll2 = false;
var canplay1 = false;
var canplay2 = false;
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
var active = false;
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
		insert("");
		wrapText("May the best faction win! Either side needs to roll at least once before each battle commences.", ctx, 20, 30, maxWidth, 25);
	} else if (active) {
		battleAction(all_races[card1], all_races[card2]);
		deactivate(control);
		active = false;
		activate(button1);
		activate(button2);
		button1.innerHTML = "Roll";
		button2.innerHTML = "Roll";
		reroll1 = false;
		reroll2 = false;
	}
});

/** ROLL FUNCTIONALITY **/
function roll(card, i) {
	"use strict";
	
	insert("");
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
	} else {
		if (card === 1) {
			canplay1 = true;
		} else {
			canplay2 = true;
		}
		if (canplay1 && canplay2) {
			activate(control);
			active = true;
			canplay1 = false;
			canplay2 = false;
		}
	}
}
button1.addEventListener("click", function () {
	"use strict";
	if (inGame && reroll1 !== -1) {
		roll(1, Math.floor((Math.random() * 5) + 10));
		if (!reroll1) {
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
			reroll2 = true;
			button2.innerHTML = "Reroll";
		} else {
			reroll2 = -1;
			deactivate(button2);
		}
	}
});


/** BATTLE RESULTS **/
var ash_ash = "The destroyer meets another destroyer.";
var ash_buz = "You stare at the star god, and its eyes of judgement, learned that anything can be bought with a price.  You offer it the riches of your enormous lifespan.  It nods, as if momentarily impressed.  Then it suddenly frowns.  The Asherog erases it from said space.";
var ash_leo = "The Asherog grimaces at the sight of the feline creature and its ostentatious mane, then chuckles at some grim thought occuring in its head.  Without reason or warning the Asherog reduces the creature to dissipating ashes in an instantaneous violet-flash.";
var ash_rac = "Two ships cross in the open void.  Asherog World-breaker and a Rachnian Sloop.  The Pirates blink out of the system, as far as they can jump.  There’s only doom in attacking the Asherog vessel.  The pirates will be lucky if they can leave before they are noticed.";
var ash_sur = "The Suronian stares in awe at the demonic alien in black and violet.  It recognizes the creature as one of the destroyer gods that purged the universe. The Suronian roars, charging at the destroyer to die fighting.";
var buz_buz = "Shall we trade friend?";
var buz_leo = "As members of the Astren Galactic Code, the Buzari do not condone the uses of slavery.  Some Buzari will attend the Leonid auctions, only to buy and release the Leonid Slaves.  Sadly, Buzari only contribute to this demand.";
var buz_rac = "The pirates waited for the Buzari Trader to wander into their clutches.  The Pirates swoop in, and plunder the Buzari riches.";
var buz_sur= "The Buzari put up a post for Suronian mercenaries to help protect their assets.  Suronian mercenaries flock to the system.  Impressed by their might, the Buzari hire the mercenaries.";
var leo_leo = "WHAT YOU AREN’T A SLAVE!?";
var leo_rac = "The Rachnian Space Pirate slips out of the asteroid belt onto the Leonid Slave-Ship.  The Leonids are no match as the star-jackals cripple its engines and flood into the ship, blasting the Leonids till they surrender.  They find a hold full of slaves.";
var leo_sur = "A Suronian vessel spots a Leonid slave-ship en-route to a planet.  The Suronians ram the Leonid ship,and board it.  They liberate their own people, as well as the other strange aliens enslaved by the Leonids.";
var rac_rac = "Hand us your most prized possessions and we won’t throw you out into the cold void.";
var rac_sur = "In a free space port.  The Suronian walks into a bar, looking for hire.  He’s a mercenary looking for gold.  He meets a bug like alien with a big fuzzy beard. “How about you join my crew for a bit of fair share,” said the Rachnian.  The Suronian drunk to their deal.";
var sur_sur = "Two Suronians cross paths.  They decide to have a friendly duel.";


/** BATTLE ACTION **/
function battleAction(p1, p2) {
	"use strict";
	
	ctx.font = 'bold 10pt Arial';
	switch(p1) {
		case "Asherog":
			switch(p2) {
				case "Asherog":
					insert(ash_ash);
					inv1 = [0,0,0,0,0];
					inv2 = [0,0,0,0,0];
					document.getElementbyId("Asherog1").style.backgroundColor = "#eee";
					document.getElementbyId("Buzari1").style.backgroundColor = "#eee";
					document.getElementbyId("Leonid1").style.backgroundColor = "#eee";
					document.getElementbyId("Rachnian1").style.backgroundColor = "#eee";
					document.getElementbyId("Suronian1").style.backgroundColor = "#eee";
					document.getElementbyId("Asherog2").style.backgroundColor = "#eee";
					document.getElementbyId("Buzari2").style.backgroundColor = "#eee";
					document.getElementbyId("Leonid2").style.backgroundColor = "#eee";
					document.getElementbyId("Rachnian2").style.backgroundColor = "#eee";
					document.getElementbyId("Suronian2").style.backgroundColor = "#eee";
					p1cards -= 5;
					p2cards -= 5;
					break;
				case "Buzari":
					insert(ash_buz);
					break;
				case "Leonid":
					insert(ash_leo);
					break;
				case "Rachnian":
					insert(ash_rac);
					break;
				case "Suronian":
					insert(ash_sur);
			}
			break;
		case "Buzari":
			switch(p2) {
				case "Asherog":
					insert(ash_buz);
					break;
				case "Buzari":
					insert(buz_buz);
					break;
				case "Leonid":
					insert(buz_leo);
					break;
				case "Rachnian":
					insert(buz_rac);
					break;
				case "Suronian":
					insert(buz_sur);
			}
			break;
		case "Leonid":
			switch(p2) {
				case "Asherog":
					insert(ash_leo);
					break;
				case "Buzari":
					insert(buz_leo);
					break;
				case "Leonid":
					insert(leo_leo);
					break;
				case "Rachnian":
					insert(leo_rac);
					break;
				case "Suronian":
					insert(leo_sur);
			}
			break;
		case "Rachnian":
			switch(p2) {
				case "Asherog":
					insert(ash_rac);
					break;
				case "Buzari":
					insert(buz_rac);
					break;
				case "Leonid":
					insert(leo_rac);
					break;
				case "Rachnian":
					insert(rac_rac);
					break;
				case "Suronian":
					insert(rac_sur);
			}
			break;
		case "Suronian":
			switch(p2) {
				case "Asherog":
					insert(ash_sur);
					break;
				case "Buzari":
					insert(buz_sur);
					break;
				case "Leonid":
					insert(leo_sur);
					break;
				case "Rachnian":
					insert(rac_sur);
					break;
				case "Suronian":
					insert(sur_sur);
			}
	}
	if (p1cards === 0 || p2cards === 0) {
		deactivate(button1);
		deactivate(button2);
		deactivate(control);
		inGame = "done";
	}
	
}
