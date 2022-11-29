using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AIMovementBehavior : MonoBehaviour
    {
        [SerializeField] private TimerBehavior _timer;
        [SerializeField] private Entity _unit;
        [SerializeField] private MovePositionRandomizer movePositionRandomizer;
        private IMoveInDirectionComponent _moveInDirectionComponent;

        private void Start()
        {
            _timer.Play();
            _moveInDirectionComponent = _unit.Get<IMoveInDirectionComponent>();
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
            _moveInDirectionComponent.Move(nextPosition);
        }
    }
}