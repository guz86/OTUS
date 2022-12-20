using UnityEngine;

namespace HomeWork
{
    //ADAPTER
    public class GameStartTimerAdapter : MonoBehaviour,
        IConstructListener,
        IReadyGameListener,
        IStartGameListener
    {
        [SerializeField] private CurrencyPanel _currencyPanel;
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _delayText;

        private GameStartTimer _timer;


        void IConstructListener.Construct(GameContext context)
        {
            _timer = context.GetService<GameStartTimer>();
            _currencyPanel.SetupAmount(_timer.Timer.ToString());
        }

        private void OnTimerStarted()
        {
            _panel.SetActive(true);
            _delayText.SetActive(true);
        }

        private void OnTimerEnded()
        {
            _panel.SetActive(false);
            _delayText.SetActive(false);
        }
        
        void IReadyGameListener.OnReadyGame()
        {
            _timer.OnTimeChanged += OnCountChanged;
            _timer.OnStarted += OnTimerStarted;
            _timer.OnEnded += OnTimerEnded;
        }
        
        void IStartGameListener.OnStartGame()
        {
            _timer.OnTimeChanged -= OnCountChanged;
            _timer.OnStarted -= OnTimerStarted;
            _timer.OnEnded -= OnTimerEnded;
        }

        private void OnCountChanged(int count)
        {
            _currencyPanel.UpdateAmount(count.ToString());
        }
    }
}