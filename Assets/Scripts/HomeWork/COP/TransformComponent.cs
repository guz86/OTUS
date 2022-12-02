using UnityEngine;

namespace HomeWork
{
    public class TransformComponent : MonoBehaviour, ITransformComponent
    {
        
        [SerializeField] private TransformEngine _transformEngine;
        
        public Vector3 GetPosition()
        {
            return _transformEngine.GetPosition();
        }
    }
}