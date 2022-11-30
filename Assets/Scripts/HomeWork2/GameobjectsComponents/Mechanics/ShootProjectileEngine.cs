using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class ShootProjectileEngine : ObjectPool_List
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _weaponPoint;
        [SerializeField] private float _bulletSpeed;
        
        //[SerializeField] private ObjectPooler _objectPooler;
        //private GameObject _bulletInstance;
        //private string _tag = "Bullet";

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
            
            // _bulletInstance = _objectPooler.SpawnFromPool(_tag,
            //     _weaponPoint.transform.position,
            //     _weaponPoint.transform.rotation);
            //
            // if (!_bulletInstance) return;
            //
            // var bulletInstanceRigidbody = _bulletInstance.GetComponent<Rigidbody>();
            // bulletInstanceRigidbody.AddForce(_weaponPoint.transform.forward * _bulletSpeed);

            // можно добавить пул из объектов до 20шт Pooling
            //_bulletInstance = Instantiate(_bulletPrefab, _weaponPoint.transform.position, _weaponPoint.transform.rotation);
            // var bulletInstanceRigidbody = _bulletInstance.GetComponent<Rigidbody>();
            // bulletInstanceRigidbody.AddForce(_weaponPoint.transform.forward * _bulletSpeed);
        }
    }
}