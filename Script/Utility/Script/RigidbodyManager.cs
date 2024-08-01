using UnityEngine;

namespace Utility
{
    public static class RigidbodyManager
    {
        /// <summary>
        /// XYZの座標移動を行う
        /// </summary>
        public static void MoveVelocity(Rigidbody rigidbody, Vector3 moveDirection, float moveSpeed)
        {
            var moveVelocity = moveDirection * moveSpeed;
            rigidbody.velocity = new Vector3(moveVelocity.x, rigidbody.velocity.y, moveVelocity.z);
        }

        /// <summary>
        /// オブジェクトの前方移動を行う
        /// </summary>
        public static void ForwardMoveVelocity(Transform transform, Rigidbody rigidbody, float moveSpeed)
        {
            var forwardMoveVelocity = transform.forward * moveSpeed;
            forwardMoveVelocity.y = rigidbody.velocity.y;
            rigidbody.velocity = forwardMoveVelocity;
        }

        /// <summary>
        /// XZのVelocityを0に初期化する
        /// </summary>
        public static void XZMoveVelocityReset(Rigidbody rigidbody)
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }

        public static void MoveAddForce(Rigidbody rigidbody, Vector3 moveDirection, float moveSpeed, ForceMode forceMode)
        {
            var moveImpulse = moveDirection * moveSpeed;
            rigidbody.AddForce(moveImpulse, forceMode);
        }

        /// <summary>
        /// Y軸の吹き飛ばしを行う（ジャンプとかに使う）
        /// </summary>
        public static void UpImpulse(Rigidbody rigidbody, float upForce)
        {
            rigidbody.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
    }
}