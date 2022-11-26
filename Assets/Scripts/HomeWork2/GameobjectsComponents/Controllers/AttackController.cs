using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AttackController : AbstractAttackController
    {
        [SerializeField] private Entity _unit;

        private IAttackComponent _attackComponent;

        private void Awake()
        {
            _attackComponent = _unit.Get<IAttackComponent>();
        }
        
        protected override void Attack()
        {
            _attackComponent.Attack();
        }
    } 
}