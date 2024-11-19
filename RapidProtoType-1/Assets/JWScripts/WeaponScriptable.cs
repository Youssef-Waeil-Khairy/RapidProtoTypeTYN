using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "JW/Weapons", order = 0)]
public class WeaponScriptable : ScriptableObject
{
    public string Name = "Weapon Name";
    public float FireRate = 1f;
}
