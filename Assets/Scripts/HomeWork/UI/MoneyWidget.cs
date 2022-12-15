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
            Debug.Log("OnMoneyChanged(BigNumber money)");
            _moneyText.text = money.ToString();
            
            Debug.Log(" _moneyText.text "+  _moneyText.text);
            Debug.Log(" money.ToString() "+  money.ToString());
        }

        public void Construct(GameContext context)
        {
            _moneyStorage = context.GetService<MoneyStorage>();
            _moneyText.text = _moneyStorage.Money.ToString();
        }

        public void OnStartGame()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        public void OnFinishGame()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
    }
}