using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private IntBehaviour _hitPoints;
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private EventReceiver _deathReceiver;
        [SerializeField] private Vector3EventReceiver _moveReceiver;

        public event Action<int> OnHitPointChanged
        {
            add { _hitPoints.OnValueChanged += value;}
            remove { _hitPoints.OnValueChanged -= value; }
        } 
        
        public int HitPoints
        {
            get { return _hitPoints.Value; }
        }
        
        public event Action OnDeath
        {
            add { _deathReceiver.OnEvent += value;}
            remove { _deathReceiver.OnEvent -= value; }
        } 
        
        [Button]
        public void Attack()
        {
            _attackReceiver.Call();
        }
        
        public void TakeDamage(int damage)
        {
            _takeDamageReceiver.Call(damage);
        }   
        
        public void Move(Vector3 vector)
        {
            _moveReceiver.Call(vector);
        }
        
    }
}