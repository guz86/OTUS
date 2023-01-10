using UnityEngine;

namespace HomeWork
{
    public class UpgraderPresentationModelFactory : MonoBehaviour, IConstructListener
    {
        private IEntity entity;
        
        private PlayerUpgrader playerUpgrader;

        private MoneyStorage moneyStorage;
    
        public PlayerPresentationModel CreatePresenter(Upgrade upgrade)
        {
            return new PlayerPresentationModel(upgrade, 
                this.entity, 
                this.playerUpgrader, 
                this.moneyStorage);
        }

        void IConstructListener.Construct(GameContext context)
        {
            this.entity = context.GetService<CharacterService>().GetCharacter();
            this.playerUpgrader = context.GetService<PlayerUpgrader>();
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}