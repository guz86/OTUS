using TMPro;
using UnityEngine;

namespace HomeWork
{
    public class MoneyWidget : MonoBehaviour, 
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        private MoneyStorage _moneyStorage;

        private void OnMoneyChanged(BigNumber money)
        {
            _moneyText.text = money.ToString();
        }

        void IConstructListener.Construct(GameContext context)
        {
            _moneyStorage = context.GetService<MoneyStorage>();
            _moneyText.text = _moneyStorage.Money.ToString();
        }

        void IStartGameListener.OnStartGame()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
        
        
    }
}