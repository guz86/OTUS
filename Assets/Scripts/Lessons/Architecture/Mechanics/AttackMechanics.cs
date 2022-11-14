using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class AttackMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private TimerBehavior _cooldown;
        [Space][SerializeField] private Enemy _enemy;
        
        
        //[SerializeField] private int _damage;

        [SerializeField] private IntBehaviour _damage;
        
        
        private void OnEnable()
        {
            this._attackReceiver.OnEvent += this.OnRequestAttack;
        }

        private void OnDisable()
        {
            this._attackReceiver.OnEvent -= this.OnRequestAttack;
        }

        private void OnRequestAttack()
        {
            if (this._cooldown.IsPlaying)
            {
               return;
            }

            // логика нанесения урона противнику
            //_enemy.TakeDamage(_damage);
            _enemy.TakeDamage(_damage.Value);
            
            // сбросить и запустить таймер снова
            this._cooldown.ResetTime();
            this._cooldown.Play();
        }
    }
}