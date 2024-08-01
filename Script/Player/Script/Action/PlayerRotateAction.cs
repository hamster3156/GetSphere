using UnityEngine;

public class PlayerRotateAction 
{
    // 滑らかに回転させるために、角度の数値を変数に入れる
    private float smoothDampAngle = 0;

    /// <summary>
    /// カメラを基準にした移動方向入力を返す
    /// </summary>
    public Vector3 UpdateCameraMoveDirection(Vector3 moveDirectionInput)
    {
        var cameraMoveDireciton = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * moveDirectionInput;
        return cameraMoveDireciton;
    }

    /// <summary>
    /// 入力方向に回転させる
    /// </summary>
    public void UpdateInputDirectionRotate(Vector3 moveDirectionInput, Transform transform, float rotateSpeed)
    {
       var cameraMoveDireciton = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * moveDirectionInput;

        if (cameraMoveDireciton.sqrMagnitude != 0.0f)
        {
            var targetRotate = Mathf.Atan2(cameraMoveDireciton.x, cameraMoveDireciton.z) * Mathf.Rad2Deg;
            var inputRotate = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotate, ref smoothDampAngle, rotateSpeed);
            transform.rotation = Quaternion.Euler(0, (int)inputRotate, 0);
        }
    }
}
