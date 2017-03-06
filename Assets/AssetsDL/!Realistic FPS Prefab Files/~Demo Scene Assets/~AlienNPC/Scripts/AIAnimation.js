private var minimumRunSpeed = 3.0;

function Start () {
	// Set all animations to loop
	GetComponent.<Animation>().wrapMode = WrapMode.Loop;

	// Except our action animations, Dont loop those
	GetComponent.<Animation>()["shoot"].wrapMode = WrapMode.Once;
	//animation["shoot"].speed = 1.75;
	// Put idle and run in a lower layer. They will only animate if our action animations are not playing
	GetComponent.<Animation>()["idle"].layer = -1;
	GetComponent.<Animation>()["walk"].layer = -1;
	GetComponent.<Animation>()["run"].layer = -1;
	
	GetComponent.<Animation>().Stop();
}

function SetSpeed (speed : float) {
	if (speed > minimumRunSpeed){
		GetComponent.<Animation>().CrossFade("run");
	}else{
		if(speed > 0){
			GetComponent.<Animation>().CrossFade("walk");
		}else{
			GetComponent.<Animation>().CrossFade("idle");
		}
	}
}