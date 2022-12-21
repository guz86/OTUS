using UnityEngine;

namespace HomeWork
{
    public class UIHPBarTransform : MonoBehaviour
    {
        [SerializeField] private Transform _visualTransform;
        [SerializeField] private Transform _uiTransform;

        private void Update()
        {
             _uiTransform.position = _visualTransform.position;
             _uiTransform.rotation = _visualTransform.rotation;
        }
    }
}