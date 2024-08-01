using System;
using System.Collections.Generic;
using UnityEngine;


namespace Utility
{
    public class ServiceClassRegister : MonoBehaviour
    {
        [Header("�o�^����N���X�̖��O�����X�g�ɒǉ�����")]
        [SerializeField] private List<string> registerClassNames = new List<string>();

        private void Awake()
        {
            Register();
        }

        /// <summary>
        /// ���X�g�ɒǉ�����Ă���N���X�����T�[�r�X���P�[�^�[�ɐ������ēo�^����
        /// </summary>
        private void Register()
        {
            for (int i = 0; i < registerClassNames.Count; i++)
            {
                // �o�^����Ă���N���X�̌^���擾����
                var classType = Type.GetType(registerClassNames[i]);

                if (classType == null)
                {
                    Debug.LogError($"{registerClassNames[i]}�͑��݂��Ȃ��N���X�A�܂���List�ɓo�^�����N���X�����ԈႦ�Ă���\��������܂��B");
                    return;
                }

                // �T�[�r�X���P�[�^�[�̃��\�b�h���擾���Ĉ�������classType��n��
                var generateRegister = typeof(ServiceLocator).GetMethod("GenerateRegister").MakeGenericMethod(classType);

                // ��������ݒ肵��GenerateRegister���\�b�h�����s����
                generateRegister.Invoke(null, null);
            }
        }
    }
}
