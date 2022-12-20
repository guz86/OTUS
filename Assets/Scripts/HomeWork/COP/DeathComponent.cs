using System;
using UnityEngine;

namespace HomeWork
{
    public class DeathComponent : MonoBehaviour,  IDeathComponent
    {
        [SerializeField] private EventReceiver _deathReceiver;
        
        public event Action OnDied;
        
        public void Die()
        {
            _deathReceiver.Call();
            OnDied?.Invoke();
        }
    }
}