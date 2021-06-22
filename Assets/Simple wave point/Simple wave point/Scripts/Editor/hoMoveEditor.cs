/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

//advantages you get from using Serialized Objects
//opportunity to:
//-use custom inspector windows
//-modify scripts of prefabs or revert specific values by right clicking
//-undo and redo
//-control common data types (only pass in a value, automatically use the right data type) 

//custom hoMove inspector
//inspect hoMove.cs and extend from Editor class
[CustomEditor(typeof(hoMove))]
public class hoMoveEditor : Editor
{
    //define Serialized Objects we want to use/control from hoMove.cs
    //this will be our serialized reference to the inspected script
    private SerializedObject m_Object;

    //delay array size, define path to know where to lookup for this variable
    //(we expect an array, so it's "name_of_array.data_type.size")
    private static string spArraySize = "StopAtPoint.Array.size";
    //.data gives us the data of the array,
    //we replace this {0} token with an index we want to get
    private static string spArrayData = "StopAtPoint.Array.data[{0}]";

    //local StopAtPoint array
    private float[] stopPoints;
    //inspector scrollbar x/y position, modified by mouse input
    private Vector2 scrollPosDelay;
    //whether delay settings menu should be visible
    private bool showDelaySetup = false;
    //variable to set all delay slots to this value
    private float delayAll = 0;

    //serialized message list property of hoMove
    SerializedProperty m_List;
    //local MessageOptions list
    private List<MessageOptions> mList;
    //inspector scrollbar x/y position, modified by mouse input
    private Vector2 scrollPosMessage;
    //whether message settings menu should be visible
    private bool showMessageSetup = false;


    //called whenever this inspector window is loaded 
    public void OnEnable()
    {
        //we create a reference to our script object by passing in the target
        m_Object = new SerializedObject(target);
        //get reference to message list
        m_List = m_Object.FindProperty("_messages");
    }


    //returns PathManager component of variable "pathContainer" for later use
    //if no Path Container is set, this will return null, so we need to check that below
    private PathManager GetPathTransform()
    {
        //get pathContainer from serialized property and return its PathManager component
        return m_Object.FindProperty("pathContainer").objectReferenceValue as PathManager;
    }


    private float[] GetStopPointArray()
    {
        //get array count from Path Manager component by accessing waypoints length,
        //and store value into var arrayCount. why length+1?
        //here we do a little trick: when we modify the last waypoint delay value
        //for example to 5, so our walker should wait 5 seconds at the last waypoint,
        //and then switch the path of this walker, because of array resizing all later
        //waypoints have a 5 second delay too. So we increase the length by 1, this slot
        //will be zero because we do not use it, and on resizing this value will be used.
        var arrayCount = GetPathTransform().waypoints.Length + 1;
        //create new float array with size of arrayCount
        var floatArray = new float[arrayCount];

        //get StopAtPoint array count from serialized property
        //and store its int value into var array
        var array = m_Object.FindProperty(spArraySize);
        //resize StopAtPoint array to waypoint array count
        array.intValue = arrayCount;

        //loop over waypoints
        for (var i = 0; i < arrayCount; i++)
        {
            //for each one use "FindProperty" to get the associated object reference
            //of StopAtPoint array, string.Format replaces {0} token with index i
            //and store the object reference value as type of float in floatArray[i]
            floatArray[i] = m_Object.FindProperty(string.Format(spArrayData, i)).floatValue;
        }
        //finally return that array copy for modification purposes
        return floatArray;
    }


    private void SetPointDelay(int index, float value)
    {
        //similiar to GetPointDelay(), find serialized property which belongs to index
        //and set this value to parameter float "value" directly
        m_Object.FindProperty(string.Format(spArrayData, index)).floatValue = value;
    }


    private float GetPointDelay(int index)
    {
        //similiar to SetPointDelay(), this will return the delay value from array at index position
        //and returns it instead of modifying
        return m_Object.FindProperty(string.Format(spArrayData, index)).floatValue;
    }


