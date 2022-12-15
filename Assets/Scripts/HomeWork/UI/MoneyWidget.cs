using TMPro;
using UnityEngine;
using DG.Tweening;

namespace HomeWork
{
    public class MoneyWidget : MonoBehaviour, 
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        private MoneyStorage _moneyStorage;

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
        
        private void OnMoneyChanged(BigNumber money)
        {
            _moneyText.text = money.ToString();
            AnimateTextBounce();
        }

        private void AnimateTextBounce()
        {
            DOTween
                .Sequence()
                 .Append(_moneyText.transform.DOScale(new Vector3(1.1f, 1.1f, 1.0f), 0.1f))
                 .Append(_moneyText.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.3f));
        }
    }
}