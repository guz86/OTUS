using UnityEngine;

namespace HomeWork
{
    public class AttackRocketComponent : MonoBehaviour, IAttackRocketComponent
    {
        [SerializeField] private EventReceiver _attackReceiver;

        public void Attack()
        {
            _attackReceiver.Call();
        }
    }

}