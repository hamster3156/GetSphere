using System.Threading;

namespace Utility
{
    public interface ICancellationTokenProvider
    {
        /// <summary>
        /// 共通のキャンセルトークンを取得する事が出来る
        /// </summary>
        public CancellationToken UtilityCancellationToken { get; }
    }
}