using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    //TEMP
    public sealed class Enemy : MonoBehaviour
    {

        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
            this._takeDamageReceiver.Call(damage);
        }
    }
}