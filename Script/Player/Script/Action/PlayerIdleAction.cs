using System;
using UnityEngine;
using Utility;

public class PlayerIdleAction 
{
    /// <summary>
    /// 移動をやめる。移動時間が長い場合、移動を止めるまでに少し時間がかかる
    /// </summary>
    public async void MoveStop(float currentMoveTime, float resetMoveTimeThreshold, float stopMoveVelocityResetTime, Rigidbody rigidbody, Action ResetCurrentMoveTime)
    {
        // 移動時間が長い場合、移動速度のリセットまで遅延を入れる
        if (currentMoveTime > resetMoveTimeThreshold)
        {
            await AsyncDelayManager.DelayTimeAsync(stopMoveVelocityResetTime);
            RigidbodyManager.XZMoveVelocityReset(rigidbody);
            ResetCurrentMoveTime();
        }
        else
        {
            RigidbodyManager.XZMoveVelocityReset(rigidbody);
            ResetCurrentMoveTime();
        }
    }

    /// <summary>
    /// 移動入力があった時にMoveStateに変更する
    /// </summary>
    public void TransitionToMoveStateOnInput(bool isMoveAction, Action<State> AnyTransitionable, State moveState)
    {
        if (isMoveAction)
        {
            AnyTransitionable(moveState);
        }
    }
}
