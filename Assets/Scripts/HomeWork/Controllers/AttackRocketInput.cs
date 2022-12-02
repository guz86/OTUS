using System;
using UnityEngine;

namespace HomeWork
{
    public sealed class AttackRocketInput : MonoBehaviour
    {
        public event Action OnAttack;
        
        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                OnAttack?.Invoke();
            }
        }

       
    }
}