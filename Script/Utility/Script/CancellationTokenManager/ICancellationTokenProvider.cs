using System.Threading;

namespace Utility
{
    public interface ICancellationTokenProvider
    {
        /// <summary>
        /// ���ʂ̃L�����Z���g�[�N�����擾���鎖���o����
        /// </summary>
        public CancellationToken UtilityCancellationToken { get; }
    }
}