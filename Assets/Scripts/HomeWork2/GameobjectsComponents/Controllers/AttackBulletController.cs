using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AttackBulletController : MonoBehaviour
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private AttackBulletInput _input;
        

        private IAttackComponent _attackComponent;

        private void Awake()
        {
            _attackComponent = _unit.Get<IAttackComponent>();
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
            _attackComponent.Attack();
        }
    } 
}