using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    //TEMP
    public sealed class Enemy : MonoBehaviour
    {

        [SerializeField] private IntEventReceiver1 takeDamageReceiver1;
        
        public void TakeDamage(int damage)
        {
            this.takeDamageReceiver1.Call(damage);
        }
    }
}