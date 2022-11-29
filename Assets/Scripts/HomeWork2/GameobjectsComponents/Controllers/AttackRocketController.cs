using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AttackRocketController : MonoBehaviour
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private AttackRocketInput _input;

        private IAttackRocketComponent _attackRocketComponent;

        private void Awake()
        {
            _attackRocketComponent = _unit.Get<IAttackRocketComponent>();
        }

        private void OnEnable()
        {
            _input.OnAttack += OnAttack;
        }
        
        private void OnDisable()
        {
            _input.OnAttack -= OnAttack;
        }

        private void OnAttack()
        {
            _attackRocketComponent.Attack();
        }
    } 
}