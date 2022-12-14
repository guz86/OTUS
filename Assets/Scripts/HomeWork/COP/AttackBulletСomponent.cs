using UnityEngine;

namespace HomeWork
{
    public class AttackBulletСomponent : MonoBehaviour, IAttackBulletComponent
    {
        // логика взаимодействия с ядром

        [SerializeField] private EventReceiver _attackReceiver;

        public void Attack()
        {
            _attackReceiver.Call();
        }
    }
}