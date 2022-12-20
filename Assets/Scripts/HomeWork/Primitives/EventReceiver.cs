using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public Action OnEvent;

        [Button]
        public void Call()
        {
            OnEvent?.Invoke();
        }
    }
}