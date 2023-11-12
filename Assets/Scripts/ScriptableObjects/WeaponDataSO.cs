using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public float hitDamage;
    public float cooldown;
    public float projectileSpeed;

    public WeaponStats(float hitDamage, float cooldown, float projectileSpeed)
    {
        this.hitDamage = hitDamage;
        this.cooldown = cooldown;
        this.projectileSpeed = projectileSpeed;
    }
}

[CreateAssetMenu(menuName = "WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
}
