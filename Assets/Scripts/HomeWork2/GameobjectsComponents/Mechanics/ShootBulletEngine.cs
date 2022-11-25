using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class ShootBulletEngine : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _weaponPoint;
        [SerializeField] private float _bulletSpeed;
        private GameObject _bulletInstance;

        public void Shoot()
        {
            // можно добавить пул из объектов до 20шт Pooling
            _bulletInstance = Instantiate(_bulletPrefab, _weaponPoint.transform.position,
                _weaponPoint.transform.rotation);
            var bulletInstanceRigidbody = _bulletInstance.GetComponent<Rigidbody>();
            bulletInstanceRigidbody.AddForce(_weaponPoint.transform.forward * _bulletSpeed);
        }
    }
}