using UnityEngine;
using Utility;

public class PlayerRotateParameter : MonoBehaviour, IPlayerRotateParameter
{
    [Header("��]���x")]
    [SerializeField] private float rotateSpeed = 0.1f;

    float IPlayerRotateParameter.RotateSpeed => rotateSpeed;

    private void Awake()
    {
        Register();
    }

    /// <summary>
    /// �T�[�r�X���P�[�^�[�ɃC���X�^���X��o�^����
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerRotateParameter>(this);   
    }
}
