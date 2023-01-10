using System;
using UnityEngine;

namespace HomeWork
{
    public class PlayerPresentationModel : PlayerUpgraderPopup.IPlayerUpgraderPresentationModel
    {
        public event Action<bool> OnUpgradeButtonStateChanged;

        private PlayerUpgrader _playerUpgrader;

        private Upgrade _upgrade;

        private readonly MoneyStorage _moneyStorage;
        private readonly IHitPointsChangedComponent _hitPointsChangedComponent;
        private readonly ILevelUpgradeComponent _levelUpgradeComponent;
        private readonly IPlayerInfoComponent _playerInfoComponent;
        private readonly IBulletHitUpgade _bulletHitUpgade;
        private readonly IManaPointsChangedComponent _manaPointsChangedComponent;

        public PlayerPresentationModel(Upgrade upgrade, IEntity iEntity, PlayerUpgrader playerUpgrader,
            MoneyStorage moneyStorage)
        {
            _hitPointsChangedComponent = iEntity.Get<IHitPointsChangedComponent>();
            _manaPointsChangedComponent = iEntity.Get<IManaPointsChangedComponent>();
            _levelUpgradeComponent = iEntity.Get<ILevelUpgradeComponent>();
            _playerInfoComponent = iEntity.Get<IPlayerInfoComponent>();
            _bulletHitUpgade = iEntity.Get<IBulletHitUpgade>();

            _playerUpgrader = playerUpgrader;

            _moneyStorage = moneyStorage;

            _upgrade = upgrade;
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
            var canBuy = _playerUpgrader.CanBuy(_upgrade);
            OnUpgradeButtonStateChanged?.Invoke(canBuy);
        }


        public string GetHitPoints()
        {
            return _hitPointsChangedComponent.HitPoints.ToString();
        }

        public string GetMaxPoints()
        {
            return _hitPointsChangedComponent.MaxHitPoints.ToString();
        }

        public string GetManaPoints()
        {
            return _manaPointsChangedComponent.ManaPoints.ToString();
        }

        public void OnUpgradeClicked()
        {
            _playerUpgrader.Buy(_upgrade); // откуда брать сумму на апгрейд?
        }


        public string GetLevel()
        {
            return _levelUpgradeComponent.Level.ToString();
        }

        public string GetName()
        {
            return _playerInfoComponent.GetName();
        }

        public string GetDescription()
        {
            return _playerInfoComponent.GetDescription();
        }

        public Sprite GetIcon()
        {
            return _playerInfoComponent.GetIcon();
        }

        public string GetDamage()
        {
            return _bulletHitUpgade.Hit.ToString();
        }
    }
}