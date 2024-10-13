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
        
         if(Physics.Raycast(shootingPoint.transform.position, shootingPoint.transform.forward, out hit, range)) 
         {
         
            if (hit.transform.CompareTag("enemy"))
            {
                enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null) 
                {
                    enemy.Die();
                }
            }
            
         }
       
    }
}
