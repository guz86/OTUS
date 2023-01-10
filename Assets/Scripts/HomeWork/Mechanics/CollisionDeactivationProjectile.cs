using UnityEngine;

namespace HomeWork
{
    public class CollisionDeactivationProjectile : MonoBehaviour
    {
        [SerializeField] private EventReceiverCollision _collision;

        private void OnEnable()
        {
            _collision.OnCollisionEntered += OnCollision;
        }

        private void OnDisable()

        {
            _collision.OnCollisionEntered -= OnCollision;
        }

        private void OnCollision(Collision obj)
        {
            gameObject.SetActive(false);
        }
    }
}