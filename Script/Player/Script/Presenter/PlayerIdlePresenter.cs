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
    /// �T�[�r�X���P�[�^�[�ɃC���X�^���X��o�^���� 
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerIdleAction>(this);
    }

    /// <summary>
    /// �T�[�r�X���P�[�^�[����C���X�^���X���擾���� 
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
