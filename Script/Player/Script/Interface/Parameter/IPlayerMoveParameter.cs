public interface IPlayerMoveParameter
{
    /// <summary>
    /// 移動速度
    /// </summary>
    public float MoveSpeed { get; }

    /// <summary>
    /// 移動時間のリセットする閾値
    /// </summary>
    public float ResetMoveTimeThreshold { get; }

    /// <summary>
    /// 移動時間の上昇値
    /// </summary>
    public float UpMoveTime { get; }

    /// <summary>
    /// 止まった時に移動速度がリセットされるまでの時間
    /// </summary>
    public float StopMoveVelocityResetTime { get; }

    /// <summary>
    /// 現在の移動時間
    /// </summary>
    public float CurrentMoveTime { get; }

    /// <summary>
    /// 現在の移動時間を増やす
    /// </summary>
    public void UpMoveCurrentMoveTime();

    /// <summary>
    /// 現在の移動時間をリセットする
    /// </summary>
    public void ResetCurrentMoveTime();
}
