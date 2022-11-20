using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class AIShootMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _shootReceiver;
        [SerializeField] private TimerBehavior _timer;

        
        private void Start()
        {
            _timer.Play();
        }

        private void Update()
        {
            if (!_timer.IsPlaying)
            {
                _timer.ResetTime();
                _timer.Play();
                _shootReceiver.Call();
            }
        }

        private void OnAIShoot()
        {
            _shootReceiver.Call();
        }
    }
}