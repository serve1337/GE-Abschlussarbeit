function loadPlayer() {
	document.getElementById("controlbar").setAttribute("class", "active");
	document.getElementById("playbutton").setAttribute("class", "");
	var ele = document.createElement("div");
	ele.id = "saturation";
	document.getElementById("loadingProgress").appendChild(ele);
}

function playGame(play) {
	if(play) {
		onLoad();
		loadPlayer();
	}
}