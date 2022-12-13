using UnityEngine;

namespace HomeWork
{
    public class VisualTransform : MonoBehaviour
    {
        [SerializeField] private GameObject _visual;
        [SerializeField] private GameObject _collision;

        private void Update()
        {
            _visual.transform.position = _collision.transform.position;
            _visual.transform.rotation = _collision.transform.rotation;
        }
    }
}