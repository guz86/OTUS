using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class RestoreHitPointsMechanics1 : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver1 takeDamageReceiver1;
        [SerializeField] private IntBehaviour1 _hitPoints;
        [SerializeField] private TimerBehavior1 _delay; // задержка перед запуском
        [SerializeField] private PeriodBehavior1 _restorePeriod; // восстановление хп

        private void OnEnable()
        {
            takeDamageReceiver1.OnEvent += OnDamageTaken;
            _delay.OnEnded += OnDelayEnded;
            _restorePeriod.OnEvent += OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            takeDamageReceiver1.OnEvent -= OnDamageTaken;
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