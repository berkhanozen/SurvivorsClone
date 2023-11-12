using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public float health;
    public float moveSpeed;
    public WeaponDataSO startingWeapon;
}

public class PlayerStats
{
    public float health;
    public float moveSpeed;
    public WeaponDataSO startingWeapon;

    public PlayerStats(float health, float moveSpeed, WeaponDataSO startingWeapon)
    {
        this.health = health;
        this.moveSpeed = moveSpeed;
        this.startingWeapon = startingWeapon;
    }
}