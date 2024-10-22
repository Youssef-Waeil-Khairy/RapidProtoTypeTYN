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

            //Killables
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

                ScoreSystem.currentScore += 10;
            }


            //BullsEye
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
                ScoreSystem.currentScore += 10;
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }

    }
}
