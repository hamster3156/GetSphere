using UnityEngine;
using Utility;

public class PlayerMoveParameter : MonoBehaviour, IPlayerMoveParameter
{
    [Header("�ړ����x")]
    [SerializeField] private float moveSpeed = 8;

    [Header("�ړ����Ԃ̃��Z�b�g����臒l")]
    [SerializeField] private float resetMoveTimeThreshold = 1;

    [Header("�ړ����Ԃ̏㏸�l")]
    [SerializeField] private float upMoveTime = 0.05f;

    [Header("�~�܂������Ɉړ����x�����Z�b�g�����܂ł̎���")]
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
    /// �T�[�r�X���P�[�^�[�ɃC���X�^���X��o�^����
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
