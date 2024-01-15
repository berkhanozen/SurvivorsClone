using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public Action<float> ExperienceChangeHandler;

    float xp = 0;

    float totalXp = 0;

    float maxExp = 100;

    int level = 1;

    public Slider levelSlider;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI xpText;

    public void UpdateLevelSlider(float enemyStats)
    {
        ComputeXP(enemyStats);
    }

    void ComputeXP(float enemyStats)
    {
        xp += enemyStats;
        levelSlider.value = (xp / maxExp);
        xpText.text = xp + " / " + maxExp;
        totalXp += xp;
        if (xp >= maxExp)
        {
            level++;
            xp = xp - maxExp;
            maxExp *= 0.2f;
            levelSlider.value = (xp / maxExp);
            xpText.text = xp + " / " + maxExp;
            levelText.text = "Level " + level;
            
        }
    }

    public int GetLevel
    {
        get
        {
            return level;
        }
    }
}
