using System;
using UnityEngine;

namespace HomeWork
{
    public class LevelUpgradeComponent : MonoBehaviour,
        ILevelUpgradeComponent
    {
        [SerializeField] private IntBehaviour _level;

        public event Action<int> OnLevelUpgrate
        {
            add => _level.OnValueChanged += value;
            remove => _level.OnValueChanged -= value;
        }
        
        public int Level
        {
            get { return _level.Value; }
        }
        
        public void UpgradeLevel(int level) 
        {
            if (_level.Value <= level)
            {
                _level.Value = level;
            }
        }
    }
}