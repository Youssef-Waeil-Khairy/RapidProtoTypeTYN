# Introduction
This package implements a Unity Event based system drawn from this [Unite talk](https://youtu.be/raQ3iHhE_Kk?si=mzpVLTZpTEa0v2O3&t=1674)

# API Documentation
## `GameEventListener`
A `Monobehaviour` script that excecutes Events in response to being raised
### To use:
    1. attach to a `GameObject` in the scene
    2. Configure the `Response` Events. These Events will be called when this listener is raised
    3. Set the `GameEvent` in the `listening` field. This is the `GameEvent` scriptable object that will raise this listener
### Properties
| Name         | Type        | Description                                                                                            |
| ------------ | ----------- | ------------------------------------------------------------------------------------------------------ |
| `Listeneing` | `GameEvent` | Gets the `listening` variable (type: `GameEvent`). Sets the `listening` variable to the provided value |
### Variables
| Name       | Type         | Description                            |
| ---------- | ------------ | -------------------------------------- |
| `Response` | `UnityEvent` | `UnityEvents` to be called when raised |
### Functions
#### OnRaised
Inputs: none
Outputs: none
Description: Invokes all the `Response` events

---

## `GameEvent`
A scriptable object that raises a list of `GameEventListener` listening for it.
### To Use:
Creating a new `GameEvent`:
    1. Create a new scriptable object by right clicking in the folder "Assets/JW/Scripts/Events" and going through the asset menu to "ScriptableObjects/GameEvents/New Event"
    2. Rename to what the event will do/what triggers it (optional but best practice)
    3. Go to each `GameEventListener` instance that will listen to it and set the `Listening` field to this scriptable object
Usage:
    1. From a script, call the `Raise` function to raise all listening `GameEventListener` scripts
### Functions
#### Raise
Inputs: none
Outputs: none
Description: Calls all listeners for this event to trigger their Response events
#### AddListener
Inputs:
- newListener: `GameEventListener` | `GameEventListener` to add to the list of listeners
Outputs: none
Description: Adds the given listener to the list of listeners
#### RemoveListener
Inputs:
- listener: `GameEventListener` | `GameEventListener` to remove from the list of listeners
Outputs: none
Description: Removes the given listener from the list of listeners
#### IsListening
Inputs:
- newListener: `GameEventListener` | `GameEventListener` to check for in the list of listeners
Outputs: `bool` | `true` if present, `false` if not
Description: Checks for the given listener in the list of listeners
#### CountListeners
Inputs: none
Outputs: `int` | Number of items in `listeners`
Description: Adds the given listener to the list of listeners