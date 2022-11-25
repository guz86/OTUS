using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class MoveController : AbstractMoveController
    {
        [SerializeField] private Entity _unit;

        private IMoveComponent _moveComponent;

        private void Awake()
        {
            _moveComponent = _unit.Get<IMoveComponent>();
        }

        protected override void Move(Vector3 direction)
        {
            const float speed = 5.0f;
            var velocity = direction * (speed * Time.deltaTime);
            _moveComponent.Move(velocity);
        }
    }
}