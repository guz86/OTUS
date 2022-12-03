using UnityEngine;

namespace HomeWork
{
    public class MoveController : AbstractMoveController, IConstructListener, IStartGameListener,
        IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        //[SerializeField] private Entity _unit;
        
        //[Inject]
        private IMoveInDirectionComponent _moveInDirectionComponent;

        private void Awake()
        {
            //    _moveInDirectionComponent = _unit.Get<IMoveInDirectionComponent>();

            enabled = false;
        }

        //[Inject]
        // public void Construct(IEntity unit)
        // {
        //     _moveInDirectionComponent = unit.Get<IMoveInDirectionComponent>();
        // }
        
        //public void Construct(ServiceLocator serviceLocator)
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