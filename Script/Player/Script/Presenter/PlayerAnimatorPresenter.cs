using UnityEngine;
using Utility;

public class PlayerAnimatorPresenter : MonoBehaviour, IPlayerAnimatorAction
{
    [SerializeField] private Animator animator;

    private PlayerAnimatorAction animatorAction;
    private IPlayerAnimatorParameter animatorParameter;
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
        ServiceLocator.Register<IPlayerAnimatorAction>(this);
    }

    /// <summary>
    /// サービスロケーターからインスタンスを取得する
    /// </summary>
    private void GetInstance()
    {
        animatorAction = ServiceLocator.GetInstance<PlayerAnimatorAction>();
        animatorParameter = ServiceLocator.GetInstance<IPlayerAnimatorParameter>();
        moveParameter = ServiceLocator.GetInstance<IPlayerMoveParameter>();
    }

    void IPlayerAnimatorAction.UpdateMoveSpeed()
    {
        animatorAction.UpdateMoveSpeed(animator, animatorParameter.MoveSpeedName, 
            animatorParameter.MoveSpeed, animatorParameter.MoveSpeedSlowDownTime);
    }

    void IPlayerAnimatorAction.ChangeMoveSpeed()
    {
        animatorParameter.ChangeMoveSpeed(moveParameter.MoveSpeed);
    }

    void IPlayerAnimatorAction.ResetMoveSpeed()
    {
        animatorParameter.ChangeMoveSpeed(0);
    }
}
