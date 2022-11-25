using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public abstract class AbstractJumpController : MonoBehaviour
    {
        
        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                this.Jump();
            }
        }

        protected abstract void Jump();
    }
}