using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{

    public GameObject characterOptionMenu;
    public GameObject pauseMenu;

    private void Start()
    {
        GameManager.Instance.BeginEvent += OnBegin;
        GameManager.Instance.StartEvent += OnStart;
        GameManager.Instance.GameplayEvent += OnGameplay;
        GameManager.Instance.PauseEvent += OnPause;
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
    }

    void OnPause()
    {
        pauseMenu.SetActive(true);
    }
}
