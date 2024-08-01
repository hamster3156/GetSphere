using UnityEngine;

public class PlayerRotateAction 
{
    // ŠŠ‚ç‚©‚É‰ñ“]‚³‚¹‚é‚½‚ß‚ÉAŠp“x‚Ì”’l‚ğ•Ï”‚É“ü‚ê‚é
    private float smoothDampAngle = 0;

    /// <summary>
    /// ƒJƒƒ‰‚ğŠî€‚É‚µ‚½ˆÚ“®•ûŒü“ü—Í‚ğ•Ô‚·
    /// </summary>
    public Vector3 UpdateCameraMoveDirection(Vector3 moveDirectionInput)
    {
        var cameraMoveDireciton = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * moveDirectionInput;
        return cameraMoveDireciton;
    }

    /// <summary>
    /// “ü—Í•ûŒü‚É‰ñ“]‚³‚¹‚é
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
