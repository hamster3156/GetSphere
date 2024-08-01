using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public static class ServiceLocator
    {
        // ��������݂��Ȃ��C���X�^���X��o�^����f�B�N�V���i��
        private static Dictionary<Type, object> singleInstanceDictionary = new Dictionary<Type, object>();

        /// <summary>
        /// ��������݂��Ȃ��C���X�^���X���f�B�N�V���i���ɓo�^����
        /// �����C���X�^���X��o�^�����ꍇ�㏑�������
        /// �ŏ���Transform(1)��o�^�������Transform(2)��o�^����Ə㏑������A
        /// GetInstance��Transfrom���擾�����(1)�ł͂Ȃ��㏑�����ꂽ(2)���擾���鎖�ɂȂ�B
        /// </summary>
        public static void Register<T>(T instance) where T : class
        {            
            // T���f�B�N�V���i���ɓo�^����
            singleInstanceDictionary[typeof(T)] = instance;
        }


        public static void GenerateRegister<T>() where T : class
        {
            // �������ăf�B�N�V���i���ɓo�^����
            var instance = Activator.CreateInstance<T>();
            singleInstanceDictionary[typeof(T)] = instance;
        }

        /// <summary>
        /// �T�[�r�X���P�[�^�[�ɓo�^�����C���X�^���X���擾����B
        /// �����o�^���Ă��Ȃ������ꍇ���O���o���A�C���X�^���X�ɂ�defalt��Ԃ��B
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
            
            // �o�^����Ă��Ȃ��C���X�^���X�̏ꍇ���O���o��
            if(instance == null)
            {
                Debug.LogWarning($"ServiceLocator�ɂ�{typeof(T).Name}�����݂��܂���");
            }

            return instance;
        }
    }
}