using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class Vector3EventReceiver : MonoBehaviour
    {
        public Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 value)
        {
            this.OnEvent?.Invoke(value);
        }
    }
}