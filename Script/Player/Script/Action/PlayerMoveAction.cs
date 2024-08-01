using System;
using Utility;
using UnityEngine;

public class PlayerMoveAction 
{
    /// <summary>
    /// �ړ����͂����鎞��Velocity��ύX����
    /// </summary>
    public void ChangeMoveVelocityOnMoveInput(bool isMoveAction, Rigidbody rigidbody, Vector3 cameraMoveDirection, float moveSpeed)
    {
        if (isMoveAction)
        {
            RigidbodyManager.MoveVelocity(rigidbody, cameraMoveDirection, moveSpeed);
        }
    }

    /// <summary>
    /// �ړ����͂������Ȃ�������IdleState�ɑJ�ڂ���
    /// </summary>
    public void TransitioToIdleStateNoInput(bool isMoveAction, Action<State> stateAnyTransitionable, State idleState)
    {
        if (!isMoveAction)
        {
            stateAnyTransitionable(idleState);
        }
    }
}