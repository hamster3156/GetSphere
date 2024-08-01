using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public static class ServiceLocator
    {
        // 一つしか存在しないインスタンスを登録するディクショナリ
        private static Dictionary<Type, object> singleInstanceDictionary = new Dictionary<Type, object>();

        /// <summary>
        /// 一つしか存在しないインスタンスをディクショナリに登録する
        /// 同じインスタンスを登録した場合上書きされる
        /// 最初にTransform(1)を登録した後にTransform(2)を登録すると上書きされ、
        /// GetInstanceでTransfromを取得すると(1)ではなく上書きされた(2)を取得する事になる。
        /// </summary>
        public static void Register<T>(T instance) where T : class
        {            
            // Tをディクショナリに登録する
            singleInstanceDictionary[typeof(T)] = instance;
        }


        public static void GenerateRegister<T>() where T : class
        {
            // 生成してディクショナリに登録する
            var instance = Activator.CreateInstance<T>();
            singleInstanceDictionary[typeof(T)] = instance;
        }

        /// <summary>
        /// サービスロケーターに登録したインスタンスを取得する。
        /// もし登録していなかった場合ログを出し、インスタンスにはdefaltを返す。
        /// </summary>
        public static T GetInstance<T>() where T : class
        {
            T instance = default;
            Type type = typeof(T);

            if(singleInstanceDictionary.ContainsKey(type))
            {
                instance = singleInstanceDictionary[type] as T;
                return instance;
            }
            
            // 登録されていないインスタンスの場合ログを出す
            if(instance == null)
            {
                Debug.LogWarning($"ServiceLocatorには{typeof(T).Name}が存在しません");
            }

            return instance;
        }
    }
}