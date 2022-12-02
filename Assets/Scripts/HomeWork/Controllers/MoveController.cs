using UnityEngine;

namespace HomeWork
{
    public class MoveController : AbstractMoveController, IStartGameListener,
        IFinishGameListener, IPauseGameListener
    {
        [SerializeField] private Entity _unit;
        private IMoveInDirectionComponent _moveInDirectionComponent;

        private void Awake()
        {
            _moveInDirectionComponent = _unit.Get<IMoveInDirectionComponent>();

            enabled = false;
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
    }
}