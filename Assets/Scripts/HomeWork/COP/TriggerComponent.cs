using System;
using UnityEngine;

namespace HomeWork
{
    public class TriggerComponent : MonoBehaviour, 
        ITriggerComponent
    {
        [SerializeField] private EventReceiverTrigger _triggerReceiver;


        public event Action<Collider> OnTriggerEntered
        {
            add => _triggerReceiver.OnTriggerEntered += value;
            remove => _triggerReceiver.OnTriggerExited -= value;
        }
    }
}