    //return message list from hoMove.cs
    //we create a new list and fill it with all given values for serialization
    private List<MessageOptions> GetMessageList()
    {
        //create new list for returning
        List<MessageOptions> msgOpt = new List<MessageOptions>();

        //loop through whole list
        for (int i = 0; i < m_List.arraySize; i++)
        {
            //get serialized MessageOption slot
            SerializedProperty slot = m_List.GetArrayElementAtIndex(i);
            //create new MessageOption to store values
            MessageOptions opt = new MessageOptions();
            //store values of serialized MessageOption properties
            SerializedProperty msgList = slot.FindPropertyRelative("message");
            SerializedProperty typeList = slot.FindPropertyRelative("type");
            SerializedProperty objList = slot.FindPropertyRelative("obj");
            SerializedProperty textList = slot.FindPropertyRelative("text");
            SerializedProperty numList = slot.FindPropertyRelative("num");
            SerializedProperty vect2List = slot.FindPropertyRelative("vect2");
            SerializedProperty vect3List = slot.FindPropertyRelative("vect3");

            //loop through values of this MessageOption
            for (int j = 0; j < msgList.arraySize; j++)
            {
                //fill created MessageOption with serialized values
                opt.message.Add(msgList.GetArrayElementAtIndex(j).stringValue);

                //abort if opened at runtime without specification of message settings before
                if (typeList.arraySize != msgList.arraySize)
                {
                    Debug.LogWarning("Resized Message List at runtime! Please open Message Settings in the editor first.");
                    return null;
                }

                opt.type.Add((MessageOptions.ValueType)typeList.GetArrayElementAtIndex(j).enumValueIndex);
                opt.obj.Add(objList.GetArrayElementAtIndex(j).objectReferenceValue);
                opt.text.Add(textList.GetArrayElementAtIndex(j).stringValue);
                opt.num.Add(numList.GetArrayElementAtIndex(j).floatValue);
                opt.vect2.Add(vect2List.GetArrayElementAtIndex(j).vector2Value);
                opt.vect3.Add(vect3List.GetArrayElementAtIndex(j).vector3Value);
            }
            //add filled MessageOption to the list
            msgOpt.Add(opt);
        }
        //return final list of messages
        return msgOpt;
    }


    //add new MessageOption at the end of waypoint's message list 
    private void AddMessageOption(int index)
    {
        //get MessageOption list at index and extend every value by one
        SerializedProperty slot = m_List.GetArrayElementAtIndex(index);
        slot.FindPropertyRelative("message").arraySize++;
        slot.FindPropertyRelative("type").arraySize++;
        slot.FindPropertyRelative("obj").arraySize++;
        slot.FindPropertyRelative("text").arraySize++;
        slot.FindPropertyRelative("num").arraySize++;
        slot.FindPropertyRelative("vect2").arraySize++;
        slot.FindPropertyRelative("vect3").arraySize++;
    }


    //remove MessageOption at the end of waypoint's message list 
    private void RemoveMessageOption(int index)
    {
        //get MessageOption list of index and decrease every value by one
        SerializedProperty slot = m_List.GetArrayElementAtIndex(index);
        slot.FindPropertyRelative("message").arraySize--;
        slot.FindPropertyRelative("type").arraySize--;
        slot.FindPropertyRelative("obj").arraySize--;
        slot.FindPropertyRelative("text").arraySize--;
        slot.FindPropertyRelative("num").arraySize--;
        slot.FindPropertyRelative("vect2").arraySize--;
        slot.FindPropertyRelative("vect3").arraySize--;
    }


    //methods to set a MessageOption value of a given waypoint
    //these are overwritten for every available data type value
    //parameters are list index, property, data type slot, type value
    private void SetMessageOption(int index, string field, int slot, string value)
    { m_List.GetArrayElementAtIndex(index).FindPropertyRelative(field).GetArrayElementAtIndex(slot).stringValue = value; }

    private void SetMessageOption(int index, string field, int slot, MessageOptions.ValueType value)
    { m_List.GetArrayElementAtIndex(index).FindPropertyRelative(field).GetArrayElementAtIndex(slot).enumValueIndex = (int)value; }

    private void SetMessageOption(int index, string field, int slot, Object value)
    { m_List.GetArrayElementAtIndex(index).FindPropertyRelative(field).GetArrayElementAtIndex(slot).objectReferenceValue = value; }

    private void SetMessageOption(int index, string field, int slot, float value)
    { m_List.GetArrayElementAtIndex(index).FindPropertyRelative(field).GetArrayElementAtIndex(slot).floatValue = value; }

    private void SetMessageOption(int index, string field, int slot, Vector2 value)
    { m_List.GetArrayElementAtIndex(index).FindPropertyRelative(field).GetArrayElementAtIndex(slot).vector2Value = value; }

    private void SetMessageOption(int index, string field, int slot, Vector3 value)
    { m_List.GetArrayElementAtIndex(index).FindPropertyRelative(field).GetArrayElementAtIndex(slot).vector3Value = value; }


