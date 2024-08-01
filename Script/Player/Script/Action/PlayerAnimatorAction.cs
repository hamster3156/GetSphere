using UnityEngine;

public class PlayerAnimatorAction 
{
    /// <summary>
    /// 移動速度を更新する
    /// </summary>
    public void UpdateMoveSpeed(Animator animator, string moveSpeedName, float moveSpeed, float moveSpeedSlowDownTime)
    {
        animator.SetFloat(moveSpeedName, moveSpeed, moveSpeedSlowDownTime, Time.deltaTime);
    }
}
