/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//movement script: iTween
[AddComponentMenu("Simple Waypoint System/iMove")]
public class iMove : MonoBehaviour
{

    //which path to call
    public PathManager pathContainer;
    //location indicator
    public int currentPoint = 0;
    //should this gameobject start to walk on game launch?
    public bool onStart = false;
    //should this gameobject walk to the first waypoint or just spawn there?
    public bool moveToPath = false;
    //should this gameobject look to its target point?
    public bool orientToPath = false;
    //if orientToPath = true, smooth rotation between waypoints by this value
    public float smoothRotation;
    //custom object size to add
    public float sizeToAdd = 0;
    //delay for each waypoint
    [HideInInspector]
    public float[] StopAtPoint;
    //messages to call at each waypoint
    [HideInInspector]
    public List<MessageOptions> _messages = new List<MessageOptions>();

    //we have the choice between 2 different move options:
    //time in seconds one node step will take to complete
    //or animation based on speed
    public TimeValue timeValue = TimeValue.speed;
    public enum TimeValue
    {
        time,
        speed
    }
    //time or speed value
    public float speed = 5;

    //animation easetype
    public iTween.EaseType easetype = iTween.EaseType.linear;
    //animation looptype
    public LoopType looptype = LoopType.loop;
    //enum to choose from available looptypes
    public enum LoopType 
    {
        none,
        loop,
        pingPong,
        random
    }

    //cache all waypoint position references of requested path
    private Transform[] waypoints;
    //used on looptype = pingpong for counting currentpoint backwards
    private bool repeat = false;

    //lock axis variable
    public AxisLock lockAxis = AxisLock.none;
    //enum to choose from available axes
    public enum AxisLock
    {
        none,
        X,
        Y,
        Z
    }
    //store start rotation for locking an axis
    private Vector3 startRot;

    //animation component
    [HideInInspector]
    public Animation anim;
	//animation to play during walk time
	public AnimationClip walkAnim;
	//animation to play during waiting time
    public AnimationClip idleAnim;
    //whether animations should fade in over a period of time or not
    public bool crossfade = false;

	
    //checks if gameobject should move on game start
    internal void Start()
    {
        if (!anim)
            anim = gameObject.GetComponentInChildren<Animation>();

        //get start rotation for locking an axis maybe later
        startRot = transform.localEulerAngles;

        //start moving instantly
        if (onStart)
            StartMove();
    }


    //can be called from an other script also to allow start delay
    public void StartMove()
    {
        //if we start the game and no path Container is set, debug a warning and return
        if (pathContainer == null)
        {
            Debug.LogWarning(gameObject.name + " has no path! Please set Path Container.");
            return;
        }

        //get Transform array with waypoint positions
        waypoints = pathContainer.waypoints;
		
        //check if delay array wasn't set in the editor, then we have to initialize it
        if (StopAtPoint == null)
            StopAtPoint = new float[waypoints.Length];
		else if (StopAtPoint.Length < waypoints.Length )
        {
            //else if the delay array is smaller than the waypoint array,
            //that means we have added waypoints to the path but haven't modified the
            //delay settings, here we need to resize it again while keeping old values
            float[] tempDelay = new float[StopAtPoint.Length];
            Array.Copy(StopAtPoint, tempDelay, StopAtPoint.Length);
            StopAtPoint = new float[waypoints.Length];
            Array.Copy(tempDelay, StopAtPoint, tempDelay.Length);
        }

        //check for message count and reinitialize if necessary
        if (_messages.Count > 0)
            InitializeMessageOptions();

        //if we should not walk to the first waypoint,
        //we set this gameobject position directly to it and launch the next waypoint routine
		if (!moveToPath)
        {
            //we also add a defined size to our object height,
            //so our gameobject could "stand" on top of the path.
            transform.position = waypoints[currentPoint].position + new Vector3(0, sizeToAdd, 0);
            //we're now at the first waypoint position,
            //so directly call the next waypoint
            StartCoroutine("NextWaypoint");
            return;
        }

        //move to the next waypoint
        Move(currentPoint);
    }


    //attach a new iTween MoveTo component to our gameobject which moves us to the next waypoint
    //(defined by passed argument)
    internal void Move(int point )
    {
	//	if(pauseGame.p==false){
			Time.timeScale=1;
        //create a hashtable to store iTween parameters
        Hashtable iTweenHash = new Hashtable();

        //prepare iTween's parameters, you can look them up here
        //http://itween.pixelplacement.com/documentation.php#MoveTo
        ////////////////////////////////////////////////////////////
        //we also add a defined value to our gameobject position, so it walks "on" the path

        iTweenHash.Add("position", waypoints[point].position + new Vector3(0, sizeToAdd, 0));
        iTweenHash.Add("easetype", easetype);
        iTweenHash.Add("orienttopath", orientToPath);
        iTweenHash.Add("oncomplete", "NextWaypoint");

        //add custom rotation time value
        if (orientToPath)
        {
            iTweenHash.Add("looktime", smoothRotation);

            //add custom axis lock on iTween's update method
            if (lockAxis != AxisLock.none)
                iTweenHash.Add("onupdate", "LockAxis");
        }

        //differ between TimeValue like mentioned above at enum TimeValue
        if (timeValue == TimeValue.time)    //use time
        {
            iTweenHash.Add("time", speed);
        }
        else //use speed
        {
            iTweenHash.Add("speed", speed);
        }

        //move this gameobject to the defined waypoint with given arguments
        iTween.MoveTo(gameObject, iTweenHash);

        //play walk animation if set
        PlayWalk();
//		}
//		else if(pauseGame.p==true){
//			Time.timeScale=0;
//		}
    }


