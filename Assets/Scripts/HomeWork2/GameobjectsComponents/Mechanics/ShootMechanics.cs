using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class ShootMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private TimerBehavior _cooldown;
        [SerializeField] private ShootBulletEngine _shootBulletEngine;
        

        private void OnEnable()
        {
            _attackReceiver.OnEvent += OnShoot;
        }

        private void OnDisable()
        {
            _attackReceiver.OnEvent -= OnShoot;
        }

        private void OnShoot()
        {
            if (_cooldown.IsPlaying)
            {
                return;
            }

            // логика выстрела
            _shootBulletEngine.Shoot();

            // сбросить и запустить таймер снова
            _cooldown.ResetTime();
            _cooldown.Play();
        }
    }
}