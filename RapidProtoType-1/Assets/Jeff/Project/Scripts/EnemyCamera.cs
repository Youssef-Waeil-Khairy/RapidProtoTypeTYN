using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamera : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player transform

    void Update()
    {
        if (playerTransform != null)
        {
            // Make the camera face the player position
            transform.LookAt(playerTransform);
            
        }
    }
}

