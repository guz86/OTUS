using System;
using UnityEngine;

namespace HomeWork
{
    public class SpeedChangedComponent : MonoBehaviour,
    ISpeedChangedComponent
    {
        [SerializeField] private FloatBehavior _speed;
    
        public event Action<float> OnSpeedChanged
        {
            add => _speed.OnValueChanged += value;
            remove => _speed.OnValueChanged -= value;
        }
       
        public float Speed => _speed.Value;
    }
}