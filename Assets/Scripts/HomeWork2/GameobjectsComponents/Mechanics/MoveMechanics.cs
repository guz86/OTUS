using System.Collections;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class MoveMechanics : MonoBehaviour
    {
        [SerializeField] private Vector3EventReceiver _moveReceiver;
        [SerializeField] private TransformEngine _transformEngine;

        private void OnEnable()
        {
            _moveReceiver.OnEvent += OnMove;
        }

        private void OnDisable()
        {
            _moveReceiver.OnEvent -= OnMove;
        }

        private void OnMove(Vector3 moveVector)
        {
            _transformEngine.SetPosition(_transformEngine.GetPosition() + moveVector);
        }
    }
}