using Utility;
using UnityEngine;

public class PlayerMovePresenter : MonoBehaviour, IPlayerMoveAction
{
    [SerializeField] private Rigidbody myRigidbody; 

    private PlayerMoveAction moveAction;
    private PlayerRotateAction rotateAction;
    private PlayerIdleState idleState;
    private IStateAnyTransitionable stateAnyTransitionable;
    private IPlayerInputParameter inputParameter;
    private IPlayerMoveParameter moveParameter;

    private void Start()
    {
        Register();
        GetInstance();
    }

    /// <summary>
    /// サービスロケーターにインスタンスを登録する
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerMoveAction>(this);
    }
        
    /// <summary>
    /// サービスロケーターからインスタンスを取得する
    /// </summary>
    private void GetInstance()
    {
        moveAction = ServiceLocator.GetInstance<PlayerMoveAction>();
        rotateAction = ServiceLocator.GetInstance<PlayerRotateAction>();
        idleState = ServiceLocator.GetInstance<PlayerIdleState>();
        stateAnyTransitionable = GetComponentInParent<IStateAnyTransitionable>();
        inputParameter = ServiceLocator.GetInstance<IPlayerInputParameter>();
        moveParameter = ServiceLocator.GetInstance<IPlayerMoveParameter>();
    }

    void IPlayerMoveAction.ChangeMoveVelocityOnMoveInput()
    {
        moveAction.ChangeMoveVelocityOnMoveInput(inputParameter.IsMoveInputAction, myRigidbody,
        rotateAction.UpdateCameraMoveDirection(inputParameter.MoveDirctionInput), moveParameter.MoveSpeed);
    }

    void IPlayerMoveAction.TransitioToIdleStateNoInput()
    {
        moveAction.TransitioToIdleStateNoInput(inputParameter.IsMoveInputAction, stateAnyTransitionable.AnyTransition, idleState);
    }

    void IPlayerMoveAction.UpCurrentMoveTime()
    {
        moveParameter.UpMoveCurrentMoveTime();
    }
}
