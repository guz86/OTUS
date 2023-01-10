using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork
{
    public class PlayerUpgrader : MonoBehaviour, IConstructListener
    {
        private MoneyStorage _moneyStorage;
        private IEntity _entity;
        private IHitPointsUpgradeComponent _hitPointsUpgradeComponent;
        private ILevelUpgradeComponent _levelUpgradeComponent;
        private IBulletHitUpgade _bulletHitUpgade;
        private IManaPointsUpgradeComponent _manaPointsUpgradeComponent;

        [Button]
        public bool CanBuy(Upgrade upgrade)
        {
            _levelUpgradeComponent = _entity.Get<ILevelUpgradeComponent>();
            _hitPointsUpgradeComponent = _entity.Get<IHitPointsUpgradeComponent>();
            _manaPointsUpgradeComponent = _entity.Get<IManaPointsUpgradeComponent>();
            _bulletHitUpgade = _entity.Get<IBulletHitUpgade>();
            
            return _moneyStorage.Money >= upgrade.price &&
                   upgrade.level > _levelUpgradeComponent.Level;
        }

        [Button]
        public void Buy(Upgrade upgrade)
        {
            if (this.CanBuy(upgrade))
            {
                _moneyStorage.SpendMoney(upgrade.price);
                Debug.Log($"<color=green>Upgrade successfully!</color>");

                // stats Upgrade
                _levelUpgradeComponent.UpgradeLevel(upgrade.level);
                _hitPointsUpgradeComponent.UpgradeMaxHitPoints(upgrade.hitPoints);
                _hitPointsUpgradeComponent.UpgradeHitPoints(upgrade.hitPoints);
                _manaPointsUpgradeComponent.UpgradeManaPoints(upgrade.manaPoints);
                _bulletHitUpgade.UpgradeHit(upgrade.damage);
                
            }
            else
            {
                Debug.LogWarning($"<color=red>Not enough money for Upgrade or you already Upgrade!</color>");
            }
        }

        void IConstructListener.Construct(GameContext context)
        {
            _moneyStorage = context.GetService<MoneyStorage>();
            _entity = context.GetService<CharacterService>().GetCharacter();
        }
    }
}