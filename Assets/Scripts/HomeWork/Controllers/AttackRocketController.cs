using UnityEngine;

namespace HomeWork
{
    public class AttackRocketController : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener,
        IPauseGameListener,
        IResumeGameListener
    {
        [SerializeField] private AttackRocketInput _input;

        private IAttackRocketComponent _attackRocketComponent;

        void IConstructListener.Construct(GameContext context)
        {
            _attackRocketComponent = context
                .GetService<CharacterService>()
                .GetCharacter()
                .Get<IAttackRocketComponent>();
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
            _attackRocketComponent.Attack();
        }
    }
}