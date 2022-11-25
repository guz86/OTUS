using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public sealed class Vector3EventReceiver : MonoBehaviour
    {
        public Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 value)
        {
            this.OnEvent?.Invoke(value);
        }
    }
}