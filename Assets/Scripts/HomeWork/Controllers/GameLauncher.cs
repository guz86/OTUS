using UnityEngine;

namespace HomeWork
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private GameStartTimer _timer;

        private int _gameTime;
        
        private void OnEnable()
        {
            _timer.OnEnded += OnDelayEnded;
        }

        private void OnDisable()
        {
            _timer.OnEnded -= OnDelayEnded;
        }

        private void Start()
        {
            _gameContext.ConstructGame();
            _gameContext.ReadyGame();
            _timer.Play();
        }
 
        private void OnDelayEnded()
        {  
            _gameContext.StartGame();
        }
    }
}