using System;
using Utility;
using UnityEngine;

public class PlayerMoveAction 
{
    /// <summary>
    /// 移動入力がある時にVelocityを変更する
    /// </summary>
    public void ChangeMoveVelocityOnMoveInput(bool isMoveAction, Rigidbody rigidbody, Vector3 cameraMoveDirection, float moveSpeed)
    {
        if (isMoveAction)
        {
            RigidbodyManager.MoveVelocity(rigidbody, cameraMoveDirection, moveSpeed);
        }
    }

    /// <summary>
    /// 移動入力が無くなった時にIdleStateに遷移する
    /// </summary>
    public void TransitioToIdleStateNoInput(bool isMoveAction, Action<State> stateAnyTransitionable, State idleState)
    {
        if (!isMoveAction)
        {
            stateAnyTransitionable(idleState);
        }
    }
}