    //constrains this game object on one axis,
    //called at every frame internally by iTween's onupdate
    internal void LockAxis()
    {
        //store transform and local rotation
        Transform trans = transform;
        Vector3 localEuler = trans.localEulerAngles;

        //differ between chosen axis
        switch (lockAxis)
        {
            //lock x-axis and apply start rotation, leave the others as is
            case AxisLock.X:
                trans.localEulerAngles = new Vector3(startRot.x, localEuler.y, localEuler.z);
                break;
            //lock y-axis
            case AxisLock.Y:
                trans.localEulerAngles = new Vector3(localEuler.x, startRot.y, localEuler.z);
                break;
            //lock z-axis
            case AxisLock.Z:
                trans.localEulerAngles = new Vector3(localEuler.x, localEuler.y, startRot.z);
                break;
        }
    }


    //this method gets called at the end of one iTween animation (after each waypoint)
    //and moves us to the next one
    internal IEnumerator NextWaypoint()
    {
        //execute all messages for this waypoint
        StartCoroutine(SendMessages());

        //only delay waypoint movement if delay settings are edited to avoid unnecessary frame yield,
        //so StopAtPoint array and current value have to be greater than zero
        if (StopAtPoint[currentPoint] > 0)
        {
            //play idle animation if set
            PlayIdle();

            //wait seconds defined in StopAtPoint at current waypoint position
            yield return new WaitForSeconds(StopAtPoint[currentPoint]);
        }

        //we differ between all looptypes, because each one has a specific property
        switch (looptype)
        {
                //LoopType.none means, there will be no repeat,
                //so we just count up till the last waypoint and move this gameobject one by one 
            case LoopType.none:
                if (currentPoint < waypoints.Length - 1)
                    currentPoint++;
                else
                {
                    //abort movement and play idle animation
                    //if we reached the last waypoint
                    PlayIdle();
                    yield break;
                }
                break;

                //in a loop, we count up till the last waypoint (like LoopType.none),
                //but then we set our position indicator back to zero and start from the beginning
            case LoopType.loop:
                //we reached the last waypoint
                if (currentPoint == waypoints.Length - 1)
                {
                    currentPoint = 0;
                    StartMove();
                    //abort further execution and do not call Move() at the end of NextWaypoint(),
                    //because this would overwrite StartMove()
                    yield break;
                }
                else
                {
                    //we're not at the end, count up waypoint index, move forward
                    currentPoint++;
                }
                break;

                //on LoopType.pingPong, we count up till the last waypoint (like with the two others before)
                //and then we decrease our location indicator till it reaches zero again to start from the beginning.
                //to achieve that, and differ between back and forth, we use the boolean "repeat"
            case LoopType.pingPong:
                //if we reached the last waypoint, set repeat to true,
                //so we start decrease currentPoint again
                //(if-else repeat query below)
                if (currentPoint == waypoints.Length - 1)
                {
                    repeat = true;
                }
                else if (currentPoint == 0)
                {
                    //when currentPoint reaches zero (our start pos),
                    //disable repeating and move forth (count up) again
                    //(if-else repeat query below)
                    repeat = false;
                }

                //repeating mode is on, decrease currentPoint one by one to move backwards
                if (repeat)
                {
                    currentPoint--;
                }
                else //repeating mode off, increase currentPoint to move forwards
                {
                    currentPoint++;
                }
                break;

                //on LoopType.random, we calculate a random waypoint between zero and max
                //waypoint count and move to that, but make sure we do not move to the same again
            case LoopType.random:
                //store old current point for being able to compare old and new point
                int oldPoint = currentPoint;
                //calculate a random point between zero and waypoint count
                do
                {
                    currentPoint = UnityEngine.Random.Range(0, waypoints.Length);
                }
                //as long as old point is equal to calculated one, so we compute it again
                while (oldPoint == currentPoint);
                break;
        }

        //move to the calculated waypoint
        Move(currentPoint);
    }


