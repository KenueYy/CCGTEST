using UnityEngine;

namespace Utillites.ObjectPooller {

    [CreateAssetMenu(menuName = "CustomObject/PoolObject")]
    public class PoolObject : ScriptableObject {

        public GameObject prefab;
        public int poolCount;
        public bool autoExpand;

    }
}