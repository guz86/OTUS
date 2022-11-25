using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public sealed class VectorEventReceiver : MonoBehaviour
    {
        public Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 value)
        {
            //Debug.Log($"Event {name} received");
            this.OnEvent?.Invoke(value);
        }
    }
}