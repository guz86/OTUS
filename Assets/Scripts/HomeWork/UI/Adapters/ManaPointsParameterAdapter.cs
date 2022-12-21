using UnityEngine;

namespace HomeWork
{
    public class ManaPointsParameterAdapter : MonoBehaviour,
        IConstructListener,
        IReadyGameListener,
        IFinishGameListener
    {
        [SerializeField] private CurrencyPanel _panel;

        private IEntity _character;

        void IConstructListener.Construct(GameContext context)
        {
            _character = context.GetService<CharacterService>().GetCharacter();
            SetupPanel();
        }

        void IReadyGameListener.OnReadyGame()
        {
            _character.Get<IManaPointsChangedComponent>().OnManaPointsChanged += this.UpdatePanel;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _character.Get<IManaPointsChangedComponent>().OnManaPointsChanged -= this.UpdatePanel;
        }

        private void SetupPanel()
        {
            var manaPoints = _character.Get<IManaPointsChangedComponent>().ManaPoints;
            _panel.SetupValue(manaPoints.ToString());
        }

        private void UpdatePanel(int newManaPoints)
        {
            _panel.UpdateValue(newManaPoints.ToString());
        }
    }
}