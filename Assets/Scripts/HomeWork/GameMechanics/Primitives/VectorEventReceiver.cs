using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class VectorEventReceiver : MonoBehaviour
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