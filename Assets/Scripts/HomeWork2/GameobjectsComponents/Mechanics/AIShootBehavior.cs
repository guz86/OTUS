using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AIShootBehavior : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
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
                _enemy.Shoot();
            }
        }
    }
}