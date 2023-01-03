using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWork
{
    public sealed class ProductPopup : Popup, IConstructListener
    {
        [SerializeField] private TextMeshProUGUI _titleText;

        [SerializeField] private TextMeshProUGUI _descriptionText;

        [SerializeField] private Image _iconImage;

        [SerializeField] private BuyButton _buyButton;

        private ProductBuyer _productBuyer;
        private MoneyStorage _moneyStorage;

        private Product _product;

        protected override void OnShow(object args)
        {
            if (args is not Product product)
            {
                throw new Exception("Expected product!");
            }

            _product = product;

            _titleText.text = product.title;
            _descriptionText.text = product.description;
            _iconImage.sprite = product.icon;

            _buyButton.SetPrice(product.price.ToString());
            _buyButton.SetAvailable(_productBuyer.CanBuy(product));
            _buyButton.AddListener(OnBuyButtonClicked);

            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        protected override void OnHide()
        {
            _buyButton.RemoveListener(OnBuyButtonClicked);
        }

        private void OnBuyButtonClicked()
        {
            _productBuyer.Buy(_product);
        }

        private void OnMoneyChanged(int money)
        {
            _buyButton.SetAvailable(_productBuyer.CanBuy(_product));
        }

        public void Construct(GameContext context)
        {
            _productBuyer = context.GetService<ProductBuyer>();
            _moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}