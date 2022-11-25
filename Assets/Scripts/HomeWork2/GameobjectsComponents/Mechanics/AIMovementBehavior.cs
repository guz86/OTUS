using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AIMovementBehavior : MonoBehaviour
    {
        [SerializeField] private TimerBehavior _timer;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private MovePositionRandomizer movePositionRandomizer;

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
            var nextPosition = movePositionRandomizer.RandomPosition();
            _enemy.Move(nextPosition);
        }
    }
}