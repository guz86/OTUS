using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork
{
    public class StartTimerStorage : MonoBehaviour
    {
        public event Action<int> OnTimeChanged;

        public int Timer
        {
            get { return this.timer; }
        }

        [ReadOnly]
        [ShowInInspector]
        private int timer;

        [Button]
        public void UpdateTime(int timer)
        {
            this.timer = timer;
            this.OnTimeChanged?.Invoke(this.timer);
        }
    }
}