using System;
using UnityEngine;

namespace HomeWork
{
    public sealed class IntBehaviour : MonoBehaviour
    {
        [SerializeField] private int _value;

        // чтобы на ячейку можно было подписаться и наблюдать как меняется значение
        public event Action<int> OnValueChanged;
        
        public int Value
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