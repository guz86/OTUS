using System;
using UnityEngine;

namespace HomeWork
{
    public class BulletHitUpgade : MonoBehaviour,
        IBulletHitUpgade
    {
        [SerializeField] private IntBehaviour _hit;

        public event Action<int> OnBulletUpgrate
        {
            add => _hit.OnValueChanged += value;
            remove => _hit.OnValueChanged -= value;
        }
        
        public int Hit
        {
            get { return _hit.Value; }
        }
        
        public void UpgradeHit(int hit) 
        {
            if (_hit.Value <= hit)
            {
                _hit.Value = hit;
            }
        }
    }
}