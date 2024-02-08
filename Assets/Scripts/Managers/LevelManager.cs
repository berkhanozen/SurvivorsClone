using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public Action<float> ExperienceChangeHandler;
    //public Action<int> LevelUpHandler;

    float xp = 0;
    float totalXp = 0;
    float maxExp = 100;
    int level = 1;

    private void Start()
    {
        //LevelUpHandler += OnLevelUpHandler;
        GameManager.Instance.LevelUpEvent += OnLevelUpHandler;
    }

    private void OnLevelUpHandler()
    {
        LevelUp();
    }

    public void UpdateLevelSlider(float enemyStats)
    {
        ComputeXP(enemyStats);
    }

    void ComputeXP(float enemyStats)
    {
        xp += enemyStats;
        UIManager.Instance.levelSlider.value = (xp / maxExp);
        //xpText.text = xp + " / " + maxExp;
        totalXp += xp;
        if (xp >= maxExp)
        {
            GameManager.Instance.UpdateGameState(GameState.LEVELUP);
        }
    }

    void LevelUp()
    {
        level++;
        xp = xp - maxExp;
        maxExp *= 2;
        UIManager.Instance.levelSlider.value = (xp / maxExp);
        //xpText.text = xp + " / " + maxExp;
        UIManager.Instance.levelText.text = "Level " + level;
    }

    public int GetLevel
    {
        get
        {
            return level;
        }
    }
}
