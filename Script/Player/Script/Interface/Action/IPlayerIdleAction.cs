public interface IPlayerIdleAction
{
    /// <summary>
    /// ステートの開始時に移動速度をリセットする
    /// </summary>
    void ResetMoveVelocity();

    /// <summary>
    /// 移動入力があれば移動ステートに遷移する
    /// </summary>
    void TransitionToMoveStateOnInput();

    /// <summary>
    /// 移動時間をリセットする
    /// </summary>
    void ResetCurrentMoveTime();
}
