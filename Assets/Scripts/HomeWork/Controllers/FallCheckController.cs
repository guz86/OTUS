using UnityEngine;

namespace HomeWork
{
    public class FallCheckController : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private string _colliderTag = "Finish";
        
        private IEntity _character;
        
        void IConstructListener.Construct(GameContext context)
        {
            _character = context.GetService<CharacterService>().GetCharacter();
        }

        void IStartGameListener.OnStartGame()
        {
            _character.Get<ITriggerComponent>().OnTriggerEntered += OnHeroEntered;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _character.Get<ITriggerComponent>().OnTriggerEntered -= OnHeroEntered;
        }

        private void OnHeroEntered(Collider other)
        {
            if (other.CompareTag(_colliderTag))
            {
                _character.Get<IDeathComponent>().Die(); 
            }
        }
    }
}