using UnityEngine;
using Utility;

public class PlayerAnimatorParameter : MonoBehaviour, IPlayerAnimatorParameter
{
    [Header("�ړ����x�̌�������")]
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
    /// �T�[�r�X���P�[�^�[�ɃC���X�^���X��o�^����
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
