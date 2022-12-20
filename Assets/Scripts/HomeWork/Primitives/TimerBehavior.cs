using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork
{
    public sealed class TimerBehavior : MonoBehaviour
    {
        public event Action OnEnded;

        [SerializeField] private float _duration; // сколько секунд работает
        [ReadOnly][SerializeField] private float _currentTime; // секунды на таймере

        private Coroutine _timerCoroutine;

        public float CurrentTime => _currentTime;
        public float Duration => _duration;
        
        public bool IsPlaying
        {
            get { return this._timerCoroutine != null; }
        }
        
        public void Play()
        {
            if (this._timerCoroutine == null)
            {
                this._timerCoroutine = this.StartCoroutine(this.TimerRoutine());
            }
        }


        public void Stop()
        {
            if (this._timerCoroutine != null)
            {
                this.StopCoroutine(this._timerCoroutine);
                this._timerCoroutine = null;
            }
        }

        public void ResetTime()
        {
            this._currentTime = 0;
        }
        
        private IEnumerator TimerRoutine()
        {
            while (this._currentTime < this._duration)
            {
                yield return null;
                this._currentTime += Time.deltaTime;
            }
            
            this._currentTime = this._duration;
            this._timerCoroutine = null;
            this.OnEnded?.Invoke();
        }

    }
}
