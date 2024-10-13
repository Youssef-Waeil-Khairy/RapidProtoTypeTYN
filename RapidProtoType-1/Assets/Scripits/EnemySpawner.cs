using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public float spawnDelay = 0.2f; 

    private void Start()
    {
        SpawnEnemy(); 
    }

    public void SpawnEnemy()
    {
       
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.onDeath += HandleEnemyDeath; 
        }
    }

    private void HandleEnemyDeath()
    {
        
        StartCoroutine(SpawnEnemyAfterDelay());
    }

    private IEnumerator SpawnEnemyAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        SpawnEnemy(); 
    }
}
