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
using Holoville.HOTween;
using Holoville.HOTween.Plugins;


//movement script: HOTween
[AddComponentMenu("Simple Waypoint System/hoMove")]
public class hoMove : MonoBehaviour
{
    //which path to call
    public PathManager pathContainer;
    //animation path type, linear or curved, curved by default
    public PathType pathtype = PathType.Curved;
    //should this gameobject start to walk on game launch?
    public bool onStart = false;
    //should this gameobject walk to the first waypoint or just spawn there?
    public bool moveToPath = false;
    //close path for building a loop
    public bool closePath = false;
    //should this gameobject look to its target point?
    public bool orientToPath = false;
    //is this gameobject parented to or should move with the path?
    public bool local = false;

    //lookAhead value used by orientToPath (0-1), 0 means restrict to path
    public float lookAhead = 0;
    //custom object size to add
    public float sizeToAdd = 0;
    //delay at each waypoint
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
    public EaseType easetype = EaseType.Linear;
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
    [HideInInspector]
    //location indicator
    public int currentPoint = 0;
    //used on looptype = pingpong for counting currentpoint backwards
    private bool repeat = false;

    //lock axis rotation variable
    public Axis lockAxis = Axis.None;
    //lock position variable
    public Axis lockPosition = Axis.None;

    //animation component
    [HideInInspector]
    public Animation anim;
    //animation to play during walk time
	public  AnimationClip walkAnim;
    //animation to play during waiting time
    public  AnimationClip idleAnim;
    //whether animations should fade in over a period of time or not
    public bool crossfade = false;


    //--HOTween animation helper variables--
    //active HOTween tween
    public Tweener tween;
    //array of modified waypoint positions for the tween
    private Vector3[] wpPos;
    //parameters for the tween
    private TweenParms tParms;
    //HOTween path plugin for curved movement
    private PlugVector3Path plugPath;
    //looptype random generator
    private System.Random rand = new System.Random();
    //looptype random waypoint index array
    private int[] rndArray;
    //looptype random current waypoint index
    private int rndIndex = 0;
    //whether the tween was paused
    private bool waiting = false;
	public bool standStill=false;

    //checks if gameobject should move on game start
    internal void Start()
    {
        //get animation component from children
        if (!anim)
            anim = gameObject.GetComponentInChildren<Animation>();

        //start moving instantly
        if (onStart)
            StartMove();
    }


    //initialize or update waypoint positions
    internal void InitWaypoints()
    {
        //recreate array used for waypoint positions
        wpPos = new Vector3[waypoints.Length];
        //fill array with original positions and add custom height
        for (int i = 0; i < wpPos.Length; i++)
        {
            wpPos[i] = waypoints[i].position + new Vector3(0, sizeToAdd, 0);
        }
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
		
		//cache original speed for future speed changes
		originSpeed = speed;

        //check if delay array wasn't set in the editor, then we have to initialize it
        if (StopAtPoint == null)
            StopAtPoint = new float[waypoints.Length];
        else if (StopAtPoint.Length < waypoints.Length)
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

        //start moving
        StartCoroutine(Move());
    }


    //start moving depending on settings
    internal IEnumerator Move()
    {
        //if this object should walk to the first waypoint,
        //first start an additional tween
        if (moveToPath)
            yield return StartCoroutine(MoveToPath());
        else
        //if we should not walk to the first waypoint,
        //we set this gameobject position directly to it and launch the next waypoint routine
        {
            //initialize waypoint positions
            InitWaypoints();
            //we also add a defined size to our object height,
            //so our gameobject could "stand" on top of the path.
            transform.position = waypoints[currentPoint].position + new Vector3(0, sizeToAdd, 0);
            //directly look at the first waypoint at start
            if (orientToPath && currentPoint < wpPos.Length - 1)
                transform.LookAt(wpPos[currentPoint + 1]);
        }

        //we're now at the first waypoint position, so directly call the next waypoint
        //on looptype random we have to initialize a random order of waypoints first
        //on all other settings we create the tween and start moving to the next waypoint
        if (looptype == LoopType.random)
            StartCoroutine(ReachedEnd());
        else
        {
            CreateTween();
            StartCoroutine(NextWaypoint());
        }
    }


    //move to path setting checked
    internal IEnumerator MoveToPath()
    {
        //if moveToPath equals true, we want to start movement from the current position
        //this means that our waypoint position array should start with the current position,
        //and then move to the first.


        //then we fill that array with at least all waypoints of wpPos, but we dont need
        //more than 4 waypoints for calculating a bezier curve to the first waypoint
        int max = waypoints.Length > 4 ? 4 : waypoints.Length;
        wpPos = new Vector3[max];

        for (int i = 1; i < max; i++)
        {
            //adding the custom height, starting from the second slot
            wpPos[i] = waypoints[i - 1].position + new Vector3(0, sizeToAdd, 0);
        }
        //finally set the first slot to the current position
        wpPos[0] = transform.position;
        //create HOTween tweener
        CreateTween();
        //resume tweener if paused
        if (tween.isPaused)
            tween.Play();

        //move object from current position to the first waypoint
        yield return StartCoroutine(tween.UsePartialPath(-1, 1).WaitForCompletion());
        //disable moveToPath option as we are at the first waypoint now
        moveToPath = false;

        //discard tweener because it was only used for this option
        tween.Kill();
        tween = null;
        //reinitialize original waypoint positions
        InitWaypoints();
    }


