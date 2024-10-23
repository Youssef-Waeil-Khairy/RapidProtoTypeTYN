using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsEyes : MonoBehaviour
{
    public Animator animator;

    public void Hit(Vector3 position)
    {
        if (position.y > transform.position.y)
        {
            animator.SetTrigger("Die");

        }
        else
        {
            animator.SetTrigger("Die2");

        }
        //StartCoroutine(PlayAnimationForduration(3f));  
    }

    private IEnumerator PlayAnimationForduration(float duration)
    {
        animator.SetTrigger("Die");

        yield return new WaitForSeconds(duration);

        animator.SetTrigger("Idle");
    }
}
