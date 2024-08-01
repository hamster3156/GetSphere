using UnityEngine;

public class PlayerAnimatorAction 
{
    /// <summary>
    /// ˆÚ“®‘¬“x‚ğXV‚·‚é
    /// </summary>
    public void UpdateMoveSpeed(Animator animator, string moveSpeedName, float moveSpeed, float moveSpeedSlowDownTime)
    {
        animator.SetFloat(moveSpeedName, moveSpeed, moveSpeedSlowDownTime, Time.deltaTime);
    }
}
