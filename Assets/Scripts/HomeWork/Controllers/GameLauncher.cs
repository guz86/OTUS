using System;
using TMPro;
using UnityEngine;

namespace HomeWork
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private TimerBehavior _delay;
        [SerializeField] private TMP_Text _delayText;

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
            _delayText.gameObject.SetActive(true);
        }

        private void Update()
        {
            var timerText = _delay.Duration - _delay.CurrentTime;
            
            if (timerText > 1)
            {
                _delayText.text = Math.Round(timerText).ToString();
            }
            else
            {
                _delayText.text = "Go!";
            }
        }

        private void OnDelayEnded()
        {
            _delayText.gameObject.SetActive(false);
            _gameContext.StartGame();
        }
    }
}