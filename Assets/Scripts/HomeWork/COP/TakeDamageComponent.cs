using UnityEngine;

namespace HomeWork
{
    public class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
            _takeDamageReceiver.Call(damage);
        }
    }
}