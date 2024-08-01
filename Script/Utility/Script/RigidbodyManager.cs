using UnityEngine;

namespace Utility
{
    public static class RigidbodyManager
    {
        /// <summary>
        /// XYZ�̍��W�ړ����s��
        /// </summary>
        public static void MoveVelocity(Rigidbody rigidbody, Vector3 moveDirection, float moveSpeed)
        {
            var moveVelocity = moveDirection * moveSpeed;
            rigidbody.velocity = new Vector3(moveVelocity.x, rigidbody.velocity.y, moveVelocity.z);
        }

        /// <summary>
        /// �I�u�W�F�N�g�̑O���ړ����s��
        /// </summary>
        public static void ForwardMoveVelocity(Transform transform, Rigidbody rigidbody, float moveSpeed)
        {
            var forwardMoveVelocity = transform.forward * moveSpeed;
            forwardMoveVelocity.y = rigidbody.velocity.y;
            rigidbody.velocity = forwardMoveVelocity;
        }

        /// <summary>
        /// XZ��Velocity��0�ɏ���������
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
        /// Y���̐�����΂����s���i�W�����v�Ƃ��Ɏg���j
        /// </summary>
        public static void UpImpulse(Rigidbody rigidbody, float upForce)
        {
            rigidbody.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
    }
}