using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerInputParameter 
{
    /// <summary>
    /// 入力設定の有効や無効を設定できる
    /// </summary>
    public PlayerInput PlayerInput { get; } 

    /// <summary>
    /// 移動方向入力
    /// </summary>
    public Vector3 MoveDirctionInput { get; }

    /// <summary>
    /// 移動入力アクションフラグ
    /// </summary>
    public bool IsMoveInputAction { get; }
}
