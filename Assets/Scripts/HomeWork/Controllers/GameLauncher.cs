using System;
using UnityEngine;

namespace HomeWork
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private TimerBehavior _delay;
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _delayText;
        [SerializeField] private StartTimerStorage _timerStorage;

        private int _gameTime;
        
        private void OnEnable()
        {
            _delay.OnEnded += OnDelayEnded;
        }

        private void OnDisable()
        {
            _delay.OnEnded -= OnDelayEnded;
        }

        private void Start()
        {
            _gameContext.ConstructGame();
            _delay.Play();
            _panel.SetActive(true);
            _delayText.SetActive(true);
        }

        private void Update()
        {
            if (_delay.CurrentTime >= _gameTime)
            {
                _timerStorage.UpdateTime(Convert.ToInt32(_delay.Duration) -_gameTime);
                _gameTime += 1;
            }
        }

        private void OnDelayEnded()
        {
            _panel.SetActive(false);
            _delayText.SetActive(false);
            _gameContext.StartGame();
        }
    }
}