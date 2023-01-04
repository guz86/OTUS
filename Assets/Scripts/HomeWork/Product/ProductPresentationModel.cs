using System;
using UnityEngine;

namespace HomeWork
{
    public class ProductPresentationModel : ProductPopup.IPresentationModel
    {
        private readonly ProductBuyer _productBuyer;
        private readonly MoneyStorage _moneyStorage;
        private readonly  Product _product;

        public ProductPresentationModel(Product product,
                                        ProductBuyer productBuyer,
                                        MoneyStorage moneyStorage)
        {
            _product = product;
            _productBuyer = productBuyer;
            _moneyStorage = moneyStorage;
        }

        public string GetTitle()
        {
            return _product.title;
        }

        public void Start()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        public void Stop()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
        
        private void OnMoneyChanged(int money)
        {
             var canBuy = _productBuyer.CanBuy(_product);
             OnBuyButtonStateChanged?.Invoke(canBuy);
        }

        public string GetDescription()
        {
            return _product.description;
        }

        public Sprite GetIcon()
        {
            return _product.icon;
        }

        public string GetPrice()
        {
            return _product.price.ToString();
        }

        public bool CanBuy()
        {
            return _productBuyer.CanBuy(_product);
        }

        public void OnBuyClicked()
        {
            _productBuyer.Buy(_product);
        }

        public event Action<bool> OnBuyButtonStateChanged;

    }
}