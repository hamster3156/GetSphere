public interface IPlayerMoveAction
{
    /// <summary>
    /// �ړ����͂����鎞�Ɉړ����x��ύX����
    /// </summary>
    void ChangeMoveVelocityOnMoveInput();

    /// <summary>
    /// �ړ����͂��~�܂�������Idle�X�e�[�g�ɕύX����
    /// </summary>
    void TransitioToIdleStateNoInput();

    /// <summary>
    /// �ړ����Ԃ𑝂₷
    /// </summary>
    void UpCurrentMoveTime();
}
