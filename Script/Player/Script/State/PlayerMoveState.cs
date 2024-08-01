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
    /// サービスロケーターからインスタンスを取得する
    /// </summary>
    private void GetInstance()
    {
        moveAction = ServiceLocator.GetInstance<IPlayerMoveAction>();
        rotateAction = ServiceLocator.GetInstance<IPlayerRotateAction>();
        animatorAction = ServiceLocator.GetInstance<IPlayerAnimatorAction>();
    }
}
