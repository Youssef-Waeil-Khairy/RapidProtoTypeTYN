using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void DeathAction();

    public event DeathAction onDeath;
   public void Die ()
   {
        if (onDeath != null) 
        {
            onDeath.Invoke(); 
        }
        Destroy(gameObject);
    }
}
