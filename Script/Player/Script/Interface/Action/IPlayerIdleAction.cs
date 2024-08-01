public interface IPlayerIdleAction
{
    /// <summary>
    /// �X�e�[�g�̊J�n���Ɉړ����x�����Z�b�g����
    /// </summary>
    void ResetMoveVelocity();

    /// <summary>
    /// �ړ����͂�����Έړ��X�e�[�g�ɑJ�ڂ���
    /// </summary>
    void TransitionToMoveStateOnInput();

    /// <summary>
    /// �ړ����Ԃ����Z�b�g����
    /// </summary>
    void ResetCurrentMoveTime();
}
