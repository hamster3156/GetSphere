using System;
using UnityEngine;
using Utility;

public class PlayerIdleAction 
{
    /// <summary>
    /// �ړ�����߂�B�ړ����Ԃ������ꍇ�A�ړ����~�߂�܂łɏ������Ԃ�������
    /// </summary>
    public async void MoveStop(float currentMoveTime, float resetMoveTimeThreshold, float stopMoveVelocityResetTime, Rigidbody rigidbody, Action ResetCurrentMoveTime)
    {
        // �ړ����Ԃ������ꍇ�A�ړ����x�̃��Z�b�g�܂Œx��������
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
    /// �ړ����͂�����������MoveState�ɕύX����
    /// </summary>
    public void TransitionToMoveStateOnInput(bool isMoveAction, Action<State> AnyTransitionable, State moveState)
    {
        if (isMoveAction)
        {
            AnyTransitionable(moveState);
        }
    }
}
