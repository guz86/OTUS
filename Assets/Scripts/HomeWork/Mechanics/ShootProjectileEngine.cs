using UnityEngine;

namespace HomeWork
{
    public class ShootProjectileEngine : ObjectPool_List
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _weaponPoint;
        [SerializeField] private float _bulletSpeed;
        
        private void Start()
        {
            Initialize(_bulletPrefab);
        }

        public void Shoot()
        {
            if (TryGetObject(out GameObject bullet))
            {
                bullet.SetActive(true);
                bullet.transform.position = _weaponPoint.transform.position;
                bullet.transform.rotation = _weaponPoint.transform.rotation;
                var bulletInstanceRigidbody = bullet.GetComponent<Rigidbody>();
                bulletInstanceRigidbody.AddForce(_weaponPoint.transform.forward * _bulletSpeed);
            }

        }
    }
}