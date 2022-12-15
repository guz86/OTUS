using UnityEngine;

namespace HomeWork
{
    //ADAPTER
    public class MoneyPanelAdapter : MonoBehaviour,
    IConstructListener,
    IStartGameListener,
    IFinishGameListener
    {
        [SerializeField] private MoneyPanel _moneyPanel;
        private MoneyStorage _moneyStorage;

        void IConstructListener.Construct(GameContext context)
        {
            _moneyStorage = context.GetService<MoneyStorage>();
            _moneyPanel.SetupMoney(_moneyStorage.Money.ToString());
        }

        void IStartGameListener.OnStartGame()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
        
        private void OnMoneyChanged(BigNumber money)
        {
            _moneyPanel.UpdateMoney(money.ToString());
        }
    }
}