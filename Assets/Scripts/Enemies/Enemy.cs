using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Action<float> HitEvent;

    public EnemyStats enemyStats;

    public GameObject player;

    void Start()
    {
        HitEvent += OnHit;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnHit(float hitDamage)
    {
        enemyStats.health -= hitDamage;
    }

    public virtual void SetEnemyData(EnemyDataSO enemyData)
    {
        enemyStats = new EnemyStats(enemyData.enemyStats.moveSpeed, enemyData.enemyStats.health, enemyData.enemyStats.hitDamage);
    }
}
