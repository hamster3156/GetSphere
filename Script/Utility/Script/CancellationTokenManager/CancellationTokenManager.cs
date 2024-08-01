using System;
using System.Threading;
using UnityEngine;

namespace Utility
{
    public class CancellationTokenManager : MonoBehaviour, ICancellationTokenProvider
    {
        // Debug.Logを出すかどうか
        [SerializeField] private bool canDebugLog = false;
        
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        CancellationToken ICancellationTokenProvider.UtilityCancellationToken => cancellationToken;

        private void Awake()
        {
            Register();
        }

        /// <summary>
        /// サービスロケーターにインスタンスを登録する
        /// </summary>
        private void Register()
        {
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
            ServiceLocator.Register<ICancellationTokenProvider>(this);
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void OnApplicationQuit()
        {
            Dispose();
        }

        /// <summary>
        /// 非同期処理をキャンセルしてトークンを破棄する
        /// </summary>
        private void Dispose()
        {
            try
            {
                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();
            }
            catch (ObjectDisposedException)
            {
                if (canDebugLog)
                {
                    Debug.Log("非同期処理は既にキャンセル済みです");
                }
            }
        }
    }
}