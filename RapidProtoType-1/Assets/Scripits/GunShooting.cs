using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public float range = 100f;
    RaycastHit hit;

    public Camera shootingPoint;
    public AudioSource shootAudio;
    public GameObject muzzleFlash;
    public Transform muzzlePossition;

    Enemy enemy;
    public AudioSource enmeyAudio;
    public AudioSource metalAudio;

    public WeaponScriptable weapon;
    [SerializeField] private int currentMagazine = 1;
    [SerializeField] private bool isFireable = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFireable)
        {
            if (weapon.isAutomatic)
            {
                if (Input.GetButton("Fire1"))
                {
                    Fire();
                }
            }
            else 
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Fire();
                }
            }
        }
    }

    void Fire()
    {
        //isFireable = false;
        currentMagazine--;
        if (currentMagazine < 0)
        {
            StartCoroutine(Reload());
            return;
        }

        // Muzlle Flash
        GameObject muzzleFlashInstance = Instantiate(muzzleFlash, muzzlePossition.position, muzzlePossition.rotation);  
        Destroy(muzzleFlashInstance, 0.1f);

        // Shoot SFX
        PlayShootSound();

        // Bullet hitting something
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

                    PlayEnemySound();
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
                    bullsEyes.Hit(hit.point);

                    PlayMetalSound();

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

        // Fire rate delay
        StartCoroutine(Reload());

        #region SFX
        void PlayShootSound()
        {
            if (shootAudio != null)
            {
                shootAudio.Play();
            }
        }

        void PlayEnemySound()
        {
            if (enmeyAudio != null)
            {
                enmeyAudio.Play();
            }
        }

        void PlayMetalSound()
        {
            if (metalAudio != null)
            {
                metalAudio.Play();
            }
        } 
        #endregion
    }

    public void WeaponSwitched()
    {
        StopAllCoroutines();
        isFireable = true;
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(weapon.ReloadTime);
        currentMagazine = weapon.MagazineCapacity;
        isFireable = true;
    }
}
