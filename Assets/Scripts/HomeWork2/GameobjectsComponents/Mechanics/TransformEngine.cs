using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class TransformEngine : MonoBehaviour
    {
        [SerializeField] private Transform[] _transforms;

        [SerializeField] private Transform _mainTransform;
        
        
        public Vector3 GetPosition()
        {
            return _mainTransform.position;
        }

        public void SetPosition(Vector3 position)
        {
            foreach (var transform in _transforms)
            {
                transform.position = position;
            }
        }
        
    }
}