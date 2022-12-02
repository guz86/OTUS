using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HomeWork
{
    public class ObjectPool_List : MonoBehaviour
    {
        //[SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        private List<GameObject> _pool = new List<GameObject>();

        protected void Initialize(GameObject prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(prefab);
                spawned.SetActive(false);
                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.First(p => p.activeSelf == false);
            return result != null;
        }
    }
}