using UnityEngine;

namespace HomeWork
{
    //ADAPTER
    public sealed class HitPointsParameterAdapter : MonoBehaviour,
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
            _character.Get<IHitPointsChangedComponent>().OnHitPointsChanged += this.UpdatePanel;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _character.Get<IHitPointsChangedComponent>().OnHitPointsChanged -= this.UpdatePanel;
        }

        private void SetupPanel()
        {
            var hitPoints = _character.Get<IHitPointsChangedComponent>().HitPoints;
            _panel.SetupValue(hitPoints.ToString());
        }

        private void UpdatePanel(int newHitPoints)
        {
            _panel.UpdateValue(newHitPoints.ToString());
        }
    }
}