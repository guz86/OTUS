using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AttackСomponent : MonoBehaviour, IAttackComponent
    {
        // логика взаимодействия с ядром

        [SerializeField] private EventReceiver _attackReceiver;

        public void Attack()
        {
            _attackReceiver.Call();
        }
    }
}