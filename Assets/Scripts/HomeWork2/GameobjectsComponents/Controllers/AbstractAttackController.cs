using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public abstract class AbstractAttackController : MonoBehaviour
    {
        
        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                this.Attack();
            }
        }

        protected abstract void Attack();
    }
}