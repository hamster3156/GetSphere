using System;
using UnityEngine;

namespace Utility
{
    public class StateController : MonoBehaviour, IStateTransitionable, IStateAnyTransitionable
    {
        [Header("�ŏ��ɏ���������X�e�[�g�N���X�̖��O")]�@
        [SerializeField] private string startInitializeStateName;

        // �X�e�[�g�}�l�[�W���[�N���X
        private StateManager stateManager = new StateManager();

        private async void Start()
        {
            // �T�[�r�X���P�[�^�[����擾����N���X��null�ɂȂ�Ȃ��悤��1�t���[���҂�
            await AsyncDelayManager.DelayFrameAsync(1);
            SetInitializeState();
        }

        /// <summary>
        /// ����������X�e�[�g��ݒ肷��
        /// </summary>
        private void SetInitializeState()
        {
            // ���O�̃N���X���擾����
            var stateType = Type.GetType(startInitializeStateName);

            // �N���X�����݂��Ȃ��ꍇ�̓G���[���O��Ԃ�
            if (stateType == null)
            {
                Debug.LogError($"{startInitializeStateName}�͑��݂��Ȃ��N���X�A�܂���string�̃N���X�����ԈႦ�Ă���\��������܂��B");
                return;
            }

            // �T�[�r�X���P�[�^�[��GetInstance���\�b�h���擾���āA��������stateType��n��
            var getInstance = typeof(ServiceLocator).GetMethod("GetInstance").MakeGenericMethod(stateType);

            // ���������ݒ肳�ꂽGetInstance���\�b�h�����s���ď���������X�e�[�g���擾����
            var initializeState = getInstance.Invoke(null, null) as State;
            stateManager.InitializeState(initializeState);
        }

        private void FixedUpdate()
        {
            stateManager?.FixedUpdate();
        }

        private void Update()
        {
            stateManager?.Update();
        }

        private void LateUpdate()
        {
            stateManager?.LateUpdate();
        }

        void IStateTransitionable.AddTransition<TState>(TState fromState, TState toState)
        {
            stateManager?.AddTransition(fromState, toState);
        }

        void IStateTransitionable.TransitionTo<TState>(TState fromState, TState toState)
        {
            stateManager?.TransitionTo(fromState, toState);
        }

        void IStateAnyTransitionable.AnyTransition<TState>(TState nextState)
        {
            stateManager?.AnyTransitionTo(nextState);
        }
    }
}
