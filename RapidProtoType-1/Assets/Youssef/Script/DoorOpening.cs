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

    // scripit will be attached to every key, if the key collides with player , it will open the door that is aiisgne din inspector
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (doorOepning != null)
            {
                doorOepning.SetBool(doorBool, true);
            }

            //destory the coin once its colided
           Destroy(gameObject);
        }
        
    }
}
