using Utility;
using UnityEngine;

public class PlayerIdlePresenter : MonoBehaviour, IPlayerIdleAction
{
    [SerializeField] private Rigidbody myRigidbody;

    private PlayerIdleAction idleAction;
    private PlayerMoveState moveState;
    private IStateAnyTransitionable stateAnyTransitionable;
    private IPlayerMoveParameter moveParameter;
    private IPlayerInputParameter inputParameter;

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
        ServiceLocator.Register<IPlayerIdleAction>(this);
    }

    /// <summary>
    /// サービスロケーターからインスタンスを取得する 
    /// </summary>
    private void GetInstance()
    {
        idleAction = ServiceLocator.GetInstance<PlayerIdleAction>();
        moveState = ServiceLocator.GetInstance<PlayerMoveState>();
        stateAnyTransitionable = GetComponentInParent<IStateAnyTransitionable>();
        inputParameter = ServiceLocator.GetInstance<IPlayerInputParameter>();
        moveParameter = ServiceLocator.GetInstance<IPlayerMoveParameter>();
    }

    void IPlayerIdleAction.ResetMoveVelocity()
    {
        idleAction.MoveStop(moveParameter.CurrentMoveTime, moveParameter.ResetMoveTimeThreshold, moveParameter.StopMoveVelocityResetTime, myRigidbody, moveParameter.ResetCurrentMoveTime);
    }

    void IPlayerIdleAction.TransitionToMoveStateOnInput()
    {
        idleAction.TransitionToMoveStateOnInput(inputParameter.IsMoveInputAction, stateAnyTransitionable.AnyTransition, moveState);
    }

    void IPlayerIdleAction.ResetCurrentMoveTime()
    {
        moveParameter.ResetCurrentMoveTime();
    }
}
