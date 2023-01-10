using System.Collections.Generic;
using UnityEngine;

namespace HomeWork
{
    public class BulletCollisionTracker : MonoBehaviour
    {
        [SerializeField] private ShootProjectileEngine _shootBulletEngine;
        [SerializeField] private IntBehaviour _BulletDamage;

        private List<GameObject> _bullets;

        private void Start()
        {
            _bullets = _shootBulletEngine.GetProjectilePool();
            
            foreach (var bullet in _bullets)
            {
                bullet.GetComponent<EventReceiverCollision>().OnCollisionEntered += OnShoot;
            }
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            foreach (var bullet in _bullets)
            {
                bullet.GetComponent<EventReceiverCollision>().OnCollisionEntered -= OnShoot;
            }
        }

        private void OnShoot(Collision obj)
        {
            if (obj.gameObject.CompareTag("Enemy"))
            {
                var parent = obj.gameObject.transform.parent.parent;
                var entity = parent.GetComponent<IEntity>();
                var takeDamage  =  entity.Get<TakeDamageComponent>();
                takeDamage.TakeDamage(_BulletDamage.Value);
                
            }
        }
    }
}