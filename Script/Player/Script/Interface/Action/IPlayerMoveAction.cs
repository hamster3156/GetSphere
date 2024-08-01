public interface IPlayerMoveAction
{
    /// <summary>
    /// 移動入力がある時に移動速度を変更する
    /// </summary>
    void ChangeMoveVelocityOnMoveInput();

    /// <summary>
    /// 移動入力が止まった時にIdleステートに変更する
    /// </summary>
    void TransitioToIdleStateNoInput();

    /// <summary>
    /// 移動時間を増やす
    /// </summary>
    void UpCurrentMoveTime();
}
