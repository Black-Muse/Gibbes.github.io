var button1 = document.createElement("button1");
var button2 = document.createElement("button2");

button1.innerHTML = "Roll";
button2.innerHTML = "Roll";

var body = document.getElementById("body");
body.appendChild(button1);
body.appendChild(button2);

button1.addEventListener("click", null);
button2.addEventListener("click", null);
