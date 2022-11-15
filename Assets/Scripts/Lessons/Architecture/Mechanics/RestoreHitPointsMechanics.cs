using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class RestoreHitPointsMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints;
        [SerializeField] private TimerBehavior _delay; // задержка перед запуском
        [SerializeField] private PeriodBehavior _restorePeriod; // восстановление хп

        private void OnEnable()
        {
            _takeDamageReceiver.OnEvent += OnDamageTaken;
            _delay.OnEnded += OnDelayEnded;
            _restorePeriod.OnEvent += OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            _takeDamageReceiver.OnEvent -= OnDamageTaken;
            _delay.OnEnded -= OnDelayEnded;
            _restorePeriod.OnEvent -= OnRestoreHitPoints;
        }

        private void OnRestoreHitPoints()
        {
            // восстанавливаем хп
            _hitPoints.Value += 1;
            if (_hitPoints.Value >=5)
            {
                _restorePeriod.Stop();
            }
        }

        private void OnDelayEnded()
        {
            // по окончанию задержки запускаем регенерацию
            _restorePeriod.Play();
        }

        private void OnDamageTaken(int damage)
        {
            // при получении урона, сброс задержки
            _delay.ResetTime();
            if (!_delay.IsPlaying)
            {
                _delay.Play();
            }
            // останавливаем процесс регенерации
            _restorePeriod.Stop();
        }
    }
}