    //execute messages at the current waypoint
    internal IEnumerator SendMessages()
    {
        //skip execution if no messages were set
        if(_messages.Count != waypoints.Length)
            yield break;

        //loop through messages for this waypoint
        for (int i = 0; i < _messages[currentPoint].message.Count; i++)
        {
            //if no message name was defined, abort further execution
            if (_messages[currentPoint].message[i] == "")
                continue;
            //else store MessageOption at this waypoint
            MessageOptions mess = _messages[currentPoint];
            //differ between various data types and pass in the corresponding value
            switch (mess.type[i])
            {
                case MessageOptions.ValueType.None:
                    SendMessage(mess.message[i], SendMessageOptions.DontRequireReceiver);
                    break;
                case MessageOptions.ValueType.Object:
                    SendMessage(mess.message[i], mess.obj[i], SendMessageOptions.DontRequireReceiver);
                    break;
                case MessageOptions.ValueType.Text:
                    SendMessage(mess.message[i], mess.text[i], SendMessageOptions.DontRequireReceiver);
                    break;
                case MessageOptions.ValueType.Numeric:
                    SendMessage(mess.message[i], mess.num[i], SendMessageOptions.DontRequireReceiver);
                    break;
                case MessageOptions.ValueType.Vector2:
                    SendMessage(mess.message[i], mess.vect2[i], SendMessageOptions.DontRequireReceiver);
                    break;
                case MessageOptions.ValueType.Vector3:
                    SendMessage(mess.message[i], mess.vect3[i], SendMessageOptions.DontRequireReceiver);
                    break;
            }
        }
    }


    //automatically initializes message slots at runtime,
    //if message count is not equal to path length
    internal void InitializeMessageOptions()
    {
        //check if message settings list wasn't set in the editor,
        //then we have to initialize it and add/remove an message per waypoint
        if (_messages.Count < waypoints.Length)
        {
            //message count is smaller than waypoint count,
            //add empty message per waypoint and refill with default values
            for (int i = _messages.Count; i < waypoints.Length; i++)
            {
                MessageOptions opt = AddMessageToOption(new MessageOptions());
                _messages.Add(opt);
            }
        }
        else if (_messages.Count > waypoints.Length)
        {
            //message count is greater than actual waypoints, remove unnecessary messages
            for (int i = _messages.Count - 1; i >= waypoints.Length; i--)
                _messages.RemoveAt(i);
        }
    }


    //add new message slot with default values to an existing message option
    internal MessageOptions AddMessageToOption(MessageOptions opt)
    {
        opt.message.Add("");
        opt.type.Add(MessageOptions.ValueType.None);
        opt.obj.Add(null);
        opt.text.Add(null);
        opt.num.Add(0);
        opt.vect2.Add(Vector2.zero);
        opt.vect3.Add(Vector3.zero);
        return opt;
    }


    //play idle animation if set
    internal void PlayIdle()
    {
        //if an idle animation is attached and set,
        //and if crossfade is checked, fade walk animation out and fade idle in
        //else play it instantly
        if (idleAnim)
        {
            if (crossfade)
                anim.CrossFade(idleAnim.name, 0.2f);
            else
                anim.Play(idleAnim.name);
        }
    }


    //play walk animation if set
    internal void PlayWalk()
    {
        //if a walk animation is attached to this walker object and set,
        //fade idle animation out (crossfade = true) and fade walk anim in,
        //or play it instantly (crossfade = false)
        if (walkAnim)
        {
            if (crossfade)
                anim.CrossFade(walkAnim.name, 0.2f);
            else
                anim.Play(walkAnim.name);            
        }
    }
    

    //method to change the current path of this walker object
    public void SetPath(PathManager newPath)
    {
        //disable any running movement methods
        Stop();
        //set new path container
        pathContainer = newPath;
        //get new waypoint positions of our new path
        waypoints = pathContainer.waypoints;
        //reset current waypoint index to zero
        currentPoint = 0;
        //restart/continue movement on new path
        StartMove();
    }


    //disables any running movement methods
    public void Stop()
    {
        //exit waypoint coroutine
        StopCoroutine("NextWaypoint");
        //destroy current iTween movement component
        iTween.Stop(gameObject);
        //play idle animation if set
        PlayIdle();
    }


    //stops movement of our walker object and sets it back to first waypoint 
    public void Reset()
    {
        //disable any running movement methods
        Stop();
        //reset current waypoint index to zero
        currentPoint = 0;
        //position this walker at our first waypoint, with our additional height
        if (pathContainer)
            transform.position = waypoints[currentPoint].position + new Vector3(0, sizeToAdd, 0);
    }
	
	
	//change running tween speed
	//requires restarting a tween
	public void ChangeSpeed(float value)
    {
        //stop object and destroy iTween component
		Stop(); 
        //set speed
		speed = value;
        //start new tween with new speed value
		StartMove();
    }


    //get message option at a specific waypoint,
    //auto adds messages if desired messageID is greater than zero
    public MessageOptions GetMessageOption(int waypointID, int messageID)
    {
        //in case message options weren't used before 
        InitializeMessageOptions();

        //get message option at waypoint
        MessageOptions opt = _messages[waypointID];

        //adds additional messages if required
        for (int i = opt.message.Count; i <= messageID; i++)
            AddMessageToOption(opt);

        //returns message option
        return opt;
    }

}
