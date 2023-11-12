using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerData;

    public PlayerStats playerStats;

    private void Awake()
    {
        playerStats = new PlayerStats(playerData.health, playerData.moveSpeed, playerData.startingWeapon);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playerStats.health -= collision.GetComponentInChildren<Enemy>().enemyStats.hitDamage;
        }
    }
}


