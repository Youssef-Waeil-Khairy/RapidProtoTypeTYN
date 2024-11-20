using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "JW/Weapons", order = 0)]
public class WeaponScriptable : ScriptableObject
{
    public string Name = "Weapon Name";
    public int MagazineCapacity = 1;
    public float ReloadTime = 1f;
    public bool isAutomatic = false;
}
