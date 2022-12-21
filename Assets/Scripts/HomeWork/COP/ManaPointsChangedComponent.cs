using System;
using UnityEngine;

namespace HomeWork
{
    public class ManaPointsChangedComponent : MonoBehaviour,
        IManaPointsChangedComponent
    {
        [SerializeField] private IntBehaviour _manaPoints;

        public event Action<int> OnManaPointsChanged
        {
            add => _manaPoints.OnValueChanged += value;
            remove => _manaPoints.OnValueChanged -= value;
        }
        
        public int ManaPoints
        {
            get { return _manaPoints.Value; }
        }
    }
}