using UnityEngine;

namespace HomeWork
{
    public class JumpController : AbstractJumpController, IStartGameListener,
        IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        [SerializeField] private Entity _unit;

        private IJumpComponent _jumpComponent;

        private void Awake()
        {
            _jumpComponent = _unit.Get<IJumpComponent>();
            enabled = false;
        }
        
        void IStartGameListener.OnStartGame()
        {
            enabled = true;
        }

        void IFinishGameListener.OnFinishGame()
        {
            enabled = false;
        }
        
        void IPauseGameListener.OnPauseGame()
        {
            enabled = false;
        }

        void IResumeGameListener.OnResumeGame()
        {
            enabled = true;
        }
        
        protected override void Jump()
        {
            _jumpComponent.Jump();
        }
    } 
}