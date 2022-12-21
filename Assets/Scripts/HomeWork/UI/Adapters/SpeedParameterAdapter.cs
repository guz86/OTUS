using UnityEngine;

namespace HomeWork
{
    public class SpeedParameterAdapter : MonoBehaviour,
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
            _character.Get<ISpeedChangedComponent>().OnSpeedChanged += this.UpdatePanel;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _character.Get<ISpeedChangedComponent>().OnSpeedChanged -= this.UpdatePanel;
        }

        private void SetupPanel()
        {
            var speed = _character.Get<ISpeedChangedComponent>().Speed;
            _panel.SetupValue(speed.ToString());
        }

        private void UpdatePanel(float newSpeed)
        {
            _panel.UpdateValue(newSpeed.ToString());
        }
    }
}