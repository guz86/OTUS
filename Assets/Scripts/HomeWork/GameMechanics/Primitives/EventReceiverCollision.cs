using System;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
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
            //Debug.Log("OnCollisionEntered" + collision + gameObject+ gameObject.tag);
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