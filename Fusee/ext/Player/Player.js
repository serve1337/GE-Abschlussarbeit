var Player = function(game, id, width, height, autoplay, fullscreen, loadimage) {
	// "playit", "600px", "300px", true, "intro.jpg"
	this.id = id;
	this.game = game;
	
	this.width = width;
	if(this.width == "undefined") {
		this.width = "100%";
	}

	this.autoplay = autoplay;
	if(this.autoplay == "undefined") {
		this.autoplay = false;
	}
	
	this.height = height;
	if(this.height == "undefined") {
		this.height = "100%";
	}
	
	this.fullscreen = fullscreen;
	if(this.fullscreen == "undefined") {
		this.fullscreen = true;
	}
	
	this.loadimage = loadimage;
	if(this.loadimage == "undefined") {
		this.loadimage = "Assets/Player/intro.jpg";
	}
	
	whileLoading();
	
	function whileLoading() {
		loadPlayer();

		if(autoplay) {
			playGame();
		}
	}
	
	function loadPlayer() {
		var playerContainer = document.createElement("div");
		playerContainer.id = "playerContainer";
		playerContainer.setAttribute("style", "width: " + width + "; height: " + height + ";");
		
		var intro = document.createElement("img");
		intro.id = "intro";
		intro.src = loadimage;
		
		var player = document.createElement("div");
		player.id = "player";
		
		var playbutton = document.createElement("a");
		playbutton.id = "playbutton";
		playbutton.href = "#";
		playbutton.setAttribute("class", "play button active");
		playbutton.onclick = function() { playGame(); };
		
		var canvas = document.createElement("canvas");
		canvas.id = "canvas";
		
		var controlbar = document.createElement("div");
		controlbar.id = "controlbar";
		
		var bg = document.createElement("div");
		bg.setAttribute("class", "bg");
		
		var fullscreenButton = document.createElement("a");
		fullscreenButton.id = "fullscreenButton";
		fullscreenButton.setAttribute("class", "fullscreen");
		
		var loadingProgress = document.createElement("div");
		loadingProgress.id = "loadingProgress";
		
		var progressBar = document.createElement("div");
		progressBar.id = "progressBar";
		
		var progressText = document.createElement("div");
		progressText.id = "progressText";
		
		var saturation = document.createElement("div");
		saturation.id = "saturation";
		
		playerContainer.appendChild(intro);
		
		player.appendChild(playbutton);
		player.appendChild(canvas);
		playerContainer.appendChild(player);
		
		controlbar.appendChild(bg);
		controlbar.appendChild(fullscreenButton);
		playerContainer.appendChild(controlbar);
		
		loadingProgress.appendChild(progressBar);
		loadingProgress.appendChild(saturation);
		loadingProgress.appendChild(progressText);
		playerContainer.appendChild(loadingProgress);

		var playit = document.getElementById(id);
		playit.appendChild(playerContainer);

		var script = document.createElement("script");
		script.setAttribute("type", "text/javascript");
		script.innerHTML = "function runMain () { \n";
		script.innerHTML += "var $mainAssembly = JSIL.GetAssembly('"+game+"'); \n";
		script.innerHTML += "$mainAssembly.Fusee.Tutorial.Web.Tutorial.Main([]); \n";
		script.innerHTML += "}; \n";
		script.innerHTML += "window.onresize = function(event) { \n";
		script.innerHTML += "document.getElementById('canvas').setAttribute('width', window.innerWidth); \n";
		script.innerHTML += "document.getElementById('canvas').setAttribute('height', window.innerHeight); \n";
		script.innerHTML += "} \n";
		script.innerHTML += "window.onresize(); \n";
		
		playit.appendChild(script);
	}
	
	function loadGame() {
 		if(fullscreen) {
			document.getElementById("controlbar").setAttribute("class", "active");
		}
		document.getElementById("playbutton").setAttribute("class", "");
		var ele = document.createElement("div");
		ele.id = "saturation";
		document.getElementById("loadingProgress").appendChild(ele);
	}
	
	function playGame() {
		onLoad();
		loadGame();
	}
};