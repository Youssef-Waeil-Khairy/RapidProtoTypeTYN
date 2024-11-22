using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloon : MonoBehaviour
{
    [SerializeField] GameObject balloon;

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        GameObject spawnBalloon = Instantiate(balloon, gameObject.transform.position, Quaternion.identity);
    }
}