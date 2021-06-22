// this is java script code for gradually increament and decrement in speed of car .......
// Initial speed of car is zero (0) ans maximum speed is 40.



#pragma strict

var speed = 1.0;
var InitialSpeed = 0.0;
var FinalSpeed = 40.0;
speed = InitialSpeed;

/*function speedUp()
{
	if (speed >= InitialSpeed && speed < FinalSpeed)
	{
		speed = speed * (speed + Time.deltaTime);
	}
	else
	{
		speed = speed;
	}
}
*/

function Update() 
{
	speed = speed + Time.deltaTime;		
	
	transform.Translate(Vector3.up * speed); 
	if (this.transform.position.y >= 300)
	{
		//speed = 0;
		
	}
	
	
		
}