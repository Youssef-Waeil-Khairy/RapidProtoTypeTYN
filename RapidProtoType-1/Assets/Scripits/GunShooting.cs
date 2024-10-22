using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public float range = 100f;

    public Camera shootingPoint;

    RaycastHit hit;

    Enemy enemy;

    public GameObject muzzleFlash;

    public Transform muzzlePossition;

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
        GameObject muzzleFlashInstance = Instantiate(muzzleFlash, muzzlePossition.position, muzzlePossition.rotation);  

        
        Destroy(muzzleFlashInstance, 0.1f);


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
            else if (hit.transform.CompareTag("BullsEye"))
            {
                BullsEyes bullsEyes = hit.transform.GetComponent<BullsEyes>();
                if(bullsEyes != null)
                {
                    bullsEyes.Hit();
                }
                else
                {
                    Debug.Log("Not found");
                }
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }

    }
}
