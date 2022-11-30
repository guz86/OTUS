/*using System;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class ObjectPooler : MonoBehaviour
    {
        private Dictionary<string, Queue<GameObject>> _poolDictionary;
        [SerializeField] private List<Pool> _pools;


        private void Start()
        {
            InitPool();
        }

        private void InitPool()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in _pools)
            {
                var objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool._size; i++)
                {
                    var obj = Instantiate(pool._prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                
                _poolDictionary.Add(pool._tag, objectPool);
            }
        }

        [Serializable]
        private class Pool
        {
            [SerializeField] public string _tag;
            [SerializeField] public GameObject _prefab;
            [SerializeField] public int _size;
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {

            if (!_poolDictionary.ContainsKey(tag)) return null;
            
            var objectToSpawn = _poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            
            _poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}*/