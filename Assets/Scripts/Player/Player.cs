using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerData;

    public PlayerStats playerStats;

    public Image healthBar;

    public Action<float> PlayerHitEvent;

    float maxHealth;

    private void Awake()
    {
        playerStats = new PlayerStats(playerData.health, playerData.moveSpeed, playerData.startingWeapon);
        maxHealth = playerStats.health;
    }

    private void Start()
    {
        PlayerHitEvent += OnPlayerHit;
    }

    public void OnPlayerHit(float enemyHitDamage)
    {
        playerStats.health -= enemyHitDamage;
        healthBar.fillAmount -= enemyHitDamage/maxHealth;
    }
}


