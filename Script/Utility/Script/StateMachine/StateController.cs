using System;
using UnityEngine;

namespace Utility
{
    public class StateController : MonoBehaviour, IStateTransitionable, IStateAnyTransitionable
    {
        [Header("最初に初期化するステートクラスの名前")]　
        [SerializeField] private string startInitializeStateName;

        // ステートマネージャークラス
        private StateManager stateManager = new StateManager();

        private async void Start()
        {
            // サービスロケーターから取得するクラスがnullにならないように1フレーム待つ
            await AsyncDelayManager.DelayFrameAsync(1);
            SetInitializeState();
        }

        /// <summary>
        /// 初期化するステートを設定する
        /// </summary>
        private void SetInitializeState()
        {
            // 名前のクラスを取得する
            var stateType = Type.GetType(startInitializeStateName);

            // クラスが存在しない場合はエラーログを返す
            if (stateType == null)
            {
                Debug.LogError($"{startInitializeStateName}は存在しないクラス、またはstringのクラス名を間違えている可能性があります。");
                return;
            }

            // サービスロケーターのGetInstanceメソッドを取得して、引き数にstateTypeを渡す
            var getInstance = typeof(ServiceLocator).GetMethod("GetInstance").MakeGenericMethod(stateType);

            // 引き数が設定されたGetInstanceメソッドを実行して初期化するステートを取得する
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
