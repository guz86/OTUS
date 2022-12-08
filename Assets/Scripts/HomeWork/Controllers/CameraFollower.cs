using UnityEngine;

namespace HomeWork
{
    public class CameraFollower : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        private Transform _targetCamera;

        private ITransformComponent _characterComponent;

        [SerializeField]
        private Vector3 offset;

        private void Awake()
        {
            this.enabled = false;
        }

        private void LateUpdate()
        {
            var newPosition = _characterComponent.GetPosition() + offset;
            _targetCamera.position = newPosition;
            //Debug.Log("LateUpdate newPosition" + newPosition);
        }

        void IConstructListener.Construct(GameContext context)
        {
            this._targetCamera = context
                .GetService<CameraService>()
                .CameraTransform;

            this._characterComponent = context
                .GetService<CharacterService>()
                .GetCharacter()
                .Get<ITransformComponent>();
        }

        void IStartGameListener.OnStartGame()
        {
            this.enabled = true;
        }

        void IFinishGameListener.OnFinishGame()
        {
            this.enabled = false;
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