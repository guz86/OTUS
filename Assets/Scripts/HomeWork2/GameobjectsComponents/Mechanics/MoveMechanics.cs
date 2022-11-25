using System.Collections;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class MoveMechanics : MonoBehaviour
    {
        [SerializeField] private Vector3EventReceiver _moveReceiver;
        [SerializeField] private TransformEngine _transformEngine;
        [SerializeField] private IntBehaviour _MovementSpeed; //15f

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