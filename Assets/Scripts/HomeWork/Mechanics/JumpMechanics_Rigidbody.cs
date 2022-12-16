using UnityEngine;

namespace HomeWork
{
    public class JumpMechanics_Rigidbody : MonoBehaviour
    {
        [SerializeField] private EventReceiver _eventReceiver;
        [SerializeField] private Rigidbody _rigidbodyCollision;
        [SerializeField] private IntBehaviour _jumpSpeed;

        private void OnEnable()
        {
            _eventReceiver.OnEvent += OnJump;
        }

        private void OnDisable()
        {
            _eventReceiver.OnEvent -= OnJump;
        }

        private void OnJump()
        {
            _rigidbodyCollision.AddForce(Vector3.up * _jumpSpeed.Value, ForceMode.Impulse);
        }
    }
}