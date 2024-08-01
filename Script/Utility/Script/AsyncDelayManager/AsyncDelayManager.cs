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
        /// �������̎��ԑҋ@����
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
                Debug.Log("�񓯊��������L�����Z�����ꂽ");
            }
        }

        /// <summary>
        /// �������̎��ԑҋ@������ɁA�������̃��\�b�h�����s����
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
                Debug.Log("�񓯊��������L�����Z�����ꂽ");
                return;
            }

            executeMethod?.Invoke();
        }

        /// <summary>
        /// �������̃t���[���ҋ@����
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
                Debug.Log("�񓯊��������L�����Z�����ꂽ");
            }
        }

        /// <summary>
        /// �������̎��ԑҋ@������ɁA�������̃��\�b�h�����s����
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
                Debug.Log("�񓯊��������L�����Z�����ꂽ");
                return;
            }

            executeMethod?.Invoke();
        }

        /// <summary>
        /// �g�[�N��������������B�������ς݂̏ꍇ�͉������Ȃ�
        /// </summary>
        private static void InitializeToken()
        {
            if(cancellationToken == null)
            {
                var cancellationTokenProvider = ServiceLocator.GetInstance<ICancellationTokenProvider>();
                cancellationToken = cancellationTokenProvider.UtilityCancellationToken;
            }
        }

        // �g�[�N�������݂��邩�m�F����
        private static void TokenNullCheck()
        {
            if (cancellationToken == null)
            {
                Debug.LogError("�L�����Z���g�[�N�������݂��܂���BInspector��CancellationTokenManager��ǉ����Ă��������B");
            }
        }
    }
}