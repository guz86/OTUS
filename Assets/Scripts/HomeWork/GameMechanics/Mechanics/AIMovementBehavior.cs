using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class AIMovementBehavior : MonoBehaviour
    {
        [SerializeField] private TimerBehavior _timer;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private MovementPositionRandomizer _movementPositionRandomizer;

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
                Move();
            }
        }

        private void Move()
        {
            var nextPosition = _movementPositionRandomizer.RandomPosition();
            _enemy.Move(nextPosition);
        }
    }
}