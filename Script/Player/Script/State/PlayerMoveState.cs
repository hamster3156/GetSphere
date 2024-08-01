using Utility;

public class PlayerMoveState : State
{
    private IPlayerMoveAction moveAction;
    private IPlayerRotateAction rotateAction;
    private IPlayerAnimatorAction animatorAction;

    public override void OnAwake()
    {
        GetInstance();
    }

    public override void OnEnter()
    {
        animatorAction.ChangeMoveSpeed();
    }

    public override void OnUpdate()
    {
        animatorAction.UpdateMoveSpeed();
    }

    public override void OnFixedUpdate()
    {
        moveAction.ChangeMoveVelocityOnMoveInput();
        moveAction.TransitioToIdleStateNoInput();
        moveAction.UpCurrentMoveTime();
        rotateAction.UpdateInputDirectionRotate();
    }

    /// <summary>
    /// �T�[�r�X���P�[�^�[����C���X�^���X���擾����
    /// </summary>
    private void GetInstance()
    {
        moveAction = ServiceLocator.GetInstance<IPlayerMoveAction>();
        rotateAction = ServiceLocator.GetInstance<IPlayerRotateAction>();
        animatorAction = ServiceLocator.GetInstance<IPlayerAnimatorAction>();
    }
}