    //creates a new HOTween tween which moves us to the next waypoint
    //(defined by passed arguments)
    internal void CreateTween()
    {
        //play walk animation if set
        PlayWalk();

        //prepare HOTween's parameters, you can look them up here
        //http://www.holoville.com/hotween/documentation.html
        ////////////////////////////////////////////////////////////

        //create new HOTween plugin for curved paths
        //pass in array of Vector3 waypoint positions, relative = true
        plugPath = new PlugVector3Path(wpPos, true, pathtype);

        //orients the tween target along the path
        //constrains this game object on one axis
        if (orientToPath || lockAxis != Axis.None)
            plugPath.OrientToPath(lookAhead, lockAxis);

        //lock position axis
        if (lockPosition != Axis.None)
            plugPath.LockPosition(lockPosition);

        //create a smooth path if closePath was true
        if (closePath)
            plugPath.ClosePath(true);

        //create TweenParms for storing HOTween's parameters
        tParms = new TweenParms();
        //sets the path plugin as tween position property
        if (local)
            tParms.Prop("localPosition", plugPath);
        else
            tParms.Prop("position", plugPath);
        //additional tween parameters for partial tweens
        tParms.AutoKill(false);
        tParms.Pause(true);
        tParms.Loops(1);

        //differ between TimeValue like mentioned above at enum TimeValue
        //use speed with linear easing
        if (timeValue == TimeValue.speed)
        {
            tParms.SpeedBased();
            tParms.Ease(EaseType.Linear);
        }
        else
            //use time in seconds and the chosen easetype
            tParms.Ease(easetype);

        //create a new tween, move this gameobject with given arguments
        tween = HOTween.To(transform, originSpeed, tParms);
		
		//continue new tween with adjusted speed if it was changed before
		if(originSpeed != speed)
			ChangeSpeed(speed);
    }


    //this method moves us one by one to the next waypoint
    //and executes all delay or tweening interaction
    internal IEnumerator NextWaypoint()
    {
        //loop through modified waypoint positions
        for (int point = 0; point < wpPos.Length - 1; point++)
        {
            //execute all messages for this waypoint
            StartCoroutine(SendMessages());

            //execute waypoint delay
			if (StopAtPoint[currentPoint] > 0)
				yield return StartCoroutine(WaitDelay());

            //check for pausing and wait until unpaused again
            while (waiting) yield return null;

            //continue tween
            PlayWalk();
            tween.Play();
            //tween from current point to the next point in array wpPos
            yield return StartCoroutine(tween.UsePartialPath(point, point + 1).WaitForCompletion());

            if (repeat)
                //repeating mode is on, decrease currentPoint one by one while moving backwards
                currentPoint--;
            else if (looptype == LoopType.random)
            {
                //count up random index after each waypoint
                rndIndex++;

                //assign next waypoint of our shuffled array with currentPoint numbers
                currentPoint = rndArray[rndIndex];
            }
            else
                //repeating mode off, normally increase currentPoint
                currentPoint++;
        }

        //on looptype pingpong or random avoid additional message/delay execution at last waypoint
        if (looptype != LoopType.pingPong && looptype != LoopType.random)
        {
            StartCoroutine(SendMessages());
			if (StopAtPoint[currentPoint] > 0)
				yield return StartCoroutine(WaitDelay());
        }

        //differ between tween options at the end of the path
        StartCoroutine(ReachedEnd());
    }


