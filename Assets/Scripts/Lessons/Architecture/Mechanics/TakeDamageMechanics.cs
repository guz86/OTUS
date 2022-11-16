using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        //[SerializeField] private EventReceiver _takeDamageReceiver;
        [SerializeField] private IntEventReceiver takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints;

        private void OnEnable()
        {
            this.takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            //const int damage = 1;
            this._hitPoints.Value -= damage;
        }
    }
}