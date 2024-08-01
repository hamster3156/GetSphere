using UnityEngine;

public class PlayerAnimatorAction 
{
    /// <summary>
    /// �ړ����x���X�V����
    /// </summary>
    public void UpdateMoveSpeed(Animator animator, string moveSpeedName, float moveSpeed, float moveSpeedSlowDownTime)
    {
        animator.SetFloat(moveSpeedName, moveSpeed, moveSpeedSlowDownTime, Time.deltaTime);
    }
}
