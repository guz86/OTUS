using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class MoveMechanics_InDirection : MonoBehaviour
    {
        [SerializeField] private Vector3EventReceiver _moveReceiver;
        [SerializeField] private TransformEngine _transformEngine;
        [SerializeField] private FloatBehavior _speed;

        private void OnEnable()
        {
            _moveReceiver.OnEvent += OnMove;
        }

        private void OnDisable()
        {
            _moveReceiver.OnEvent -= OnMove;
        }

        private void OnMove(Vector3 direction)
        {
            _transformEngine.AddPosition(direction * _speed.Value);
        }
    }
}