    //inserts a delay at the current waypoint
    internal IEnumerator WaitDelay()
    {
        //only delay waypoint movement if delay settings are edited to avoid unnecessary frame yield,
        //so current value at StopAtPoint has to be greater than zero
        //pause tween while waiting
		tween.Pause();

        //play idle animation if set
        PlayIdle();

        //wait seconds defined in StopAtPoint at current waypoint position
        //own implementation of a WaitForSeconds() coroutine,
        //with an additional check for pausing/unpausing (waiting)
        float timer = Time.time + StopAtPoint[currentPoint];
        while (!waiting && Time.time < timer)
            yield return null;
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


    //we reached the end of the path
    internal IEnumerator ReachedEnd()
    {
        //we differ between all looptypes, because each one has a specific property
        switch (looptype)
        {
            //LoopType.none means there will be no repeat,
            //so we just discard the tweener and return
            case LoopType.none:

                tween.Kill();
                tween = null;
                PlayIdle();
                yield break;

            //in a loop we set our position indicator back to zero and start from the beginning
            case LoopType.loop:

                //additional option: if the path was closed, we move our object
                //from the last to the first waypoint instead of just "appearing" there
                if (closePath)
                {
                    tween.Play();
                    PlayWalk();
                    yield return StartCoroutine(tween.UsePartialPath(currentPoint, -1).WaitForCompletion());
                }
                currentPoint = 0;
                break;

            //on LoopType.pingPong, we decrease our location indicator till it reaches zero again
            //to start from the beginning - to achieve that, and differ between back and forth,
            //we use the boolean "repeat" here and in NextWaypoint()
            case LoopType.pingPong:

                //discard tweener as it only moved us forwards or backwards
                tween.Kill();
                tween = null;

                //we moved till the end of the path
                if (!repeat)
                {
                    //enable repeat mode
                    repeat = true;
                    //update waypoint positions backwards
                    for (int i = 0; i < wpPos.Length; i++)
                    {
                        wpPos[i] = waypoints[waypoints.Length - 1 - i].position + new Vector3(0, sizeToAdd, 0);
                    }
                }
                else
                {
                    //we are at the first waypoint again,
                    //reinitialize original waypoint positions
                    //and disable repeating mode
                    InitWaypoints();
                    repeat = false;
                }

                //create tweener for next iteration
                CreateTween();
                break;

            //on LoopType.random, we calculate a random order between all waypoints
            //and loop through them, for this case we use the Fisher-Yates algorithm
            case LoopType.random:
                //reset random index, because we calculate a new order
                rndIndex = 0;
                //reinitialize original waypoint positions
                InitWaypoints();

                //discard tweener for new order
                if (tween != null)
                {
                    tween.Kill();
                    tween = null;
                }

                //create array with ongoing index numbers to keep them in mind,
                //this gets shuffled with all waypoint positions at the next step 
                rndArray = new int[wpPos.Length];
                for (int i = 0; i < rndArray.Length; i++)
                {
                    rndArray[i] = i;
                }

                //get total array length
                int n = wpPos.Length;
                //shuffle wpPos and rndArray
                while (n > 1)
                {
                    int k = rand.Next(n--);
                    Vector3 temp = wpPos[n];
                    wpPos[n] = wpPos[k];
                    wpPos[k] = temp;

                    int tmpI = rndArray[n];
                    rndArray[n] = rndArray[k];
                    rndArray[k] = tmpI;
                }

                //since all waypoints are shuffled the first waypoint does not
                //correspond with the actual current position, so we have to
                //swap the first waypoint with the actual waypoint
                //start by caching the first waypoint position and number
                Vector3 first = wpPos[0];
                int rndFirst = rndArray[0];
                //loop through wpPos array and find corresponding waypoint
                for (int i = 0; i < wpPos.Length; i++)
                {
                    //currentPoint is equal to this waypoint number
                    if (rndArray[i] == currentPoint)
                    {
                        //swap rnd index number and waypoint positions
                        rndArray[i] = rndFirst;
                        wpPos[0] = wpPos[i];
                        wpPos[i] = first;
                    }
                }
                //set current rnd index number to the actual current point
                rndArray[0] = currentPoint;

                //create tween with random order
                CreateTween();
                break;
        }

        //start moving to the next iteration
        StartCoroutine(NextWaypoint());
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
                anim.CrossFade(idleAnim.name, 0.02f);
            else
                anim.Play(idleAnim.name);
        }
    }


    //play walk animation if set
    public void PlayWalk()
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
        StopAllCoroutines();
        //destroy current HOTween movement component
        HOTween.Kill(transform);
        plugPath = null;
        tween = null;
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


    //pauses the current tween and tries to play the idle animation
	/*void Update () {
		if (pauseGame.p == true) {
			
			//block further tween execution in NextWaypoint()
			waiting = true;
			//pause the tweener of this object and play idle animation
			HOTween.Pause (transform);
			PlayIdle ();
		}
		if (pauseGame.p == false) {
			//unblock further tween execution in NextWaypoint()
			waiting = false;
			//resume tweener
			HOTween.Play (transform);
			//play walk animation
			PlayWalk ();
		}
		
	}*/
    public void Pause()
    {

	
						//block further tween execution in NextWaypoint()
						waiting = true;
						//pause the tweener of this object and play idle animation
						HOTween.Pause (transform);
						PlayIdle ();
				

    }


    //resumes the current tween and tries to play the walk animation
    public void Resume()
    {

						//unblock further tween execution in NextWaypoint()
						waiting = false;
						//resume tweener
						HOTween.Play (transform);
						//play walk animation
						PlayWalk ();
				
    }
	
	
	//cache original speed at start
	private float originSpeed;
	//change running tween speed
	//manipulates HOTween's tween timeScale value
	public void ChangeSpeed(float value)
    {
		//calulate new timeScale value based on original speed
        float newValue;
        if (timeValue == TimeValue.speed)
            newValue = value / originSpeed;
        else
            newValue = originSpeed / value;
        //set speed, change HOTween timescale percentually to 'newValue'
		speed = value;

		if (GetComponent<hoMove>().enabled) {
						tween.timeScale = newValue;
				}
				
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
