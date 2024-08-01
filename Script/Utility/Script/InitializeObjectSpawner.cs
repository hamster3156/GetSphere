using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class InitializeObjectSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> instantiateObjects = new List<GameObject>();

        private void Awake()
        {
            // リストに何か追加されていればリストのオブジェクトを生成する
            if (instantiateObjects.Count > 0)
            {
                for (int instantiateObjectsNumber = 0; instantiateObjectsNumber < instantiateObjects.Count; instantiateObjectsNumber++)
                {
                    Instantiate(instantiateObjects[instantiateObjectsNumber]);
                }
            }
            else
            {
                Debug.Log("生成オブジェクがリストに格納されていない");
            }
        }
    }
}