using UnityEngine;

namespace HomeWork
{
    public class RestoreHitPointsMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver takeDamageReceiver;
        [SerializeField] private HitPointsEngine _hitPoints;
        [SerializeField] private TimerBehavior _delay; 
        [SerializeField] private PeriodBehavior _restorePeriod; 

        private void OnEnable()
        {
            takeDamageReceiver.OnEvent += OnDamageTaken;
            _delay.OnEnded += OnDelayEnded;
            _restorePeriod.OnEvent += OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            takeDamageReceiver.OnEvent -= OnDamageTaken;
            _delay.OnEnded -= OnDelayEnded;
            _restorePeriod.OnEvent -= OnRestoreHitPoints;
        }

        private void OnRestoreHitPoints()
        {
            _hitPoints.CurrentHitPoints += 1;
            if (_hitPoints.CurrentHitPoints >=_hitPoints.MaxHitPoints)
            {
                _restorePeriod.Stop();
            }
        }

        private void OnDelayEnded()
        {
            _restorePeriod.Play();
        }

        private void OnDamageTaken(int damage)
        {
            _delay.ResetTime();
            if (!_delay.IsPlaying)
            {
                _delay.Play();
            }
            _restorePeriod.Stop();
        }
    }
}