using System;
using System.Threading;
using UnityEngine;

namespace Utility
{
    public class CancellationTokenManager : MonoBehaviour, ICancellationTokenProvider
    {
        // Debug.Log���o�����ǂ���
        [SerializeField] private bool canDebugLog = false;
        
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        CancellationToken ICancellationTokenProvider.UtilityCancellationToken => cancellationToken;

        private void Awake()
        {
            Register();
        }

        /// <summary>
        /// �T�[�r�X���P�[�^�[�ɃC���X�^���X��o�^����
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
        /// �񓯊��������L�����Z�����ăg�[�N����j������
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
                    Debug.Log("�񓯊������͊��ɃL�����Z���ς݂ł�");
                }
            }
        }
    }
}