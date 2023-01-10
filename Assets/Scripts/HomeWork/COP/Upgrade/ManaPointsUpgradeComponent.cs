using System;
using UnityEngine;

namespace HomeWork
{
    public class ManaPointsUpgradeComponent : MonoBehaviour,
        IManaPointsUpgradeComponent
    {
        [SerializeField] private IntBehaviour _manaPoints;

        public event Action<int> OnManaPointsUpgrate
        {
            add => _manaPoints.OnValueChanged += value;
            remove => _manaPoints.OnValueChanged -= value;
        }
        
        public void UpgradeManaPoints(int manaPoints) 
        {
            if (_manaPoints.Value <= manaPoints)
            {
                _manaPoints.Value = manaPoints;
            }
        }
    }
}