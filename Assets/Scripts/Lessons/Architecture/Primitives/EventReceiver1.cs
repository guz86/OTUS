using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public sealed class EventReceiver1 : MonoBehaviour
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