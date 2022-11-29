using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AttackBulletController : MonoBehaviour
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private AttackBulletInput _input;
        

        private IAttackBulletComponent _attackBulletComponent;

        private void Awake()
        {
            _attackBulletComponent = _unit.Get<IAttackBulletComponent>();
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
            _attackBulletComponent.Attack();
        }
    } 
}