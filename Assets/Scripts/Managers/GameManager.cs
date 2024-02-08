using Cinemachine;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState currentState = GameState.STARTED;

    public GameResources gameResources;

    public Transform projectilePool;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    Vector3 playerSpawnPoint = new Vector3(0, 0, 0);

    GameObject selectedPlayer;
    int selectedSkill;

    public Action BeginEvent;
    public Action StartEvent;
    public Action GameplayEvent;
    public Action PauseEvent;
    public Action FinishEvent;
    public Action LevelUpEvent;
    public Action<int> LevelChangeEvent;

    public void SelectPlayer(int index)
    {
        selectedPlayer = gameResources.characterList.characters[index];
        InstantiatePlayer(selectedPlayer, playerSpawnPoint);
        UpdateGameState(GameState.STARTED);
    }

    public void SelectSkill(int index)
    {
        selectedSkill = index;
        UpdateGameState(GameState.LEVELCHANGE);
    }

    void InstantiatePlayer(GameObject player, Vector3 spawnPoint)
    {
        GameObject newPlayer = Instantiate(player, spawnPoint, Quaternion.identity);
        newPlayer.name = "Player";
        virtualCamera.Follow = newPlayer.transform;
    }

    private void Start()
    {
        UpdateGameState(currentState);

        LevelUpEvent += OnLevelUo;
        GameplayEvent += OnGameplay;
        PauseEvent += OnPause;
    }

    public void UpdateGameState(GameState newState)
    {
        if (currentState == GameState.BEGIN && (newState == GameState.PLAYING || newState == GameState.PAUSED))
            return;
        
        currentState = newState;

        switch(currentState)
        {
            case GameState.BEGIN:
                HandleBegin();
                break;
            case GameState.STARTED:
                HandleStart();
                break;
            case GameState.PLAYING:
                HandleGameplay();
                break;
            case GameState.PAUSED:
                HandlePause();
                break;
            case GameState.FINISHED:
                HandleFinish();
                break;
            case GameState.LEVELUP:
                HandleLevelUp();
                break;
            case GameState.LEVELCHANGE:
                HandleLevelChange();
                break;
        }
    }

    private void Update()
    {
        Debug.Log(currentState);
    }

    void HandleBegin()
    {
        BeginEvent?.Invoke();
    }

    void HandleStart()
    {
        StartEvent?.Invoke();
        UpdateGameState(GameState.PLAYING);
    }

    void HandleGameplay()
    {
        GameplayEvent?.Invoke();
    }

    void HandlePause()
    {
        PauseEvent?.Invoke();
    }

    void HandleFinish()
    {
        FinishEvent?.Invoke();
    }

    void HandleLevelUp()
    {
        LevelUpEvent?.Invoke();
    }

    void HandleLevelChange()
    {
        LevelChangeEvent?.Invoke(selectedSkill);
    }
    

    void OnPause()
    {
        Time.timeScale = 0;
    }

    void OnLevelUo()
    {
        Time.timeScale = 0;
    }

    void OnGameplay()
    {
        Time.timeScale = 1;
    }
}


public enum GameState
{
    BEGIN,
    STARTED,
    PLAYING,
    PAUSED,
    FINISHED,
    LEVELUP,
    LEVELCHANGE
}
