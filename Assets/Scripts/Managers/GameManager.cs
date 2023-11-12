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

    public Action BeginEvent;
    public Action StartEvent;
    public Action GameplayEvent;
    public Action PauseEvent;
    public Action FinishEvent;

    public void SelectPlayer(int index)
    {
        selectedPlayer = gameResources.characterList.characters[index];
        InstantiatePlayer(selectedPlayer, playerSpawnPoint);
        UpdateGameState(GameState.STARTED);
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
}

public enum GameState
{
    BEGIN,
    STARTED,
    PLAYING,
    PAUSED,
    FINISHED
}
