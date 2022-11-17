using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints;
        [SerializeField] private ActionBehaviourPlayParticle _particle;
        

        private void OnEnable()
        {
            this._takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this._takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            //const int damage = 1;
            this._hitPoints.Value -= damage;
            if (_particle != null) _particle.Do();
        }
    }
}