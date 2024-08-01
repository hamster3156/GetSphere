using UnityEngine;
using Utility;

public class PlayerAnimatorParameter : MonoBehaviour, IPlayerAnimatorParameter
{
    [Header("移動速度の減少時間")]
    [SerializeField] private float moveSpeedSlowDownTime = 0.35f;

    private string moveSpeedName = "MoveSpeed";
    private float moveSpeed;

    float IPlayerAnimatorParameter.MoveSpeed => moveSpeed;
    float IPlayerAnimatorParameter.MoveSpeedSlowDownTime => moveSpeedSlowDownTime;
    string IPlayerAnimatorParameter.MoveSpeedName => moveSpeedName;

    private void Awake()
    {
       Register();
    }

    /// <summary>
    /// サービスロケーターにインスタンスを登録する
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerAnimatorParameter>(this);
    }

    void IPlayerAnimatorParameter.ChangeMoveSpeed(float changeMoveSpeed)
    {
        moveSpeed = changeMoveSpeed;
    }
}
