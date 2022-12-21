using UnityEngine;

namespace HomeWork
{
    //ADAPTER
    public sealed class MoneyPanelAdapter : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private CurrencyPanel currencyPanel;
        private MoneyStorage _moneyStorage;

        void IConstructListener.Construct(GameContext context)
        {
            _moneyStorage = context.GetService<MoneyStorage>();
            currencyPanel.SetupValue(_moneyStorage.Money.ToString());
        }

        void IStartGameListener.OnStartGame()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int money)
        {
            currencyPanel.UpdateValue(money.ToString());
        }
    }
}