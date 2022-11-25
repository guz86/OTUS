﻿using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public sealed class IntEventReceiver : MonoBehaviour
    {
        public Action<int> OnEvent;

        [Button]
        public void Call(int value)
        {
            //Debug.Log($"Event {name} received");
            this.OnEvent?.Invoke(value);
        }
    }
}