using UnityEngine;

namespace HomeWork
{
    public class MoveController : AbstractMoveController, 
        IConstructListener, 
        IStartGameListener,
        IFinishGameListener, 
        IPauseGameListener, 
        IResumeGameListener
    {
        private IMoveInDirectionComponent _moveInDirectionComponent;

        private void Awake()
        {
            enabled = false;
        }

        void IConstructListener.Construct(GameContext context)
        {
            _moveInDirectionComponent = context.GetService<CharacterService>()
                .GetCharacter()
                .Get<IMoveInDirectionComponent>();
        }

        protected override void Move(Vector3 direction)
        {
            var velocity = direction * Time.deltaTime;
            _moveInDirectionComponent.Move(velocity);
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
    }
}