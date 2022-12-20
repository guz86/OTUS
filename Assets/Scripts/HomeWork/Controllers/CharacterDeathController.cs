using UnityEngine;

namespace HomeWork
{
    public class CharacterDeathController : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    { 
        private GameContext _gameContext;
        private IEntity _character;

        void IConstructListener.Construct(GameContext context)
        {
            _gameContext = context;
            _character = context.GetService<CharacterService>().GetCharacter();
        }

        void IStartGameListener.OnStartGame()
        {
            _character.Get<IDeathComponent>().OnDied += OnHeroDied;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _character.Get<IDeathComponent>().OnDied -= OnHeroDied;
        }

        private void OnHeroDied()
        {
            _gameContext.FinishGame();
        }
    }
}