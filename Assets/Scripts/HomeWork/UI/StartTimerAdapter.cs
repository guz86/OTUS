using UnityEngine;

namespace HomeWork
{
    //ADAPTER
    public class StartTimerAdapter : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private CurrencyPanel currencyPanel;
        private StartTimerStorage _timerStorage;
        
        void IConstructListener.Construct(GameContext context)
        {
            _timerStorage = context.GetService<StartTimerStorage>();
            currencyPanel.SetupAmount(_timerStorage.Timer.ToString());
            
            _timerStorage.OnTimeChanged += OnCountChanged;
        }

        void IStartGameListener.OnStartGame()
        { 
            _timerStorage.OnTimeChanged -= OnCountChanged;
        }

        void IFinishGameListener.OnFinishGame()
        {
            
        }
        
        private void OnCountChanged(int count)
        {
            currencyPanel.UpdateAmount(count.ToString());
        }
    }
}