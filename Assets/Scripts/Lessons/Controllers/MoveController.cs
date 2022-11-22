using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class MoveController : AbstractMoveController
    {
        [SerializeField] private Entity _unit;
        
        protected override void Move(Vector3 direction)
        {
            const float speed = 5.0f;
            var velocity = direction * (speed * Time.deltaTime);
            _unit.Get<IMoveComponent>().Move(velocity);
        }
    }
}