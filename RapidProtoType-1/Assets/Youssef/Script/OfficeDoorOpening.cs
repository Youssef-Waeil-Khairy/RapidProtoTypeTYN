using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoorOpening : MonoBehaviour
{
    //refrencing the animtor for door/cell gates
    public Animator doorOepning;

    //the parameter in th enaimtor
    public string doorBool = "isDoorOpen";

    public AudioSource audioSource;
    public AudioClip voiceOver;
    //play audio once
    private bool hasPlayedAudio = false;

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

            if (!hasPlayedAudio && audioSource != null && voiceOver != null)
            {
                audioSource.PlayOneShot(voiceOver);
                hasPlayedAudio = true;
            }

            StartCoroutine(DestroyAfterSound());

        }
        
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(voiceOver.length);

        //destory the coin once its colided
        Destroy(gameObject);
    }
}
