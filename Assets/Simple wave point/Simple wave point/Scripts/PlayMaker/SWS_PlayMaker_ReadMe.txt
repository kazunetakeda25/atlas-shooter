Currently Simple Waypoint System includes 3 PlayMaker actions,
you can find them in the zipped file "CustomActions".
If you want to use them, please unzip the file into your project.

Once unzipped, you can find them through PlayMaker's Action Browser under:

Simple Waypoint System \


Path modifications
------------------

-Get Path Node: Returns the waypoint gameObject of a specific path at the defined index
	-Path Object
	-Waypoint Index
	-Waypoint GameObject (return)
	
-Set Path Node: Sets the waypoint gameObject of a specific path at the defined index
	-Path Object
	-Waypoint Index
	-Waypoint GameObject
	
-Set Path: Changes the path of a walker object and immediately starts moving on the new path
	-Target GameObject
	-Path Name OR Path Object
	

All other methods should just work fine with Playmaker's regular SendMessage() functionality.