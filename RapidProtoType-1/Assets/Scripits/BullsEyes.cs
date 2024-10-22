using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsEyes : MonoBehaviour
{
    public Animator animator;

    public void Hit()
    {
        StartCoroutine(PlayAnimationForduration(3f));  
    }

    private IEnumerator PlayAnimationForduration(float duration)
    {
        animator.SetTrigger("Die");

        yield return new WaitForSeconds(duration);

        animator.SetTrigger("Idle");
    }
}
