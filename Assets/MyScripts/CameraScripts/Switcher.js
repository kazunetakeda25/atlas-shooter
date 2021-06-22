#pragma strict

var sf : SmoothFollowsjk;
var cr : CameraRotation;
var height ; 
function Start () {
	sf.enabled = true;
	cr.enabled = false;

}

function Update () {
	if (this.transform.position.y > 270)
	{
		sf.enabled = true;
		cr.enabled = false;
	}
	
	if (this.transform.position.y <= 270)
	{
		sf.enabled = false;
		cr.enabled = true;
	}
}