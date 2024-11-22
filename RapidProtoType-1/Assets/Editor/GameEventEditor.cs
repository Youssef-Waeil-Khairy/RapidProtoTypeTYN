using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JW.Project3.Events;

/// <summary>
/// Author: JW
/// Custom inspector for easily adding/removing listeners and raising the event at editor time
/// </summary>
[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameEvent gameEvent = (GameEvent)target; // GameEvent we are inspecting

        //EditorGUILayout.HelpBox("*IMPORTANT* If you add some GameEventListeners to a GameEvent using the inspector buttons, it breaks during play-time.", MessageType.Warning);

        // Show how many listeners this event has
        EditorGUILayout.LabelField("Number of listeners", gameEvent.CountListeners().ToString());

        // Button to raise all listeners without having to start the game
        if (GUILayout.Button("Raise Event")) 
        {
            if (gameEvent != null)
            {
                gameEvent.Raise();
            }
            else
            {
                Debug.Log("Wierdness");
            }
        }
    }
}
