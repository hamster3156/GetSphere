public interface IPlayerAnimatorParameter
{
    /// <summary>
    /// �ړ����x
    /// </summary>
    public float MoveSpeed { get; }

    /// <summary>
    /// �ړ����x�̖��O
    /// </summary>
    public string MoveSpeedName { get; }

    /// <summary>
    /// �ړ����x�̌�������
    /// </summary>
    public float MoveSpeedSlowDownTime { get; }

    /// <summary>
    /// �ړ����x��ύX����
    /// </summary>
    void ChangeMoveSpeed(float changeMoveSpeed);
}
