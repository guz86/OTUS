using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class AttackMechanics1 : MonoBehaviour
    {
        [SerializeField] private EventReceiver1 attackReceiver1;
        [SerializeField] private TimerBehavior1 _cooldown;
        [Space][SerializeField] private Enemy _enemy;
        
        
        //[SerializeField] private int _damage;

        [SerializeField] private IntBehaviour1 _damage;
        
        
        private void OnEnable()
        {
            this.attackReceiver1.OnEvent += this.OnRequestAttack;
        }

        private void OnDisable()
        {
            this.attackReceiver1.OnEvent -= this.OnRequestAttack;
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