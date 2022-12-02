using UnityEngine;

namespace HomeWork
{
    public class RestoreManaPointsMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _shootRocketReceiver;
        [SerializeField] private IntBehaviour _manaPoints;
        [SerializeField] private TimerBehavior _delay; 
        [SerializeField] private PeriodBehavior _restorePeriod; 

        private void OnEnable()
        {
            _shootRocketReceiver.OnEvent += OnShootRocket;
            _delay.OnEnded += OnDelayEnded;
            _restorePeriod.OnEvent += OnRestoreManaPoints;
        }

        private void OnDisable()
        {
            _shootRocketReceiver.OnEvent -= OnShootRocket;
            _delay.OnEnded -= OnDelayEnded;
            _restorePeriod.OnEvent -= OnRestoreManaPoints;
        }

        private void OnRestoreManaPoints()
        {
            _manaPoints.Value += 1;
            if (_manaPoints.Value >=10)
            {
                _restorePeriod.Stop();
            }
        }

        private void OnDelayEnded()
        {
            _restorePeriod.Play();
        }

        private void OnShootRocket()
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