using Utility;

public class PlayerIdleState : State
{
    private IPlayerIdleAction idleAction;
    private IPlayerAnimatorAction animatorAction;

    public override void OnAwake()
    {
        GetInstance();
    }

    public override void OnEnter()
    {
        idleAction.ResetMoveVelocity();
        idleAction.ResetCurrentMoveTime();
        animatorAction.ResetMoveSpeed();
    }

    public override void OnUpdate()
    {
        animatorAction.UpdateMoveSpeed();
    }

    public override void OnFixedUpdate()
    {
        idleAction.TransitionToMoveStateOnInput();
    }

    /// <summary>
    /// �T�[�r�X���P�[�^�[����C���X�^���X���擾����
    /// </summary>
    private void GetInstance()
    {
        idleAction = ServiceLocator.GetInstance<IPlayerIdleAction>();
        animatorAction = ServiceLocator.GetInstance<IPlayerAnimatorAction>();
    }
}
