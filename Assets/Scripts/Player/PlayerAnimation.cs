using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private Direction currentDir;
    private State currentState = State.IDLE;

    enum State
    {
        IDLE,
        RUN
    }

    enum Direction
    {
        UP,
        RIGHT,
        LEFT,
        UPRIGHT,
        UPLEFT,
        DOWN,
    }

    private void OnEnable()
    {
        GetComponent<PlayerMovement>().MoveEvent += OnAnimation;
    }

    private void OnDisable()
    {
        GetComponent<PlayerMovement>().MoveEvent -= OnAnimation;
    }


    private void Start()
    {
        currentDir = Direction.DOWN;

        anim = GetComponent<Animator>();
    }

    private void OnAnimation(Vector2 moveDirection)
    {
        InitializeAnim(currentDir);
        AnimationControl(moveDirection);
        AnimatePlayer(currentState, currentDir);
    }

    private void InitializeAnim(Direction direction)
    {
        currentDir = direction;

        anim.SetBool("isIdle", false);
        anim.SetBool("isRun", false);
        anim.SetBool("isUp", false);
        anim.SetBool("isUpRight", false);
        anim.SetBool("isUpLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isLeft", false);
        anim.SetBool("isDown", false);
    }

    public void AnimationControl(Vector2 moveDirection)
    {
        if(moveDirection == Vector2.zero)
        {
            currentState = State.IDLE;
        }
        else
        {
            currentState = State.RUN;

            if (moveDirection.x > 0)
            {
                if (moveDirection.y > 0)
                {
                    currentDir = Direction.UPRIGHT;
                }
                else
                {
                    currentDir = Direction.RIGHT;
                }
            }
            else if (moveDirection.x < 0)
            {
                if (moveDirection.y > 0)
                {
                    currentDir = Direction.UPLEFT;
                }
                else
                {
                    currentDir = Direction.LEFT;
                }
            }
            else
            {
                if (moveDirection.y > 0)
                {
                    currentDir = Direction.UP;
                }
                else
                {
                    currentDir = Direction.DOWN;
                }
            }
        }
    }

    private void AnimatePlayer(State state, Direction direction)
    {
        //STATE
        if(state == State.IDLE)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", true);
        }

        //DIRECTION
        if(direction == Direction.UP)
        {
            anim.SetBool("isUp", true);
        }
        else if (direction == Direction.UPRIGHT)
        {
            anim.SetBool("isUpRight", true);
        }
        else if (direction == Direction.UPLEFT)
        {
            anim.SetBool("isUpLeft", true);
        }
        else if (direction == Direction.RIGHT)
        {
            anim.SetBool("isRight", true);
        }
        else if (direction == Direction.LEFT)
        {
            anim.SetBool("isLeft", true);
        }
        else
        {
            anim.SetBool("isDown", true);
        }
    }
}
