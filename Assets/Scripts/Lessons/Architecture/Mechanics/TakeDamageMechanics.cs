using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints;

        private void OnEnable()
        {
            this._takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this._takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken()
        {
            const int damage = 1;
            this._hitPoints.Value -= damage;
        }
    }
}