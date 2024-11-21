using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JW.Project3.Events
{
    /// <summary>
    /// Author: JW
    /// Creates an event that can be raised to call all responses from the current listeners.
    /// </summary>
    [CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/GameEvents/New Event", order = 0)]
    public class GameEvent : ScriptableObject
    {
        #region Variables
        private List<GameEventListener> listeners = new List<GameEventListener>(); // All the scripts waiting for this event to be raised
        #endregion

        #region Public Functions
        /// <summary>
        /// Calls all listeners for this event to trigger their Response events
        /// </summary>
        public void Raise()
        {
            Debug.Assert(listeners != null, $"ERROR |{name}| Listeners is null");
            Debug.Assert(listeners.Count != 0, $"ERROR |{name}| There are no listeners for this GameEvent");
            if (listeners == null || listeners.Count == 0) return;

            Debug.Log($"{name} Raised");
            for (int i = listeners.Count - 1; i >= 0; i--) // Loop through all listeners backwards to avoid breaking if they get removed
            {
                GameEventListener item = listeners[i];
                if (item == null) Debug.LogError("item is null");
                else item.OnRaised();
            }
        }

        /// <summary>
        /// Adds the given listener to the list of listeners
        /// </summary>
        /// <param name="newListener">GameEventListener | the listener to add</param>
        public void AddListener(GameEventListener newListener)
        {
            #region Validation Check
            Debug.Assert(!listeners.Contains(newListener), $"ERROR |{name}| {newListener.gameObject.name} is already listening forr this GameEvent"); 
            #endregion   

            // Add listener to the list
            listeners.Add(newListener);
            Debug.Log($"Added listener: {newListener.gameObject.name} -> {name}");
        }

        /// <summary>
        /// Remove the given listener from the list
        /// </summary>
        /// <param name="listener">GameEventListener | listener to remove</param>
        public void RemoveListener(GameEventListener listener)
        {
            #region Validation Check
            Debug.Assert(listeners.Contains(listener), $"ERROR |{name}| {listener.gameObject.name} is not listening to this GameEvent so can not be removed"); 
            #endregion

            // Remove the given listener from the list
            listeners.Remove(listener);
            Debug.Log($"Removed listener: {listener.gameObject.name} -> {name}");
        }

        /// <summary>
        /// Checks whether the given GameEventListener is in the list
        /// </summary>
        /// <param name="listener">GameEventListener | listenr to check for</param>
        /// <returns>bool | true if it is in the list, otherwise false</returns>
        public bool IsListening(GameEventListener listener)
        {
            return listeners.Contains(listener);
        }

        /// <summary>
        /// Returns the number of GameEventListeners there are in the list
        /// </summary>
        /// <returns>int | number of listeners</returns>
        public int CountListeners() { return listeners.Count; }
        #endregion
    }
}
