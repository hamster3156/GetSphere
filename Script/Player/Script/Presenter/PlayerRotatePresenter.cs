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
    /// �T�[�r�X���P�[�^�[�ɃC���X�^���X��o�^����
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerRotateAction>(this);
    }

    /// <summary>
    /// �T�[�r�X���P�[�^�[����C���X�^���X���擾����
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
