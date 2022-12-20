using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork
{
    public class GameStartTimer : MonoBehaviour
    {
        [SerializeField] private float _duration; // сколько секунд работает
        [ReadOnly] [SerializeField] private float _currentTime; // секунды на таймере
        [ReadOnly] [ShowInInspector] private int timer;

        public event Action<int> OnTimeChanged;
        public event Action OnStarted;
        public event Action OnEnded;

        private Coroutine _timerCoroutine;
        private int _gameTime;

        public int Timer
        {
            get { return this.timer; }
        }

        private void UpdateTime(int timer)
        {
            this.timer = timer;
            this.OnTimeChanged?.Invoke(this.timer);
        }
 
        public void Play()
        {
            if (this._timerCoroutine == null)
            {
                this._timerCoroutine = this.StartCoroutine(this.TimerRoutine());
            }
            this.OnStarted?.Invoke();
        }

        private IEnumerator TimerRoutine()
        {
            while (this._currentTime < this._duration)
            {
                yield return null;
                this._currentTime += Time.deltaTime;
                // логика обновления
                if (_currentTime >= _gameTime)
                {
                    UpdateTime(Convert.ToInt32(_duration) - _gameTime);
                    _gameTime += 1;
                }
            }
            
            this._currentTime = this._duration;
            this._timerCoroutine = null;
            this.OnEnded?.Invoke();
        }
    }
    
    

}