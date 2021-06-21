#pragma strict


// Drag this to the Water Object for more freedom of animation 


//----------------------------------------------------


// Declare here the input properties for each 
// shader properties you want to animate

// MainTex slot
var texture1Speed : Vector2;
var texture2Speed : Vector2;
var distort1Speed : Vector2;
var distort2Speed : Vector2;

private var texture1UV : Vector2;
private var texture2UV : Vector2;
private var distortionMap1UV : Vector2;
private var distortionMap2UV : Vector2;


function Start () {

 
 texture1Speed = texture1Speed /10;
 texture2Speed = texture2Speed /10;
 distort1Speed = distort1Speed /10;
 distort2Speed = distort2Speed /10; 

}

function Update () {

// Declare here the UV properties for each
// shader properties you're animating

//MainTex UV -- Repeat it for each shader properties
texture1UV.x = Time.time * texture1Speed.x;
texture1UV.y = Time.time * texture1Speed.y;

texture2UV.x = Time.time * texture2Speed.x;
texture2UV.y = Time.time * texture2Speed.y;

distortionMap1UV.x = Time.time * distort1Speed.x;
distortionMap1UV.y = Time.time * distort1Speed.y;

distortionMap2UV.x =  (Time.time * distort2Speed.x);
distortionMap2UV.y =  (Time.time * distort2Speed.y);




// For each property copy this line and chage texture names and UV properties
renderer.material.SetTextureOffset("_Texture1", texture1UV);
renderer.material.SetTextureOffset("_Texture2", texture2UV);
renderer.material.SetTextureOffset("_DistortionMap1", distortionMap1UV);
renderer.material.SetTextureOffset("_DistortionMap2", distortionMap2UV);


}