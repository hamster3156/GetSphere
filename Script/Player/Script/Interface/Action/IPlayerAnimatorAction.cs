public interface IPlayerAnimatorAction
{
    /// <summary>
    /// 移動速度を更新する
    /// </summary>
    void UpdateMoveSpeed();

    /// <summary>
    /// 移動速度を変更する
    /// </summary>
    void ChangeMoveSpeed();

    /// <summary>
    /// 移動速度をリセットする
    /// </summary>
    void ResetMoveSpeed();
}
