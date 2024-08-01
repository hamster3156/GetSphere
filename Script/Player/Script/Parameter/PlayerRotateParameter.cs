using UnityEngine;
using Utility;

public class PlayerRotateParameter : MonoBehaviour, IPlayerRotateParameter
{
    [Header("回転速度")]
    [SerializeField] private float rotateSpeed = 0.1f;

    float IPlayerRotateParameter.RotateSpeed => rotateSpeed;

    private void Awake()
    {
        Register();
    }

    /// <summary>
    /// サービスロケーターにインスタンスを登録する
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerRotateParameter>(this);   
    }
}
