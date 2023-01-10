using System;
using UnityEngine;

namespace HomeWork
{
    public class HitPointsUpgradeComponent : MonoBehaviour,
        IHitPointsUpgradeComponent
    {
        [SerializeField] private HitPointsEngine _hitPoints;

        public event Action<int> OnHitPointsUpgrate
        {
            add => _hitPoints.OnMaxHitPointsChanged += value;
            remove => _hitPoints.OnMaxHitPointsChanged -= value;
        }
        
        public void UpgradeHitPoints(int hitPoints) 
        {
            if (_hitPoints.MaxHitPoints <= hitPoints)
            {
                _hitPoints.CurrentHitPoints = hitPoints;
            }
        }
        
        public void UpgradeMaxHitPoints(int hitPoints) 
        {
            if (_hitPoints.MaxHitPoints <= hitPoints)
            {
                _hitPoints.MaxHitPoints = hitPoints;
            }
        }
                

    }
}