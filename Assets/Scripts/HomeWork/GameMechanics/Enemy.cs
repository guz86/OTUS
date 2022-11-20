using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EventReceiver _shootReceiver;
        
        
        public void Shoot()
        {
            _shootReceiver.Call();
        }
    }
}