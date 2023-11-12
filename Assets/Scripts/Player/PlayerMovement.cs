using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;

    public Action<Vector2> MoveEvent;

    private void OnEnable()
    {
        MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        MoveEvent -= OnMove;
    }

    private void Update()
    {
        MoveEvent.Invoke(InputManager.Instance.moveDirection);
    }

    private void OnMove(Vector2 moveDirection)
    {
        this.moveDirection = moveDirection;

        Move();
    }

    private void Move()
    {
        transform.Translate((Vector2.up + Vector2.right) * GetComponent<Player>().playerStats.moveSpeed * moveDirection * Time.deltaTime);
    }

}
