using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class ShootRocketMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private TimerBehavior _cooldown;
        [SerializeField] private ShootBulletEngine _shootBulletEngine;
        [SerializeField] private IntBehaviour _manaPoints; 
        [SerializeField] private int _takemana; // 5 
        
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
            
            if (_manaPoints.Value < _takemana)
            {
                return;
            }
            
            // логика выстрела
            
            _shootBulletEngine.Shoot();
            
            OnManaTaken(_takemana);
            
            _cooldown.ResetTime();
            _cooldown.Play();
        }
        
        private void OnManaTaken(int mana)
        {
            _manaPoints.Value -= mana;
        }
    }
}