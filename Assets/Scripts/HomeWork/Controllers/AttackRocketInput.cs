using System;
using UnityEngine;

namespace HomeWork
{
    public sealed class AttackRocketInput : MonoBehaviour, IStartGameListener,
        IFinishGameListener, IPauseGameListener, IResumeGameListener
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

        void IStartGameListener.OnStartGame()
        {
            enabled = true;
        }

        void IFinishGameListener.OnFinishGame()
        {
            enabled = false;
        }

        void IPauseGameListener.OnPauseGame()
        {
            enabled = false;
        }

        void IResumeGameListener.OnResumeGame()
        {
            enabled = true;
        }
    }
}