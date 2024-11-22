using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JW.Project3.Events
{
    /// <summary>
    /// Author: JW
    /// This script listens for a given GameEvent to be Raised to perform all the given responses
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        #region Variables
        [Header("Game Event Listener")]
        [SerializeField, Tooltip("The `GameEvent` to listen for")] private GameEvent listening;
        [SerializeField] public UnityEvent Response;

        #region Properties, Getters & Setters
        public GameEvent Listening { get { return listening; } set { listening = value; } }
        #endregion
        #endregion

        #region Public Functions
        /// <summary>
        /// Calls all the events to respond to being raised
        /// </summary>
        public void OnRaised()
        {
            Response.Invoke(); // Calls all the response events
            Debug.Log($"{gameObject.name} responded");
        }
        #endregion

        #region Unity Specific Functions
        private void OnEnable()
        {
            #region Validation Checks
            Debug.Assert(listening != null, $"ERROR |{gameObject.name}| This listener is not listening to any GameEvents");
            #endregion

            // Remove and re-add the listener to the GameEvent
            if (listening.IsListening(this))
            {
                Debug.Log($"{gameObject.name} wierd add");
                listening.RemoveListener(this);
                listening.AddListener(this);
            }
            else
            {
                Debug.Log($"{gameObject.name} normal add");
                listening.AddListener(this);
            }
        }

        private void OnDisable()
        {
            #region Validation Checks
            Debug.Assert(listening != null, $"ERROR |{gameObject.name}| This listener is not listening to any GameEvents");
            #endregion

            // remove listener from event if we are listening to it
            if (listening.IsListening(this))
            {
                listening.RemoveListener(this);
            }
            else
            {
                listening.AddListener(this);
                listening.RemoveListener(this);
            }
        }
        #endregion
    } 
}
