using UnityEngine;

namespace HomeWork
{
    public class DelayStartGameController: MonoBehaviour
    {
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private TimerBehavior _delay;
        
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
        }
        
        private void OnDelayEnded()
        {
            _gameContext.StartGame();
        }
        
        // private IEnumerator StartGame()
        // {
        //     yield return new WaitForSeconds(3f);
        //     _gameContext.StartGame();
        //     Debug.Log("IEnumerator StartGame()");
        // }
    }
}