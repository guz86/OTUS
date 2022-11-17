using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class AIMovementMechanics : MonoBehaviour
    {
        [SerializeField] private RandomMovementMechanics _randomMovementMechanics;
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
                _randomMovementMechanics.OnMove();
            }
        }
    }
}