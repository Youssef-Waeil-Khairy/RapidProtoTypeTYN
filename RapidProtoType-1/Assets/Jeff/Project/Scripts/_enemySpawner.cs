using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to instantiate
    public Transform[] spawnPoints; // Array of spawn points
    public Transform playerTransform; // Reference to the player's transform
    void Start()
    {
        // go through each spawn point and instantiate an enemy at each position
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }

    }
}
