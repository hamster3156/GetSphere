using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class InitializeObjectSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> instantiateObjects = new List<GameObject>();

        private void Awake()
        {
            // ���X�g�ɉ����ǉ�����Ă���΃��X�g�̃I�u�W�F�N�g�𐶐�����
            if (instantiateObjects.Count > 0)
            {
                for (int instantiateObjectsNumber = 0; instantiateObjectsNumber < instantiateObjects.Count; instantiateObjectsNumber++)
                {
                    Instantiate(instantiateObjects[instantiateObjectsNumber]);
                }
            }
            else
            {
                Debug.Log("�����I�u�W�F�N�����X�g�Ɋi�[����Ă��Ȃ�");
            }
        }
    }
}