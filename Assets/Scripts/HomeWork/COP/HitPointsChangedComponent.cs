using System;
using UnityEngine;

namespace HomeWork
{
    public class HitPointsChangedComponent : MonoBehaviour,
        IHitPointsChangedComponent
    {
        [SerializeField] private HitPointsEngine _hitPoints;

        public event Action<int> OnHitPointsChanged
        {
            add => _hitPoints.OnHitPointsChanged += value;
            remove => _hitPoints.OnHitPointsChanged -= value;
        }
        
        public int HitPoints
        {
            get { return _hitPoints.CurrentHitPoints; }
        }     
        
        public int MaxHitPoints
        {
            get { return _hitPoints.MaxHitPoints; }
        }
    }
}