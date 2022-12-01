using System;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public sealed class AttackBulletInput : MonoBehaviour
    {
        public event Action OnAttack;
        
        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnAttack?.Invoke();
            }
        }

        
    }
}