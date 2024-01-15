using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public string Name;
    public EnemyStats enemyStats;
    public GameObject enemyPrefab;
}

[Serializable]
public class EnemyStats
{
    public float moveSpeed;
    public float health;
    public float hitDamage;
    public float onDeathXP;

    public EnemyStats(float moveSpeed, float health, float hitDamage, float onDeathXP)
    {
        this.moveSpeed = moveSpeed;
        this.health = health;
        this.hitDamage = hitDamage;
        this.onDeathXP = onDeathXP;
    }
}
