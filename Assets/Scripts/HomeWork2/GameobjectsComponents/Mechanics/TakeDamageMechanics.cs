using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints; 
        //[SerializeField] private ActionBehaviourPlayParticle _particle;
        

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
            this._hitPoints.Value -= damage;
        //    if (_particle != null) _particle.Do();
        }
    }
}