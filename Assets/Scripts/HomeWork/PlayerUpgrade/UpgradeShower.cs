using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork.Player
{
    public class UpgradeShower : MonoBehaviour, IConstructListener
    {
        private PopupManager popupManager;
        private UpgraderPresentationModelFactory presenterFactory;
        
        
        [Button]
        public void ShowUpgrade(Upgrade upgrade)
        {
            var presentationModel = this.presenterFactory.CreatePresenter(upgrade);
            this.popupManager.ShowPopup(PopupName.UPGRADE, presentationModel);
        }
        
        public void Construct(GameContext context)
        {
            this.popupManager = context.GetService<PopupManager>();
            this.presenterFactory = context.GetService<UpgraderPresentationModelFactory>();

        }
    }
}