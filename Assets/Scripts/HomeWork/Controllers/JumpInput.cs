using System;
using UnityEngine;

namespace HomeWork
{
    public class JumpInput : MonoBehaviour,
        IStartGameListener,
        IFinishGameListener,
        IPauseGameListener,
        IResumeGameListener
    {
        public event Action OnJump;

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }
        }

        public void OnStartGame()
        {
            enabled = true;
        }

        public void OnFinishGame()
        {
            enabled = false;
        }

        public void OnPauseGame()
        {
            enabled = false;
        }

        public void OnResumeGame()
        {
            enabled = true;
        }
    }
}