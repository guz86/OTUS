using System;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public sealed class FloatBehavior : MonoBehaviour
    {
        [SerializeField] private float _value;

        // чтобы на ячейку можно было подписаться и наблюдать как меняется значение
        public event Action<float> OnValueChanged;
        
        public float Value
        {
            get { return this._value; }
            set
            {
                this._value = value;
                this.OnValueChanged?.Invoke(value); // уведомляем что значение ячейки поменялось
            }
        }
    }
}