using UnityEngine;

namespace HomeWork
{
    public class VisualTransform : MonoBehaviour
    {
        [SerializeField] private Transform _visualTransform;
        [SerializeField] private Transform _collisionTransform;

        private void Update()
        {
            _visualTransform.position = _collisionTransform.position;
            _visualTransform.rotation = _collisionTransform.rotation;
        }
    }
}