    //called whenever the inspector gui gets rendered
    public override void OnInspectorGUI()
    {
        //this pulls the relative variables from unity runtime and stores them in the object
        //always call this first
        m_Object.Update();

        //show default iMove.cs public variables in inspector
        DrawDefaultInspector();

        //get Path Manager component by calling method GetWaypointArray()
        var path = GetPathTransform();

        EditorGUILayout.Space();
        //make the default styles used by EditorGUI look like controls
        EditorGUIUtility.LookLikeControls();

        //draw bold delay settings label
        GUILayout.Label("Settings:", EditorStyles.boldLabel);

        //check whether a Path Manager component is set, if not display a label
        if (path == null)
        {
            GUILayout.Label("No path set.");

            //get StopAtPoint array count from serialized property and resize it to zero
            //(in case of previously defined delay settings, clear old data)
            //do the same with message list properties
            m_Object.FindProperty(spArraySize).intValue = 0;
            m_List.arraySize = 0;
        }
        else
        {
            //draw delay options
            DelaySettings();
            EditorGUILayout.Separator();
            //draw message options
            MessageSettings();
        }

        //we push our modified variables back to our serialized object
        //always call this after all fields and buttons
        m_Object.ApplyModifiedProperties();
    }


    void DelaySettings()
    {
        //path is set and boolean for displaying delay settings is true
        //(button below was clicked)
        if (showDelaySetup)
        {
            //get StopAtPoint array reference by calling method GetStopPointArray()
            stopPoints = GetStopPointArray();

            EditorGUILayout.BeginHorizontal();
            //begin a scrolling view inside GUI, pass in Vector2 scroll position 
            scrollPosDelay = EditorGUILayout.BeginScrollView(scrollPosDelay, GUILayout.Height(105));

            //loop through waypoint array
            for (int i = 0; i < GetPathTransform().waypoints.Length; i++)
            {
                GUILayout.BeginHorizontal();
                //draw label with waypoint index,
                //increased by one (so it does not start at zero)
                GUILayout.Label((i + 1) + ".", GUILayout.Width(20));
                //create a float field for every waypoint delay slot
                var result = EditorGUILayout.FloatField(stopPoints[i], GUILayout.Width(50));

                //if the float field has changed, set waypoint delay to new input
                //(within serialized StopAtPoint array property)
                if (GUI.changed)
                    SetPointDelay(i, result);

                GUILayout.EndHorizontal();
            }
            //ends the scrollview defined above
            EditorGUILayout.EndScrollView();

            EditorGUILayout.BeginVertical();

            //draw button for hiding of delay settings
            if (GUILayout.Button("Hide Delay Settings"))
            {
                showDelaySetup = false;
            }

            //draw button to set all delay value slots to the value specified in "delayAll"
            if (GUILayout.Button("Set All:"))
            {
                //loop through all delay slots, call SetPointDelay() and pass in "delayAll"
                for (int i = 0; i < stopPoints.Length; i++)
                    SetPointDelay(i, delayAll);
            }

            //create a float field for being able to change variable delayAll
            delayAll = EditorGUILayout.FloatField(delayAll, GUILayout.Width(50));

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();
        }
        else
        {
            //if path is set but delay settings are not shown,
            //draw button to toggle showDelaySetup
            if (GUILayout.Button("Show Delay Settings"))
                showDelaySetup = true;
        }
    }


