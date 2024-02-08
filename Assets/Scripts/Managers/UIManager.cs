using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    public GameObject characterOptionMenu;
    public GameObject pauseMenu;

    public Slider levelSlider;
    public GameObject decideSkillCanvas;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;

    private void Start()
    {
        GameManager.Instance.BeginEvent += OnBegin;
        GameManager.Instance.StartEvent += OnStart;
        GameManager.Instance.GameplayEvent += OnGameplay;
        GameManager.Instance.PauseEvent += OnPause;
        GameManager.Instance.LevelUpEvent += OnLevelUp;
        GameManager.Instance.LevelChangeEvent += OnLevelChange;
    }

    void OnBegin()
    {
        characterOptionMenu.SetActive(true);
    }

    void OnStart()
    {
        characterOptionMenu.SetActive(false);
    }

    void OnGameplay()
    {
        pauseMenu.SetActive(false);
        decideSkillCanvas.SetActive(false);
    }

    void OnPause()
    {
        pauseMenu.SetActive(true);
    }

    void OnLevelUp()
    {
        decideSkillCanvas.SetActive(true);
    }

    void OnLevelChange(int index)
    {
        decideSkillCanvas.SetActive(false);
    }
}
