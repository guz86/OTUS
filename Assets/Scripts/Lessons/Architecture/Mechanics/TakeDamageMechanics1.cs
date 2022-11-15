using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class TakeDamageMechanics1 : MonoBehaviour
    {
        //[SerializeField] private EventReceiver _takeDamageReceiver;
        [SerializeField] private IntEventReceiver1 takeDamageReceiver1;
        [SerializeField] private IntBehaviour1 _hitPoints;

        private void OnEnable()
        {
            this.takeDamageReceiver1.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.takeDamageReceiver1.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            //const int damage = 1;
            this._hitPoints.Value -= damage;
        }
    }
}