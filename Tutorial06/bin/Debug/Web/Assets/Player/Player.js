function loadPlayer() {
	document.getElementById("controlbar").setAttribute("class", "active");
	document.getElementById("playbutton").setAttribute("class", "");
    document.getElementById("intro").style.filter = "grayscale(0%)";
}

function playGame(play) {
	if(play) {
		onLoad();
		loadPlayer();
	}
}