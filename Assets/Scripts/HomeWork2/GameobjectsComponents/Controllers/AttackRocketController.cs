using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AttackRocketController : AbstractAttackRocketController
    {
        [SerializeField] private Entity _unit;

        private IAttackRocketComponent _attackRocketComponent;

        private void Awake()
        {
            _attackRocketComponent = _unit.Get<IAttackRocketComponent>();
        }
        
        protected override void Attack()
        {
            _attackRocketComponent.Attack();
        }
    } 
}