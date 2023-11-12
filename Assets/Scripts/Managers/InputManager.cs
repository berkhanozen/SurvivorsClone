using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class InputManager : Singleton<InputManager>, InputActions.IPlayerActions, InputActions.IUIActions
{
    private InputActions inputActions;

    [HideInInspector] public Vector2 moveDirection;

    private void Start()
    {
        GameManager.Instance.BeginEvent += SetPause;
        GameManager.Instance.GameplayEvent += SetGameplay;
        GameManager.Instance.PauseEvent += SetPause;
        GameManager.Instance.FinishEvent += SetPause;

        if (inputActions == null)
        {
            inputActions = new InputActions();
            inputActions.Enable();
            inputActions.Player.SetCallbacks(this);
            inputActions.UI.SetCallbacks(this);
        }

        if (GameManager.Instance.currentState == GameState.PLAYING)
            SetGameplay();
        else
            SetPause();
    }

    void SetGameplay()
    {
        inputActions.Player.Enable();
        inputActions.UI.Disable();
    }

    void SetPause()
    {
        inputActions.Player.Disable();
        inputActions.UI.Enable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            GameManager.Instance.UpdateGameState(GameState.PAUSED);
        }
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            GameManager.Instance.UpdateGameState(GameState.PLAYING);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            GameManager.Instance.UpdateGameState(GameState.BEGIN);
        }
    }
}
