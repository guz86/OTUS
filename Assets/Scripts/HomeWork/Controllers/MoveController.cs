using UnityEngine;

namespace HomeWork
{
    public class MoveController : AbstractMoveController
    {
        [SerializeField] private Entity _unit;

        private IMoveInDirectionComponent _moveInDirectionComponent;

        private void Awake()
        {
            _moveInDirectionComponent = _unit.Get<IMoveInDirectionComponent>();
        }

        protected override void Move(Vector3 direction)
        {
            var velocity = direction * Time.deltaTime;
            _moveInDirectionComponent.Move(velocity);
        }
    }
}