using System;
using UnityEngine;

namespace HomeWork
{
    public class HitPointsEngine : MonoBehaviour
    {
        [SerializeField] private int _maxHitPoints;

        [SerializeField] private int _currentHitPoints;

        public event Action OnSetuped;

        public event Action<int> OnHitPointsChanged;

        public event Action<int> OnMaxHitPointsChanged;

        public event Action OnHitPointsFull;

        public event Action OnHitPointsEmpty;

        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set { SetHitPoints(value); }
        }

        public int MaxHitPoints
        {
            get { return _maxHitPoints; }
            set { SetMaxHitPoints(value); }
        }

        public void Setup(int current, int max)
        {
            _maxHitPoints = max;
            _currentHitPoints = Mathf.Clamp(current, 0, _maxHitPoints);
            OnSetuped?.Invoke();
        }

        private void SetHitPoints(int value)
        {
            value = Mathf.Clamp(value, 0, _maxHitPoints);
            _currentHitPoints = value;
            OnHitPointsChanged?.Invoke(_currentHitPoints);

            if (value <= 0)
            {
                this.OnHitPointsEmpty?.Invoke();
            }

            if (value >= _maxHitPoints)
            {
                this.OnHitPointsFull?.Invoke();
            }
        }

        private void SetMaxHitPoints(int value)
        {
            value = Math.Max(1, value);
            if (_currentHitPoints > value)
            {
                _currentHitPoints = value;
            }

            _maxHitPoints = value;
            OnMaxHitPointsChanged?.Invoke(value);
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            _maxHitPoints = Math.Max(1, _maxHitPoints);
            _currentHitPoints = Mathf.Clamp(_currentHitPoints, 1, _maxHitPoints);
        }
#endif
    }
}