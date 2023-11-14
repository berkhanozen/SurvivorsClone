using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Action<float> EnemyHitEvent;

    public EnemyStats enemyStats;

    public GameObject player;

    void Start()
    {
        EnemyHitEvent += OnEnemyHit;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPlayerHit(collision.GetComponent<Player>());
        }
    }

    void OnEnemyHit(float weaponHitDamage)
    {
        enemyStats.health -= weaponHitDamage;
    }

    void OnPlayerHit(Player player)
    {
        player.PlayerHitEvent.Invoke(enemyStats.hitDamage);
    }

    public virtual void SetEnemyData(EnemyDataSO enemyData)
    {
        enemyStats = new EnemyStats(enemyData.enemyStats.moveSpeed, enemyData.enemyStats.health, enemyData.enemyStats.hitDamage);
    }
}
