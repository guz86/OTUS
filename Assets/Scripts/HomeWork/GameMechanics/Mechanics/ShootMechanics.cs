using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class ShootMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private TimerBehavior _cooldown;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _weaponPoint;
        [SerializeField] private IntBehaviour __bulletSpeed;
        
        private GameObject _bulletInstance;
        
        private void OnEnable()
        {
            _attackReceiver.OnEvent += OnShoot;
        }

        private void OnDisable()
        {
            _attackReceiver.OnEvent -= OnShoot;
        }

        public void OnShoot()
        {
            if (_cooldown.IsPlaying)
            {
                return;
            }

            // логика выстрела
            
            _bulletInstance = Instantiate(_bulletPrefab,_weaponPoint.transform.position,_weaponPoint.transform.rotation) as GameObject;
            var bulletInstanceRigidbody = _bulletInstance.GetComponent<Rigidbody>();
            bulletInstanceRigidbody.AddForce(_weaponPoint.transform.forward * __bulletSpeed.Value);
            
            // сбросить и запустить таймер снова
            _cooldown.ResetTime();
            _cooldown.Play();
        }
    }
}