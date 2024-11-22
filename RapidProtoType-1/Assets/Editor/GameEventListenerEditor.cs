using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JW.Project3.Events;
using UnityEngine.UIElements;

/// <summary>
/// Author: JW
/// Custom inspector for GameEventListeners to be able to easily add listeners in the inspector at editor time
/// </summary>
[CustomEditor(typeof(GameEventListener))]
public class GameEventListenerEditor : Editor
{
    #region Variables
    SerializedProperty response;
    SerializedProperty listening;
    #endregion

    #region Unity Specific Functions
    private void OnEnable()
    {
        response = serializedObject.FindProperty("Response");
        listening = serializedObject.FindProperty("listening");
    }
    #endregion

    #region Custom Inspector
    public override void OnInspectorGUI()
    {
        GameEventListener listener = (GameEventListener)target;

        #region Response Events
        // Allows for editing the Response UnityEvents
        serializedObject.Update();
        EditorGUILayout.PropertyField(response);
        #endregion

        #region GameEvent
        //listener.Listening = (GameEvent)EditorGUILayout.ObjectField(listener.Listening, typeof(GameEvent), true); // Shows a drag and drop box for the GameEvent to listen for
        EditorGUILayout.PropertyField(listening);
        if (listener.Listening != null) // Only show if a GameEvent is set in the box
        {
            if (!listener.Listening.IsListening(listener)) // We are not listening for the event
            {
                EditorGUILayout.HelpBox("This listener is not currently listening for this event", MessageType.Warning);

                if (GUILayout.Button("Add Listener"))
                {
                    listener.Listening.AddListener(listener);
                }
            }
            else // We are listening
            {
                EditorGUILayout.HelpBox("This listener is listening for this event", MessageType.Info);

                if (GUILayout.Button("Remove Listener"))
                {
                    listener.Listening.RemoveListener(listener);
                }
            }
        }
        serializedObject.ApplyModifiedProperties();

        #endregion
    }
    #endregion
}
