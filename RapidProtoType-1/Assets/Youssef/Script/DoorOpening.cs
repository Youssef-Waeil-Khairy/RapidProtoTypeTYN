using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    //refrencing the animtor for door/cell gates
    public Animator doorOepning;

    //the parameter in th enaimtor
    public string doorBool = "isDoorOpen";


    private void Start()
    {
        //enusres its always false at start
        doorOepning.SetBool(doorBool, false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Key"))
        {
            if (doorOepning != null)
            {
                doorOepning.SetBool(doorBool, true);
            }

            //destroys the key gameobject
            Destroy(collision.gameObject);
        }
        
    }
}
