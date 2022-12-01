using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class BulletHitMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiverCollision _shootbulletReceiver;
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _damage;
        [SerializeField] private string _tag; //"Enemy"


        private void OnEnable()
        {
            _shootbulletReceiver.OnCollisionEntered += OnShoot;
        }

        private void OnDisable()
        {
            _shootbulletReceiver.OnCollisionEntered -= OnShoot;
        }


        private void OnShoot(Collision obj)
        {
            if (obj.gameObject.CompareTag(_tag))
            {
                _takeDamageReceiver.Call(_damage.Value);
                Destroy(obj.gameObject);
            }
        }
    }
}