using UnityEngine;
using Utility;

public class PlayerRotatePresenter : MonoBehaviour, IPlayerRotateAction
{
    [SerializeField] private Transform myTransform;
    private PlayerRotateAction rotateAction;
    private IPlayerInputParameter inputParameter;
    private IPlayerRotateParameter rotateParameter;

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
        ServiceLocator.Register<IPlayerRotateAction>(this);
    }

    /// <summary>
    /// サービスロケーターからインスタンスを取得する
    /// </summary>
    private void GetInstance()
    {
        rotateAction = ServiceLocator.GetInstance<PlayerRotateAction>();
        inputParameter = ServiceLocator.GetInstance<IPlayerInputParameter>();
        rotateParameter = ServiceLocator.GetInstance<IPlayerRotateParameter>();
    }

    void IPlayerRotateAction.UpdateInputDirectionRotate()
    {
        rotateAction.UpdateInputDirectionRotate(inputParameter.MoveDirctionInput, myTransform, rotateParameter.RotateSpeed);
    }
}
