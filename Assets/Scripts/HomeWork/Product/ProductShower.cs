using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork
{
    public class ProductShower : MonoBehaviour, IConstructListener
    {
        private PopupManager popupManager;
        private ProductPresentationModelFactory presenterFactory;
        
        [Button]
        public void ShowProduct(Product product)
        {
            var presentationModel = this.presenterFactory.CreatePresenter(product);
            this.popupManager.ShowPopup(PopupName.PRODUCT, presentationModel);
        }

        public void Construct(GameContext context)
        {
            this.popupManager = context.GetService<PopupManager>();
            this.presenterFactory = context.GetService<ProductPresentationModelFactory>();
        }
    }
}