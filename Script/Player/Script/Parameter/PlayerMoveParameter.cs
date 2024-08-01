using UnityEngine;
using Utility;

public class PlayerMoveParameter : MonoBehaviour, IPlayerMoveParameter
{
    [Header("移動速度")]
    [SerializeField] private float moveSpeed = 8;

    [Header("移動時間のリセットする閾値")]
    [SerializeField] private float resetMoveTimeThreshold = 1;

    [Header("移動時間の上昇値")]
    [SerializeField] private float upMoveTime = 0.05f;

    [Header("止まった時に移動速度がリセットされるまでの時間")]
    [SerializeField] private float stopMoveVelocityResetTime = 0.5f;

    private float currentMoveTime = 0;

    float IPlayerMoveParameter.MoveSpeed => moveSpeed;
    float IPlayerMoveParameter.ResetMoveTimeThreshold => resetMoveTimeThreshold;
    float IPlayerMoveParameter.UpMoveTime => upMoveTime;
    float IPlayerMoveParameter.StopMoveVelocityResetTime => stopMoveVelocityResetTime;
    float IPlayerMoveParameter.CurrentMoveTime => currentMoveTime;

    private void Awake()
    {
        Register();
    }

    /// <summary>
    /// サービスロケーターにインスタンスを登録する
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerMoveParameter>(this);
    }

    void IPlayerMoveParameter.ResetCurrentMoveTime()
    {
        currentMoveTime = 0;
    }

    void IPlayerMoveParameter.UpMoveCurrentMoveTime()
    {
        currentMoveTime += upMoveTime;
    }
}
