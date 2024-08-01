using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;

namespace Utility
{
    public static class AsyncDelayManager
    {
        private static CancellationToken cancellationToken;

        /// <summary>
        /// 引き数の時間待機する
        /// </summary>
        public static async UniTask DelayTimeAsync(float delayTime)
        {
            InitializeToken();
            TokenNullCheck();

            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delayTime), cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("非同期処理がキャンセルされた");
            }
        }

        /// <summary>
        /// 引き数の時間待機した後に、引き数のメソッドを実行する
        /// </summary>
        public static async UniTask DelayTimeAsync(float delayTime, Action executeMethod)
        {
            InitializeToken();
            TokenNullCheck();

            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delayTime), cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("非同期処理がキャンセルされた");
                return;
            }

            executeMethod?.Invoke();
        }

        /// <summary>
        /// 引き数のフレーム待機する
        /// </summary>
        public static async UniTask DelayFrameAsync(int delayFrame) 
        {
            InitializeToken();
            TokenNullCheck();

            try
            {
                await UniTask.DelayFrame(delayFrame, cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("非同期処理がキャンセルされた");
            }
        }

        /// <summary>
        /// 引き数の時間待機した後に、引き数のメソッドを実行する
        /// </summary>
        public static async UniTask DelayFrameAsync(int delayFrame, Action executeMethod)
        {
            InitializeToken();
            TokenNullCheck();

            try
            {
                await UniTask.DelayFrame(delayFrame, cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("非同期処理がキャンセルされた");
                return;
            }

            executeMethod?.Invoke();
        }

        /// <summary>
        /// トークンを初期化する。初期化済みの場合は何もしない
        /// </summary>
        private static void InitializeToken()
        {
            if(cancellationToken == null)
            {
                var cancellationTokenProvider = ServiceLocator.GetInstance<ICancellationTokenProvider>();
                cancellationToken = cancellationTokenProvider.UtilityCancellationToken;
            }
        }

        // トークンが存在するか確認する
        private static void TokenNullCheck()
        {
            if (cancellationToken == null)
            {
                Debug.LogError("キャンセルトークンが存在しません。InspectorにCancellationTokenManagerを追加してください。");
            }
        }
    }
}