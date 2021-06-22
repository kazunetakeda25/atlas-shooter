#pragma strict


var backFan 					: GameObject;
var wingsSpeed 					: float = 1000;

function Update () {
	backFan.transform.Rotate (wingsSpeed * Time.deltaTime,180,180);
}