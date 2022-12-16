using UnityEngine;

namespace HomeWork
{
    public class MoveController : MonoBehaviour,
        IConstructListener, 
        IStartGameListener,
        IFinishGameListener, 
        IPauseGameListener, 
        IResumeGameListener
    {
        private MoveInput _input;
        
        private IMoveInDirectionComponent _moveInDirectionComponent;


        void IConstructListener.Construct(GameContext context)
        {
            _input = context.GetService<MoveInput>();
            Debug.Log(_input);
            _moveInDirectionComponent = context.GetService<CharacterService>()
                .GetCharacter()
                .Get<IMoveInDirectionComponent>();
        }
 
        public void OnStartGame()
        {
            _input.OnMove += OnMove;
        }

        public void OnFinishGame()
        {
            _input.OnMove -= OnMove;
        }

        public void OnPauseGame()
        {
            _input.OnMove -= OnMove;
        }

        public void OnResumeGame()
        {
            _input.OnMove += OnMove;
        }
        
        
        private void OnMove(Vector3 direction)
        {
            var velocity = direction * Time.deltaTime;
            Debug.Log(velocity);
            _moveInDirectionComponent.Move(velocity);
        }
    }
}