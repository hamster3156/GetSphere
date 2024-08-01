using System;
using Utility;
using UnityEngine;

public class PlayerMoveAction 
{
    /// <summary>
    /// ˆÚ“®“ü—Í‚ª‚ ‚é‚ÉVelocity‚ğ•ÏX‚·‚é
    /// </summary>
    public void ChangeMoveVelocityOnMoveInput(bool isMoveAction, Rigidbody rigidbody, Vector3 cameraMoveDirection, float moveSpeed)
    {
        if (isMoveAction)
        {
            RigidbodyManager.MoveVelocity(rigidbody, cameraMoveDirection, moveSpeed);
        }
    }

    /// <summary>
    /// ˆÚ“®“ü—Í‚ª–³‚­‚È‚Á‚½‚ÉIdleState‚É‘JˆÚ‚·‚é
    /// </summary>
    public void TransitioToIdleStateNoInput(bool isMoveAction, Action<State> stateAnyTransitionable, State idleState)
    {
        if (!isMoveAction)
        {
            stateAnyTransitionable(idleState);
        }
    }
}