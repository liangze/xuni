function ShowDetails(obj) {
	LeftPosition = window.event.x-obj.offsetLeft;
	TopPosition = window.event.y-obj.offsetTop;

	TopPosition = (TopPosition + 50)

	if (LeftPosition > 450) {
		LeftPosition = (LeftPosition - 280)
	} else {
		LeftPosition = (LeftPosition + 20)
	}

	eval("document.all." + obj.id + "_Details.style.left = LeftPosition");
	eval("document.all." + obj.id + "_Details.style.top = TopPosition");
	eval("document.all." + obj.id + "_Details.style.display = 'inline'");
}

function OffDetails(obj) {
	eval("document.all." + obj.id + "_Details.style.display = 'none'");
}