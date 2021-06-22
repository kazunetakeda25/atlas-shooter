#pragma strict

var topfan 						: GameObject;
var wingsSpeed 					: float = 1000;

function Update () {
	topfan.transform.Rotate( 0, 0, wingsSpeed * Time.deltaTime);
}