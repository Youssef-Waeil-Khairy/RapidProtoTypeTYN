using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsEye : MonoBehaviour
{
    public Animator animator;

    private bool isDead = false;

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;

            animator.SetTrigger("Die");

            StartCoroutine(IdleState());
        }
    }

    IEnumerator IdleState()

    {
        yield return new WaitForSeconds(3f);

        animator.ResetTrigger("Die");

        isDead = false;
    }
}
