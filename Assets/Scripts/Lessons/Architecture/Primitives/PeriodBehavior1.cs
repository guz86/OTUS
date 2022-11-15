using System;
using System.Collections;
using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    // работает бесконечно
    public class PeriodBehavior1 : MonoBehaviour
    {
        public event Action OnEvent;

        private Coroutine _timerCoroutine;

        public bool IsPlaying
        {
            get { return _timerCoroutine != null; }
        }

        [SerializeField] private float _period = 1f;

        public void Play()
        {
            if (_timerCoroutine == null)
            {
                _timerCoroutine = this.StartCoroutine(this.PeriodRoutine());
            }
        }

        public void Stop()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(this._timerCoroutine);
                _timerCoroutine = null;
            }
        }

        private IEnumerator PeriodRoutine()
        {
            var period = new WaitForSeconds(_period);
            while (true)
            {
                yield return period;
                OnEvent?.Invoke();
            }
        }
    }
}