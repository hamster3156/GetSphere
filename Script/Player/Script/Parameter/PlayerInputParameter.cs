using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

public class PlayerInputParameter : MonoBehaviour, IPlayerInputParameter
{
    [SerializeField] private PlayerInput playerInput;

    [Header("���̓A�N�V�����̏���������")]
    [SerializeField] private float inputActionInitializeTime = 0.01f;
    
    private Vector3 moveDirectionInput = Vector3.zero;
    private bool isMoveInputAction = false;

    PlayerInput IPlayerInputParameter.PlayerInput => playerInput;
    Vector3 IPlayerInputParameter.MoveDirctionInput => moveDirectionInput;
    bool IPlayerInputParameter.IsMoveInputAction => isMoveInputAction;

    // PlayerInput��Move�ɐݒ肷�郁�\�b�h�B�ړ����͂̍X�V���s�������B
    public void OnMoveInputAction(InputAction.CallbackContext inputActionCallbackContext)
    {
        if (inputActionCallbackContext.performed)
        {
            var inputDirection = inputActionCallbackContext.ReadValue<Vector2>();
            moveDirectionInput = new Vector3(inputDirection.x, 0, inputDirection.y).normalized;
            isMoveInputAction = true;
        }
        else
        {
            moveDirectionInput = Vector3.zero;
            isMoveInputAction = false;
        }
    }

    private void Awake()
    {
        Register();
    }

    /// <summary>
    /// �T�[�r�X���P�[�^�[�ɃC���X�^���X��o�^����
    /// </summary>
    private void Register()
    {
        ServiceLocator.Register<IPlayerInputParameter>(this);
    }
}
