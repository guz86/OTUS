using UnityEngine;

namespace HomeWork
{
    public sealed class AttackBulletController : MonoBehaviour, IStartGameListener,
        IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private AttackBulletInput _input;


        private IAttackBulletComponent _attackBulletComponent;

        private void Awake()
        {
            _attackBulletComponent = _unit.Get<IAttackBulletComponent>();
        }

        void IStartGameListener.OnStartGame()
        {
            _input.OnAttack += OnAttack;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _input.OnAttack -= OnAttack;
        }
        
        void IPauseGameListener.OnPauseGame()
        {
            _input.OnAttack -= OnAttack;
        }

        void IResumeGameListener.OnResumeGame()
        {
            _input.OnAttack += OnAttack;
        }

        private void OnAttack()
        {
            _attackBulletComponent.Attack();
        }
    }
}