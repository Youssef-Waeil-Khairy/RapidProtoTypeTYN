using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponScriptable> weapons = new List<WeaponScriptable>();
    [SerializeField] private WeaponScriptable weapon;
    [SerializeField] private GunShooting shooter;

    [SerializeField] private GameObject weaponPanel;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<GunShooting>();
        weapon = shooter.weapon;
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
            shooter.gameObject.SetActive(!shooter.gameObject.activeSelf);
        }
        else
        {
            weaponPanel.SetActive(!weaponPanel.activeSelf); // Flip between on and off
            shooter.gameObject.SetActive(!shooter.gameObject.activeSelf);
        }
    }

    public void SwitchWeapon(int id)
    {
        if (id >= weapons.Count)
        {
            weapon = weapons[weapons.Count - 1];
        }
        else
        {
            weapon = weapons[id];
        }
        PanelFlip();
        shooter.weapon = weapon;
    }
}
