using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public float range = 100f;

    public Camera shootingPoint;

    RaycastHit hit;

    Enemy enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {

        if (Physics.Raycast(shootingPoint.transform.position, shootingPoint.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.transform.CompareTag("enemy"))
            {
                enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Debug.Log("Enemy found! Calling Die method.");
                    enemy.Die();
                }
                else
                {
                    Debug.Log("Enemy component not found.");
                }
            }
            else
            {
                Debug.Log("Hit object is not an enemy.");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }

    }
}
