using System;
using UnityEngine;

namespace HomeWork
{
    [DisallowMultipleComponent]
    public sealed class EventReceiverCollision : MonoBehaviour
    {
        
        public event Action<Collision> OnCollisionEntered;

        public event Action<Collision> OnCollisionStaying; 

        public event Action<Collision> OnCollisionExited;
        
        private void OnCollisionEnter(Collision collision)
        {
            this.OnCollisionEntered?.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            this.OnCollisionStaying?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            this.OnCollisionExited?.Invoke(collision);
        }
    }
}