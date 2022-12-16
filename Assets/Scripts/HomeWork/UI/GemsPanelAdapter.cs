using UnityEngine;

namespace HomeWork
{
    //ADAPTER
    public sealed class GemsPanelAdapter : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private CurrencyPanel currencyPanel;
        private GemsStorage _gemsStorage;

        void IConstructListener.Construct(GameContext context)
        {
            _gemsStorage = context.GetService<GemsStorage>();
            currencyPanel.SetupAmount(_gemsStorage.Gems.ToString());
        }

        void IStartGameListener.OnStartGame()
        {
            _gemsStorage.OnGemsChanged += OnGemsChanged;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _gemsStorage.OnGemsChanged -= OnGemsChanged;
        }

        private void OnGemsChanged(int money)
        {
            currencyPanel.UpdateAmount(money.ToString());
        }
    }
}