using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponScriptable> weapons = new List<WeaponScriptable>();
    [SerializeField] private List<GameObject> weaponPrefabs = new List<GameObject>();
    [SerializeField] private WeaponScriptable weapon;
    [SerializeField] private int weaponID = 0;
    [SerializeField] private GunShooting shooter;

    [SerializeField] private GameObject weaponPanel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shooter = weaponPrefabs[weaponID].GetComponent<GunShooting>();
        weapon = shooter.weapon;
        weaponID = weapons.IndexOf(weapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PanelFlip();
        }
    }

    public void PanelFlip()
    {
        if (weaponPanel.activeSelf)
        {
            weaponPanel.SetActive(false);
            //shooter.gameObject.SetActive(!shooter.gameObject.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            weaponPanel.SetActive(!weaponPanel.activeSelf); // Flip between on and off
            //shooter.gameObject.SetActive(!shooter.gameObject.activeSelf);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void SwitchWeapon(int id)
    {
        shooter.WeaponSwitched();
        weaponPrefabs[weaponID].SetActive(false);
        weaponID = id;
        weapon = weapons[id];
        weaponPrefabs[weaponID].SetActive(true);
        shooter = weaponPrefabs[weaponID].GetComponent<GunShooting>();
        shooter.weapon = weapon;
        PanelFlip();
    }
}
