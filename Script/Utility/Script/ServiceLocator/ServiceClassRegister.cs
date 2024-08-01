using System;
using System.Collections.Generic;
using UnityEngine;


namespace Utility
{
    public class ServiceClassRegister : MonoBehaviour
    {
        [Header("登録するクラスの名前をリストに追加する")]
        [SerializeField] private List<string> registerClassNames = new List<string>();

        private void Awake()
        {
            Register();
        }

        /// <summary>
        /// リストに追加されているクラス名をサービスロケーターに生成して登録する
        /// </summary>
        private void Register()
        {
            for (int i = 0; i < registerClassNames.Count; i++)
            {
                // 登録されているクラスの型を取得する
                var classType = Type.GetType(registerClassNames[i]);

                if (classType == null)
                {
                    Debug.LogError($"{registerClassNames[i]}は存在しないクラス、またはListに登録したクラス名を間違えている可能性があります。");
                    return;
                }

                // サービスロケーターのメソッドを取得して引き数にclassTypeを渡す
                var generateRegister = typeof(ServiceLocator).GetMethod("GenerateRegister").MakeGenericMethod(classType);

                // 引き数を設定したGenerateRegisterメソッドを実行する
                generateRegister.Invoke(null, null);
            }
        }
    }
}