    void MessageSettings()
    {
        //path is set and boolean for displaying message settings is true
        //(button below was clicked)
        if (showMessageSetup)
        {
            //draw button for hiding message settings
            if (GUILayout.Button("Hide Message Settings"))
                showMessageSetup = false;

            EditorGUILayout.BeginHorizontal();

            //clear message values
            if (GUILayout.Button("Clear"))
            {
                //display custom dialog and wait for user input to clear all message values
                if (EditorUtility.DisplayDialog("Are you sure?",
                "Do you really want to reset all messages and their values?",
                "Continue",
                "Cancel"))
                {
                    //user clicked "Yes", reset array size to zero
                    m_List.arraySize = 0;
                }
            }

            //delete all message values and disable settings so they are not recreated again
            if (GUILayout.Button("Deactivate"))
            {
                //display custom dialog and wait for user input to delete all message values
                if (EditorUtility.DisplayDialog("Are you sure?",
                "This will delete all message slots to reduce memory usage.",
                "Continue",
                "Cancel"))
                {
                    //user clicked "Yes", reset array size to zero and hide settings
                    m_List.arraySize = 0;
                    showMessageSetup = false;
                    return;
                }
            }

            EditorGUILayout.EndHorizontal();

            //begin a scrolling view inside GUI, pass in Vector2 scroll position 
            scrollPosMessage = EditorGUILayout.BeginScrollView(scrollPosMessage, GUILayout.Height(245));
            //get modifiable list of MessageProperties
            mList = GetMessageList();

            //loop through list
            for (int i = 0; i < mList.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();

                //draw label with waypoint index, display total count of messages for this waypoint
                //increased by one (so it does not start at zero)
                EditorGUILayout.HelpBox((i + 1) + ". Waypoint - " + "Messages: " + mList[i].message.Count, MessageType.None);

                //add new message to this waypoint
                if (GUILayout.Button("+"))
                    AddMessageOption(i);

                //remove last message from this waypoint
                if (mList[i].message.Count > 1 && GUILayout.Button("-"))
                    RemoveMessageOption(i);

                EditorGUILayout.EndHorizontal();

                //loop through messages
                for (int j = 0; j < mList[i].message.Count; j++)
                {
                    //display text box and message name input field
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.HelpBox("Method: ", MessageType.None);
                    string messageField = EditorGUILayout.TextField(mList[i].message[j]);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();

                    //display enum for selectable data types
                    //declare variables for each data type for storing their input value
                    MessageOptions.ValueType typeField = (MessageOptions.ValueType)EditorGUILayout.EnumPopup(mList[i].type[j]);
                    Object objField; string textField; float numField; Vector2 vect2Field; Vector3 vect3Field;

                    //draw corresponding data type field for selected enum type
                    //store input in the values above. if the field has changed,
                    //set the corresponding type value for the current MessageOption 
                    switch (typeField)
                    {
                        case MessageOptions.ValueType.None:
                            break;
                        case MessageOptions.ValueType.Object:
                            objField = EditorGUILayout.ObjectField(mList[i].obj[j], typeof(Object), true);
                            if (GUI.changed) SetMessageOption(i, "obj", j, objField);
                            break;
                        case MessageOptions.ValueType.Text:
                            textField = EditorGUILayout.TextField(mList[i].text[j]);
                            if (GUI.changed) SetMessageOption(i, "text", j, textField);
                            break;
                        case MessageOptions.ValueType.Numeric:
                            numField = EditorGUILayout.FloatField(mList[i].num[j]);
                            if (GUI.changed) SetMessageOption(i, "num", j, numField);
                            break;
                        case MessageOptions.ValueType.Vector2:
                            vect2Field = EditorGUILayout.Vector2Field("", mList[i].vect2[j]);
                            if (GUI.changed) SetMessageOption(i, "vect2", j, vect2Field);
                            break;
                        case MessageOptions.ValueType.Vector3:
                            vect3Field = EditorGUILayout.Vector3Field("", mList[i].vect3[j]);
                            if (GUI.changed) SetMessageOption(i, "vect3", j, vect3Field);
                            break;
                    }

                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Separator();
                    //regardless of the data type,
                    //set the message name and enum type of this MessageOption
                    if (GUI.changed)
                    {
                        SetMessageOption(i, "message", j, messageField);
                        SetMessageOption(i, "type", j, typeField);
                    }
                }
            }
            //ends the scrollview defined above
            EditorGUILayout.EndScrollView();

            //here we check for the last GUI pass, where the Inspector gets drawn
            //the first pass is responsible for the GUI layout of all fields,
            //and if we resize the list in the first pass it throws an error in the second pass
            //this is because the first and the second pass must have the same values on redraw
            if (Event.current.type == EventType.Repaint)
            {
                //get total list size and set it to the waypoint size,
                //so each waypoint has one MessageOption value
                m_List.arraySize = GetPathTransform().waypoints.Length;
                //loop through messages per waypoint
                for (int i = 0; i < mList.Count; i++)
                {
                    //if the waypoint does not contain a message option, add a new slot
                    if (mList[i].message.Count == 0)
                    {
                        AddMessageOption(i);
                        break;
                    }
                }
            }
        }
        else
        {
            //if path is set but delay settings are not shown,
            //draw button to toggle showDelaySetup
            if (GUILayout.Button("Show Message Settings"))
            {
                showMessageSetup = true;
            }
        }
    }


    //if this path is selected, display small info boxes above all waypoint positions
    void OnSceneGUI()
    {
        //again, get Path Manager component
        var path = GetPathTransform();

        //do not execute further code if we have no path defined
        //or delay settings are not visible
        if (path == null || !showDelaySetup) return;

        //get waypoints array of Path Manager
        var waypoints = path.waypoints;

        //begin GUI block
        Handles.BeginGUI();
        //loop through waypoint array
        for (int i = 0; i < waypoints.Length; i++)
        {
            //translate waypoint vector3 position in world space into a position on the screen
            var guiPoint = HandleUtility.WorldToGUIPoint(waypoints[i].transform.position);
            //create rectangle with that positions and do some offset
            var rect = new Rect(guiPoint.x - 50.0f, guiPoint.y - 60, 100, 20);
            //draw box at rect position with current waypoint name
            GUI.Box(rect, "Waypoint: " + (i + 1));
            //create rectangle and position it below
            var rectDelay = new Rect(guiPoint.x - 50.0f, guiPoint.y - 40, 100, 20);
            //draw box at rectDelay position with current delay at that waypoint
            GUI.Box(rectDelay, "Delay: " + GetPointDelay(i));
        }
        Handles.EndGUI(); //end GUI block
    }
}
