using UnityEngine;

namespace HomeWork
{
    public class JumpController : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener,
        IPauseGameListener,
        IResumeGameListener
    {
        private JumpInput _input;
        private IJumpComponent _jumpComponent;

        private void Awake()
        {
            enabled = false;
        }

        void IConstructListener.Construct(GameContext context)
        {
            _input = context
                .GetService<JumpInput>();
            _jumpComponent = context
                .GetService<CharacterService>()
                .GetCharacter()
                .Get<IJumpComponent>();
        }


        void IStartGameListener.OnStartGame()
        {
            _input.OnJump += OnJump;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _input.OnJump -= OnJump;
        }

        void IPauseGameListener.OnPauseGame()
        {
            _input.OnJump -= OnJump;
        }

        void IResumeGameListener.OnResumeGame()
        {
            _input.OnJump += OnJump;
        }

        private void OnJump()
        {
            _jumpComponent.Jump();
        }
    }
}