using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public Action OnEvent;

        [Button]
        public void Call()
        {
            Debug.Log($"Event {name} received");
            OnEvent?.Invoke();
        }
    }
}