using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    //TEMP
    public sealed class Enemy : MonoBehaviour
    {

        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private Vector3EventReceiver _moveReceiver;
        
        public void TakeDamage(int damage)
        {
            this._takeDamageReceiver.Call(damage);
        }
        
        public void Move(Vector3 vector)
        {
            _moveReceiver.Call(vector);
        }
    }
}