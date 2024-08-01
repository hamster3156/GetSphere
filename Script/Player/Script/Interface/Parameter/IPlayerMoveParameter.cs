public interface IPlayerMoveParameter
{
    /// <summary>
    /// �ړ����x
    /// </summary>
    public float MoveSpeed { get; }

    /// <summary>
    /// �ړ����Ԃ̃��Z�b�g����臒l
    /// </summary>
    public float ResetMoveTimeThreshold { get; }

    /// <summary>
    /// �ړ����Ԃ̏㏸�l
    /// </summary>
    public float UpMoveTime { get; }

    /// <summary>
    /// �~�܂������Ɉړ����x�����Z�b�g�����܂ł̎���
    /// </summary>
    public float StopMoveVelocityResetTime { get; }

    /// <summary>
    /// ���݂̈ړ�����
    /// </summary>
    public float CurrentMoveTime { get; }

    /// <summary>
    /// ���݂̈ړ����Ԃ𑝂₷
    /// </summary>
    public void UpMoveCurrentMoveTime();

    /// <summary>
    /// ���݂̈ړ����Ԃ����Z�b�g����
    /// </summary>
    public void ResetCurrentMoveTime();
}
