namespace HomeWork
{
    public class JumpController : AbstractJumpController,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener,
        IPauseGameListener,
        IResumeGameListener
    {
        private IJumpComponent _jumpComponent;

        private void Awake()
        {
            enabled = false;
        }

        void IConstructListener.Construct(GameContext context)
        {
            _jumpComponent = context
                .GetService<CharacterService>()
                .GetCharacter()
                .Get<IJumpComponent>();
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