using System;
using UnityEngine;

namespace HomeWork
{
    public class HitPointsChangedComponent : MonoBehaviour,
        IHitPointsChangedComponent
    {
        [SerializeField] private IntBehaviour _hitPoints;

        public event Action<int> OnHitPointsChanged
        {
            add => _hitPoints.OnValueChanged += value;
            remove => _hitPoints.OnValueChanged -= value;
        }
        
        public int HitPoints
        {
            get { return _hitPoints.Value; }
        }
    }
}