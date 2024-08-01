using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerInputParameter 
{
    /// <summary>
    /// ���͐ݒ�̗L���△����ݒ�ł���
    /// </summary>
    public PlayerInput PlayerInput { get; } 

    /// <summary>
    /// �ړ���������
    /// </summary>
    public Vector3 MoveDirctionInput { get; }

    /// <summary>
    /// �ړ����̓A�N�V�����t���O
    /// </summary>
    public bool IsMoveInputAction { get; }
}
