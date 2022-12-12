using UnityEngine;

namespace HomeWork
{
    public sealed class AttackBulletController : MonoBehaviour, 
        IConstructListener,
        IStartGameListener,
        IFinishGameListener, 
        IPauseGameListener, 
        IResumeGameListener
    { 
        [SerializeField] private AttackBulletInput _input;

        private IAttackBulletComponent _attackBulletComponent;

        public void Construct(GameContext context)
        {
            _attackBulletComponent = context
                .GetService<CharacterService>()
                .GetCharacter()
                .Get<IAttackBulletComponent>();
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