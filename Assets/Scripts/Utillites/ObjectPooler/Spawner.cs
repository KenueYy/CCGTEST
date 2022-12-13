using System.Collections.Generic;
using UnityEngine;

namespace Utillites.ObjectPooller {

    public class Spawner : MonoBehaviour {

        [SerializeField] 
        private Transform ObjectPoolContainer;

        public static Spawner instance;

        private Dictionary<string, GameObjectPool> _pools = new Dictionary<string, GameObjectPool>();

        private void Awake() {
            instance = this;
        }

        public void PreparationPool(PoolObject PoolData) {
            GameObjectPool pool = new GameObjectPool(PoolData.prefab, PoolData.poolCount, ObjectPoolContainer, PoolData.autoExpand);
            _pools.Add(PoolData.prefab.name, pool);
        }

        public GameObject SpawnObject(PoolObject PoolData) {
            _pools.TryGetValue(PoolData.prefab.name, out GameObjectPool pool);
            GameObject poolObject = pool.GetFreeElement();
            poolObject.transform.position = transform.position;
            poolObject.SetActive(true);
            return poolObject;
        }

        public void DispawnObject(GameObject poolObject, PoolObject PoolData) {
            _pools.TryGetValue(PoolData.prefab.name, out GameObjectPool pool);
            foreach (var element in pool.GetBusyElements()) {
                if(element == poolObject) {
                    element.transform.position = ObjectPoolContainer.transform.position;
                    element.transform.parent = ObjectPoolContainer.transform;
                    element.transform.rotation = new Quaternion(0, 0, 0, 0);
                    element.SetActive(false);
                }
            }
        }

        public void DispawnAll() {
            foreach (var pool in _pools) {
                List<GameObject> dispawnElements = pool.Value.GetBusyElements();
                foreach (GameObject element in dispawnElements) {
                    element.transform.position = ObjectPoolContainer.transform.position;
                    element.transform.parent = ObjectPoolContainer.transform;
                    element.transform.rotation = new Quaternion(0, 0, 0, 0);
                    element.SetActive(false);
                }
            }
        }

    }
}
 