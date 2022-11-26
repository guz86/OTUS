using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public abstract class AbstractAttackRocketController : MonoBehaviour
    {
        
        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                this.Attack();
            }
        }

        protected abstract void Attack();
    }
}