using UnityEngine;

namespace HomeWork
{
    public class AttackRocketController : MonoBehaviour, IStartGameListener,
        IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private AttackRocketInput _input;

        private IAttackRocketComponent _attackRocketComponent;

        private void Awake()
        {
            _attackRocketComponent = _unit.Get<IAttackRocketComponent>();
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