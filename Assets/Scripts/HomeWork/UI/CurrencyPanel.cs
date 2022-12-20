using DG.Tweening;
using TMPro;
using UnityEngine;

namespace HomeWork
{
    //VIEW
    public sealed class CurrencyPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amountText;

        public void SetupAmount(string amount)
        {
            _amountText.text = amount;
        }
        
        public void UpdateAmount(string amount)
        {
            _amountText.text = amount;
            AnimateTextBounce();
        }
        
        private void AnimateTextBounce()
        {
            DOTween
                .Sequence()
                .Append(_amountText.transform.DOScale(new Vector3(1.1f, 1.1f, 1.0f), 0.1f))
                .Append(_amountText.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.3f));
        }
    }
}