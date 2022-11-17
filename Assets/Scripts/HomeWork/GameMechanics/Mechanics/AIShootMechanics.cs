using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class AIShootMechanics : MonoBehaviour
    {
        [SerializeField] private ShootMechanics _shootMechanics;
        [SerializeField] private EventReceiver _eventReceiver;
        [SerializeField] private TimerBehavior _timer;

        private void Update()
        {
            if (!_timer.IsPlaying)
            {
                _timer.ResetTime();
                _timer.Play();
                _shootMechanics.OnShoot();
            }
        }

        private void OnEnable()
        {
            _eventReceiver.OnEvent += OnAIShoot;
        }

        private void OnDisable()
        {
            _eventReceiver.OnEvent -= OnAIShoot;
        }

        private void OnAIShoot()
        {
            _shootMechanics.OnShoot();
        }
    }
}