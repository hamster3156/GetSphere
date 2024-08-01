public interface IPlayerAnimatorParameter
{
    /// <summary>
    /// 移動速度
    /// </summary>
    public float MoveSpeed { get; }

    /// <summary>
    /// 移動速度の名前
    /// </summary>
    public string MoveSpeedName { get; }

    /// <summary>
    /// 移動速度の減少時間
    /// </summary>
    public float MoveSpeedSlowDownTime { get; }

    /// <summary>
    /// 移動速度を変更する
    /// </summary>
    void ChangeMoveSpeed(float changeMoveSpeed);
}
